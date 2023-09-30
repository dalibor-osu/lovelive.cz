using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoveLiveCZ.Utilities.Interfaces;
using static LoveLiveCZ.Models.Database.Constants;

namespace LoveLiveCZ.Models.Database.Models;

[Table(PostsTable.TableName)]
public class Post : IIdentifiable, IUserIdentifiable, IDeletable, ICreated, IUpdated
{
    /// <inheritdoc cref="IIdentifiable"/>
    [Column(IIdentifiable.ColumnName)]
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets text values
    /// </summary>
    [Column(PostsTable.Text)]
    [MaxLength(5000)]
    public string Text { get; set; }

    public List<Attachment> Attachments { get; set; }

    /// <inheritdoc cref="IDeletable"/>
    [Column(IDeletable.ColumnName)]
    public bool Deleted { get; set; }

    /// <inheritdoc cref="ICreated"/>
    [Column(ICreated.ColumnName)]
    public DateTimeOffset Created { get; set; }

    /// <inheritdoc cref="IUpdated"/>
    [Column(IUpdated.ColumnName)]
    public DateTimeOffset Updated { get; set; }
    
    /// <inheritdoc cref="IUserIdentifiable"/>
    [Column(IUserIdentifiable.ColumnName)]
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets User author of a post
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Gets or sets number of likes
    /// </summary>
    [NotMapped]
    public List<Like> Likes { get; set; }
    
    /// <summary>
    /// Gets or sets number of likes
    /// </summary>
    public int LikeCount => Likes?.Count ?? 0;
}