using Dapper;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Domain.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Offers.API.Repositories.Implementations
{
    public class OfferRepository : BaseRepository<Offer, int>, IOfferRepository
    {
        public OfferRepository(IDbConnection dbConnection) : base(dbConnection) { }

        public async Task<decimal> GetTotalOfferPrice(int offerId)
        {
            const string sql = @"
            SELECT SUM(TotalPrice) 
            FROM OfferItems 
            WHERE OfferId = @OfferId;";

            var totalPrice = await _dbConnection.QuerySingleOrDefaultAsync<decimal?>(sql, new { OfferId = offerId });
            return totalPrice ?? 0; 
        }
    }

}
