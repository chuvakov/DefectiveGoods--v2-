using DefectiveGoods.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectiveGoods.Core.Infrastructure.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        IList<TEntity> GetAll();

        TEntity Get(TPrimaryKey id);

        TEntity Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TPrimaryKey id);
    }
}
    

