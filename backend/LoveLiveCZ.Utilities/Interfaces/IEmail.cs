using System.Text.RegularExpressions;

namespace LoveLiveCZ.Utilities.Interfaces;

public interface IEmail
{
    /// <summary>
    /// Gets or sets email value
    /// </summary>
    public string Email { get; set; }
    
    public const string ColumnName = "Email";
    
    public static bool Validate(IEmail value)
    {
        const string regex = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
        return Regex.IsMatch(value.Email, regex);
    }
}