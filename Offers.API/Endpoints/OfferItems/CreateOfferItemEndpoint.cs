using FastEndpoints;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.OfferItems
{
    public class CreateOfferItemEndpoint : Endpoint<CreateOfferItemCommand>
    {
        private readonly IMediator _mediator;

        public CreateOfferItemEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("/offeritems");
            AllowAnonymous(); 
        }

        public override async Task HandleAsync(CreateOfferItemCommand req, CancellationToken ct)
        {
            await _mediator.Send(req, ct);
            await SendOkAsync();
        }
    }
}
