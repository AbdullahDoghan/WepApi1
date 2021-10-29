using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetCatalogList
{
    public class GetCatalogListQueryHandler : IRequestHandler<GetCatalogListQuery, List<CatalogVm>>
    {
        private readonly ICatalogRepositoryBase<CatalogEntity> _IcatalogRepositoryBase;
        private readonly IMapper _mapper;

        public GetCatalogListQueryHandler(ICatalogRepositoryBase<CatalogEntity> icatalogRepositoryBase, IMapper mapper)
        {
            _IcatalogRepositoryBase = icatalogRepositoryBase;
            _mapper = mapper;
        }

        public async Task<List<CatalogVm>> Handle(GetCatalogListQuery request, CancellationToken cancellationToken)
        {
            var cataloglist=await _IcatalogRepositoryBase.GetProducts();
            return _mapper.Map<List<CatalogVm>>(cataloglist);
            

        }
    }
}
