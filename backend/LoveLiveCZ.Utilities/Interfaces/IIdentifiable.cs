namespace LoveLiveCZ.Utilities.Interfaces;

public interface IIdentifiable : IIdentifiable<Guid>
{
}

public interface IIdentifiable<T>
{
    /// <summary>
    /// Gets or sets identifier value 
    /// </summary>
    public T Id { get; set; }

    public const string ColumnName = "Id";
}