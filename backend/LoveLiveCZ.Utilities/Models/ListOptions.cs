namespace LoveLiveCZ.Utilities.Models;

public class ListOptions
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public Guid? LastItemId { get; set; }
    public DateTimeOffset? LastItemCreatedAt { get; set; }
    public Guid? ParentId { get; set; }
}