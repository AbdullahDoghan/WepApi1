using MediatR;

namespace Application.Features.Catalog.Commands.DeleteCatalog
{
    public class DeleteCatalogCommand:IRequest
    {
        public int Id { get; set; }
    }
}
