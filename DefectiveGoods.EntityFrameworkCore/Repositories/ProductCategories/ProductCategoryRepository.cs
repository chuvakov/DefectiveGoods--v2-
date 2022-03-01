using DefectiveGoods.Core.ProductCaterories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DefectiveGoods.EntityFrameworkCore.Repositories.ProductCategories
{
    public class ProductCategoryRepository :
        EfRepositoryBase<DefectiveGoodsContext, ProductCategory, int>,
        IProductCategoryRepository
    {
        public ProductCategoryRepository(DefectiveGoodsContext context) : base(context)
        {
        }

        public string[] GetCategoryNames(long productId)
        {
            return Table
                .Include(pc => pc.Category)
                .Where(pc => pc.ProductId == productId)
                .Select(pc => pc.Category.Name)
                .ToArray();
        }
    }
}
