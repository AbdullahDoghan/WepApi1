using Application.Features.Catalog.Commands.CreateNewCatalog;
using Application.Features.Catalog.Commands.UpdateCatalog;
using Application.Features.Catalog.Commands.DeleteCatalog;
using Application.Features.Catalog.Queries.GetCatalogById;
using Application.Features.Catalog.Queries.GetCatalogByName;
using Application.Features.Catalog.Queries.GetCatalogList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class CatalogController:ControllerBase
    {
        private readonly IMediator _mediator;
        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //Get all Catalog
        [HttpGet(Name ="GetCatalog")]
        [ProducesResponseType(typeof(IEnumerable<CatalogVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogVm>>> GetCatalog()
        {
            var query = new GetCatalogListQuery();
            var Catalogs = await _mediator.Send(query);
            return Ok(Catalogs);
        }
        // end of get all Catalog


        //get catalog by id
        [HttpGet("{Id}", Name = "GetCatalogById")]
        [ProducesResponseType(typeof(IEnumerable<CatalogVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogVm>>> GetCataloById(int Id)
        {
            var query = new GetCatalogByIdQuery(Id);
            var Catalog = await _mediator.Send(query);
            return Ok(Catalog);
        }

        //end of get catalog by id


        //get catalog by name
        [HttpGet("{Name}", Name = "GetCatalogByName")]
        [ProducesResponseType(typeof(IEnumerable<CatalogVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogVm>>> GetCatalogByName(string Name)
        {
            var query = new GetCatalogByNameQuery(Name);
            var Catalog = await _mediator.Send(query);
            return Ok(Catalog);
        }
        // end of catalog by name

        //create new catalog
        [HttpPost(Name = "Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCatalog([FromBody] CreateNewCatalogCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        // end of create new catalog

        //Update catalog
        [HttpPut(Name = "UpdateCatalog")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCatalog([FromBody] UpdateCatalogCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        //end of update catalog



        //delete catalog
        [HttpDelete("{id}", Name = "DeleteCatalog")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCatalog(int id)
        {
            var command = new DeleteCatalogCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
