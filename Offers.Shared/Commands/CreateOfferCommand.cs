using FluentValidation;
using MediatR;

namespace Offers.Shared.Commands
{
    public class CreateOfferCommand : IRequest<int>
    {
        public DateTime OfferDate { get; set; }
    }

    public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
    {
        public CreateOfferCommandValidator()
        {
            RuleFor(x => x.OfferDate)
                .NotEmpty().WithMessage("Offer date is required.");
        }
    }
}
