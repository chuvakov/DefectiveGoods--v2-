using DefectiveGoods.Core.Branches;
using DefectiveGoods.Core.Categories;
using DefectiveGoods.Core.Photos;
using DefectiveGoods.Core.ProductCaterories;
using DefectiveGoods.Core.Products;
using DefectiveGoods.Core.Users;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace DefectiveGoods.Core
{
    public class DefectiveGoodsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DefectiveGoodsDb;Trusted_Connection=True;");
        }

    }
}
