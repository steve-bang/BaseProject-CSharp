using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBase.Filter
{
    public interface IBaseFilter
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public string SortDataField { get; set; }

        public string SortBy { get; set; }

    }
}
