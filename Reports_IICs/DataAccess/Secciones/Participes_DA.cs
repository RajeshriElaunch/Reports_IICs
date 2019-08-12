using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class Participes_DA
    {
        //public static void Insert_Temp(Plantilla plantilla, List<Temp_Participes> listaTmp)
        //{
        //    using (var dbContext = new Reports_IICSEntities())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_Participes.RemoveRange(dbContext.Temp_Participes.Where(p => p.CodigoIC == plantilla.CodigoIc));
        //            dbContext.Temp_Participes.AddRange(listaTmp);

        //            dbContext.SaveChanges();        
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        public static IQueryable<string> GetTempIsins(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_Participes.Where(r => r.CodigoIC == codigoIC).Select(s => s.Isin).Distinct();
        }

        public static T_Participes Get_Temp_ParticipesById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            T_Participes RentaCartera_temp = new T_Participes();

           
            foreach (var item in dbContext.Temp_Participes.Where(r => r.Id == id))
            {
                RentaCartera_temp.Id = item.Id;
                RentaCartera_temp.CodigoIC = item.CodigoIC;
                RentaCartera_temp.Isin = item.Isin;
                RentaCartera_temp.NombreApellidos = item.NombreApellidos;
                RentaCartera_temp.NumeroParticipaciones = item.NumeroParticipaciones;
                RentaCartera_temp.PorcentajeParticipacion = item.PorcentajeParticipacion;

            }

            return RentaCartera_temp;
        }
    }
}
