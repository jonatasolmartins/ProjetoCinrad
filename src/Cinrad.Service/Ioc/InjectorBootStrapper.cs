﻿using Cinrad.Service.Interface;
using Cinrad.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cinrad.Service.Ioc
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {           
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ITransportadorService, TransportadorService>();
            services.AddTransient<IClienteTransportadora, ClienteTransportadoraService>();
            services.AddTransient<IProdutoService, ProdutoService>();

            services.AddTransient<IService, Services.Service>();

        }

    }
}
