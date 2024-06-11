namespace ShoppingCart.Tests;

public class ContentsSummaryBuilder
{
    private List<Line> _lines;

    public ContentsSummaryBuilder()
    {
        _lines = new List<Line>();
    }

    public ContentsSummaryBuilder With(LineBuilder lineBuilder)
    {
        _lines.Add(lineBuilder.Build());
        return this;
    }

    public ContentsSummary Build()
    {
        return new ContentsSummary(_lines);
    }

    public static ContentsSummaryBuilder EmptySummary()
    {
        return new ContentsSummaryBuilder();
    }

    public static ContentsSummaryBuilder Summary()
    {
        return EmptySummary();
    }
}