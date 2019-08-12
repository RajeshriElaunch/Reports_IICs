using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;

namespace Reports_IICs.DataAccess
{
    public static class Errores_DA
    {
        public static void InsertError(Exception ex, string errorMsg, string codigoIC, DateTime? fechaInforme)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changes to Db

                var obj = new Errore();

                obj.CodigoError = ex.HResult;
                //obj.Error = ex.Message;
                //if(ex.InnerException != null)
                //{
                //    obj.Error += Environment.NewLine;
                //    obj.Error += ex.InnerException.Message;
                //}
                obj.Error = errorMsg;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    obj.Error += Environment.NewLine;
                    obj.Error += ex.InnerException.Message;
                }
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    obj.Error += Environment.NewLine;
                    obj.Error += ex.Message;
                }
                
                obj.CodigoIC = codigoIC;
                obj.FechaGeneracionInforme = fechaInforme;
                obj.FechaError = DateTime.Now;
                string equipo = Utils.GetEquipo();
                obj.Equipo = equipo;

                dbContext.Errores.Add(obj);
                dbContext.SaveChanges();

                //Enviamos email para notificar el error
                Utils.SendEmail("Reports IICs", errorMsg, "juliomanzano@aheadt.com", equipo, codigoIC, fechaInforme);
            }

            catch (System.Exception)
            {

            }
        }

        
    }
}
