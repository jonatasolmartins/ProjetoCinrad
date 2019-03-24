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


        public Service(IUnitOfWork unitOfWork, IMapper mapper, IUsuarioService usuarioService, IClienteService clienteService, ITransportadorService transportadorService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _clienteService = clienteService;
            _transportadorService = transportadorService;
        }

        public IUsuarioService UsuarioService => _usuarioService;

        public IClienteService ClienteService => _clienteService;

        public ITransportadorService TransportadorService => _transportadorService;
    }
}
