using NUnit.Framework;

namespace norC.Test
{
    public class StringExtensionsTest
    {
        [Test]
        public void CanGetCronExpressiomFromHumanString()
        {
            Assert.That("Every hour".AsCron().ToString(), Is.EqualTo("0 * * * *"));
        }

        [Test]
        public void CanGetCronExpressionStringFromHumanString()
        {
            Assert.That("Every hour".AsCronString(), Is.EqualTo("0 * * * *"));
        }
    }
}
