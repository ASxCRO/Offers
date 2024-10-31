using Offers.Shared.Domain.Models;

namespace Offers.API.Repositories.Abstractions
{
    public interface IOfferItemRepository : IRepository<OfferItem, int>
    {
        Task<IEnumerable<OfferItem>> GetItemsByOfferIdAsync(int offerId, int pageNumber, int pageSize);
    }
}

