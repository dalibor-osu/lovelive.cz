namespace LoveLiveCZ.Utilities.Interfaces;

public interface IDeletable
{
    /// <summary>
    /// Get or sets deleted value
    /// </summary>
    public bool Deleted { get; set; }
    
    public const string ColumnName = "Deleted";
}