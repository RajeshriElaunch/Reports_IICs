using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class GraficoCompCartTipoProd_DA
    {
        public static void Insert_Temp_GraficoCompCarteraTipoProducto(string codigoIC, List<Temp_GraficoCompCarteraTipoProducto> lista)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    //Si hubiera datos para este CodigoIC los borramos antes de insertar
                    dbContext.Temp_GraficoCompCarteraTipoProducto.RemoveRange(dbContext.Temp_GraficoCompCarteraTipoProducto.Where(p => p.CodigoIC == codigoIC));

                    dbContext.Temp_GraficoCompCarteraTipoProducto.AddRange(lista);
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();

                    throw ex;
                }
            }
        }
    }
}
