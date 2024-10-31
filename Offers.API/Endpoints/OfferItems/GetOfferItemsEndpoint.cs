using FastEndpoints;
using MediatR;
using Offers.Shared.Queries;

namespace Offers.API.Endpoints.OfferItems
{
    public class GetOfferItemsEndpoint : Endpoint<GetOfferItemsQuery>
    {
        private readonly IMediator _mediator;

        public GetOfferItemsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("/offers/{offerId}/items"); 
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetOfferItemsQuery req, CancellationToken ct)
        {
            var result = await _mediator.Send(req, ct);
            await SendAsync(result); 
        }
    }
}
