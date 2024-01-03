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


        }
    }
}
