using System;
using System.ComponentModel.DataAnnotations.Schema;
using DefectiveGoods.Core.Categories;
using DefectiveGoods.Core.Infrastructure.Entities;
using DefectiveGoods.Core.Products;

namespace DefectiveGoods.Core.ProductCaterories
{
    public class ProductCategory : Entity<int>
    {
        public virtual long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public virtual int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
