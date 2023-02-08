using NUnit.Framework;
using System;

namespace norC.Test
{
    public class StringExtensionsTest
    {
        [Test]
        public void CanGetCronFromString()
        {
            Assert.That("Every hour".AsCron().ToString(), Is.EqualTo("0 * * * *"));
        }
    }
}
