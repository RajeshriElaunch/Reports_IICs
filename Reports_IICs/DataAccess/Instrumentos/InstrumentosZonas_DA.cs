using Reports_IICs.DataModels;
using System.Data.Entity;
using System.Linq;

namespace Reports_IICs.DataAccess.Instrumentos
{
    public class InstrumentosZonas_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static DbSet<Instrumentos_Zonas> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Zonas;
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumentos_Zonas </param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Instrumentos_Zonas  NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtodelete.Id != null)
                {

                    var Ins_Zonas = dbContext.Instrumentos_Zonas.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                    if (Ins_Zonas != null)
                    {
                        dbContext.Instrumentos_Zonas.Remove(Ins_Zonas);
                    }
                    try
                    {
                        //save changues to Db
                        dbContext.SaveChanges();
                        GetAll();
                    }

                    catch (System.Exception)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }


        public static bool Update(Instrumentos_Zonas NVtoupdate)
        {
            bool result = true;

            if (NVtoupdate != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtoupdate.Id != null)
                {
                    var Ins_Zonas = dbContext.Instrumentos_Zonas.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_Zonas != null)
                    {

                        Ins_Zonas.Codigo = NVtoupdate.Codigo;
                        Ins_Zonas.Descripcion = NVtoupdate.Descripcion;
                    }

                    try
                    {
                        //save changues to Db
                        dbContext.SaveChanges();
                        GetAll();
                    }

                    catch (System.Exception)
                    {
                        result = false;
                    }
                }

            }


            return result;
        }

        public static int Insert(Instrumentos_Zonas NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changues to Db

                Instrumentos_Zonas toInsert = new Instrumentos_Zonas
                {
                    Codigo = NVtoinsert.Codigo,
                    Descripcion = NVtoinsert.Descripcion
                };
                dbContext.Instrumentos_Zonas.Add(toInsert);
                dbContext.SaveChanges();
                result = toInsert.Id;
                GetAll();
                //var PP = dbContext.GetValidationErrors();
            }

            catch (System.Exception)
            {

            }

            return result;
        }
    }
}
