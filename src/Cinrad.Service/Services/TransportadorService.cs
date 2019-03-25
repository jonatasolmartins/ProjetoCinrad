using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Interface;
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
            //var result = new TransportadoraValidator().Validate(transp);
            //if (!result.IsValid)
            //    return false;

            _unitOfWork.TransportadoraRepository.Adicionar(transp);

            return _unitOfWork.Save() > 0;
        }

        public bool Atualizar(TransportadoraViewModel transportadora)
        {
            var transp = _mapper.Map<Transportadora>(transportadora);
            //var result = new TransportadoraValidator().Validate(transp);
            //if (!result.IsValid)
            //    return false;
            _unitOfWork.TransportadoraRepository.Atualizar(transp);
            return _unitOfWork.Save() > 0;

        }

        public TransportadoraViewModel ObeterPorId(Guid id)
        {
            return _mapper.Map<TransportadoraViewModel>(_unitOfWork.TransportadoraRepository.ObterPorId(id));
        }

        public IList<TransportadoraViewModel> ObterTodos()
        {
            return _mapper.Map<List<TransportadoraViewModel>>(_unitOfWork.TransportadoraRepository.ObterTodos());
        }

        public bool Remover(TransportadoraViewModel transportadora)
        {
            var transp = _mapper.Map<Transportadora>(transportadora);
            _unitOfWork.TransportadoraRepository.Remover(transp);
            return _unitOfWork.Save() > 0;
        }

        public bool Remover(Guid id)
        {
            _unitOfWork.TransportadoraRepository.Remover(id);
            return _unitOfWork.Save() > 0;
        }
    }
}
