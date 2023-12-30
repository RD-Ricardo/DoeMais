using DM.Core.Messages;
using DM.Core.Messages.Handlers;
using DM.Core.WebApi;
using DM.Domain.Repositories;
using DM.Shared.ViewModels;
using MongoDB.Driver;

namespace DM.Application.Queries.Doacao.DoacoesPorDoador
{
    public class DoacoesPorDoadorQueryHandler : QueryHandler<DoacoesPorDoadorQuery, IEnumerable<DoacaoViewModel>>
    {
        private readonly IRepositoryQuery<Domain.Entities.Doacao> _repositoryQueryDoacao;
        
        private readonly IRepositoryQuery<Domain.Entities.Doador> _repositoryQueryDoador;

        public DoacoesPorDoadorQueryHandler(IRepositoryQuery<Domain.Entities.Doacao> repositoryQueryDoacao, IRepositoryQuery<Domain.Entities.Doador> repositoryQueryDoador)
        {
            _repositoryQueryDoacao = repositoryQueryDoacao;
            _repositoryQueryDoador = repositoryQueryDoador;
        }

        public override async Task<RequestResult<IEnumerable<DoacaoViewModel>>> Handle(DoacoesPorDoadorQuery message, CancellationToken cancellationToken)
        {
            var doador = await _repositoryQueryDoador.FindById(message.DoadorId);

            if (doador == null)
                return Falha("não existe doador");

            var doacoesPorDoador = await _repositoryQueryDoacao.GetAllWhere(x => x.DoadorId == message.DoadorId);

            if (!doacoesPorDoador.Any())
                Falha("");

            IEnumerable<DoacaoViewModel> doacoesReturn = doacoesPorDoador.Select(d => new DoacaoViewModel 
            { 
                DaoadorNome = doador.NomeCompleto,
                DoadorId = message.DoadorId,
                DataDoacao = d.DataDoacao,
                QuantidadeML = d.QuantidadeML,
            });

            return Sucesso(doacoesReturn);
        }
    }
}
