using System;
using System.Linq;

namespace norC
{
    internal class Parser
    {
        const string every = "every";
        const string once = "once";
        const string at = "at";
        const string each = "each";
        private static string[] wellKnownTerms = new[] { every, once, at, each };

        internal static CronExpression Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(nameof(input));

            var cron = new CronExpression();

            var terms = input.ToLower().Split(' ');

            for (var i = 0; i < terms.Length; i++)
            {
                var term = terms[i];
                switch (term)
                {
                    case every:
                    case each:
                        i = Each(terms, i, cron);
                        break;
                    case once:
                        break;
                    case at:
                        i = At(terms, i, cron);
                        break;
                }
            }

            return cron;
        }

        private static int At(string[] terms, int counter, CronExpression cron)
        {
            var nextterm = NextTerm(terms, counter);
            if (nextterm == null) return counter;
            counter++;

            if (nextterm.Contains(":"))
            {
                var splitted = nextterm.Split(':');
                if (splitted.Length != 2) return counter;
                if (!int.TryParse(splitted[0], out int phour) || !int.TryParse(splitted[1], out int pminute)) return counter;

                nextterm = NextTerm(terms, counter);
                if (nextterm == null || wellKnownTerms.Contains(nextterm) || nextterm == "am")
                {
                    cron.Minute = pminute.ToString();
                    cron.Hour = phour.ToString();
                    counter++;
                }
                else if (nextterm == "pm")
                {
                    cron.Minute = pminute.ToString();
                    cron.Hour = (12 + phour).ToString();
                    counter++;
                }
            }
            else if (int.TryParse(nextterm, out int parsed))
            {
                nextterm = NextTerm(terms, counter);

                if (nextterm == null || wellKnownTerms.Contains(nextterm) || nextterm == "am")
                {
                    cron.Minute = "0";
                    cron.Hour = parsed.ToString();
                }
                else if (nextterm == "pm")
                {
                    cron.Minute = "0";
                    cron.Hour = (12 + parsed).ToString();
                }
            }

            return counter;
        }

        private static int Each(string[] terms, int counter, CronExpression cron)
        {
            var nextterm = NextTerm(terms, counter);
            if (nextterm == null) return counter;
            counter++;

            if (int.TryParse(nextterm, out int count))
            {
                nextterm = NextTerm(terms, counter);
                if (nextterm == null) return counter;
                counter++;

                switch (nextterm)
                {
                    case "minute":
                    case "minutes":
                        cron.Minute = $"*/{count}";
                        break;
                    case "hour":
                    case "hours":
                        cron.Minute = "0";
                        cron.Hour = $"*/{count}";
                        break;
                    case "day":
                    case "days":
                        cron.Minute = "0";
                        cron.Hour = "0";
                        cron.DayOfMonth = $"*/{count}";
                        break;
                    case "month":
                    case "months":
                        cron.Minute = "0";
                        cron.Hour = "0";
                        cron.DayOfMonth = "1";
                        cron.Month = $"*/{count}";
                        break;
                }
            }
            else
            {
                switch (nextterm)
                {
                    case "minute":
                        cron.Minute = "*";
                        cron.Hour = "*";
                        break;
                    case "hour":
                        cron.Minute = "0";
                        cron.Hour = "*";
                        break;
                    case "day":
                        cron.Minute = "0";
                        cron.Hour = "0";
                        cron.DayOfMonth = "*";
                        break;
                    case "month":
                        cron.Minute = "0";
                        cron.Hour = "0";
                        cron.DayOfMonth = "1";
                        break;
                }
            }

            return counter;
        }

        private static string NextTerm(string[] tokens, int i)
        {
            if (tokens.Length > i + 1)
            {
                return tokens[i + 1];
            }

            return null;
        }
    }
}
