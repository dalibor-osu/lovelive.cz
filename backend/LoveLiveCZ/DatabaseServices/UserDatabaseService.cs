using System.Data;
using Dapper;
using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Base;
using LoveLiveCZ.Utilities.Interfaces;
using static LoveLiveCZ.Models.Database.Constants.UsersTable;

namespace LoveLiveCZ.DatabaseServices;

public class UserDatabaseService : DatabaseServiceBase, IUserDatabaseService
{
    public UserDatabaseService(Func<IDbConnection> connectionFactory) : base(connectionFactory)
    {
    }
    
    public async Task<User> CreateUserAsync(NewUser user)
    {
        const string query = $@"
            INSERT INTO love_live_cz.""{TableName}"" (
                ""{IDisplayNameable.ColumnName}"",
                ""{Username}"",
                ""{IEmail.ColumnName}"",
                ""{PasswordHash}""
            ) VALUES (
                @displayName,
                @username,
                @email,
                @passwordHash
            ) RETURNING *;
        ";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleAsync<User>(query, user);
        
        return result;
    }

    public async Task<User> GetUserAsync(Guid id)
    {
        const string query = $@"
            SELECT *
            FROM love_live_cz.""{TableName}""
            WHERE ""{IIdentifiable.ColumnName}"" = @id;";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleOrDefaultAsync<User>(query, new { id });
        return result;
    }

    public async Task<User> GetUserAsync(string username)
    {
        const string query = $@"
            SELECT *
            FROM love_live_cz.""{TableName}""
            WHERE ""{Username}"" = @username;";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleOrDefaultAsync<User>(query, new { username });
        return result;
    }

    public async Task<bool> UsernameOrEmailExistsAsync(string username, string email)
    {
        DynamicParameters parameters = new(new
        {
            username,
            email
        });
        
        const string query = $@"
            SELECT EXISTS (
                SELECT 1
                FROM love_live_cz.""{TableName}""
                WHERE ""{Username}"" = @username
                OR ""{IEmail.ColumnName}"" = @email
            );";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleAsync<bool>(query, parameters);
        
        return result;
    }

    public async Task<User> UpdateAsync(User user)
    {
        const string query = $@"
            UPDATE love_live_cz.""{TableName}""
                SET
                    ""{IDisplayNameable.ColumnName}"" = @displayName,
                    ""{ProfilePicture}"" = @profilePicture
            WHERE ""{IIdentifiable.ColumnName}"" = @id
            RETURNING *;
        ";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleOrDefaultAsync<User>(query, user);
        return result;
    }

    public async Task<string> GetPasswordHashByUsernameAsync(string username)
    {
        const string query = $@"
            SELECT ""{PasswordHash}""
            FROM love_live_cz.""{TableName}""
            WHERE ""{Username}"" = @username;
        ";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleAsync<string>(query, username);
        
        return result;
    }
}