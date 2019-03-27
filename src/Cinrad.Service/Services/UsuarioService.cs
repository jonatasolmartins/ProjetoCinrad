using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Infrastructure.CrossCutting.Identity;
using Cinrad.Infrastructure.CrossCutting.Identity.Interface;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Enums;
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

        public async Task<bool> Adicionar(UsuarioViewModel usuario, int perfil)
        {
            //Validando o Usuário
            var user = _mapper.Map<Usuario>(usuario);
            var result = new UsuarioValidator().Validate(user);

            if (!result.IsValid)
                return false;

            var role = (PerfilEnum)perfil;

            //Criando Usuário na tabela Identity 
            var userId = await _identityRepository.CreateAsync(_mapper.Map<ApplicationUser>(usuario), role.ToString());
            if (userId == Guid.Empty)
                return false;

            user.SetId(userId);           
               
            ////Criando Usuario na Tabela do sistema
            _unitOfWork.UsuarioRepository.Adicionar(user);

            return _unitOfWork.Save() > 0;
        }

        public bool Atualizar(UsuarioViewModel usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            var result = new UsuarioValidator().Validate(user);
            if (!result.IsValid)
                return false;

            _unitOfWork.UsuarioRepository.Atualizar(user);
            return _unitOfWork.Save() > 0;
        }

        public bool Remover(UsuarioViewModel usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            var result = new UsuarioValidator().Validate(user);
            if (!result.IsValid)
                return false;

            _unitOfWork.UsuarioRepository.Remover(user);
            return _unitOfWork.Save() > 0;

        }

        public IList<UsuarioViewModel> ObterTodos()
        {            
            var teste = _unitOfWork.UsuarioRepository.ObterTodos();
            return _mapper.Map<List<UsuarioViewModel>>(teste);
        }

        public bool Remover(Guid id)
        {
            if (id == Guid.Empty)
                return false;

            _unitOfWork.UsuarioRepository.Remover(id);
            return _unitOfWork.Save() > 0;
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(_unitOfWork.UsuarioRepository.ObterPorId(id));
        }
    }
}
