using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpworkTask.Helpers
{
    public class PaginationParams
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get { return _pageSize; }
            // if value is greater than max page size -> set the page size to maximum
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}