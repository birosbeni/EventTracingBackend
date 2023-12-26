using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EventTracingBackend.BusinessLogic.Validators
{
    public class LocationValidator : AbstractValidator<CreateLocation>
    {
        public LocationValidator()
        {
            RuleFor(location => location.Country).NotEmpty().WithMessage("Az ország nem lehet üres");
            RuleFor(location => location.PostalCode).GreaterThan(0);
            RuleFor(location => location.City).NotEmpty();
            RuleFor(location => location.Street).NotEmpty();
            RuleFor(location => location.House).GreaterThan(0).WithMessage("A házszámnak nagyobbnak kell lennie mint 0");
        }
    }
}
