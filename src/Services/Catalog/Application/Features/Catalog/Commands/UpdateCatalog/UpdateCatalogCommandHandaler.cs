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

namespace Application.Features.Catalog.Commands.UpdateCatalog
{
    public class UpdateCatalogCommandHandaler : IRequestHandler<UpdateCatalogCommand>
    {
        private readonly ICatalogRepositoryBase<CatalogEntity> _catalogRepositoryBase;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCatalogCommand> _logger;

        public UpdateCatalogCommandHandaler(ICatalogRepositoryBase<CatalogEntity> catalogRepositoryBase, IMapper mapper, ILogger<UpdateCatalogCommand> logger)
        {
            _catalogRepositoryBase = catalogRepositoryBase;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var id = await _catalogRepositoryBase.GetProduct(request.Id);
            if (id == null)
            {
                _logger.LogError("Catalog not found in database!!.");
                //throw new NotFoundException(typeof(CatalogEntity), request.Id);
            }

            _mapper.Map(request, id, typeof(UpdateCatalogCommand), typeof(CatalogEntity));
            await _catalogRepositoryBase.UpdateAsync(id);
            _logger.LogInformation($"Catalog {id.Id} is update.");
            return Unit.Value;


        }
    }
}
