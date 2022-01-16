using System;
namespace DefectiveGoods.Core.Infrastructure.Entities.Auditing
{
    public interface ICreationAudited
    {
        long? CreatorUserId { get; set; }
        DateTime CreationTime { get; set; }
    }
}
