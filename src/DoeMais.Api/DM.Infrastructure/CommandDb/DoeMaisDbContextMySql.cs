using DM.Core.Communication.Mediator;
using DM.Core.Data;
using DM.Core.DomainObjects;
using DM.Core.Messages;
using DM.Domain.Entities;
using DM.Infrastructure.Data.Outbox;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DM.Infrastructure.Data.CommandsDb
{
    public class DoeMaisDbContextMySql : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public DoeMaisDbContextMySql(DbContextOptions<DoeMaisDbContextMySql> options, IMediatorHandler mediatorHandler) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            _mediatorHandler = mediatorHandler;
        }
        
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<EstoqueSangue> EstoqueSangues { get; set; }
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoeMaisDbContextMySql).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entidade in ChangeTracker.Entries<Entity>())
            {
                if (entidade.State == EntityState.Added)
                {
                    entidade.Entity.SetDataCadastro(DateTime.Now);
                }
                else if(entidade.State == EntityState.Modified)
                {
                    entidade.Entity.SetDataAtualizado(DateTime.Now);
                }

                Type entidadeType = entidade.Entity.GetType();

                var entidadeJson = Newtonsoft.Json.JsonConvert.SerializeObject(entidade.Entity, new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                entidade.Entity.AdicionarEvento(new EntityEvent(entidadeJson, entidadeType, (EntityStateEvent)entidade.State, 0));
            }

            await _mediatorHandler.PublicarEventosDominios(this);
            return await SaveChangesAsync() > 0;
        }
    }
}
