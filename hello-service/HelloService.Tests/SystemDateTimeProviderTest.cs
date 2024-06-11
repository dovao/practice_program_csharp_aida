using Hello.Infrastructure;
using NUnit.Framework;

namespace Hello.Tests;

[TestFixture]
[TestOf(typeof(SystemDateTimeProvider))]
public class SystemDateTimeProviderTest
{

    [Test]
    public void get_current_datetime()
    {
        var systemDateTimeProvider = new SystemDateTimeProvider();

        var currentDate = systemDateTimeProvider.GetDateTime();

        Assert.That(currentDate, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(30)));
    }
}