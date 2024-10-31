using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Offers.API.Repositories
{
    public abstract class BaseRepository<T, TId> : IRepository<T, TId> where T : class
    {
        protected readonly IDbConnection _dbConnection;

        protected BaseRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public virtual async Task<T> GetByIdAsync(TId id)
        {
            var sql = $"SELECT * FROM [{typeof(T).Name}s] WHERE [Id] = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            var offset = (pageNumber - 1) * pageSize;
            var sql = $@"
                SELECT * 
                FROM [{typeof(T).Name}s] 
                ORDER BY [Id] 
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            return await _dbConnection.QueryAsync<T>(sql, new { Offset = offset, PageSize = pageSize });
        }

        public virtual async Task<TId> AddAsync(T entity)
        {
            var sql = $"INSERT INTO [{typeof(T).Name}s] OUTPUT INSERTED.[Id] VALUES ({GetInsertFields()})";
            return await _dbConnection.ExecuteScalarAsync<TId>(sql, entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var sql = $"UPDATE [{typeof(T).Name}s] SET {GetUpdateFields()} WHERE [Id] = @Id";
            await _dbConnection.ExecuteAsync(sql, entity);
        }

        public virtual async Task DeleteAsync(TId id)
        {
            var sql = $"DELETE FROM [{typeof(T).Name}s] WHERE [Id] = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        private string GetUpdateFields()
        {
            var properties = typeof(T).GetProperties().Where(p => p.Name != "Id");
            return string.Join(", ", properties.Select(p => $"[{p.Name}] = @{p.Name}"));
        }

        private string GetInsertFields()
        {
            var properties = typeof(T).GetProperties().Where(p => p.Name != "Id");
            return string.Join(", ", properties.Select(p => $"@{p.Name}"));
        }

        public virtual async Task<int> TotalCountAsync()
        {
            var sql = $"SELECT COUNT(*) FROM [{typeof(T).Name}s]";
            return await _dbConnection.ExecuteScalarAsync<int>(sql);
        }
    }
}
