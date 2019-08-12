using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Reports_IICs.DataAccess.Instrumentos
{
    public class Instrumentos_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static DbSet<Instrumento> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos;
        }

        public static Instrumento GetInstrumentoById(string id)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos.Where(w=>w.Id == id).FirstOrDefault();
        }


        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumento</param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Instrumento NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtodelete.Id != null)
                {

                    var Ins_instrumento = dbContext.Instrumentos.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                    if (Ins_instrumento != null)
                    {
                        dbContext.Instrumentos.Remove(Ins_instrumento);
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


        public static bool Update(Instrumento NVtoupdate)
        {
            bool result = true;

            if (NVtoupdate != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtoupdate.Id != null)
                {
                    var Ins_instrumento = dbContext.Instrumentos.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_instrumento != null)
                    {

                        Ins_instrumento.Codigo = NVtoupdate.Codigo;
                        Ins_instrumento.Descripcion = NVtoupdate.Descripcion;
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

        public static int Insert(Instrumento NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changes to Db

                Instrumento toInsert = new Instrumento
                {
                    Codigo = NVtoinsert.Codigo,
                    Descripcion = NVtoinsert.Descripcion
                };
                dbContext.Instrumentos.Add(toInsert);
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

        public static IEnumerable<Instrumentos_Equivalencias> GetInstrumentosEquivalencias()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return  dbContext.Instrumentos_Equivalencias;
        }

    }
}
