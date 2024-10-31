using FastEndpoints;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.Offers
{
    public class DeleteOfferEndpoint : Endpoint<DeleteOfferCommand>
    {
        private readonly IMediator _mediator;

        public DeleteOfferEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Delete("/offers/{id}"); 
            AllowAnonymous(); 
        }

        public override async Task HandleAsync(DeleteOfferCommand req, CancellationToken ct)
        {
            await _mediator.Send(req, ct);
            await SendNoContentAsync();
        }
    }
}
