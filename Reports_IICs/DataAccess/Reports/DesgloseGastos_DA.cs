using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.DataAccess.Reports
{
    public class DesgloseGastos_DA
    {
        public static Get_Temp_DesgloseGastos_Result Get_Temp_DesgloseGastos(string codigoIC, string isin)
        {
            var dbcontext = new Reports_IICSEntities();
            return dbcontext.Get_Temp_DesgloseGastos(codigoIC, isin).FirstOrDefault();
        }
    }
}
