using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Infrastructure.CrossCutting.Identity;
using Cinrad.Service.ViewModels;

namespace Cinrad.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>()
                .ConstructUsing(c => new Usuario(c.Nome, c.Email));  
            
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<TransportadoraViewModel, Transportadora>();

            CreateMap<UsuarioViewModel, ApplicationUser>()
                .ConstructUsing(c => new ApplicationUser { UserName = c.UserName, Email = c.Email, Password = c.CPF });

            CreateMap<ProdutoViewModel, Produto>();                

        }
    }
}
