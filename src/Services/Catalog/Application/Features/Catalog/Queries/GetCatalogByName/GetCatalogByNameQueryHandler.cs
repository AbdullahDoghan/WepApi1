using Application.Contracts.Persistence;
using Application.Features.Catalog.Queries.GetCatalogList;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetCatalogByName
{
    public class GetCatalogByNameQueryHandler : IRequestHandler<GetCatalogByNameQuery, List<CatalogVm>>
    {
        private readonly ICatalogRepositoryBase<CatalogEntity> _IcatalogRepositoryBase;
        private readonly IMapper _mapper;

        public GetCatalogByNameQueryHandler(ICatalogRepositoryBase<CatalogEntity> icatalogRepositoryBase, IMapper mapper)
        {
            _IcatalogRepositoryBase = icatalogRepositoryBase;
            _mapper = mapper;
        }

        public async Task<List<CatalogVm>> Handle(GetCatalogByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _IcatalogRepositoryBase.GetProductByName(request.Name);
            return _mapper.Map<List<CatalogVm>>(result);
        }
    }
}
