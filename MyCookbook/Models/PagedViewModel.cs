using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Models
{
    public class PagedViewModel<T> 
        : PagedListViewModelBase
        where T : new()
    {
        public int Id { get; set; }
        public ICollection<T> Items { get; set; }
        public T Item { get; set; }

        public PagedViewModel()
        {
            Item = new T();
        }

    }
}
