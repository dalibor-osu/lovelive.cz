namespace LoveLiveCZ.Models.DataTransferObjects;

public class UserDto : BasicUserDto
{
    /// <summary>
    /// Gets or sets username
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Gets or sets created date
    /// </summary>
    public DateTimeOffset Created { get; set; }
    
    /// <summary>
    /// Gets or sets user bio
    /// </summary>
    public string Bio { get; set; }
    
    /// <summary>
    /// Gets or sets whether user has custom banner
    /// </summary>
    public bool HasCustomBanner { get; set; }
}