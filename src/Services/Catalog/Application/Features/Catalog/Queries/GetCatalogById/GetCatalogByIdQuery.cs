using Application.Features.Catalog.Queries.GetCatalogList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetCatalogById
{
    public class GetCatalogByIdQuery:IRequest<List<CatalogVm>>
    {
        public GetCatalogByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
