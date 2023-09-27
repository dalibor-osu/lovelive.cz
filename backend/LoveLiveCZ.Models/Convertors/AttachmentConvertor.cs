using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Models.DataTransferObjects;

namespace LoveLiveCZ.Models.Convertors;

public static class AttachmentConvertor
{
    public static AttachmentDto ToDto(this Attachment source)
    {
        return new AttachmentDto
        {
            Id = source.Id,
            Name = source.Name,
            Type = source.Type,
            Created = source.Created
        };
    }
}