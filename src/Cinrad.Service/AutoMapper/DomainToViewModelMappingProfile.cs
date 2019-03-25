using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Service.ViewModels;

namespace Cinrad.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ConstructUsing(c => new UsuarioViewModel
                 {
                    Nome = c.Nome, Email = c.Email, CPF = c.CPF,
                    Celular = c.Celular, Telefone = c.Telefone,
                    ClienteId = c.ClienteId, TransportadraId = c.TransportadoraId,
                    ClienteNome = c.Cliente.RazaoSocial ?? string.Empty,
                    TransportadoraNome = c.Transportadora.RazaoSocial ?? string.Empty,
                    IsDeleted = c.IsDeleted, Id = c.Id

                });
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Transportadora, TransportadoraViewModel>();
        }
    }
}
