using FastEndpoints;
using FluentValidation;
using MediatR;
using Offers.Shared.Commands;
using System.Net;

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
                var validationMessages = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
                await SendStringAsync(validationMessages, (int)HttpStatusCode.NotAcceptable);
                return;
            }

            await _mediator.Send(req, ct);
            await SendOkAsync(); 
        }
    }
}
