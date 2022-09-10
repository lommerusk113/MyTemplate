using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace Core.Repository
{
    public class BaseRepository
    {
        public string ConnectionString = "Server=LOCALHOST; Database=DNDNOTES; Trusted_connection = True; MultipleActiveResultSets = true";

        public async Task<List<T>> GetList<T>(string query, object? parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return (await connection.QueryAsync<T>(query, parameters)).ToList();
            }
        }
        public async Task<int> Insert<T>(string sql, object parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }
        public async Task<int> Update<T>(string sql, object parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }
        public async Task<int> Delete<T>(string sql, object Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(sql, Id);
            }
        }
    }
}
