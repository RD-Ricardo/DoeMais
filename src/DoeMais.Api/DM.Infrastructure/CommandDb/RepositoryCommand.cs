using DM.Core.Data;
using DM.Core.DomainObjects;
using DM.Domain.Repositories;
using DM.Infrastructure.Data.CommandsDb;

namespace DM.Infrastructure.Data.CommandDb
{
    public class RepositoryCommand<TEntity> : IRepositoryComand<TEntity> where TEntity : IAggregateRoot
    {
        private readonly DoeMaisDbContextMySql _context;
        public RepositoryCommand(DoeMaisDbContextMySql context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
