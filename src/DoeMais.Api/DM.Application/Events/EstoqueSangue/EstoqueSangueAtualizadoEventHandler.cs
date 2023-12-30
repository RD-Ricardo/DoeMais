using DM.Core.Messages.Handlers;
using DM.Domain.Repositories;

namespace DM.Application.Events.EstoqueSangue
{
    public class EstoqueSangueAtualizadoEventHandler : IEventHandler<EstoqueSangueAtualizadoEvent>
    {
        private readonly IRepositoryCommandAll<Domain.Entities.EstoqueSangue> _repositoryCommandAllEstoqueSangue;
        public EstoqueSangueAtualizadoEventHandler(IRepositoryCommandAll<Domain.Entities.EstoqueSangue> repositoryCommandAllEstoqueSangue)
        {
            _repositoryCommandAllEstoqueSangue = repositoryCommandAllEstoqueSangue;
        }
        public async Task Handle(EstoqueSangueAtualizadoEvent @event, CancellationToken cancellationToken)
        {
            var estoqueSangue = await _repositoryCommandAllEstoqueSangue.FirstOrDefault(leitura: true,
                filtro: es => es.TipoSanguineo == @event.TipoSanguineo && es.FatorRh == @event.FatorRh);

            estoqueSangue.AdicionarQuantidadeMl(@event.QuantidadeMl);

            _repositoryCommandAllEstoqueSangue.Update(estoqueSangue);

            await _repositoryCommandAllEstoqueSangue.UnitOfWork.Commit();
        }
    }
}
