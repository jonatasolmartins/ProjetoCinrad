using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cinrad.Core.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado);
        void Remover(TEntity entity);
        void Remover(Guid id);
        //void Save();
    }
}
