using DM.Core.Messages.Handlers;
using DM.Core.WebApi;
using DM.Domain.Repositories;
using DM.Shared.ViewModels;

namespace DM.Application.Queries.Doador.ListarTodosDoadores
{
    public class ListarTodosDoadoresQueryHandler : QueryHandler<ListarTodosDoadoresQuery, IEnumerable<DoadorViewModel>>
    {
        private readonly IRepositoryQuery<Domain.Entities.Doador> _repositoryQuery;

        public ListarTodosDoadoresQueryHandler(IRepositoryQuery<Domain.Entities.Doador> repositoryQuery)
        {
            _repositoryQuery = repositoryQuery;
        }

        public override async Task<RequestResult<IEnumerable<DoadorViewModel>>> Handle(ListarTodosDoadoresQuery message, CancellationToken cancellationToken)
        {
            var doadores = await _repositoryQuery.GetAll();

            if (!doadores.Any())
                return Falha("Não tem doadores.");

            var doadoresViewModel = doadores.Select(d => new DoadorViewModel
            {
                Id = d.Id.ToString(),
                DataNascimento = d.DataNascimento,
                Email = d.Email,
                FatorRh = d.FatorRh,
                Genero = d.Genero,
                NomeCompleto = d.NomeCompleto,
                Peso = d.Peso,
                TipoSanguineo = d.TipoSanguineo,
            });

            return Sucesso(doadoresViewModel);
        }
    }
}
