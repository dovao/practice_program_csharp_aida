using NUnit.Framework;

namespace MarketingCampaign.Tests;

public class MarketingCampaignTests
{
    [Test]
    public void Would_I_Always_Pass()
    {
        var campaign = new MarketingCampaign();

        var isCrazySalesDay = campaign.IsCrazySalesDay();

        Assert.That(isCrazySalesDay, Is.True);
    }

    [Test]
    public void Fix_Me()
    {
        var campaign = new MarketingCampaign();

        var isActive = campaign.IsActive();

        Assert.That(isActive, Is.True);
    }
}