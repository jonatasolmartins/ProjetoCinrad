namespace Cinrad.Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        ClienteRepository ClienteRepository { get; }
        TransportadoraRepository TransportadoraRepository { get; }
        UsuarioRepository UsuarioRepository { get; }
        ClienteTransportadoraRepository ClienteTransportadoraRepository { get; }
        ProdutoRepository ProdutoRepository { get; }
        void Dispose();
        int Save();
    }
}