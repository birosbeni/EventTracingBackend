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
            RuleFor(location => location.Country).NotEmpty().WithMessage("Country can not be empty");
            RuleFor(location => location.PostalCode).GreaterThan(0).WithMessage("Postalcode must be greater than 0");
            RuleFor(location => location.City).NotEmpty().WithMessage("City can not be empty");
            RuleFor(location => location.Street).NotEmpty().When(location => location.House > 0).WithMessage("Street can not be empty if house is given");
            RuleFor(location => location.House).GreaterThan(0).When(location => !string.IsNullOrEmpty(location.Street)).WithMessage("House must be greater than 0 if street is given");
        }
    }
}
