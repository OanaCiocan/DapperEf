using System;
using System.Collections.Generic;
using System.Linq;
using eShop.DataAccess.EntityFramework.Context;
using eShop.Domain;
using eShop.Domain.Repositories;
using EnsureThat;

namespace eShop.DataAccess.EntityFramework
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly OnlineShopContext context;

        public EFRepository(OnlineShopContext context)
        {
            EnsureArg.IsNotNull(context);
            this.context = context;
        }

        public TEntity GetbyId(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public ICollection<TEntity> Find(Func<TEntity, bool> filter)
        {
            return context.Set<TEntity>().Where(filter).ToList();
        }

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            TEntity entity = new TEntity{Id = id};
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void ExecuteProcedure(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
