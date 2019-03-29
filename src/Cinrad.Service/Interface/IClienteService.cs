using Cinrad.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Cinrad.Service.Interface
{
    public interface IClienteService
    {
        bool Adicionar(ClienteViewModel cliente);
        bool Atualizar(ClienteViewModel cliente);
        bool Remover(ClienteViewModel cliente);
        bool Remover(Guid id);
        ClienteViewModel ObterPorId(Guid id);
        IList<ClienteViewModel> ObterTodos();        
    }
}
