using DM.Application.Events.EstoqueSangue;
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


        public AdicionarDoacaoCommandHandler(IRepositoryCommandAll<Domain.Entities.Doacao> repositoryCommandAllDoacao,
            IRepositoryCommandAll<Domain.Entities.Doador> repositoryCommandAllDoador)
        {
            _repositoryCommandAllDoacao = repositoryCommandAllDoacao;
            _repositoryCommandAllDoador = repositoryCommandAllDoador;
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

            doacao.AdicionarEvento(new EstoqueSangueAtualizadoEvent(doadorExistente.FatorRh, 
                doadorExistente.TipoSanguineo, 
                doacao.QuantidadeML));

            await _repositoryCommandAllDoacao.CreateAsync(doacao);
            
            await _repositoryCommandAllDoacao.UnitOfWork.Commit();

            return Sucesso();
        }
    } 
}
