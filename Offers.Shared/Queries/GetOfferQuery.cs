using MediatR;
using Offers.Shared.Domain.Dtos;

namespace Offers.Shared.Queries
{
    public class GetOfferQuery : IRequest<OfferDto>
    {
        public int OfferId { get; set; }

        public GetOfferQuery(int offerId)
        {
            OfferId = offerId;
        }
    }
}
