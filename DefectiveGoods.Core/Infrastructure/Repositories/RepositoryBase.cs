using DefectiveGoods.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectiveGoods.Core.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
    {
        public abstract void Delete(TEntity entity);

        public abstract void Delete(TPrimaryKey id);

        public abstract TEntity Get(TPrimaryKey id);

        public abstract IList<TEntity> GetAll();

        public abstract TEntity Insert(TEntity entity);        

        public abstract void Update(TEntity entity);
    }
}
