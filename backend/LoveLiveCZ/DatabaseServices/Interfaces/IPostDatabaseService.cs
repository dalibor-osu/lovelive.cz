using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Models;

namespace LoveLiveCZ.DatabaseServices.Interfaces;

public interface IPostDatabaseService
{
    public Task<Post> GetPost(Guid postId);
    public Task<IReadOnlyCollection<Post>> ListPostsAsync(ListOptions options);
    public Task<Post> CreatePostAsync(Post post);
    public Task<bool> ExistsAsync(Guid postId);
    public Task<Guid> DeleteAsync(Guid postId);
}