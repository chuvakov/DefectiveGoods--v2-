using System;

namespace DefectiveGoods.Mvc.Dto.Products
{
    public class ProductDto : EntityDto<long>
    {     
        public virtual string Code { get; set; }
       
        public virtual string Name { get; set; }

        public virtual string ArrivalNumber { get; set; }

        public virtual int Count { get; set; }
        
        public virtual string Comment { get; set; }

        public virtual string Location { get; set; }

        public virtual string[] CategoryNames { get; set; }

        public virtual DateTime ArrivalDate { get; set; }
    }
}
