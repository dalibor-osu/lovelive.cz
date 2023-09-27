using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.Convertors;
using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Models.DataTransferObjects;
using LoveLiveCZ.Utilities.Models;

namespace LoveLiveCZ.Manager;

public class PostManager
{
    private readonly IPostDatabaseService _postDatabaseService;
    private readonly AttachmentManager _attachmentManager;
    private readonly IUserDatabaseService _userDatabaseService;
    
    public PostManager(IPostDatabaseService postDatabaseService, AttachmentManager attachmentManager, IUserDatabaseService userDatabaseService)
    {
        _postDatabaseService = postDatabaseService;
        _attachmentManager = attachmentManager;
        _userDatabaseService = userDatabaseService;
    }
    
    public async Task<PostDto> GetPost(Guid userId, Guid postId)
    {
        var post = await _postDatabaseService.GetPost(userId, postId);
        var attachments = await _attachmentManager.GetPostAttachmentsAsync(postId);
        
        if (attachments.Any())
        {
            post.Attachments = attachments.ToList();
        }
        
        return post.ToDto();
    }
    
    public async Task<IEnumerable<PostDto>> ListPostsAsync(ListOptions options)
    {
        var posts = await _postDatabaseService.ListPostsAsync(options);

        foreach (var post in posts)
        {
            var attachments = await _attachmentManager.GetPostAttachmentsAsync(post.Id);
        
            if (attachments.Any())
            {
                post.Attachments = attachments.ToList();
            }
        }
        
        return posts.Select(x => x.ToDto());
    }
    
    public async Task<PostDto> PostNewPost(Guid userId, NewPostDto postDto)
    {
        postDto.File = postDto.File?.ToList() ?? new List<IFormFile>();
        var post = await _postDatabaseService.CreatePostAsync(postDto.ToModel(userId));
        var user = await _userDatabaseService.GetUserAsync(userId);
        
        if (postDto.File.Any())
        {
            var attachments = await _attachmentManager.AddPostAttachmentsAsync(userId, post.Id, postDto.File);
            post.Attachments = attachments.ToList();
        }
        
        post.User = user;
        return post.ToDto();
    }
}