using MediatR;
using Offers.Shared.Domain.Dtos;

namespace Offers.Shared.Queries
{
    public class GetOfferItemQuery : IRequest<OfferItemDto>
    {
        public int ItemId { get; set; }

        public GetOfferItemQuery(int itemId)
        {
            ItemId = itemId;
        }
    }
}
