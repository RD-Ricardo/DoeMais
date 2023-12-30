using DM.Core.DomainObjects;
using DM.Domain.Repositories;
using DM.Infrastructure.Data.QueryDb.Context;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DM.Infrastructure.Data.QueryDb
{
    public class RepositoryQuery<TEntity> : IRepositoryQuery<TEntity> where TEntity : Entity
    {
        private readonly IMongoCollection<TEntity> DbSet;
        private readonly IDoeMaisContextMongo _context;
        public RepositoryQuery(IDoeMaisContextMongo context)
        {
            _context = context;

            var nameCollection = typeof(TEntity).Name.ToLower();
            DbSet = _context.GetCollection<TEntity>(nameCollection);
        }

        public async Task<TEntity> FindById(Guid id)
        {
            var data = await DbSet.FindAsync(entity => entity.Id == id);
            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllWhere(Expression<Func<TEntity, bool>> filter)
        {
            return await DbSet.Find(filter).ToListAsync();
        }
    }
}
