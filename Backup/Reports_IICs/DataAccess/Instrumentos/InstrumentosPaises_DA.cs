using Reports_IICs.DataModels;
using System.Data.Entity;
using System.Linq;

namespace Reports_IICs.DataAccess.Instrumentos
{
    public class InstrumentosPaises_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static DbSet<Instrumentos_Paises> GetAll()
        {
            return dbContext.Instrumentos_Paises;
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumentos_Paises</param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Instrumentos_Paises NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtodelete.Id != null)
                {

                    var Ins_paises = dbContext.Instrumentos_Paises.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                    if (Ins_paises != null)
                    {
                        dbContext.Instrumentos_Paises.Remove(Ins_paises);
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

        public static bool Update(Instrumentos_Paises NVtoupdate)
        {
            bool result = true;

            if (NVtoupdate != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtoupdate.Id != null)
                {
                    var Ins_paises = dbContext.Instrumentos_Paises.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_paises != null)
                    {

                        Ins_paises.Codigo = NVtoupdate.Codigo;
                        Ins_paises.Descripcion = NVtoupdate.Descripcion;
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

        public static int Insert(Instrumentos_Paises NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changues to Db

                Instrumentos_Paises toInsert = new Instrumentos_Paises
                {
                    Codigo = NVtoinsert.Codigo,
                    Descripcion = NVtoinsert.Descripcion
                };
                dbContext.Instrumentos_Paises.Add(toInsert);
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
