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
            HasCustomAvatar = source.HasCustomAvatar,
            Roles = source.Roles
        };
    }
    
    public static UserDto ToDto(this User source)
    {
        return new UserDto
        {
            Id = source.Id,
            DisplayName = source.DisplayName,
            Username = source.Username,
            HasCustomAvatar = source.HasCustomAvatar,
            HasCustomBanner = source.HasCustomBanner,
            Created = source.Created,
            Roles = source.Roles,
            Bio = source.Bio
        };
    }
    
    public static FullUserDto ToFullDto(this User source)
    {
        return new FullUserDto
        {
            Id = source.Id,
            DisplayName = source.DisplayName,
            Username = source.Username,
            HasCustomAvatar = source.HasCustomAvatar,
            HasCustomBanner = source.HasCustomBanner,
            Email = source.Email,
            Created = source.Created,
            Updated = source.Updated,
            Roles = source.Roles
        };
    }
}