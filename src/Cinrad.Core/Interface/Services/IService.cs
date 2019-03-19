using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cinrad.Core.Interface.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado);
        void Remover(TEntity entity);
        void Remover(Guid id);
    }
}
