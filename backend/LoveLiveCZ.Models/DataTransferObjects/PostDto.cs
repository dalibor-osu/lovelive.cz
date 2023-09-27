namespace LoveLiveCZ.Models.DataTransferObjects;

public class PostDto
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets text value
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets attachments
    /// </summary>
    public List<AttachmentDto> Attachments { get; set; }
    
    /// <summary>
    /// Gets or sets user
    /// </summary>
    public BasicUserDto User { get; set; }
    
    /// <summary>
    /// Gets or sets created date
    /// </summary>
    public DateTimeOffset Created { get; set; }
    
    /// <summary>
    /// Gets or sets updated date
    /// </summary>
    public DateTimeOffset Updated { get; set; }
}