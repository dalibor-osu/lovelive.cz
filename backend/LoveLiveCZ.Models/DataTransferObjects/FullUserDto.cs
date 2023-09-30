namespace LoveLiveCZ.Models.DataTransferObjects;

public class FullUserDto : UserDto
{
    /// <summary>
    /// Gets or sets email
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Gets or sets updated date
    /// </summary>
    public DateTimeOffset Updated { get; set; }
}