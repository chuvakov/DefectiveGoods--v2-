using DefectiveGoods.Core.ProductCaterories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectiveGoods.EntityFrameworkCore.Repositories.ProductCategories
{
    public class ProductCategoryPepository :
        EfRepositoryBase<DefectiveGoodsContext, ProductCategory, int>,
        IProductCategoryRepository
    {
        public ProductCategoryPepository(DefectiveGoodsContext context) : base(context)
        {
        }

        public string[] GetCategoryNames(long productId)
        {
            throw new NotImplementedException();
        }
    }
}
