using FastEndpoints;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.Offers
{
    public class UpdateOfferEndpoint : Endpoint<UpdateOfferCommand>
    {
        private readonly IMediator _mediator;

        public UpdateOfferEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Put("/offers"); 
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateOfferCommand req, CancellationToken ct)
        {
            await _mediator.Send(req, ct);
            await SendOkAsync(); 
        }
    }
}
