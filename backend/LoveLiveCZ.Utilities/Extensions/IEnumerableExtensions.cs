using System.Collections.ObjectModel;

namespace LoveLiveCZ.Utilities.Extensions;

public static class IEnumerableExtensions
{
    public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> enumerable)
    {
        return new ReadOnlyCollection<T>(enumerable.ToList());
    }
}