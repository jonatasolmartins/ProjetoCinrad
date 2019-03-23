using AutoMapper;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Interface;

namespace Cinrad.Service.Services
{
    public class Service : IService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Service(IUnitOfWork unitOfWork, IMapper mapper, IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        public IUsuarioService UsuarioService
        {
            get
            {
                return _usuarioService ?? new UsuarioService(_unitOfWork, _mapper);
            }
        }
    }
}
