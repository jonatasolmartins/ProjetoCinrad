using Cinrad.Service.ViewModels;
using System.Collections.Generic;

namespace Cinrad.Service.Interface
{
    public interface ITransportadorService
    {
        bool Adicionar(TransportadoraViewModel transportadora);
        void Atualizar(TransportadoraViewModel transportadora);
        void Remover(TransportadoraViewModel transportadora);
        IList<TransportadoraViewModel> ObterTodos();
    }
}
