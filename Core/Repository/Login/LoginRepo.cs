
using System.Data.SqlClient;
using Dapper;
using Core.Repository;
using Domain.DataModels.Models;

namespace Core.Repository.Login
{
    public class LoginRepo : BaseRepository
    {
        internal string GetSqlWhere(UserModel user, string sql)
        {
            List<string> SearchParameters = new List<string>();

            if (user.UserId > 0) return sql + "Where UserId = @UserId";

            if (user.Username != null) SearchParameters.Add("Username = @Username");
            if (user.Password != null) SearchParameters.Add("Password = @Password");
            
            return SearchParameters.Count() > 0 ? sql + "Where " + string.Join(" AND ", SearchParameters) : sql;

        }
        internal string GetSql(UserModel user)
        {
            string sql = @"SELECT * FROM USERS";
            return GetSqlWhere(user, sql);
        }

        public async Task<List<UserModel>> GetList(UserModel user)
        {
            return await GetList<UserModel>(GetSql(user));
        }

        public async Task<int> Insert(UserModel user)
        {
            string sql = @"INSERT INTO USERS Username, Password
                            VALUES(@Username,@Password)";
            return await Insert<UserModel>(sql, new { Username = user.Username, Password = user.Password });
        }

        public async Task<int> Update(UserModel user)
        {
            string sql = @"UPDATE USERS SET 
                            Username = @Username, Password = @Password WHERE UserId = @UserId";
            return await Update<UserModel>(sql, new { UserId = user.UserId, Username = user.Username, Password = user.Password });
        }

        public async Task<int> Delete(long UserId)
        {
            string sql = @"DELETE FROM USERS WHERE UserId = @UserId";
            return await Delete<UserModel>(sql, new { UserId = UserId });
        }
    }
}
