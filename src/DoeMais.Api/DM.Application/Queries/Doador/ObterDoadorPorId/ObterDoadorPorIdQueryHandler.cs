using DM.Core.Messages;
using DM.Core.Messages.Handlers;
using DM.Core.WebApi;
using DM.Domain.Repositories;
using DM.Shared.ViewModels;

namespace DM.Application.Queries.Doador.ObterDoadorPorId
{
    public class ObterDoadorPorIdQueryHandler : QueryHandler<ObterDoadorPorIdQuery, DoadorPorIdViewModel>
    {

        private readonly IRepositoryCommandAll<Domain.Entities.Doador> _repositoryCommandAllDoador;

        public ObterDoadorPorIdQueryHandler(IRepositoryCommandAll<Domain.Entities.Doador> repositoryCommandAllDoador)
        {
            _repositoryCommandAllDoador = repositoryCommandAllDoador;
        }

        public override async Task<RequestResult<DoadorPorIdViewModel>> Handle(ObterDoadorPorIdQuery message, CancellationToken cancellationToken)
        {
            var doador = await _repositoryCommandAllDoador.FindById(message.DoadorId);

            if (doador == null)
                return Falha("não existe doador");

            var result = new DoadorPorIdViewModel
            {
                Email = doador.Email,
                DataNascimento = doador.DataNascimento,
                Endereco = doador.Endereco,
                FatorRh = doador.FatorRh,
                TipoSanguineo = doador.TipoSanguineo,
                Genero = doador.Genero,
                NomeCompleto = doador.NomeCompleto,
                Peso = doador.Peso
            };

            return Sucesso(result);
        }
    }
}
