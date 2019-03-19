using Cinrad.Core.Entity;
using Cinrad.Core.Interface.Repository;
using Cinrad.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cinrad.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente entity)
        {
            //TODO: Adicionar Regra de Negócio
            //Use Fluent Validation to validate the class propeties
            return _clienteRepository.Adicionar(entity);
        }    

        public void Atualizar(Cliente entity)
        {
            _clienteRepository.Atualizar(entity);
        }

        public IEnumerable<Cliente> Buscar(Expression<Func<Cliente, bool>> predicado)
        {
            return _clienteRepository.Buscar(predicado);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Cliente entity)
        {
            _clienteRepository.Remover(entity);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
