using AutoMapper;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Interface;

namespace Cinrad.Service.Services
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly IClienteService _clienteService;
        private readonly ITransportadorService _transportadorService;
        private readonly IClienteTransportadora _clienteTransportadora;
        private readonly IProdutoService _produtoService;
        public Service(
            IUnitOfWork unitOfWork, IMapper mapper, IUsuarioService usuarioService,
            IClienteService clienteService, ITransportadorService transportadorService,
            IClienteTransportadora clienteTransportadora, IProdutoService produtoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _clienteService = clienteService;
            _transportadorService = transportadorService;
            _clienteTransportadora = clienteTransportadora;
            _produtoService = produtoService;
        }

        public IUsuarioService UsuarioService => _usuarioService;

        public IClienteService ClienteService => _clienteService;

        public ITransportadorService TransportadorService => _transportadorService;

        public IClienteTransportadora ClienteTransportadora => _clienteTransportadora;

        public IProdutoService ProdutoService => _produtoService;
    }
}
