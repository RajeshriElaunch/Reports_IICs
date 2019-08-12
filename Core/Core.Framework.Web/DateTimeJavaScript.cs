using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Framework.Web
{
    public static class DateTimeJavaScript
    {
        private static readonly long DatetimeMinTimeTicks =
           (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;

        public static double ToJavaScriptMilliseconds(this DateTime dt)
        {
            //return (long)((dt.AddDays(-1).ToUniversalTime().Ticks - DatetimeMinTimeTicks) / 10000);
            //return (long)((dt.ToUniversalTime().Ticks - DatetimeMinTimeTicks) / 10000);

            return (dt - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}
