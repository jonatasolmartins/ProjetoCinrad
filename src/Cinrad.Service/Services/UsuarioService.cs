using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Interface;
using Cinrad.Service.Validators;
using Cinrad.Service.ViewModels;
using System.Collections.Generic;

namespace Cinrad.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            var result = new UsuarioValidator().Validate(user);
            if (!result.IsValid)
                return null;
            
            return _mapper.Map<UsuarioViewModel>(_unitOfWork.UsuarioRepository.Adicionar(user));
        }

        public void Atualizar(UsuarioViewModel usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            var result = new UsuarioValidator().Validate(user);
            if (result.IsValid)
                _unitOfWork.UsuarioRepository.Atualizar(user);
        }

        public void Remover(UsuarioViewModel usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            var result = new UsuarioValidator().Validate(user);
            if (result.IsValid)
                _unitOfWork.UsuarioRepository.Remover(user);
        }

        public IList<UsuarioViewModel> ObterTodos()
        {
            return _mapper.Map<List<UsuarioViewModel>>(_unitOfWork.UsuarioRepository.ObterTodos());
        }


    }
}
