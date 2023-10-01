using LoveLiveCZ.Manager;
using LoveLiveCZ.Models.DataTransferObjects;
using LoveLiveCZ.Utilities.Enums;
using LoveLiveCZ.Utilities.Extensions;
using LoveLiveCZ.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoveLiveCZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;

        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }
        
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResultDto>> Register(
            [FromServices] Validator validator,
            [FromBody] NewUserDto user)
        {
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            
            var result = await _userManager.RegisterAsync(user);
            
            if (result == null)
            {
                return Conflict();
            }
            
            return Ok(result);
        }
        
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResultDto>> Login([FromBody] LoginDto loginDto)
        {
            var result = await _userManager.LoginAsync(loginDto);

            if (result.ResultType == LoginResultType.InvalidPassword)
            {
                return Unauthorized();
            }
            
            if (result.ResultType == LoginResultType.UserNotFound)
            {
                return NotFound();
            }
            
            return Ok(result);
        }
        
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<FullUserDto>> GetCurrentUserAsync()
        {
            var userId = User.GetUserId();
            
            if (userId == Guid.Empty)
            {
                return Forbid();
            }

            var result = await _userManager.GetFullAsync(userId);
            
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserDto>> GetAsync([FromRoute] Guid id)
        {
            var result = await _userManager.GetAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserDto>> UpdateAsync([FromBody] FullUserDto userDto)
        {
            var userId = User.GetUserId();
            var result = await _userManager.UpdateAsync(userId, userDto);
            return Ok(result);
        }
        
        [HttpDelete("ban/{userId:guid}")]
        [Authorize(Policy = "Moderator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> BanAsync([FromRoute] Guid userId)
        {
            var exists = await _userManager.ExistsAsync(userId);

            if (!exists)
            {
                return NotFound();
            }
            
            var result = await _userManager.BanAsync(userId);
            return result == Guid.Empty ? NotFound() : Ok();
        }
    }
}