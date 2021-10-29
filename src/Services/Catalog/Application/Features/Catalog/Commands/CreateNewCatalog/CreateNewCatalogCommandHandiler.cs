using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.CreateNewCatalog
{
    public class CreateNewCatalogCommandHandiler : IRequestHandler<CreateNewCatalogCommand, int>
    {
        private readonly ICatalogRepositoryBase<CatalogEntity> _catalogRepositoryBase;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateNewCatalogCommandHandiler> _logger;

        public CreateNewCatalogCommandHandiler(ICatalogRepositoryBase<CatalogEntity> catalogRepositoryBase, IMapper mapper, ILogger<CreateNewCatalogCommandHandiler> logger)
        {
            _catalogRepositoryBase = catalogRepositoryBase;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateNewCatalogCommand request, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<CatalogEntity>(request);
            var NewCatalog = _catalogRepositoryBase.AddAsync(Entity);
            _logger.LogInformation($"Order {NewCatalog.Id} is Created.");
            return NewCatalog.Id;
        }
    }
}
