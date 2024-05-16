namespace SBase.Filter
{
    /// <summary>
    /// This is the base interface for all filters in the system.<br/>
    /// It is used to provide a common base interface for all filters.
    /// </summary>
    public interface IBaseFilter
    {
        /// <summary>
        /// The @PageNumber filter. 
        /// </summary>
        public int? PageNumber { get; set; }
        
        /// <summary>
        /// The @PageSize filter.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// The @SortDataField filter.
        /// </summary>
        public string SortDataField { get; set; }

        /// <summary>
        /// The @SortDirection filter.
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Build to parameters to excute the stored procedure.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> BuildToPatameters();
    }
}
