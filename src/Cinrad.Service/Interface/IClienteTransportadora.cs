using Cinrad.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Cinrad.Service.Interface
{
    public interface IClienteTransportadora
    {
        bool Adicionar(ClienteTransportadoraViewModel clienteTransportadora);
        IList<TransportadoraViewModel> ListarTransportadoras(Guid clienteId);
        bool Remover(ClienteTransportadoraViewModel clienteTransportadora);
        bool Remover(Guid id);
    }
}
