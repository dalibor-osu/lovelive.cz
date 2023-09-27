using System.Data;
using System.Text;
using Dapper;
using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Base;
using LoveLiveCZ.Utilities.Extensions;
using LoveLiveCZ.Utilities.Interfaces;
using LoveLiveCZ.Utilities.Models;
using static LoveLiveCZ.Models.Database.Constants;

namespace LoveLiveCZ.DatabaseServices;

public class PostDatabaseService : DatabaseServiceBase, IPostDatabaseService
{
    public PostDatabaseService(Func<IDbConnection> connectionFactory) : base(connectionFactory)
    {
    }
    
    public async Task<Post> GetPost(Guid userId, Guid postId)
    {
        const string query = @$"
            SELECT * FROM love_live_cz.""{PostsTable.TableName}""
            WHERE ""{IIdentifiable.ColumnName}"" = @postId
        ";
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleOrDefaultAsync<Post>(query, new { postId });
        return result;
    }

    public async Task<IReadOnlyCollection<Post>> ListPostsAsync(ListOptions options)
    {
        options ??= new ListOptions
        {
            Limit = int.MaxValue,
            Offset = 0
        };
        
        DynamicParameters parameters = new();
        
        StringBuilder query = new($@"
            SELECT * FROM love_live_cz.""{PostsTable.TableName}"" AS {PostsTable.Prefix}
                JOIN love_live_cz.""{UsersTable.TableName}"" AS {UsersTable.Prefix}
                    ON {PostsTable.Prefix}.""{IUserIdentifiable.ColumnName}"" = {UsersTable.Prefix}.""{IIdentifiable.ColumnName}""
        ");
        
        if (options.ParentId.HasValue)
        {
            query.AppendLine($@"WHERE {PostsTable.Prefix}.""{IUserIdentifiable.ColumnName}"" = @author");
            parameters.Add("author", options.ParentId.Value);
        }

        if (options.LastItemCreatedAt.HasValue)
        {
            var keyword = options.ParentId.HasValue ? "AND" : "WHERE";
            query.AppendLine($@"{keyword} {PostsTable.Prefix}.""{ICreated.ColumnName}"" < @lastItemCreatedAt");
            parameters.Add("lastItemCreatedAt", options.LastItemCreatedAt.Value);
        }   

        query.AppendListOptions(options, PostsTable.Prefix);
        
        var connection = ConnectionFactory();
        var result = await connection.QueryAsync<Post, User, Post>(query.ToString(), (post, user) =>
        {
            post.User = user;
            return post;
        }, parameters);
        return result.ToReadOnlyCollection();
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        const string query = @$"
            INSERT INTO love_live_cz.""{PostsTable.TableName}"" (
                ""{IUserIdentifiable.ColumnName}"",
                ""{PostsTable.Text}"",
                ""{ICreated.ColumnName}"",
                ""{IUpdated.ColumnName}""
            ) VALUES (
                @userId,
                @text,
                @created,
                @updated
            ) RETURNING *;
        ";
        
        post.Created = post.Updated = DateTimeOffset.UtcNow;
        
        var connection = ConnectionFactory();
        var result = await connection.QuerySingleAsync<Post>(query, post);
        return result;
    }
}