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

namespace Application.Features.Catalog.Queries.GetCatalogById
{
    public class GetCatalogByIdQueryHandler : IRequestHandler<GetCatalogByIdQuery, List<CatalogVm>>
    {
        private readonly ICatalogRepositoryBase<CatalogEntity> _IcatalogRepositoryBase;
        private readonly IMapper _mapper;

        public GetCatalogByIdQueryHandler(ICatalogRepositoryBase<CatalogEntity> icatalogRepositoryBase, IMapper mapper)
        {
            _IcatalogRepositoryBase = icatalogRepositoryBase;
            _mapper = mapper;
        }

        public async Task<List<CatalogVm>> Handle(GetCatalogByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _IcatalogRepositoryBase.GetProduct(request.Id);
            return _mapper.Map<List<CatalogVm>>(result);
        }
    }
}
