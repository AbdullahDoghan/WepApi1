using Application.Features.Catalog.Queries.GetCatalogList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetCatalogByName
{
    public class GetCatalogByNameQuery:IRequest<List<CatalogVm>>
    {
        public GetCatalogByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
