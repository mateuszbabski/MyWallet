using MyWallet.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Wrappers
{
    public class RequestParams
    {
        public string? SearchPhrase { get; set; }

        const int maxPageSize = 25;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 5;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }

        //public string SortBy { get; set; }
        //public SortDirection SortDirection { get; set; }
    }
}
