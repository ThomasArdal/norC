using System;
using System.Collections.Generic;
using System.Text;

namespace norC
{
    public static class StringExtensions
    {
        public static CronExpression AsCron(this string str)
        {
            return Parser.Parse(str);
        }
    }
}
