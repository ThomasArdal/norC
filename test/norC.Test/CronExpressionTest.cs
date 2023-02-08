using NUnit.Framework;
using System;

namespace norC.Test
{
    public class CronExpressionTest
    {
        [TestCase("Every minute", "* * * * *")]
        [TestCase("Every 10 minutes", "*/10 * * * *")]
        [TestCase("Every hour", "0 * * * *")]
        [TestCase("Every 2 hours", "0 */2 * * *")]
        [TestCase("Every day", "0 0 * * *")]
        [TestCase("Every 5 days", "0 0 */5 * *")]
        [TestCase("Every day at 5 PM", "0 17 * * *")]
        [TestCase("at 15:30", "30 15 * * *")]
        [TestCase("at 10:55 PM", "55 22 * * *")]
        [TestCase("every day at 3 PM", "0 15 * * *")]
        [TestCase("every day at 15", "0 15 * * *")]
        [TestCase("each minute", "* * * * *")]
        [TestCase("each 2 minutes", "*/2 * * * *")]
        [TestCase("each hour", "0 * * * *")]
        [TestCase("each day", "0 0 * * *")]
        [TestCase("each day each minute", "* * * * *")]
        [TestCase("each month", "0 0 1 * *")]
        [TestCase("each 5 months", "0 0 1 */5 *")]
        [TestCase("every minute", "* * * * *")]
        [TestCase("every 2 minutes", "*/2 * * * *")]
        [TestCase("every hour", "0 * * * *")]
        [TestCase("every day each minute", "* * * * *")]
        [TestCase("every month", "0 0 1 * *")]
        [TestCase("every 5 months", "0 0 1 */5 *")]
        [TestCase("once each hour", "0 * * * *")]
        [TestCase("once each 2 months", "0 0 1 */2 *")]
        [TestCase("once each 2 months at 14:00", "0 14 1 */2 *")]
        [TestCase("once each 5 hours", "0 */5 * * *")]
        [TestCase("once every hour", "0 * * * *")]
        [TestCase("once every 2 months", "0 0 1 */2 *")]
        [TestCase("once every 2 months at 14:00", "0 14 1 */2 *")]
        [TestCase("once every 5 hours", "0 */5 * * *")]
        [TestCase("once", "* * * * *")]
        public void CanParse(string input, string expected)
        {
            Assert.That(CronExpression.FromHumanString(input).ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void CanThrowExceptionOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => CronExpression.FromHumanString(null));
        }
    }
}