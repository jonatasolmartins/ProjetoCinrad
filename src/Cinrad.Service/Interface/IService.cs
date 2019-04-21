namespace Cinrad.Service.Interface
{
    public interface IService
    {
        IUsuarioService UsuarioService { get; }
        IClienteService ClienteService { get; }
        ITransportadorService TransportadorService { get; }
        IClienteTransportadora ClienteTransportadora { get; }

        IProdutoService ProdutoService { get; }

    }
}
