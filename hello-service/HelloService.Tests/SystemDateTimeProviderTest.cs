using NUnit.Framework;

namespace Hello.Tests;

[TestFixture]
[TestOf(typeof(SystemSystemDateTimeProvider))]
public class SystemDateTimeProviderTest
{

    [Test]
    public void get_current_datetime()
    {
        var systemDateTimeProvider = new SystemSystemDateTimeProvider();

        var currentDate = systemDateTimeProvider.GetDateTime();

        Assert.That(currentDate, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(30)));
    }
}