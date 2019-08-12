using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Instrumentos
{
    public class InstrumentosCategorias_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static List<Instrumentos_Categorias> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Categorias.ToList();
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumentos_Categorias</param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Instrumentos_Categorias NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                var Ins_categoria = dbContext.Instrumentos_Categorias.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                if (Ins_categoria != null)
                {
                    dbContext.Instrumentos_Categorias.Remove(Ins_categoria);
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

            return result;
        }

        public static bool Update(Instrumentos_Categorias NVtoupdate)
        {
            bool result = true;

            if (NVtoupdate != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtoupdate.Id != null)
                {
                    var Ins_categoria = dbContext.Instrumentos_Categorias.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_categoria != null)
                    {

                        Ins_categoria.Codigo = NVtoupdate.Codigo;
                        Ins_categoria.Descripcion = NVtoupdate.Descripcion;
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

        public static int Insert(Instrumentos_Categorias NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changues to Db

                Instrumentos_Categorias toInsert = new Instrumentos_Categorias
                {
                    Codigo = NVtoinsert.Codigo,
                    Descripcion = NVtoinsert.Descripcion
                };
                dbContext.Instrumentos_Categorias.Add(toInsert);
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
