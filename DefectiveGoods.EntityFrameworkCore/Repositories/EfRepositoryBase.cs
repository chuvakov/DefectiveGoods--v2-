using DefectiveGoods.Core.Infrastructure.Entities;
using DefectiveGoods.Core.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectiveGoods.EntityFrameworkCore.Repositories
{
    public class EfRepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
        where TDbContext : DbContext
    {
        protected virtual TDbContext Context { get; set; }
        protected virtual DbSet<TEntity> Table { get; private set; }

        public EfRepositoryBase(TDbContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        public override void Delete(TEntity entity)
        {
            Table.Remove(entity);
            Context.SaveChanges();
        }

        public override void Delete(TPrimaryKey id)
        {
            TEntity entity = Table.FirstOrDefault(x => x.Id.Equals(id));

            if (entity != null)
            {
                Delete(entity);
            }
        }

        public override TEntity Get(TPrimaryKey id)
        {
            TEntity entity = Table.FirstOrDefault(x => x.Id.Equals(id));

            if (entity == null)
            {
                throw new Exception($"Не удалось найти {typeof(TEntity)} c id = {id}");
            }

            return entity;
        }

        public override IList<TEntity> GetAll()
        {
            return Table.ToList();
        }

        public override TEntity Insert(TEntity entity)
        {
            var result = Table.Add(entity).Entity;
            Context.SaveChanges();
            return result;
        }

        public override void Update(TEntity entity)
        {
            Table.Update(entity);
            Context.SaveChanges();
        }
    }
}
