using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DefectiveGoods.Core.Infrastructure.Entities;
using DefectiveGoods.Core.Products;

namespace DefectiveGoods.Core.Photos
{
    public class Photo : Entity<long>
    {
        public virtual long ProductId { get; set; }

        [ForeignKey ("Product")]
        public virtual Product Product { get; set; }

        [Required]
        public virtual string Path { get; set; }        
    }
}
