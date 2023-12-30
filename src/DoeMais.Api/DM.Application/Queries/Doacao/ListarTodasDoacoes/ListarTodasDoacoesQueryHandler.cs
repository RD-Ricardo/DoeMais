using DM.Application.Queries.Doacao.DoacoesPorDoador;
using DM.Core.Messages.Handlers;
using DM.Core.WebApi;
using DM.Domain.Repositories;
using DM.Shared.ViewModels;

namespace DM.Application.Queries.Doacao.ListarTodasDoacoes
{
    public class ListarTodasDoacoesQueryHandler : QueryHandler<ListarTodasDoacoesQuery, IEnumerable<DoacaoViewModel>>
    {

        private readonly IRepositoryQuery<Domain.Entities.Doacao> _repositoryQueryDoacao;

        private readonly IRepositoryQuery<Domain.Entities.Doador> _repositoryQueryDoador;

        public ListarTodasDoacoesQueryHandler(IRepositoryQuery<Domain.Entities.Doacao> repositoryQueryDoacao, IRepositoryQuery<Domain.Entities.Doador> repositoryQueryDoador)
        {
            _repositoryQueryDoacao = repositoryQueryDoacao;
            _repositoryQueryDoador = repositoryQueryDoador;
        }

        public override async Task<RequestResult<IEnumerable<DoacaoViewModel>>> Handle(ListarTodasDoacoesQuery message, CancellationToken cancellationToken)
        {
            var doadores = await _repositoryQueryDoador.GetAll();

            var doacoes = await _repositoryQueryDoacao.GetAll();

            if (!doacoes.Any())
                Falha("");

            IEnumerable<DoacaoViewModel> doacoesReturn = doacoes.Select(d => new DoacaoViewModel
            {
                DaoadorNome = doadores.FirstOrDefault(x => x.Id == d.DoadorId).NomeCompleto,
                DoadorId = d.DoadorId,
                DataDoacao = d.DataDoacao,
                QuantidadeML = d.QuantidadeML,
            });

            return Sucesso(doacoesReturn);
        }
    }
}
