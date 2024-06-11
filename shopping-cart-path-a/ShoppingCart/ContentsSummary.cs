using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart;

public record ContentsSummary(List<Line> lines)
{
    public virtual bool Equals(ContentsSummary other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return lines.SequenceEqual(other.lines);
    }

    public override int GetHashCode()
    {
        return (lines != null ? lines.GetHashCode() : 0);
    }

    public override string ToString()
    {
        return $"{nameof(lines)}: {String.Join(',',lines)}";
    }
}