using FastEndpoints;
using FluentValidation;
using MediatR;
using Offers.Shared.Commands;
using System.Net;

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
                var validationMessages = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
                await SendStringAsync(validationMessages, (int)HttpStatusCode.NotAcceptable);
                return;
            }

            await _mediator.Send(req, ct);
            await SendOkAsync();
        }
    }
}
