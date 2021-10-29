using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.CreateNewCatalog
{
    public class CreateNewCatalogCommandValidator : AbstractValidator<CreateNewCatalogCommand>
    {
        public CreateNewCatalogCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{Name} Is required").NotNull();
            RuleFor(p => p.Price).NotEmpty().WithMessage("{Price} Is Required").GreaterThan(0).WithMessage("{Price} Should be bigger than Zero.");
        }
    }
}
