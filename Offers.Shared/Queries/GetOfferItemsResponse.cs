using Offers.Shared.Domain.Dtos;

namespace Offers.Shared.Queries
{
    public class GetOfferItemsResponse
    {
        public List<OfferItemDto> OfferItems { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalPrice{ get; set; }

        public GetOfferItemsResponse(List<OfferItemDto> offerItems, int totalCount, decimal totalPrice)
        {
            OfferItems = offerItems;
            TotalCount = totalCount;
            TotalPrice = totalPrice;
        }
    }
}
