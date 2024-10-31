using FastEndpoints;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.Offers
{
    public class CreateOfferEndpoint : Endpoint<CreateOfferCommand>
    {
        private readonly IMediator _mediator;

        public CreateOfferEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("/offers");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateOfferCommand req, CancellationToken ct)
        {
            await _mediator.Send(req, ct);
            await SendOkAsync();
        }
    }
}
