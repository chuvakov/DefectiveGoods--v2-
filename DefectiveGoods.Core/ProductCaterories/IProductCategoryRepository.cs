using DefectiveGoods.Core.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectiveGoods.Core.ProductCaterories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        string[] GetCategoryNames(long productId);
    }
}
