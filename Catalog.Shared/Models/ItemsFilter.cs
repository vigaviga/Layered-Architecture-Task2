using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Shared.Models
{
    public class ItemsFilter
    {
        public int CategoryId { get; set; }
        public int Start { get; set; }
        public int PageSize { get; set; }

    }
}
