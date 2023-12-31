using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Models.Convertors;
using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Models.DataTransferObjects;
using LoveLiveCZ.Utilities.Base;
using LoveLiveCZ.Utilities.Enums;
using Microsoft.IdentityModel.Tokens;

namespace LoveLiveCZ.Manager;

public class UserManager
{
    private readonly IConfiguration _configuration;
    private readonly IUserDatabaseService _userDatabaseService;
    private readonly AttachmentManager _attachmentManager;
    
    public UserManager(
        IConfiguration configuration,
        IUserDatabaseService userDatabaseService,
        AttachmentManager attachmentManager)
    {
        _configuration = configuration;
        _userDatabaseService = userDatabaseService;
        _attachmentManager = attachmentManager;
    }
    
    public async Task<FullUserDto> GetFullAsync(Guid userId)
    {
        var result = await _userDatabaseService.GetUserAsync(userId);
        return result?.ToFullDto();
    }

    public async Task<UserDto> GetAsync(Guid userId)
    {
        var result = await _userDatabaseService.GetUserAsync(userId);
        return result?.ToDto();
    }
    
    public async Task<LoginResultDto> RegisterAsync(NewUserDto user)
    {
        var exists = await _userDatabaseService.UsernameOrEmailExistsAsync(user.Username, user.Email);

        if (exists)
        {
            return null;
        }
        
        var newUser = new NewUser
        {
            DisplayName = user.DisplayName.IsNullOrEmpty() ? user.Username : user.DisplayName,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = PasswordHelper.GetPasswordHash(user.Password)
        };
        
        var createdUser = await _userDatabaseService.CreateUserAsync(newUser);
        
        return new LoginResultDto
        {
            Token = GenerateJwt(createdUser),
            ResultType = LoginResultType.Success,
            User = createdUser.ToFullDto()
        };
    }

    public async Task<LoginResultDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userDatabaseService.GetUserAsync(loginDto.Username);

        if (user == null)
        {
            return new LoginResultDto
            {
                ResultType = LoginResultType.UserNotFound
            };
        }

        var validPassword = PasswordHelper.ValidatePassword(loginDto.Password, user.PasswordHash);

        if (!validPassword)
        {
            return new LoginResultDto
            {
                ResultType = LoginResultType.InvalidPassword
            };
        }
        
        return new LoginResultDto
        {
            Token = GenerateJwt(user),
            ResultType = LoginResultType.Success,
            User = user.ToFullDto()
        };
    }

    public async Task<FullUserDto> UpdateAsync(Guid userId, UpdateUserDto userDto)
    {
        var user = await _userDatabaseService.GetUserAsync(userId);

        if (!string.IsNullOrEmpty(userDto.DisplayName))
        {
            user.DisplayName = userDto.DisplayName;
        }
        
        if (!string.IsNullOrEmpty(userDto.Bio))
        {
            user.Bio = userDto.Bio;
        }
        
        if (userDto.Avatar != null)
        {
            var success = await _attachmentManager.ChangeUserAvatarAsync(userId, userDto.Avatar);

            if (!success)
            {
                return null;
            }
            
            user.HasCustomAvatar = true;
        }
        
        if (userDto.Banner != null)
        {
            var success = await _attachmentManager.ChangeUserBannerAsync(userId, userDto.Avatar);

            if (!success)
            {
                return null;
            }
            
            user.HasCustomBanner = true;
        }
        
        var result = await _userDatabaseService.UpdateAsync(user);
        return result.ToFullDto();
    }
    
    public async Task<Guid> BanAsync(Guid userId)
    {
        // TODO: Log the ban
#pragma warning disable CS4014 // We want to run this in the background
        Task.Run(() => _attachmentManager.DeleteAttachmentsForUser(userId));
#pragma warning restore CS4014
        return await _userDatabaseService.DeleteAsync(userId);
    }

    public async Task<bool> ExistsAsync(Guid userId)
    {
        return await _userDatabaseService.ExistsAsync(userId);
    }

    private string GenerateJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
        
        var claims = new List<Claim>() {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Username),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        if (user.Roles?.Any() ?? false)
        {
            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.ToString())));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(120),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Issuer"],
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}