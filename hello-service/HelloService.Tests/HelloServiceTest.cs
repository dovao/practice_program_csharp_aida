using NUnit.Framework;

namespace Hello.Tests
{
    public class HelloServiceTest
    {
        [Test]
        public void Canary_Test()
        {
            Assert.That(true, Is.True);
        }
    }
}