using Cinrad.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Cinrad.Service.Interface
{
    public interface ITransportadorService
    {
        bool Adicionar(TransportadoraViewModel transportadora);
        bool Atualizar(TransportadoraViewModel transportadora);
        bool Remover(TransportadoraViewModel transportadora);
        bool Remover(Guid id);
        TransportadoraViewModel ObeterPorId(Guid id);
        IList<TransportadoraViewModel> ObterTodos();
    }
}
