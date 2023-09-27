using System.Text.RegularExpressions;

namespace LoveLiveCZ.Utilities.Interfaces;

public interface INameable
{
    /// <summary>
    /// Gets or sets username name value
    /// </summary>
    public string Name { get; set; }

    public const string ColumnName = "Name";
}