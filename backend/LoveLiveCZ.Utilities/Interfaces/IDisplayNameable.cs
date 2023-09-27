using System.Text.RegularExpressions;

namespace LoveLiveCZ.Utilities.Interfaces;

public interface IDisplayNameable
{
    /// <summary>
    /// Gets or sets display name value
    /// </summary>
    public string DisplayName { get; set; }

    public const string ColumnName = "DisplayName";
    
    public static bool Validate(IDisplayNameable value)
    {
        const string regex = @"^.{1,20}$";
        return Regex.IsMatch(value.DisplayName, regex);
    }
}