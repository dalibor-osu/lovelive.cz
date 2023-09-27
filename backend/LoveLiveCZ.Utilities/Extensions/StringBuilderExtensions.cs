using System.Text;
using LoveLiveCZ.Utilities.Interfaces;
using LoveLiveCZ.Utilities.Models;
using static LoveLiveCZ.Utilities.Constants.ListConstants;

namespace LoveLiveCZ.Utilities.Extensions;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendListOptions(this StringBuilder builder, ListOptions options, string prefix)
    {
        if (options.Offset > 0)
        {
            builder.AppendLine($"OFFSET {options.Offset}");
        }

        if (options.Limit is <= 0 or > MaxListLimit)
        {
            options.Limit = MaxListLimit;
        }
        
        builder.AppendLine($@"ORDER BY {prefix}.""{ICreated.ColumnName}"" DESC");
        
        builder.AppendLine($"LIMIT {options.Limit}");
        
        return builder;
    }
}