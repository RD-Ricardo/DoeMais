using DM.Core.Data;
using DM.Core.DomainObjects;
using DM.Domain.Repositories;
using DM.Infrastructure.Data.QueryDb.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DM.Infrastructure.Data.QueryDb
{
    public class RepositoryQueryAll<TEntity> : IRepositoryQueryAll<TEntity> where TEntity : Entity
    {
        private readonly IDoeMaisContextMongo _context;

        private readonly IMongoCollection<TEntity> _collection;

        public RepositoryQueryAll(IDoeMaisContextMongo context)
        {
            _context = context;
            
            var nameCollection = typeof(TEntity).Name.ToLower();
            _collection = context.GetCollection<TEntity>(nameCollection);
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(TEntity entity)
        {
           entity.SetDataCadastro(DateTime.UtcNow);
           await _context.AddCommand(async() => 
                await _collection.InsertOneAsync(entity));
        }
        public async Task UpdateAsync(TEntity entity)
        {
            entity.SetDataAtualizado(DateTime.UtcNow);
            await _context.AddCommand(async() => 
                await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity));
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _context.AddCommand(async() => 
                await _collection.DeleteOneAsync(x => x.Id == entity.Id));
        }
      
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWhere(Expression<Func<TEntity, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<TEntity> FindById(Guid id)
        {
            return await _collection.Find(entity => entity.Id == id).SingleOrDefaultAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
