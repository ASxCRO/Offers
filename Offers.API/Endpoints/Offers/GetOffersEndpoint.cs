using FastEndpoints;
using MediatR;
using Offers.Shared.Queries;

namespace Offers.API.Endpoints.Offers
{
    public class GetOffersEndpoint : Endpoint<GetOffersQuery>
    {
        private readonly IMediator _mediator;

        public GetOffersEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("/offers"); 
            AllowAnonymous(); 
        }

        public override async Task HandleAsync(GetOffersQuery req, CancellationToken ct)
        {
            var result = await _mediator.Send(req, ct);
            await SendAsync(result); 
        }
    }
}
