using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Security.Authentication;
using LoveLiveCZ.Utilities.Enums;
using Microsoft.AspNetCore.Identity;

namespace LoveLiveCZ.Utilities.Extensions;

public static class ClaimsPrincipalExtensions
{
    private const string SubjectClaimTypeSpecificationUrl = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
    
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var subject = FindClaim(claimsPrincipal, JwtRegisteredClaimNames.Sub, SubjectClaimTypeSpecificationUrl)?.Value;
        return Guid.Parse(subject!);
    }
    
    public static Guid TryGetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var subject = FindClaim(claimsPrincipal, JwtRegisteredClaimNames.Sub, SubjectClaimTypeSpecificationUrl)?.Value;
        return subject == null ? Guid.Empty : Guid.Parse(subject!);
    }

    public static UserRoleType[] GetUserRoles(this ClaimsPrincipal claimsPrincipal)
    {
        var subject = FindClaimArray(claimsPrincipal, ClaimTypes.Role)?.Select(x => x.Value).ToArray();

        if (!subject?.Any() ?? true)
        {
            return Array.Empty<UserRoleType>();
        }
        
        return subject.Select(Enum.Parse<UserRoleType>)?.ToArray() ?? Array.Empty<UserRoleType>();
    }

    public static bool IsRole(this ClaimsPrincipal claimsPrincipal, UserRoleType role)
    {
        var roles = claimsPrincipal.GetUserRoles();
        return roles.Contains(role);
    }

    public static bool IsOneOfRoles(ClaimsPrincipal claimsPrincipal, params UserRoleType[] roles)
    {
        var userRoles = claimsPrincipal.GetUserRoles();
        return userRoles.Intersect(roles).Any();
    }
    
    private static Claim? FindClaim(ClaimsPrincipal principal, params string[] types)
    {
        var identities = principal.Identities.ToArray();
        
        if (!identities.Any())
        {
            return null;
        }

        return identities[0].Claims.FirstOrDefault(
            c => Array.Exists(types, t => c.Type.Equals(t)));
    }
    
    private static Claim[] FindClaimArray(ClaimsPrincipal principal, params string[] types)
    {
        var identities = principal.Identities.ToArray();
        
        if (!identities.Any())
        {
            return Array.Empty<Claim>();
        }

        return identities[0].Claims.Where(
            c => Array.Exists(types, t => c.Type.Equals(t)))?
            .ToArray() ?? Array.Empty<Claim>();
    }
}