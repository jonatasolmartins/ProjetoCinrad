using Cinrad.Service.ViewModels;
using System.Collections.Generic;

namespace Cinrad.Service.Interface
{
    public interface IClienteService
    {
        bool Adicionar(ClienteViewModel cliente);
        void Atualizar(ClienteViewModel cliente);
        void Remover(ClienteViewModel cliente);
        IList<ClienteViewModel> ObterTodos();
    }
}
