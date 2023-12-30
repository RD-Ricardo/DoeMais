using DM.Core.Data;
using MongoDB.Driver;

namespace DM.Infrastructure.Data.QueryDb.Context
{
    public interface IDoeMaisContextMongo : IUnitOfWork, IDisposable
    {
        Task<int> SaveChanges();
        Task AddCommand(Func<Task> func);
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
