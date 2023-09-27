namespace LoveLiveCZ.Utilities.Interfaces;

public interface IUserIdentifiable
{
    /// <summary>
    /// Gets or sets identifier of a user
    /// </summary>
    public Guid UserId { get; set; }
    
    public const string ColumnName = "UserId";
}