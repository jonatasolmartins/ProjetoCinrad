using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.Data;
using Cinrad.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Cinrad.Infrastructure.CrossCutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Infra - Data 

            //services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            //services.AddTransient<IClienteRepository, ClienteRepository>();
            //services.AddTransient<ITransportadoraRepository, TransportadoraRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CinradContext>();
         
        }
    }
}
