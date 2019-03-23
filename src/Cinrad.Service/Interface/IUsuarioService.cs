using Cinrad.Service.ViewModels;
using System.Collections.Generic;

namespace Cinrad.Service.Interface
{
    public interface IUsuarioService
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuario);
        void Atualizar(UsuarioViewModel usuario);
        void Remover(UsuarioViewModel usuario);
        IList<UsuarioViewModel> ObterTodos();
    }
}
