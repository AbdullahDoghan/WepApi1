using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CatalogEntity:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LonDescription { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; }
    }
}
