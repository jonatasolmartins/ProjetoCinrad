using Cinrad.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinrad.Service.Interface
{
    public interface IUsuarioService
    {
        Task<bool> Adicionar(UsuarioViewModel usuario);
        void Atualizar(UsuarioViewModel usuario);
        void Remover(UsuarioViewModel usuario);
        IList<UsuarioViewModel> ObterTodos();
    }
}
