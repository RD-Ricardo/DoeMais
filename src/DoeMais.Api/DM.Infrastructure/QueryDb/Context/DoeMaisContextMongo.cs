using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DM.Infrastructure.Data.QueryDb.Context
{
    public class DoeMaisContextMongo : IDoeMaisContextMongo
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;
        private readonly IConfiguration _configuration;

        public DoeMaisContextMongo(IConfiguration configuration)
        {
            _configuration = configuration;                                            
            _commands = new List<Func<Task>>();
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                var commandTasks = _commands.Select(c => c());
                
                try
                {
                    await Task.WhenAll(commandTasks);

                    await Session.CommitTransactionAsync(new CancellationToken());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            return _commands.Count;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
            {
                return;
            }

            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);

            Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();

            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task AddCommand(Func<Task> func)
        {
            _commands.Add(func);
            return Task.CompletedTask;
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await SaveChanges();

            return changeAmount > 0;
        }

    }
}
