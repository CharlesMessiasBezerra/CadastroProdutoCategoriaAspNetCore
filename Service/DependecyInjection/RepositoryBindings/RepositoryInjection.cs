using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Infrastructure.Repository.AppContext;

namespace App.Service.DependecyInjection.RepositoryBindings
{
    public class RepositoryInjection
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        { 
            services.AddScoped<ProdutoRepository>();

            services.AddScoped<CategoriaRepository>();

        }
    }
}
