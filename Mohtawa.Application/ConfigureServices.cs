using Microsoft.Extensions.DependencyInjection;
using Mohtawa.Application.Helpers;
using Mohtawa.Application.Services;
using Mohtawa.Domain.Contracts;

namespace Mohtawa.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICacheManager, CacheManager>();

            services.AddMemoryCache();
            return services;
        }
    }
}
