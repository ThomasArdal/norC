namespace norC
{
    public static class StringExtensions
    {
        public static CronExpression AsCron(this string str, CronOptions options = null)
        {
            return CronExpression.FromHumanString(str, options);
        }

        public static string AsCronString(this string str, CronOptions options = null)
        {
            return CronExpression.FromHumanString(str, options).ToString();
        }
    }
}
