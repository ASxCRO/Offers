using Offers.Shared.Domain.Models;

namespace Offers.API.Repositories.Abstractions
{
    public interface IOfferRepository : IRepository<Offer, int>
    {
        Task<decimal> GetTotalOfferPrice(int offerId);
    }
}
