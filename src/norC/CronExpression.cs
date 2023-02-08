namespace norC
{
    public class CronExpression
    {
        public string Minute { get; set; } = "*";

        public string Hour { get; set; } = "*";

        public string DayOfMonth { get; set; } = "*";

        public string Month { get; set; } = "*";

        public string DayOfWeek { get; set; } = "*";

        public override string ToString()
        {
            return $"{Minute} {Hour} {DayOfMonth} {Month} {DayOfWeek}";
        }
    }
}
