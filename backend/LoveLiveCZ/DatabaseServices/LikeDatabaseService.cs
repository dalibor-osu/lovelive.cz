using System.Data;
using Dapper;
using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Utilities.Base;
using LoveLiveCZ.Utilities.Interfaces;
using static LoveLiveCZ.Models.Database.Constants.LikesTable;

namespace LoveLiveCZ.DatabaseServices;

public class LikeDatabaseService : DatabaseServiceBase, ILikeDatabaseService
{
    public LikeDatabaseService(Func<IDbConnection> connectionFactory) : base(connectionFactory)
    {
    }

    public async Task<bool> ExistsAsync(Guid userId, Guid postId)
    {
        const string query = @$"
            SELECT EXISTS (
                SELECT 1 FROM love_live_cz.""{TableName}""
                    WHERE ""{IUserIdentifiable.ColumnName}"" = @userId
                        AND ""{PostIdentifier}"" = @postId
        );";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleAsync<bool>(query, new { userId, postId });
        return result;
    }

    public async Task<bool> LikeAsync(Guid userId, Guid postId)
    {
        const string query = @$"
            INSERT INTO love_live_cz.""{TableName}""
                (
                    ""{IUserIdentifiable.ColumnName}"",
                    ""{PostIdentifier}""
                )
                VALUES
                (
                    @userId,
                    @postId
                );
        ";
        
        var connection = ConnectionFactory();
        var result = await connection.ExecuteAsync(query, new { userId, postId });
        return result > 0;
    }

    public async Task<bool> UnlikeAsync(Guid userId, Guid postId)
    {
        const string query = @$"
            DELETE FROM love_live_cz.""{TableName}""
                WHERE ""{IUserIdentifiable.ColumnName}"" = @userId
                    AND ""{PostIdentifier}"" = @postId;
        ";
        
        var connection = ConnectionFactory();
        var result = await connection.ExecuteAsync(query, new { userId, postId });
        return result > 0;
    }
}