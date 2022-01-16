using System;
using System.ComponentModel.DataAnnotations;
using DefectiveGoods.Core.Infrastructure.Entities;

namespace DefectiveGoods.Core.Categories
{
    public class Category : Entity<int>
    {
        [Required]
        [MaxLength(64)]
        public virtual string Name { get; set; }
    }
}
