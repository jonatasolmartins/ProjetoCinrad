using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cinrad.Infrastructure.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CinradContext _cinradContext;
        protected readonly DbSet<TEntity> dbSet;

        public EFRepository(CinradContext dbContext)
        {
            _cinradContext = dbContext;
            dbSet = _cinradContext.Set<TEntity>();
        }

        public void Adicionar(TEntity entity)
        {
            dbSet.Add(entity);            
        }

        public void Atualizar(TEntity entity)
        {
            dbSet.Attach(entity);
            _cinradContext.Entry(entity).State = EntityState.Modified;            
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return dbSet.Where(predicado).AsEnumerable();
        }

        public TEntity ObterPorId(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return dbSet.AsEnumerable();
        }

        public void Remover(TEntity entity)
        {
            if (_cinradContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);           
        }

        public void Remover(Guid Id)
        {
            var entity = dbSet.Find(Id); 
            dbSet.Remove(entity);
        }

    }
}
