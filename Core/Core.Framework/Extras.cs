using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Framework
{
    public static class Extras
    {
        public static bool ValidarCuit(string data, out string result)
        {
            data = data.Replace("-", "");
            data = data.Replace(".", "");

            result = data;

            if (data.Length < 10 || data.Length > 11)
                result = string.Empty;
            else if (!Common.IsLong(data))
                result = string.Empty;

            return (result == data);

        }

        public static DateTime RemoveTime(DateTime date)
        {
            string strDate = date.ToShortDateString();
            return Common.ToDateTime(strDate);
        }
    }
}
