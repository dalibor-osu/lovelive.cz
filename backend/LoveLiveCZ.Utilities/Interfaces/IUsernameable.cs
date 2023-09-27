using System.Text.RegularExpressions;

namespace LoveLiveCZ.Utilities.Interfaces;

public interface IUsernameable
{
    /// <summary>
    /// Gets or sets username name value
    /// </summary>
    public string Username { get; set; }

    public const string ColumnName = "Username";
    
    public static bool Validate(IUsernameable value)
    {
        const string regex = @"^[a-z0-9_]{3,16}$";
        return Regex.IsMatch(value.Username, regex);
    }
}