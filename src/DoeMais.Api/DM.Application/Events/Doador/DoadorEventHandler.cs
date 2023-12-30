using DM.Core.Messages.Handlers;
using DM.Domain.Repositories;

namespace DM.Application.Events.Doador
{
    public class DoadorEventHandler : 
        IEventHandler<DoadorAdicionadoEvent>,
        IEventHandler<DoadorAtualizadoEvent>,
        IEventHandler<DoadorExcluidoEvent>
    {
        public readonly IRepositoryQueryAll<Domain.Entities.Doador> _repositoryQueryAll;
        public DoadorEventHandler(IRepositoryQueryAll<Domain.Entities.Doador> repositoryQueryAll)
        {
            _repositoryQueryAll = repositoryQueryAll;
        }
        public async Task Handle(DoadorAdicionadoEvent @event, CancellationToken cancellationToken)
        {
            //var doador = @event.ToEntity();
            //sawait _repositoryQueryAll.CreateAsync(doador);
            ///await _repositoryQueryAll.UnitOfWork.Commit();
        }

        public Task Handle(DoadorAtualizadoEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(DoadorExcluidoEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
