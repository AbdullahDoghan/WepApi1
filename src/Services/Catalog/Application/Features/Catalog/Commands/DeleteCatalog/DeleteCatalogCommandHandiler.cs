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

namespace Application.Features.Catalog.Commands.DeleteCatalog
{
    class DeleteCatalogCommandHandiler : IRequestHandler<DeleteCatalogCommand>
    {
        private readonly ICatalogRepositoryBase<CatalogEntity> _catalogRepositoryBase;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCatalogCommand> _logger;

        public DeleteCatalogCommandHandiler(ICatalogRepositoryBase<CatalogEntity> catalogRepositoryBase, IMapper mapper, ILogger<DeleteCatalogCommand> logger)
        {
            _catalogRepositoryBase = catalogRepositoryBase;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
        {
            var id = await _catalogRepositoryBase.GetProduct(request.Id);
            if (id == null)
            {
                _logger.LogError("Catalog not found in database!!.");
                //throw new NotFoundException(typeof(CatalogEntity), request.Id);
            }
            await _catalogRepositoryBase.DeleteAsync(id);
            _logger.LogInformation($"Catalog {id.Id} is Deleted.");
            return Unit.Value;
        }
    }
}
