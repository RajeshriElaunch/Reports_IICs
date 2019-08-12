using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Core.Framework.Web
{
    public static class Extensions
    {
        public static int? SelectedValueInt(this DropDownList ddl)
        {
            return Helper._DropDownList.GetIntValue(ddl.SelectedValue);
        }
    }
}
