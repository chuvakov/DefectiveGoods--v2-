using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DefectiveGoods.Core.Branches;
using DefectiveGoods.Core.Infrastructure.Entities;

namespace DefectiveGoods.Core.Users
{
    public class User : Entity<long>
    {
        public virtual int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [Required]
        [MaxLength(32)]
        public virtual string Login { get; set; }

        [Required]
        [MaxLength(128)]
        public virtual string Password { get; set; }
    }
}
