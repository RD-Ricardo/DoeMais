using DM.Core.Communication.Mediator;
using DM.Core.DomainObjects;

namespace DM.Infrastructure.Data.CommandsDb
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventosDominios(this IMediatorHandler mediator, DoeMaisDbContextMySql ctx)
        {
            var domainEntities = ctx.ChangeTracker.Entries<Entity>().Where(x => x.Entity.Eventos != null && x.Entity.Eventos.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.Eventos).ToList();

            var tasks = domainEvents.Select(async (domian) =>
            {
                await mediator.PublicarDomainEvent(domian);
            });

            await Task.WhenAll(tasks);
        }
    }
}
