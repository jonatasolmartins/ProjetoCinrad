using Cinrad.Service.ViewModels;

namespace Cinrad.Service.Interface
{
    public interface IUsuarioService
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuario);
        void Atualizar(UsuarioViewModel usuario);
        void Remover(UsuarioViewModel usuario);
    }
}
