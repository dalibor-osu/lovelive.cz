using LoveLiveCZ.Models.Database.Models;

namespace LoveLiveCZ.DatabaseServices.Interfaces;

public interface IAttachmentDatabaseService
{
    /// <summary>
    /// Asynchronously gets all attachments for a post
    /// </summary>
    /// <param name="postId">ID of a post to get the attachments for</param>
    /// <returns>List of <see cref="Attachment"/> as <see cref="IReadOnlyCollection{T}"/></returns>
    public Task<IReadOnlyCollection<Attachment>> GetPostAttachmentsAsync(Guid postId);
    
    /// <summary>
    /// Asynchronously adds a new attachment
    /// </summary>
    /// <param name="attachment">Attachment to add</param>
    /// <returns>Added <see cref="Attachment"/></returns>
    public Task<Attachment> AddAsync(Attachment attachment);

    /// <summary>
    /// Asynchronously deletes an attachment
    /// </summary>
    /// <param name="id">ID of an attachment to delete</param>
    /// <returns>True if attachment was successfully delete, false if not</returns>
    public Task<bool> DeleteAsync(Guid id);
}