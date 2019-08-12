using Reports_IICs.DataModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace Reports_IICs.DataAccess.Instrumentos
{
    public class InstrumentosTipos_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static DbSet<Instrumentos_Tipos> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Tipos;
        }

        public static IQueryable<Instrumentos_Tipos> GetTiposEspecialesRV()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Tipos.Where(w=> w.Codigo.Equals("CCP") || w.Codigo.Equals("PER") || w.Codigo.Equals("PAT"));
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumentos_Tipos</param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Instrumentos_Tipos NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtodelete.Id != null)
                {

                    var Ins_tipos = dbContext.Instrumentos_Tipos.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                    if (Ins_tipos != null)
                    {
                        dbContext.Instrumentos_Tipos.Remove(Ins_tipos);
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

        public static bool Update(Instrumentos_Tipos NVtoupdate)
        {
            bool result = true;

            if (NVtoupdate != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtoupdate.Id != null)
                {
                    var Ins_tipos = dbContext.Instrumentos_Tipos.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_tipos != null)
                    {

                        Ins_tipos.Codigo = NVtoupdate.Codigo;
                        Ins_tipos.Descripcion = NVtoupdate.Descripcion;
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

        public static int Insert(Instrumentos_Tipos NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changues to Db

                Instrumentos_Tipos toInsert = new Instrumentos_Tipos
                {
                    Codigo = NVtoinsert.Codigo,
                    Descripcion = NVtoinsert.Descripcion
                };
                dbContext.Instrumentos_Tipos.Add(toInsert);
                dbContext.SaveChanges();
                result = Convert.ToInt32(toInsert.Id);
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
