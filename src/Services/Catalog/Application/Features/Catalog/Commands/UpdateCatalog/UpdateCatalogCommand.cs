using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.UpdateCatalog
{
     public class UpdateCatalogCommand: IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LonDescription { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; }
    }
}
