using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Infrastructure.UnitOfWork.App;

namespace Service.DependecyInjection.UnitOfWorkBindings
{
    public class UnitOfWorkInjection
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {            
            services.AddScoped<ProdutoUnitOfWork>();
            services.AddScoped<CategoriaUnitOfWork>();

        }
    }
}
