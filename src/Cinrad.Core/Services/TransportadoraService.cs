using Cinrad.Core.Entity;
using Cinrad.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cinrad.Core.Services
{
    public class TransportadoraService : ITransportadoraService
    {
        private readonly ITransportadoraService _transportadoraService;

        public TransportadoraService(ITransportadoraService transportadoraService)
        {
            _transportadoraService = transportadoraService;
        }
        
        public Transportadora Adicionar(Transportadora entity)
        {
            //TODO: Adicionar Regra de Negócio
            //Use Fluent Validation to validate the class propeties
            return _transportadoraService.Adicionar(entity);
        }

        public void Atualizar(Transportadora entity)
        {
            _transportadoraService.Atualizar(entity);
        }

        public IEnumerable<Transportadora> Buscar(Expression<Func<Transportadora, bool>> predicado)
        {
            return _transportadoraService.Buscar(predicado);
        }

        public Transportadora ObterPorId(Guid id)
        {
            return _transportadoraService.ObterPorId(id);
        }

        public IEnumerable<Transportadora> ObterTodos()
        {
            return _transportadoraService.ObterTodos();
        }

        public void Remover(Transportadora entity)
        {
            _transportadoraService.Remover(entity);
        }

        public void Remover(Guid id)
        {
            _transportadoraService.Remover(id);
        }
    }
}
