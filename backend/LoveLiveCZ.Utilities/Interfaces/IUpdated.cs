namespace LoveLiveCZ.Utilities.Interfaces;

public interface IUpdated
{
    /// <summary>
    /// Gets or sets updated value
    /// </summary>
    public DateTimeOffset Updated { get; set; }
    
    public const string ColumnName = "Updated";
}