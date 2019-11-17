using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Service.ApplicationService;

namespace App.Service.DependecyInjection.ApplicationServiceBindings
{
    public class ApplicationServiceInjection
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ProdutoApplicationService>();

            services.AddScoped<CategoriaApplicationService>();

        }
    }
}
