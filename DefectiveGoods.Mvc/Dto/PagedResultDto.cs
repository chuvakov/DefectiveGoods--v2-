using System.Collections.Generic;

namespace DefectiveGoods.Mvc.Dto
{
    public class PagedResultDto<T>
    {
        public int TotalCount { get; set; }
        public IReadOnlyList<T> Items { get; set; }

        public PagedResultDto(int totalCount, IReadOnlyList<T> items)
        {
            TotalCount = totalCount;
            Items = items;
        }
    }
}
