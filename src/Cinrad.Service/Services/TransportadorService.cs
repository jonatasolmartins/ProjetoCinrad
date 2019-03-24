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
    public class TransportadorService : ITransportadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;        
        public TransportadorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;           
        }

        public bool Adicionar(TransportadoraViewModel transportadora)
        {
            var transp = _mapper.Map<Transportadora>(transportadora);
            var result = new TransportadoraValidator().Validate(transp);
            if (!result.IsValid)
                return false;

            _unitOfWork.TransportadoraRepository.Adicionar(transp);

            return _unitOfWork.Save() > 0;
        }

        public void Atualizar(TransportadoraViewModel transportadora)
        {
            throw new NotImplementedException();
        }

        public IList<TransportadoraViewModel> ObterTodos()
        {
            return _mapper.Map<List<TransportadoraViewModel>>(_unitOfWork.TransportadoraRepository.ObterTodos());
        }

        public void Remover(TransportadoraViewModel transportadora)
        {
            throw new NotImplementedException();
        }
    }
}
