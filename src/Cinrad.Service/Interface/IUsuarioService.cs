using Cinrad.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinrad.Service.Interface
{
    public interface IUsuarioService
    {
        Task<bool> Adicionar(UsuarioViewModel usuario, int perfil);
        bool Atualizar(UsuarioViewModel usuario);
        bool Remover(UsuarioViewModel usuario);
        bool Remover(Guid id);
        UsuarioViewModel ObterPorId(Guid id);
        IList<UsuarioViewModel> ObterTodos();
    }
}
