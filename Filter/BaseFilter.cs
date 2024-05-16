namespace SBase.Filter
{
    public class BaseFilter : IBaseFilter
    {
        #region Constant
        // Parameter Names
        public const string ParamId = "ID";
        public virtual string ParamPageNumber { get; set; } = "Page_Number";
        public virtual string ParamePageSize { get; set; } = "Page_Size";
        public virtual string ParamSortDataField { get; set; } = "Sort_Data_Field";
        public virtual string ParamSortDirection { get; set; } = "Sort_Order";
        #endregion

        /// <inheritdoc/>
        public int? PageNumber { get; set; }

        /// <inheritdoc/>
        public int? PageSize { get; set; }

        /// <inheritdoc/>
        public string SortDataField { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string SortOrder { get; set; } = string.Empty;

        /// <inheritdoc/>
        public virtual IDictionary<string, object> BuildToPatameters()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>();

            // Checks if the filter has a PageNumber.
            if ( PageNumber.HasValue )
            {
                parameters.Add( ParamPageNumber, PageNumber.Value );
            }

            // Checks if the filter has a PageSize.
            if ( PageSize.HasValue )
            {
                parameters.Add(ParamePageSize, PageSize.Value);
            }

            // Checks if the filter has a SortDataField.
            if ( string.IsNullOrEmpty(SortDataField) == false )
            {
                parameters.Add(ParamSortDataField, SortDataField);
            }

            // Checks if the filter has a SortDirection.
            if (string.IsNullOrEmpty(SortOrder) == false)
            {
                parameters.Add(ParamSortDirection, SortOrder);
            }

            return parameters;
        }

    }

    /// <summary>
    /// This class is provide the data sort direction.
    /// </summary>
    public class SortDirection
    {
        /// <summary>
        /// The ASC sorting.
        /// </summary>
        public const string ASC = "ASC";

        /// <summary>
        /// The DESC sorting.
        /// </summary>
        public const string DESC = "DESC";
    }
}
