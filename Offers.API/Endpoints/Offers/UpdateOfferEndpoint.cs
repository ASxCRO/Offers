using FastEndpoints;
using FluentValidation;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.Offers
{
    public class UpdateOfferEndpoint : Endpoint<UpdateOfferCommand>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<UpdateOfferCommand> _validator;

        public UpdateOfferEndpoint(IMediator mediator, IValidator<UpdateOfferCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public override void Configure()
        {
            Put("/offers"); 
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateOfferCommand req, CancellationToken ct)
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
