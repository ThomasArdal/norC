using System.Runtime.Serialization;
using System.Text;

namespace norC
{
    public class CronExpression
    {
        private readonly CronOptions options;

        public string Second { get; internal set; } = "*";

        public string Minute { get; internal set; } = "*";

        public string Hour { get; internal set; } = "*";

        public string DayOfMonth { get; internal set; } = "*";

        public string Month { get; internal set; } = "*";

        public string DayOfWeek { get; internal set; } = "*";

        public CronExpression(CronOptions options)
        {
            this.options = options;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (options.IncludeSeconds)
            {
                sb.Append(Second).Append(" ");
            }

            sb.Append($"{Minute} {Hour} {DayOfMonth} {Month} {DayOfWeek}");
            return sb.ToString();
        }

        public static CronExpression FromHumanString(string str, CronOptions options = null)
        {
            return Parser.Parse(str, options);
        }
    }
}
