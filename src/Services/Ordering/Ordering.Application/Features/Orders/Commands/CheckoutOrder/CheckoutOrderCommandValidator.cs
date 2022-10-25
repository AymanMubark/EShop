using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty()
                .WithMessage("{FirstName} is required.")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{FirstName} is required.");
            RuleFor(p => p.Email).NotEmpty()
                .WithMessage("{Email} is required.");
            RuleFor(p => p.OrderDetails.Count()).NotEmpty()
                .WithMessage("{OrderDetails} is required.")
                .GreaterThan(0)
                .WithMessage("{TotalPrice} should be greater than zero.");

        }
    }
}
