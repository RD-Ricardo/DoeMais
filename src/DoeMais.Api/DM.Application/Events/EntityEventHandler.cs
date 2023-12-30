using DM.Core.Messages;
using DM.Core.Messages.Handlers;
using DM.Domain.Repositories;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.Json;

namespace DM.Application.Events
{
    public class EntityEventHandler : IEventHandler<EntityEvent>
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(EntityEvent @event, CancellationToken cancellationToken)
        {
            var entityType = @event.EntityType;
            
            var repositoryType = typeof(IRepositoryQueryAll<>).MakeGenericType(entityType);
            
            var repository = _serviceProvider.GetService(repositoryType);

            var unitOfWorkPropriedade = repositoryType.GetProperty("UnitOfWork");
            
            var unitOfWork = unitOfWorkPropriedade?.GetValue(repository);

            var entidade = System.Text.Json.JsonSerializer.Deserialize(@event.ContentEntity, entityType);

            MethodInfo metodo = null;

            object[] parameters = { entidade };

            switch (@event.State)
            {
                case EntityStateEvent.Deleted:
                    metodo = repositoryType.GetMethod("DeleteAsync");
                    break;
                case EntityStateEvent.Modified:
                    metodo = repositoryType.GetMethod("UpdateAsync");
                    break;
                case EntityStateEvent.Added:
                    metodo = repositoryType.GetMethod("CreateAsync");
                    break;
                case EntityStateEvent.Unchanged:
                    metodo = repositoryType.GetMethod("CreateAsync");
                break;
            }

            await (Task)metodo?.Invoke(repository, parameters);

            var commitMethod = unitOfWork?.GetType().GetMethod("Commit");
            
            await (Task)commitMethod?.Invoke(unitOfWork, null);
        }
    }

}
