using System;
using System.ComponentModel.DataAnnotations;
using DefectiveGoods.Core.Infrastructure.Entities.Auditing;

namespace DefectiveGoods.Core.Products
{
    public class Product : CreationAuditedEntity<long>
    {
        [Required]
        [MaxLength(128)]
        public virtual string Code { get; set; }

        [MaxLength(128)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public virtual string ArrivalNumber { get; set; }

        [Required]
        public virtual int Count { get; set; }

        [MaxLength(256)]
        public virtual string Comment { get; set; }

        [MaxLength(64)]
        public virtual string Location { get; set; }

        [Required]
        public virtual DateTime ArrivalDate { get; set; }   
    }
}
