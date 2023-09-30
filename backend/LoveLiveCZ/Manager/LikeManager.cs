using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.DataTransferObjects;

namespace LoveLiveCZ.Manager;

public class LikeManager
{
    private readonly ILikeDatabaseService _likeDatabaseService;
    
    public LikeManager(ILikeDatabaseService likeDatabaseService)
    {
        _likeDatabaseService = likeDatabaseService;
    }
    
    public async Task<LikeResultDto> LikeAsync(Guid userId, Guid postId)
    {
        var liked = await _likeDatabaseService.ExistsAsync(userId, postId);
        LikeResultDto result;
        
        if (liked)
        {
            var unlikeResult = await _likeDatabaseService.UnlikeAsync(userId, postId);

            if (!unlikeResult)
            {
                return null;
            }
            
            result = new LikeResultDto
            {
                PostId = postId,
                Liked = false
            };
        }
        else
        {
            var likeResult = await _likeDatabaseService.LikeAsync(userId, postId);
            
            if (!likeResult)
            {
                return null;
            }
            
            result = new LikeResultDto
            {
                PostId = postId,
                Liked = true
            };
        }
        
        return result;
    }
}