using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Security.Authentication;
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
}