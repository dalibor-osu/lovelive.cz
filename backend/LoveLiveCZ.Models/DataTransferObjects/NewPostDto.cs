using Microsoft.AspNetCore.Http;

namespace LoveLiveCZ.Models.DataTransferObjects;

public class NewPostDto
{
    /// <summary>
    /// Gets or sets text value
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Gets or sets file list
    /// </summary>
    public IEnumerable<IFormFile> File { get; set; }
}