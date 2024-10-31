using FastEndpoints;
using FluentValidation;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.Offers
{
    public class CreateOfferEndpoint : Endpoint<CreateOfferCommand>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateOfferCommand> _validator;

        public CreateOfferEndpoint(IMediator mediator, IValidator<CreateOfferCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public override void Configure()
        {
            Post("/offers");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateOfferCommand req, CancellationToken ct)
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
