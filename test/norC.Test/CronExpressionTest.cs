using NUnit.Framework;
using System;

namespace norC.Test
{
    public class CronExpressionTest
    {
        [TestCase("Every minute", "* * * * *", false)]
        [TestCase("Every 10 minutes", "*/10 * * * *", false)]
        [TestCase("Every hour", "0 * * * *", false)]
        [TestCase("Every 2 hours", "0 */2 * * *", false)]
        [TestCase("Every day", "0 0 * * *", false)]
        [TestCase("Every 5 days", "0 0 */5 * *", false)]
        [TestCase("Every day at 5 PM", "0 17 * * *", false)]
        [TestCase("at 15:30", "30 15 * * *", false)]
        [TestCase("at 10:55 PM", "55 22 * * *", false)]
        [TestCase("every day at 3 PM", "0 15 * * *", false)]
        [TestCase("every day at 15", "0 15 * * *", false)]
        [TestCase("each minute", "* * * * *", false)]
        [TestCase("each 2 minutes", "*/2 * * * *", false)]
        [TestCase("each hour", "0 * * * *", false)]
        [TestCase("each day", "0 0 * * *", false)]
        [TestCase("each day each minute", "* * * * *", false)]
        [TestCase("each month", "0 0 1 * *", false)]
        [TestCase("each 5 months", "0 0 1 */5 *", false)]
        [TestCase("every minute", "* * * * *", false)]
        [TestCase("every 2 minutes", "*/2 * * * *", false)]
        [TestCase("every hour", "0 * * * *", false)]
        [TestCase("every day each minute", "* * * * *", false)]
        [TestCase("every month", "0 0 1 * *", false)]
        [TestCase("every 5 months", "0 0 1 */5 *", false)]
        [TestCase("once each hour", "0 * * * *", false)]
        [TestCase("once each 2 months", "0 0 1 */2 *", false)]
        [TestCase("once each 2 months at 14:00", "0 14 1 */2 *", false)]
        [TestCase("once each 5 hours", "0 */5 * * *", false)]
        [TestCase("once every hour", "0 * * * *", false)]
        [TestCase("once every 2 months", "0 0 1 */2 *", false)]
        [TestCase("once every 2 months at 14:00", "0 14 1 */2 *", false)]
        [TestCase("once every 5 hours", "0 */5 * * *", false)]
        [TestCase("once", "* * * * *", false)]

        [TestCase("Every second", "* * * * * *", true)]
        [TestCase("Every minute", "0 * * * * *", true)]
        [TestCase("Every 10 minutes", "0 */10 * * * *", true)]
        [TestCase("Every hour", "0 0 * * * *", true)]
        [TestCase("Every 2 hours", "0 0 */2 * * *", true)]
        [TestCase("Every day", "0 0 0 * * *", true)]
        [TestCase("Every 5 days", "0 0 0 */5 * *", true)]
        [TestCase("Every day at 5 PM", "0 0 17 * * *", true)]
        [TestCase("at 15:30", "0 30 15 * * *", true)]
        [TestCase("at 10:55 PM", "0 55 22 * * *", true)]
        [TestCase("every day at 3 PM", "0 0 15 * * *", true)]
        [TestCase("every day at 15", "0 0 15 * * *", true)]
        [TestCase("each second", "* * * * * *", true)]
        [TestCase("each minute", "0 * * * * *", true)]
        [TestCase("each 2 minutes", "0 */2 * * * *", true)]
        [TestCase("each hour", "0 0 * * * *", true)]
        [TestCase("each day", "0 0 0 * * *", true)]
        [TestCase("each day each minute", "0 * * * * *", true)]
        [TestCase("each month", "0 0 0 1 * *", true)]
        [TestCase("each 5 months", "0 0 0 1 */5 *", true)]
        [TestCase("every minute", "0 * * * * *", true)]
        [TestCase("every 2 minutes", "0 */2 * * * *", true)]
        [TestCase("every hour", "0 0 * * * *", true)]
        [TestCase("every day each minute", "0 * * * * *", true)]
        [TestCase("every month", "0 0 0 1 * *", true)]
        [TestCase("every 5 months", "0 0 0 1 */5 *", true)]
        [TestCase("once each hour", "0 0 * * * *", true)]
        [TestCase("once each 2 months", "0 0 0 1 */2 *", true)]
        [TestCase("once each 2 months at 14:00", "0 0 14 1 */2 *", true)]
        [TestCase("once each 5 hours", "0 0 */5 * * *", true)]
        [TestCase("once every hour", "0 0 * * * *", true)]
        [TestCase("once every 2 months", "0 0 0 1 */2 *", true)]
        [TestCase("once every 2 months at 14:00", "0 0 14 1 */2 *", true)]
        [TestCase("once every 5 hours", "0 0 */5 * * *", true)]
        [TestCase("once", "* * * * * *", true)]
        public void CanParse(string input, string expected, bool includeSeconds)
        {
            var options = new CronOptions { IncludeSeconds = includeSeconds };
            Assert.That(CronExpression.FromHumanString(input, options).ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void CanThrowExceptionOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => CronExpression.FromHumanString(null));
        }
    }
}