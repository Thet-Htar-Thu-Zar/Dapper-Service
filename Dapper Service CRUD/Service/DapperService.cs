using Dapper_Service_CRUD.Models;

namespace Dapper_Service_CRUD.Service
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using(var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Product>("SELECT * FROM Product");
            }
        }

        private async Task<int> ExecuteAsync(string sql, object param = null)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, param);
            }
        }
    }
}
