using Dapper;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Domain.Models;
using System.Data;

namespace Offers.API.Repositories.Implementations
{
    public class OfferItemRepository : BaseRepository<OfferItem, int>, IOfferItemRepository
    {
        public OfferItemRepository(IDbConnection dbConnection) : base(dbConnection) { }

        public async Task<int> CountItemsByOfferIdAsync(int offerId)
        {
            var sql = $"SELECT COUNT(*) FROM [OfferItems] WHERE OfferId = {offerId}";
            return await _dbConnection.ExecuteScalarAsync<int>(sql);
        }

        public async Task<IEnumerable<OfferItem>> GetItemsByOfferIdAsync(int offerId, int pageNumber, int pageSize)
        {
            var sql = @"
            SELECT * 
            FROM OfferItems 
            WHERE OfferId = @OfferId
            ORDER BY Id 
            OFFSET @Offset ROWS 
            FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                OfferId = offerId,
                Offset = (pageNumber - 1) * pageSize, 
                PageSize = pageSize
            };

            return await _dbConnection.QueryAsync<OfferItem>(sql, parameters);
        }

        public override string GetUpdateFields()
        {
            var properties = typeof(OfferItem).GetProperties().Where(p => p.Name != "Id" && p.Name != "TotalPrice");
            return string.Join(", ", properties.Select(p => $"[{p.Name}] = @{p.Name}"));
        }
    }
}
