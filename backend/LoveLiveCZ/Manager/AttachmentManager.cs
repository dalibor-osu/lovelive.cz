using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Enums;

namespace LoveLiveCZ.Manager;

public class AttachmentManager
{
    private readonly IAttachmentDatabaseService _attachmentDatabaseService;
    
    public AttachmentManager(IAttachmentDatabaseService attachmentDatabaseService)
    {
        _attachmentDatabaseService = attachmentDatabaseService;
    }
    
    public async Task<IEnumerable<Attachment>> AddPostAttachmentsAsync(Guid userId, Guid postId, IEnumerable<IFormFile> files)
    {
        var attachments = new List<Attachment>();

        foreach (var file in files)
        {
            var saveResult = await SaveFileAsync(file, userId, Guid.NewGuid());
            saveResult.PostId = postId;
            var result = await _attachmentDatabaseService.AddAttachmentAsync(saveResult);
            attachments.Add(result);
        }

        return attachments;
    }
    
    public async Task<IReadOnlyCollection<Attachment>> GetPostAttachmentsAsync(Guid postId)
    {
        return await _attachmentDatabaseService.GetPostAttachmentsAsync(postId);
    }

    private async Task<Attachment> SaveFileAsync(IFormFile file, Guid userId, Guid attachmentId)
    {
        const string filesDirectoryPath = "/files";
        var userDirectory = Path.Combine(filesDirectoryPath, userId.ToString());
            
        if (!Directory.Exists(userDirectory))
        {
            Directory.CreateDirectory(userDirectory);
        }
        
        var filePath = Path.Combine(userDirectory, $"{attachmentId}_{file.FileName}");
        await using Stream fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);
        
        return new Attachment
        {
            Id = attachmentId,
            Name = file.FileName,
            UserId = userId,
            Type = AttachmentType.Image
        };
    }
}