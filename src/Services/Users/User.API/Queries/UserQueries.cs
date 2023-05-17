using Dapper;
using Microsoft.Data.SqlClient;
using Users.Application.Queries;
using User = Users.Application.Queries.User;

namespace Users.API.Queries
{
    public class UserQueries
        : IUserQueries
    {
        private string _connectionString = string.Empty;

        public UserQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var result = await connection.QueryAsync<dynamic>(
                @"select
                       u.Id
                      ,u.CreatedDate
                      ,u.Credentials_DisplayName as [DisplayName]
                      ,u.Credentials_Login       as [Login]
                      ,u.Credentials_Email       as [Email]
                      ,u.IsActive
                      ,u.IsDeleted
                      ,c.Id                      as [ConnectionId]
                      ,c.ConnectionTo
                      ,c.ForeignUserId
                      ,c.[Login]                 as [ConnectionLogin]
                      ,c.Email                   as [ConnectionEmail]
                      ,c.Scopes
                    from users.users        as u
                    join users.connections  as c on c.UserId = u.Id
                    where u.id = @userId", 
                new { userId });

            if (result.AsList().Count == 0)
                throw new KeyNotFoundException();

            return MapUser(result);
        }

        private User MapUser(dynamic result)
        {
            User user = new()
            {
                Id = result[0].Id,
                CreatedDate = result[0].CreatedDate,
                DisplayName = result[0].DisplayName,
                Login = result[0].Login,
                Email = result[0].Email,
                IsActive = result[0].IsActive,
                IsDeleted = result[0].IsDeleted,
                Connections = new()
            };

            foreach (dynamic connection in result)
            {
                Connection con = new()
                {
                    Id = connection.ConnectionId,
                    ConnectionTo = connection.ConnectionTo,
                    ForeignUserId = connection.ForeignUserId,
                    Login = connection.ConnectionLogin,
                    Email = connection.ConnectionEmail,
                    Scopes = connection.Scopes
                };

                user.Connections.Add(con);
            }

            return user;
        }
    }
}
