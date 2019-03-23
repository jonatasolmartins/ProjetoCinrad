using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Service.ViewModels;

namespace Cinrad.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<TransportadoraViewModel, Transportadora>();
        }
    }
}
