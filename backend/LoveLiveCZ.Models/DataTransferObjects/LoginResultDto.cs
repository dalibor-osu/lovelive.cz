using LoveLiveCZ.Utilities.Enums;

namespace LoveLiveCZ.Models.DataTransferObjects;

public class LoginResultDto
{
    public string Token { get; set; }
    public LoginResultType ResultType { get; set; }
    
    public FullUserDto User { get; set; }
}