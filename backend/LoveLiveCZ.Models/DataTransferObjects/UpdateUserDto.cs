using Microsoft.AspNetCore.Http;

namespace LoveLiveCZ.Models.DataTransferObjects;

public class UpdateUserDto
{
    public string DisplayName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public IFormFile Avatar { get; set; }
    public IFormFile Banner { get; set; }
}