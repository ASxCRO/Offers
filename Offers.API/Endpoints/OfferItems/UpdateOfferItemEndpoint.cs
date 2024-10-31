using FastEndpoints;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.OfferItems
{
    public class UpdateOfferItemEndpoint : Endpoint<UpdateOfferItemCommand>
    {
        private readonly IMediator _mediator;

        public UpdateOfferItemEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Put("/offeritems"); 
            AllowAnonymous(); 
        }

        public override async Task HandleAsync(UpdateOfferItemCommand req, CancellationToken ct)
        {
            await _mediator.Send(req, ct);
            await SendOkAsync(); 
        }
    }
}
