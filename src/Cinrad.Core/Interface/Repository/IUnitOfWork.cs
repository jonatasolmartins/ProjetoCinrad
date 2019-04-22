namespace Cinrad.Core.Interface.Repository
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IClienteTransportadoraRepository ClienteTransportadoraRepository { get; }
        ITransportadoraRepository TransportadoraRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        void Dispose();
        int Save();
    }
}
