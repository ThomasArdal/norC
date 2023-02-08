namespace norC
{
    public static class StringExtensions
    {
        public static CronExpression AsCron(this string str)
        {
            return CronExpression.FromHumanString(str);
        }

        public static string AsCronString(this string str)
        {
            return CronExpression.FromHumanString(str).ToString();
        }
    }
}
