using FastEndpoints;
using FluentValidation;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.OfferItems
{
    public class CreateOfferItemEndpoint : Endpoint<CreateOfferItemCommand>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateOfferItemCommand> _validator;

        public CreateOfferItemEndpoint(IMediator mediator, IValidator<CreateOfferItemCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public override void Configure()
        {
            Post("/offeritems");
            AllowAnonymous(); 
        }

        public override async Task HandleAsync(CreateOfferItemCommand req, CancellationToken ct)
        {
            var validationResult = await _validator.ValidateAsync(req);
            if (!validationResult.IsValid)
            {
                await SendErrorsAsync();
                return;
            }

            await _mediator.Send(req, ct);
            await SendOkAsync();
        }
    }
}
