using System.Data;
using Dapper;
using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.Database;
using LoveLiveCZ.Models.Database.Models;
using static LoveLiveCZ.Models.Database.Constants.AttachmentsTable;
using LoveLiveCZ.Utilities.Base;
using LoveLiveCZ.Utilities.Interfaces;

namespace LoveLiveCZ.DatabaseServices;

public class AttachmentDatabaseService : DatabaseServiceBase, IAttachmentDatabaseService
{
    public AttachmentDatabaseService(Func<IDbConnection> connectionFactory) : base(connectionFactory)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Attachment>> GetPostAttachmentsAsync(Guid postId)
    {
        const string query = @$"
            SELECT * FROM love_live_cz.""{TableName}""
            WHERE ""{PostIdentifier}"" = @postId";
        
        var connection = ConnectionFactory();
        var result = await connection.QueryAsync<Attachment>(query, new { postId });
        return result.ToList().AsReadOnly();
    }

    /// <inheritdoc />
    public async Task<Attachment> AddAsync(Attachment attachment)
    {
        attachment.Created = DateTimeOffset.UtcNow;
        
        const string query = @$"
            INSERT INTO love_live_cz.""{TableName}"" (
                ""{IIdentifiable.ColumnName}"",
                ""{PostIdentifier}"",
                ""{IUserIdentifiable.ColumnName}"",
                ""{Constants.AttachmentsTable.Type}"",
                ""{INameable.ColumnName}"",
                ""{ICreated.ColumnName}""
            ) VALUES (
                @id,
                @postId,
                @userId,
                @type,
                @name,
                @created
            ) RETURNING *;";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleAsync<Attachment>(query, attachment);
        return result;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string query = @$"
            DELETE FROM love_live_cz.""{TableName}""
                WHERE ""{IIdentifiable.ColumnName}"" = @id;
        ";
        
        var connection = ConnectionFactory();
        return await connection.ExecuteAsync(query, new { id }) > 0;
    }
}