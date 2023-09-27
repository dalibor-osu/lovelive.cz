using LoveLiveCZ.Utilities.Interfaces;

namespace LoveLiveCZ.Models.DataTransferObjects;

public class NewUserDto : IDisplayNameable, IUsernameable, IPasswordCarrier, IEmail
{
    /// <summary>
    /// Gets or sets display name
    /// </summary>
    public string DisplayName { get; set; }
    
    /// <summary>
    /// Gets or sets username
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Gets or sets password
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Gets or sets email
    /// </summary>
    public string Email { get; set; }
}