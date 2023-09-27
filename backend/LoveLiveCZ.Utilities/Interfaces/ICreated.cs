namespace LoveLiveCZ.Utilities.Interfaces;

public interface ICreated
{
    /// <summary>
    /// Gets or sets created value
    /// </summary>
    public DateTimeOffset Created { get; set; }
    
    public const string ColumnName = "Created";
}