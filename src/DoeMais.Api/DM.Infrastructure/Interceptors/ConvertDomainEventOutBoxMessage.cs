using DM.Core.DomainObjects;
using DM.Infrastructure.Data.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace DM.Infrastructure.Data.Interceptors
{
    public class ConvertDomainEventOutBoxMessageInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, 
            InterceptionResult<int> result, 
            CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;

            if (dbContext == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var events = dbContext.ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .SelectMany(entity =>
                {
                    var domainEvents = entity.GetEventos();

                    entity.LimparEventos();

                    return domainEvents;
                })
                .Select(domainEvent => new OutBoxMessage
                {
                    Id = Guid.NewGuid(),
                    OccurrendOnUtc = DateTime.Now,
                    Type = domainEvent.GetType().Name,
                    TypeFullName = domainEvent.GetType().FullName,
                    Content = JsonConvert.SerializeObject(domainEvent,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All,
                        }),
                })
                .ToList();

            dbContext.Set<OutBoxMessage>()
                .AddRange(events);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        
    }
}
