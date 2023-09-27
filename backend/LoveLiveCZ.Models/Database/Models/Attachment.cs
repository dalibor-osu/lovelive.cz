using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoveLiveCZ.Utilities;
using LoveLiveCZ.Utilities.Enums;
using LoveLiveCZ.Utilities.Interfaces;
using static LoveLiveCZ.Models.Database.Constants;

namespace LoveLiveCZ.Models.Database.Models;

public class Attachment : IIdentifiable, IUserIdentifiable, INameable, ICreated
{
    /// <inheritdoc cref="IIdentifiable"/>
    [Column(IIdentifiable.ColumnName)]
    [Key]
    public Guid Id { get; set; }

    /// <inheritdoc cref="INameable"/>
    [Column(INameable.ColumnName)]
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets ID of a related post
    /// </summary>
    [Column(AttachmentsTable.PostIdentifier)]
    public Guid PostId { get; set; }

    /// <summary>
    /// Gets or sets Post of a image
    /// </summary>
    public Post Post { get; set; }
    
    /// <inheritdoc cref="IIdentifiable"/>
    [Column(IUserIdentifiable.ColumnName)]
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets related user
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets or sets type of attachment
    /// </summary>
    [Column(AttachmentsTable.Type)]
    public AttachmentType Type { get; set; }

    /// <inheritdoc cref="ICreated"/>
    [Column(ICreated.ColumnName)]
    public DateTimeOffset Created { get; set; }
}