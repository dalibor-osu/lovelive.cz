using System.Text.RegularExpressions;

namespace LoveLiveCZ.Utilities.Interfaces;

public interface IPasswordCarrier
{
    /// <summary>
    /// Gets or sets password value
    /// </summary>
    public string Password { get; set; }
    
    public static bool Validate(IPasswordCarrier value)
    {
        const string regex = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
        return Regex.IsMatch(value.Password, regex);
    }
}