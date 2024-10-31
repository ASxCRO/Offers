using Offers.Shared.Domain.Dtos;

namespace Offers.Shared.Queries
{
    public class GetOffersResponse
    {
        public GetOffersResponse(List<OfferDto> offers, int totalCount)
        {
            TotalCount = totalCount;
            Offers = offers;
        }

        public List<OfferDto> Offers { get; set; }
        public int TotalCount { get; set; } // For pagination
    }
}
