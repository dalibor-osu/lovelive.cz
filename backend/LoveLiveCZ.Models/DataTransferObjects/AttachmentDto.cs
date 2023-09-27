using LoveLiveCZ.Utilities.Enums;

namespace LoveLiveCZ.Models.DataTransferObjects;

public class AttachmentDto
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets name of an attachment
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets type of attachment
    /// </summary>
    public AttachmentType Type { get; set; }
    
    /// <summary>
    /// Gets or sets created date
    /// </summary>
    public DateTimeOffset Created { get; set; }
}