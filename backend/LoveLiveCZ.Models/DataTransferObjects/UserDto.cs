namespace LoveLiveCZ.Models.DataTransferObjects;

public class UserDto
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
    /// Gets or sets username
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Gets or sets path to profile picture
    /// </summary>
    public string ProfilePicture { get; set; }
    
    /// <summary>
    /// Gets or sets created date
    /// </summary>
    public DateTimeOffset Created { get; set; }
}