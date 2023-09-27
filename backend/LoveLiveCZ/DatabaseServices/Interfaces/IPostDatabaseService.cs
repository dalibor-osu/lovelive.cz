using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Models;

namespace LoveLiveCZ.DatabaseServices.Interfaces;

public interface IPostDatabaseService
{
    public Task<Post> GetPost(Guid userId, Guid postId);
    public Task<IReadOnlyCollection<Post>> ListPostsAsync(ListOptions options);
    public Task<Post> CreatePostAsync(Post post);
}