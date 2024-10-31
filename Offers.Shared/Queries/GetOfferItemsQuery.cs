using MediatR;

namespace Offers.Shared.Queries
{
    public class GetOfferItemsQuery : IRequest<GetOfferItemsResponse>
    {
        public int OfferId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetOfferItemsQuery(int offerId)
        {
            OfferId = offerId;
        }
    }
}
