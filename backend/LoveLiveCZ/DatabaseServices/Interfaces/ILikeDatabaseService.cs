namespace LoveLiveCZ.DatabaseServices.Interfaces;

public interface ILikeDatabaseService
{
    public Task<bool> ExistsAsync(Guid userId, Guid postId);
    public Task<bool> LikeAsync(Guid userId, Guid postId);
    public Task<bool> UnlikeAsync(Guid userId, Guid postId);
}