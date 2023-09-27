using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoveLiveCZ.Utilities.Interfaces;
using static LoveLiveCZ.Models.Database.Constants;

namespace LoveLiveCZ.Models.Database.Models;

[Table(UsersTable.TableName)]
public class User : IIdentifiable, IDisplayNameable, IUsernameable, IEmail, IDeletable, ICreated, IUpdated
{
    /// <inheritdoc cref="IIdentifiable"/>
    [Column(IIdentifiable.ColumnName)]
    [Key]
    public Guid Id { get; set; }

    /// <inheritdoc cref="IDisplayNameable"/>
    [Column(IDisplayNameable.ColumnName)]
    [Required]
    public string DisplayName { get; set; }

    /// <inheritdoc cref="IUsernameable"/>
    [Column(IUsernameable.ColumnName)]
    [Required]
    public string Username { get; set; }
    
    /// <summary>
    /// Gets or sets password hash
    /// </summary>
    [Column(UsersTable.PasswordHash)]
    [Required]
    public string PasswordHash { get; set; }

    /// <summary>
    /// Get or sets path to profile picture
    /// </summary>
    [Column(UsersTable.ProfilePicture)]
    public string ProfilePicture { get; set; }

    /// <inheritdoc cref="IEmail"/>
    [Column(IEmail.ColumnName)]
    [Required]
    public string Email { get; set; }

    /// <inheritdoc cref="IDeletable"/>
    [Column(IDeletable.ColumnName)]
    public bool Deleted { get; set; }

    /// <inheritdoc cref="ICreated"/>
    [Column(ICreated.ColumnName)]
    public DateTimeOffset Created { get; set; }

    /// <inheritdoc cref="IUpdated"/>
    [Column(IUpdated.ColumnName)]
    public DateTimeOffset Updated { get; set; }
}