using FluentValidation;
using MediatR;

namespace Offers.Shared.Commands
{
    public class UpdateOfferCommand : IRequest
    {
        public int OfferId { get; set; }
        public DateTime OfferDate { get; set; }
    }

    public class UpdateOfferCommandValidator : AbstractValidator<UpdateOfferCommand>
    {
        public UpdateOfferCommandValidator()
        {
            RuleFor(x => x.OfferId)
                .GreaterThan(0).WithMessage("Offer ID must be greater than zero.");
            RuleFor(x => x.OfferDate)
                .NotEmpty().WithMessage("Offer date is required.");
        }
    }
}
