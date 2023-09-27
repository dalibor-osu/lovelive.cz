using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Models.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace LoveLiveCZ.Models.Convertors;

public static class UserConvertor
{
    public static BasicUserDto ToBasicDto(this User source)
    {
        return new BasicUserDto
        {
            Id = source.Id,
            DisplayName = source.DisplayName,
            ProfilePicture = source.ProfilePicture
        };
    }
    
    public static UserDto ToDto(this User source)
    {
        return new UserDto
        {
            Id = source.Id,
            DisplayName = source.DisplayName,
            Username = source.Username,
            ProfilePicture = source.ProfilePicture,
            Created = source.Created,
        };
    }
    
    public static FullUserDto ToFullDto(this User source)
    {
        return new FullUserDto
        {
            Id = source.Id,
            DisplayName = source.DisplayName,
            Username = source.Username,
            ProfilePicture = source.ProfilePicture,
            Email = source.Email,
            Created = source.Created,
            Updated = source.Updated
        };
    }

    public static User ToModel(this FullUserDto source)
    {
        return new User
        {
            Id = source.Id,
            Email = source.Email,
            DisplayName = source.DisplayName,
            ProfilePicture = source.ProfilePicture,
            Updated = source.Updated,
            Created = source.Created,
            Username = source.Username
        };
    }
}