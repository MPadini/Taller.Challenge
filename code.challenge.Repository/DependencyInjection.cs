using code.challenge.Core.Entities;
using code.challenge.Core.RepositoryInterfaces;
using code.challenge.Repository.Configuration;
using code.challenge.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace code.challenge.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MemoryDbContext>(options => options.UseInMemoryDatabase(databaseName: "MyMemoryDatabase"));
            services.AddScoped(typeof(IRepository<>), typeof(MemoryRepository<>));

            return services;
        }
    }
}
