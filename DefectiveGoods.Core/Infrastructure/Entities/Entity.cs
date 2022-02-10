using System;
namespace DefectiveGoods.Core.Infrastructure.Entities
{
    public abstract class Entity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
