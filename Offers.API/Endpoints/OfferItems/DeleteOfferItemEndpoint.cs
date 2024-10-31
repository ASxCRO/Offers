using FastEndpoints;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.OfferItems
{
    public class DeleteOfferItemEndpoint : Endpoint<DeleteOfferItemCommand>
    {
        private readonly IMediator _mediator;

        public DeleteOfferItemEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Delete("/offeritems/{id}"); 
            AllowAnonymous(); 
        }

        public override async Task HandleAsync(DeleteOfferItemCommand req, CancellationToken ct)
        {
            await _mediator.Send(req, ct);
            await SendNoContentAsync(); 
        }
    }
}
