using SBase.Filter;
using SBase.Helper;

namespace SBase.Pageable
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CPageable<T>
    {
        /// <summary>
        /// The list of the items.
        /// </summary>
        public IEnumerable<T> Contents { get; set; } = Enumerable.Empty<T>();

        /// <summary>
        /// The PageNumber value.
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// The PageSize value.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// The Total pages result value.
        /// </summary>
        public int? TotalPages { 
            get => PageSize.HasValue && PageSize.Value > 0 ? (int)(TotalItems - 1) / PageSize.Value + 1 : 0;
        }

        /// <summary>
        /// The Total items result value.
        /// </summary>
        public long TotalItems { get; set; } = 0;

        public int NumberOfCurrentPage 
        { 
            get => CollectionHelper.IsPresent(Contents) ? Contents.Count() : 0; 
            set => NumberOfCurrentPage = value; 
        }

        /// <summary>
        /// Defaults the constructor.
        /// </summary>
        public CPageable() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="items">The list of the items.</param>
        /// <param name="totalItems">The total of the item result.</param>
        /// <param name="filter">The filter object.</param>
        public CPageable(IEnumerable<T> items, long totalItems, IBaseFilter filter)
        {
            Contents = items;
            TotalItems = totalItems;

            if ( filter.PageNumber.HasValue && filter.PageSize.HasValue )
            {
                PageNumber = filter.PageNumber.Value;
                PageSize = filter.PageSize.Value;
                
               /* if ( PageSize.Value > 0 )
                {
                    TotalPages = (int)(totalItems - 1) / PageSize.Value + 1;
                }*/
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="items">The list of the items.</param>
        /// <param name="totalItems">The total of the item result.</param>
        public CPageable(IEnumerable<T> items, long totalItems)
        {
            Contents = items;
            TotalItems = totalItems;
        }

        public CPageable<V> Map<V>(Func<T,V> lamdaExpress)
        {
            try
            {
                IEnumerable<V> transformedData = Contents.Select(lamdaExpress);

                return new CPageable<V>()
                {
                    Contents = transformedData,
                    TotalItems = this.TotalItems,
                    PageNumber = this.PageNumber,
                    PageSize = this.PageSize,
                    //TotalPages = this.TotalPages,
                };
            }
            catch ( Exception )
            {
                throw;
            }
        }

        /// <summary>
        /// Maps the content of the pageable.
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="lamdaExpress"></param>
        /// <returns></returns>
        public async Task<CPageable<V>> MapAsync<V>(Func<T, Task<V>> lamdaExpress)
        {
            try
            {
                var tasks = Contents.Select(lamdaExpress);

                var contents = await Task.WhenAll(tasks);

                return new CPageable<V>
                {
                    Contents = contents,
                    TotalItems = TotalItems,
                    PageNumber = PageNumber,
                    PageSize = PageSize,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
