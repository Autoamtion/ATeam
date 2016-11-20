using System;
using System.Runtime.CompilerServices;

namespace ATeam.Helpers
{
    public static class DatesFormatHelper
    {
        private static readonly string[] monthsNames =
        {
            "stycznia",
            "lutego",
            "marca",
            "kwietnia",
            "maja",
            "czerwca",
            "lipca",
            "sierpnia",
            "września",
            "października",
            "listopada",
            "grudnia"
        };

        public static string LandingPageDateFormat(DateTime date)
        {
            return string.Format(
                "{0} {1} {2}",
                date.Day,
                monthsNames[date.Month - 1],
                date.Year);
        }
    }
}
