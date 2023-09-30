using System.ComponentModel.DataAnnotations.Schema;
using LoveLiveCZ.Utilities.Enums;
using LoveLiveCZ.Utilities.Interfaces;

namespace LoveLiveCZ.Models.Database.Models;

[Table(Constants.UserRolesTable.TableName)]
public class UserRole : IUserIdentifiable
{
    /// <inheritdoc cref="IUserIdentifiable"/>
    [Column(IUserIdentifiable.ColumnName)]
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets User with a role
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Gets or sets role of a User
    /// </summary>
    [Column(Constants.UserRolesTable.Role)]
    public UserRoleType Role { get; set; }
}