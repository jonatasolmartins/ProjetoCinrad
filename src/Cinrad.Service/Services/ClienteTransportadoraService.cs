using System;
using System.Collections.Generic;
using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Interface;
using Cinrad.Service.ViewModels;

namespace Cinrad.Service.Services
{
    public class ClienteTransportadoraService : IClienteTransportadora
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClienteTransportadoraService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Adicionar(ClienteTransportadoraViewModel clienteTransportadora)
        {
            var clientetransp = _mapper.Map<ClienteTransportadora>(clienteTransportadora);
            if (clientetransp.ClienteId == Guid.Empty && clientetransp.TransportadoraId == Guid.Empty)
                return false;

            _unitOfWork.ClienteTransportadoraRepository.Adicionar(clientetransp);
            return _unitOfWork.Save() > 0;
        }

        public IList<TransportadoraViewModel> ListarTransportadoras(Guid clienteId)
        {
            return _mapper.Map<IList<TransportadoraViewModel>>(_unitOfWork.ClienteTransportadoraRepository.Listar(clienteId));
        }

        public bool Remover(ClienteTransportadoraViewModel clienteTransportadora)
        {
            var clientetransp = _mapper.Map<ClienteTransportadora>(clienteTransportadora);
            if (clientetransp.Cliente == null && clientetransp.Transportadora == null)
                return false;
            _unitOfWork.ClienteTransportadoraRepository.Remover(clientetransp);

            return _unitOfWork.Save() > 0;
        }

        public bool Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
