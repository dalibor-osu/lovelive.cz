using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Models.DataTransferObjects;

namespace LoveLiveCZ.Models.Convertors;

public static class PostConvertor
{
    public static PostDto ToDto(this Post source)
    {
        return new PostDto
        {
            Id = source.Id,
            Text = source.Text,
            Attachments = source.Attachments?.Select(x => x.ToDto()).ToList() ?? new List<AttachmentDto>(),
            Created = source.Created,
            Updated = source.Updated,
            User = source.User?.ToBasicDto()
        };
    }
    
    public static Post ToModel(this PostDto source, Guid userId)
    {
        return new Post
        {
            Id = source.Id,
            Text = source.Text,
            Created = source.Created,
            Updated = source.Updated,
            UserId = userId
        };
    }
    
    public static Post ToModel(this NewPostDto source, Guid userId)
    {
        return new Post
        {
            Text = source.Text,
            UserId = userId
        };
    }
}