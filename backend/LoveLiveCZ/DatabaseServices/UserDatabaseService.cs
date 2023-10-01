using System.Data;
using Dapper;
using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Base;
using LoveLiveCZ.Utilities.Enums;
using LoveLiveCZ.Utilities.Interfaces;
using static LoveLiveCZ.Models.Database.Constants;

namespace LoveLiveCZ.DatabaseServices;

public class UserDatabaseService : DatabaseServiceBase, IUserDatabaseService
{
    public UserDatabaseService(Func<IDbConnection> connectionFactory) : base(connectionFactory)
    {
    }
    
    public async Task<User> CreateUserAsync(NewUser user)
    {
        const string query = $@"
            INSERT INTO love_live_cz.""{UsersTable.TableName}"" (
                ""{IDisplayNameable.ColumnName}"",
                ""{UsersTable.Username}"",
                ""{IEmail.ColumnName}"",
                ""{UsersTable.PasswordHash}""
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
                FROM love_live_cz.""{UsersTable.TableName}"" AS {UsersTable.Prefix}
                LEFT JOIN love_live_cz.""{UserRolesTable.TableName}"" AS {UserRolesTable.Prefix}
                    ON {UsersTable.Prefix}.""{IIdentifiable.ColumnName}"" = {UserRolesTable.Prefix}.""{IUserIdentifiable.ColumnName}""
            WHERE {UsersTable.Prefix}.""{IIdentifiable.ColumnName}"" = @id;";
        
        User result = null;
        var connection = ConnectionFactory();
        await connection.QueryAsync<User, UserRole, User>(query, (user, role) =>
        {
            if (result == null)
            {
                result = user;
                result.Roles = new List<UserRoleType>();
            }

            if (role != null)
            {
                result.Roles.Add(role.Role);
            }
            
            return user;
        }, new { id }, splitOn: IUserIdentifiable.ColumnName);
        return result;
    }

    public async Task<User> GetUserAsync(string username)
    {
        const string query = $@"
            SELECT *
                FROM love_live_cz.""{UsersTable.TableName}"" AS {UsersTable.Prefix}
                LEFT JOIN love_live_cz.""{UserRolesTable.TableName}"" AS {UserRolesTable.Prefix}
                    ON {UsersTable.Prefix}.""{IIdentifiable.ColumnName}"" = {UserRolesTable.Prefix}.""{IUserIdentifiable.ColumnName}""
            WHERE {UsersTable.Prefix}.""{UsersTable.Username}"" = @username;";
        
        User result = null;
        var connection = ConnectionFactory();
        await connection.QueryAsync<User, UserRole, User>(query, (user, role) =>
        {
            if (result == null)
            {
                result = user;
                result.Roles = new List<UserRoleType>();
            }

            if (role != null)
            {
                result.Roles.Add(role.Role);
            }
            
            return user;
        }, new { username }, splitOn: IUserIdentifiable.ColumnName);
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
                FROM love_live_cz.""{UsersTable.TableName}""
                WHERE ""{UsersTable.Username}"" = @username
                OR ""{IEmail.ColumnName}"" = @email
            );";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleAsync<bool>(query, parameters);
        
        return result;
    }

    public async Task<User> UpdateAsync(User user)
    {
        const string query = $@"
            UPDATE love_live_cz.""{UsersTable.TableName}""
                SET
                    ""{IDisplayNameable.ColumnName}"" = @displayName,
                    ""{UsersTable.ProfilePicture}"" = @profilePicture
            WHERE ""{IIdentifiable.ColumnName}"" = @id
            RETURNING *;
        ";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleOrDefaultAsync<User>(query, user);
        return result;
    }

    public Task<Guid> DeleteAsync(Guid userId)
    {
        const string query = $@"
            DELETE FROM love_live_cz.""{UsersTable.TableName}""
                WHERE ""{IIdentifiable.ColumnName}"" = @userId
            RETURNING ""{IIdentifiable.ColumnName}"";
        ";
        
        var connection = ConnectionFactory();
        return connection.QuerySingleAsync<Guid>(query, new { userId });
    }

    public Task<bool> ExistsAsync(Guid userId)
    {
        const string query = $@"
            SELECT EXISTS (
                SELECT 1
                    FROM love_live_cz.""{UsersTable.TableName}""
                        WHERE ""{IIdentifiable.ColumnName}"" = @userId
            );
        ";
        
        var connection = ConnectionFactory();
        return connection.QuerySingleAsync<bool>(query, new { userId });
    }

    public async Task<string> GetPasswordHashByUsernameAsync(string username)
    {
        const string query = $@"
            SELECT ""{UsersTable.PasswordHash}""
            FROM love_live_cz.""{UsersTable.TableName}""
            WHERE ""{UsersTable.Username}"" = @username;
        ";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleAsync<string>(query, username);
        
        return result;
    }
}