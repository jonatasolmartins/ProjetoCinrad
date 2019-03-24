using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Interface;
using Cinrad.Service.Validators;
using Cinrad.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Cinrad.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;       
        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;            
        }

        public bool Adicionar(ClienteViewModel cliente)
        {
            var cli = _mapper.Map<Cliente>(cliente);
            var result = new ClienteValidator().Validate(cli);
            if (!result.IsValid)
                return false;

             _unitOfWork.ClienteRepository.Adicionar(cli);

            return _unitOfWork.Save() > 0;
        }

        public void Atualizar(ClienteViewModel cliente)
        {
            throw new NotImplementedException();
        }

        public IList<ClienteViewModel> ObterTodos()
        {
            return _mapper.Map<List<ClienteViewModel>>(_unitOfWork.ClienteRepository.ObterTodos());
        }

        public void Remover(ClienteViewModel cliente)
        {
            throw new NotImplementedException();
        }
    }
}
