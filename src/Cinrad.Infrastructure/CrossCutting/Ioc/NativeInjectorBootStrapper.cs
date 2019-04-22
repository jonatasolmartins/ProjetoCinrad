using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.CrossCutting.Identity;
using Cinrad.Infrastructure.CrossCutting.Identity.Interface;
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
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteTransportadoraRepository, ClienteTransportadoraRepository>();
            services.AddTransient<ITransportadoraRepository, TransportadoraRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IIdenityRepository, IdentityRepository>();

            services.AddScoped<CinradContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
         
        }
    }
}
