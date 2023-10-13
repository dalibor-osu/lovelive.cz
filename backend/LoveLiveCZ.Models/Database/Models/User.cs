using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoveLiveCZ.Utilities.Enums;
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
    [MaxLength(32)]
    public string DisplayName { get; set; }

    /// <inheritdoc cref="IUsernameable"/>
    [Column(IUsernameable.ColumnName)]
    [Required]
    [MaxLength(16)]
    public string Username { get; set; }
    
    /// <summary>
    /// Gets or sets password hash
    /// </summary>
    [Column(UsersTable.PasswordHash)]
    [Required]
    public string PasswordHash { get; set; }

    /// <summary>
    /// Get or sets whether user has custom avatar
    /// </summary>
    [Column(UsersTable.HasCustomAvatar)]
    public bool HasCustomAvatar { get; set; }
    
    /// <summary>
    /// Get or sets whether user has custom banner
    /// </summary>
    [Column(UsersTable.HasCustomBanner)]
    public bool HasCustomBanner { get; set; }
    
    /// <summary>
    /// Gets or sets user bio
    /// </summary>
    [Column(UsersTable.Bio)]
    [MaxLength(200)]
    public string Bio { get; set; }

    /// <inheritdoc cref="IEmail"/>
    [Column(IEmail.ColumnName)]
    [Required]
    [MaxLength(320)]
    public string Email { get; set; }

    /// <inheritdoc cref="IDeletable"/>
    [Column(IDeletable.ColumnName)]
    public bool Deleted { get; set; }
    
    /// <summary>
    /// Gets or sets user roles
    /// </summary>
    [NotMapped]
    public List<UserRoleType> Roles { get; set; }

    /// <inheritdoc cref="ICreated"/>
    [Column(ICreated.ColumnName)]
    public DateTimeOffset Created { get; set; }

    /// <inheritdoc cref="IUpdated"/>
    [Column(IUpdated.ColumnName)]
    public DateTimeOffset Updated { get; set; }
}