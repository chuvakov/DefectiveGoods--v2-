using AutoMapper;
using DefectiveGoods.Core.Products;
using DefectiveGoods.Mvc.Dto.Products;

namespace DefectiveGoods.Mvc.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
