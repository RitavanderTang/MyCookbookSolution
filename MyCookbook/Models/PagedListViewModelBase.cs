using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Models
{
    public class PagedListViewModelBase
    {
        public int ItemCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount => Convert.ToInt32(Math.Ceiling(ItemCount / (double)PageSize));

        protected PagedListViewModelBase()
        {
            this.PageSize = 3;
            this.PageNumber = 1;
        }
    }
}
