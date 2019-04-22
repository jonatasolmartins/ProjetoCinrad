using AutoMapper;
using Cinrad.Core.Interface.Repository;
using Cinrad.Service.Interface;

namespace Cinrad.Service.Services
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Service(
            IUnitOfWork unitOfWork, IMapper mapper, IUsuarioService usuarioService,
            IClienteService clienteService, ITransportadorService transportadorService,
            IClienteTransportadora clienteTransportadora, IProdutoService produtoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            UsuarioService = usuarioService;
            ClienteService = clienteService;
            TransportadorService = transportadorService;
            ClienteTransportadora = clienteTransportadora;
            ProdutoService = produtoService;
        }

        public IUsuarioService UsuarioService { get; }

        public IClienteService ClienteService { get; }

        public ITransportadorService TransportadorService { get; }

        public IClienteTransportadora ClienteTransportadora { get; }

        public IProdutoService ProdutoService { get; }
    }
}
