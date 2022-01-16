using System;
namespace DefectiveGoods.Core.Infrastructure.Entities.Auditing
{
    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAudited
    {
        public virtual long? CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }

        protected CreationAuditedEntity()
        {
            CreationTime = DateTime.Now;
        }
    }
}
