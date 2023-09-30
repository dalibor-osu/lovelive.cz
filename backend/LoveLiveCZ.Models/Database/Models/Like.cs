using System.ComponentModel.DataAnnotations.Schema;
using LoveLiveCZ.Utilities.Interfaces;

namespace LoveLiveCZ.Models.Database.Models;

[Table(Constants.LikesTable.TableName)]
public class Like : IUserIdentifiable
{
    /// <inheritdoc cref="IUserIdentifiable"/>
    [Column(IUserIdentifiable.ColumnName)]
    [ForeignKey(Constants.UsersTable.TableName)]
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets User that liked a post
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Gets or sets ID of a Post that was liked
    /// </summary>
    [Column(Constants.LikesTable.PostIdentifier)]
    [ForeignKey(Constants.PostsTable.TableName)]
    public Guid PostId { get; set; }
    
    /// <summary>
    /// Gets or sets Post that was liked
    /// </summary>
    public Post Post { get; set; }
}