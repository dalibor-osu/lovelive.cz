using LoveLiveCZ.Utilities.Enums;

namespace LoveLiveCZ.Models.DataTransferObjects;

public class BasicUserDto
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets display name
    /// </summary>
    public string DisplayName { get; set; }
    
    /// <summary>
    /// Gets or sets whether user has custom avatar
    /// </summary>
    public bool HasCustomAvatar { get; set; }
    
    /// <summary>
    /// Gets or sets roles of the user
    /// </summary>
    public IEnumerable<UserRoleType> Roles { get; set; }
}