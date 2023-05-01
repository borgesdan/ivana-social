using System;

namespace Ivana.Core
{
    public static class DateTimeExtensions
    {
        public static int? GetAge(this DateTime? dateTime)
        {
            if (dateTime == null)
                return null;

            var now = DateTime.Now;
            var diff = now - dateTime;

            return (int)(diff?.TotalDays / 365);
        }
    }
}
