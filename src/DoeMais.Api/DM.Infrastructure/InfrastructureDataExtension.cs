using DM.Domain.Repositories;
using DM.Infrastructure.Data.CommandDb;
using DM.Infrastructure.Data.QueryDb;
using DM.Infrastructure.Data.QueryDb.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DM.Infrastructure.Data
{
    public static class InfrastructureDataExtension
    {
        public static IServiceCollection InfrastructureData(this IServiceCollection services)
        {
            services.AddScoped<IDoeMaisContextMongo, DoeMaisContextMongo>();
            //services.AddScoped<IUnitOfWork, DoeMaisContextMongo>();
            services.AddScoped(typeof(IRepositoryQuery<>),  typeof(RepositoryQuery<>));
            services.AddScoped(typeof(IRepositoryComand<>),  typeof(RepositoryCommand<>));
            services.AddScoped(typeof(IRepositoryCommandAll<>), typeof(RepositoryCommandAll<>));
            services.AddScoped(typeof(IRepositoryQueryAll<>), typeof(RepositoryQueryAll<>));

            return services;
        }
    }
}
