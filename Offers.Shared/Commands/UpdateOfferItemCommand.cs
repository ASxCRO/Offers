using FluentValidation;
using MediatR;

namespace Offers.Shared.Commands
{
    public class UpdateOfferItemCommand : IRequest
    {
        public int ItemId { get; set; }
        public int OfferId { get; set; }
        public string ArticleName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } // Validation: must be > 0
    }

    public class UpdateOfferItemCommandValidator : AbstractValidator<UpdateOfferItemCommand>
    {
        public UpdateOfferItemCommandValidator()
        {
            RuleFor(x => x.ItemId)
                .GreaterThan(0).WithMessage("Item ID must be greater than zero.");
            RuleFor(x => x.OfferId)
                .GreaterThan(0).WithMessage("Offer ID must be greater than zero.");
            RuleFor(x => x.ArticleName)
                .NotEmpty().WithMessage("Article name is required.");
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than zero.");
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
