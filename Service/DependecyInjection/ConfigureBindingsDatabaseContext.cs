using App.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Service.DependecyInjection
{
    public class ConfigureBindingsDatabaseContext
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<Banco>(
                        options => options.UseSqlServer(configuration.GetConnectionString("projeto"),
                        providerOptions => providerOptions.EnableRetryOnFailure())
                );
        }
    }
}
