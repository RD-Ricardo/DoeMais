using DM.Application.Events.EstoqueSangue;
using DM.Core.Messages;
using DM.Core.Messages.Handlers;
using DM.Core.WebApi;
using DM.Domain.Repositories;
using MediatR;

namespace DM.Application.Commands.Doacao.AdicionarDoacao
{
    public class AdicionarDoacaoCommandHandler : CommandHandler<AdicionarDoacaoCommand, Unit>
    {
        private readonly IRepositoryCommandAll<Domain.Entities.Doador> _repositoryCommandAllDoador;
        
        private readonly IRepositoryCommandAll<Domain.Entities.Doacao> _repositoryCommandAllDoacao;
        private readonly IRepositoryCommandAll<Domain.Entities.EstoqueSangue> _repositoryCommandAllEstoqueSangue;

        public AdicionarDoacaoCommandHandler(IRepositoryCommandAll<Domain.Entities.Doacao> repositoryCommandAllDoacao,
            IRepositoryCommandAll<Domain.Entities.Doador> repositoryCommandAllDoador,
            IRepositoryCommandAll<Domain.Entities.EstoqueSangue> repositoryCommandAllEstoqueSangue)
        {
            _repositoryCommandAllDoacao = repositoryCommandAllDoacao;
            _repositoryCommandAllDoador = repositoryCommandAllDoador;
            _repositoryCommandAllEstoqueSangue = repositoryCommandAllEstoqueSangue;
        }

        public override async Task<RequestResult<Unit>> Handle(AdicionarDoacaoCommand message, CancellationToken cancellationToken)
        {
            var doadorExistente = await _repositoryCommandAllDoador.FindById(message.DoadorId);

            if (doadorExistente == null)
                return Falha("Doador não encontrado.");

            if (!doadorExistente.MaiorDeIdade())
                return Falha("Doador menor de idade.");

            int dias = doadorExistente.Genero == Domain.Enums.Genero.MASCULINO ? 60 : 90;

            IEnumerable<Domain.Entities.Doacao> doacoesDoDoador = await _repositoryCommandAllDoacao.FindBy(
                leitura: true, 
                filtro: doacao => doadorExistente.Id == doacao.DoadorId && 
                    doacao.DataDoacao >= DateTime.Now.AddDays(-dias));

            if (doacoesDoDoador.Any())
                return Falha("Tempo minimo para doacao não respeitado");

            Domain.Entities.Doacao doacao = new(message.DataDoacao, 
                message.QuantidadeML, 
                message.DoadorId);

            
             var estoqueSangue = await _repositoryCommandAllEstoqueSangue.FirstOrDefault(leitura: true,
                filtro: es => es.TipoSanguineo == doadorExistente.TipoSanguineo && es.FatorRh == doadorExistente.FatorRh);
                estoqueSangue.AdicionarQuantidadeMl(doacao.QuantidadeML);

                _repositoryCommandAllEstoqueSangue.Update(estoqueSangue);

                await _repositoryCommandAllEstoqueSangue.UnitOfWork.Commit();

            doacao.AdicionarEvento(new EstoqueSangueAtualizadoEvent(doadorExistente.FatorRh, doadorExistente.TipoSanguineo, doacao.QuantidadeML, doadorExistente.NomeCompleto));

            await _repositoryCommandAllDoacao.CreateAsync(doacao);
            
            await _repositoryCommandAllDoacao.UnitOfWork.Commit();

            return Sucesso();
        }
    } 
}
