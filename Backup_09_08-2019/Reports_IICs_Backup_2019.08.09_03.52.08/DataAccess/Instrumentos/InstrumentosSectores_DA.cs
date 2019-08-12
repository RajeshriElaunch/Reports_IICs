using Reports_IICs.DataModels;
using System.Data.Entity;
using System.Linq;

namespace Reports_IICs.DataAccess.Instrumentos
{
    public class InstrumentosSectores_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static DbSet<Instrumentos_Sectores> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Sectores;
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumentos_Sectores</param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Instrumentos_Sectores NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtodelete.Id != null)
                {

                    var Ins_sectores = dbContext.Instrumentos_Sectores.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                    if (Ins_sectores != null)
                    {
                        dbContext.Instrumentos_Sectores.Remove(Ins_sectores);
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

        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="NVtoupdate">Object Instrumentos_Sectores</param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Update(Instrumentos_Sectores NVtoupdate)
        {
            bool result = true;

            if (NVtoupdate != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtoupdate.Id != null)
                {
                    var Ins_sectores = dbContext.Instrumentos_Sectores.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_sectores != null)
                    {

                        Ins_sectores.Id = NVtoupdate.Id;
                        Ins_sectores.Descripcion = NVtoupdate.Descripcion;
                        Ins_sectores.IdCategoria = NVtoupdate.IdCategoria;
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

        /// <summary>
        /// Insert Method
        /// </summary>
        /// <param name="NVtoinsert">Object Instrumentos_Sectores</param>
        /// <returns> id element just inserted</returns>
        public static int Insert(Instrumentos_Sectores NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changues to Db

                Instrumentos_Sectores toInsert = new Instrumentos_Sectores
                {
                    Id = NVtoinsert.Id,
                    Descripcion = NVtoinsert.Descripcion,
                    IdCategoria = NVtoinsert.IdCategoria
                };
                dbContext.Instrumentos_Sectores.Add(toInsert);
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
