using Dapper;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Domain.Models;
using System.Data;

namespace Offers.API.Repositories.Implementations
{
    public class OfferRepository : BaseRepository<Offer, int>, IOfferRepository
    {
        public OfferRepository(IDbConnection dbConnection) : base(dbConnection) { }

    }

}
