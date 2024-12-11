using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mohtawa.Domain.IRepositories;
using Mohtawa.Infrastructure.Contexts;

namespace Mohtawa.Infrastructure
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbConnectionString)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(dbConnectionString);
            });

            services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(dbConnectionString));
            services.AddTransient<ILibraryUnitOfWork, LibraryUnitOfWork>();
            return services;
        }
    }
}