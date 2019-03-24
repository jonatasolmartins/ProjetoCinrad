using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Infrastructure.CrossCutting.Identity;
using Cinrad.Infrastructure.CrossCutting.Identity.Interface;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Interface;
using Cinrad.Service.Validators;
using Cinrad.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinrad.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIdenityRepository _identityRepository;
        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper, IIdenityRepository identityRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _identityRepository = identityRepository;
        }

        public  async Task<bool> Adicionar(UsuarioViewModel usuario)
        {
            //Validando o Usuário
            var user = _mapper.Map<Usuario>(usuario);
            var result = new UsuarioValidator().Validate(user);
            if (!result.IsValid)
                return false;
           
            //Criando Usuário na tabela Identity 
            var userId = await _identityRepository.CreateAsync(_mapper.Map<ApplicationUser>(usuario));
            if (userId == Guid.Empty)
                return false;
            
            user.SetId(userId);
            //Criando Usuario na Tabela do sistema
            _unitOfWork.UsuarioRepository.Adicionar(user);

            return _unitOfWork.Save() > 0;
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
