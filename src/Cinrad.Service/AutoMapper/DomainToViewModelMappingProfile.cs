using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Service.ViewModels;

namespace Cinrad.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();                
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Transportadora, TransportadoraViewModel>();
        }
    }
}
