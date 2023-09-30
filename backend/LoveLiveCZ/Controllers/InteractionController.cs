using LoveLiveCZ.Manager;
using LoveLiveCZ.Models.DataTransferObjects;
using LoveLiveCZ.Utilities.Extensions;
using LoveLiveCZ.Utilities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoveLiveCZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InteractionController : ControllerBase
    {
        private readonly LikeManager _likeManager;
        private readonly PostManager _postManager;

        public InteractionController(LikeManager likeManager, PostManager postManager)
        {
            _likeManager = likeManager;
            _postManager = postManager;
        }

        /// <summary>
        /// Asynchronously likes or unlikes a post
        /// </summary>
        /// <param name="id">ID of a post to like or unlike</param>
        /// <returns><see cref="LikeResultDto"/> with like information</returns>
        [HttpPost("like/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LikeResultDto>> Like([FromRoute] Guid id)
        {
            var userId = User.GetUserId();
            
            var postExists = await _postManager.ExistsAsync(id);
            
            if (!postExists)
            {
                return BadRequest();
            }
            
            var result = await _likeManager.LikeAsync(userId, id);

            if (result == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
    }
}