using LoveLiveCZ.Utilities.Interfaces;

namespace LoveLiveCZ.Models.Database.Models;

public class NewUser : IUsernameable, IDisplayNameable, IEmail, IDeletable
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
    /// Gets or sets password hash
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    /// Gets or sets email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets deleted
    /// </summary>
    public bool Deleted { get; set; } = false;
}