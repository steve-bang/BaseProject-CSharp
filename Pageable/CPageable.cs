using SBase.Filter;
using System.Collections.ObjectModel;

namespace SBase.Pageable
{
    public class CPageable<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public int? TotalPages { get; set; }

        public long TotalItems = 0;

        public CPageable() {}

        public CPageable(IEnumerable<T> items, long totalItems, IBaseFilter filter)
        {
            Items = items;
            TotalItems = totalItems;

            if ( filter.PageNumber.HasValue && filter.PageSize.HasValue )
            {
                PageNumber = filter.PageNumber.Value;
                PageSize = filter.PageSize.Value;
                
                if ( PageSize.Value > 0 )
                {
                    TotalPages = (int)(totalItems - 1) / PageSize.Value + 1;
                }
            }
        }

        public CPageable(IEnumerable<T> items, long totalItems)
        {
            Items = items;
            TotalItems = totalItems;
        }


    }
}
