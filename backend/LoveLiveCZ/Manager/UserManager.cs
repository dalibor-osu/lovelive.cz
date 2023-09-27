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
    
    public UserManager(IConfiguration configuration, IUserDatabaseService userDatabaseService)
    {
        _configuration = configuration;
        _userDatabaseService = userDatabaseService;
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

    public async Task<FullUserDto> UpdateAsync(Guid userId, FullUserDto userDto)
    {
        userDto.Id = userId;
        var user = userDto.ToModel();

        var result = await _userDatabaseService.UpdateAsync(user);
        return result.ToFullDto();
    }

    private string GenerateJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
        
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
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