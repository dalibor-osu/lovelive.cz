using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Constants;
using LoveLiveCZ.Utilities.Enums;
using Image = SixLabors.ImageSharp.Image;

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
            var result = await _attachmentDatabaseService.AddAsync(saveResult);
            attachments.Add(result);
        }

        return attachments;
    }
    
    public async Task<IReadOnlyCollection<Attachment>> GetPostAttachmentsAsync(Guid postId)
    {
        return await _attachmentDatabaseService.GetPostAttachmentsAsync(postId);
    }
    
    public async Task<int> DeleteAttachmentsForPostAsync(Guid postId)
    {
        var attachments = await _attachmentDatabaseService.GetPostAttachmentsAsync(postId);

        if (!attachments.Any())
        {
            return 0;
        }

        foreach (var attachment in attachments)
        {
            // TODO: Log failed deletions
            DeleteFileAsync(attachment);
            await _attachmentDatabaseService.DeleteAsync(attachment.Id);
        }

        return attachments.Count;
    }

    public bool DeleteAttachmentsForUser(Guid userId)
    {
        var path = Path.Combine(AttachmentConstants.FilesDirectoryPath, userId.ToString());

        if (!Directory.Exists(path))
        {
            return false;
        }
        
        Directory.Delete(path, true);
        return true;

    }

    public async Task<bool> ChangeUserAvatarAsync(Guid userId, IFormFile file)
    {
        var path = GetUserAvatarPath(userId);
        return await ChangeUserImageAsync(userId, file, path);
    }
    
    public async Task<bool> ChangeUserBannerAsync(Guid userId, IFormFile file)
    {
        var path = GetUserBannerPath(userId);
        return await ChangeUserImageAsync(userId, file, path);
    }

    private async Task<bool> ChangeUserImageAsync(Guid userId, IFormFile file, string path)
    {
        try
        {
            var image = await Image.LoadAsync(file.OpenReadStream());
            File.Delete(path);
            await image.SaveAsWebpAsync(path);
            return true;
        }
        catch
        {
            // TODO: Log error
            return false;
        }
    }

    private async Task<Attachment> SaveFileAsync(IFormFile file, Guid userId, Guid attachmentId)
    {
        var userDirectory = Path.Combine(AttachmentConstants.FilesDirectoryPath, userId.ToString());
            
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
    
    private bool DeleteFileAsync(Attachment attachment)
    {
        var filePath = GetAttachmentPath(attachment);

        if (!File.Exists(filePath))
        {
            return false;
        }
        
        File.Delete(filePath);
        return true;
    }
    
    private string GetUserAvatarPath(Guid userId)
    {
        return Path.Combine(GetUserAttachmentDirectory(userId), "avatar.webp");
    }
    
    private string GetUserBannerPath(Guid userId)
    {
        return Path.Combine(GetUserAttachmentDirectory(userId), "banner.webp");
    }
    
    private string GetUserAttachmentDirectory(Guid userId)
    {
        return Path.Combine(AttachmentConstants.FilesDirectoryPath, userId.ToString());
    }

    private string GetAttachmentPath(Attachment attachment)
    {
        return Path.Combine(GetUserAttachmentDirectory(attachment.UserId), $"{attachment.Id}_{attachment.Name}");
    }
}