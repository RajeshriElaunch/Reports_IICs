using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Reports_IICs.DataAccess.Instrumentos
{
    class Instrumentos_divisas_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static List<Instrumentos_Divisas> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Divisas.ToList();
        }

        public static Instrumentos_Divisas GetDivisaPorCodigo(string codigo)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Divisas.Where(w=>w.Codigo.Equals(codigo)).FirstOrDefault();
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumentos Divisas</param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Instrumentos_Divisas NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtodelete.Id != null)
                {

                    var Ins_divisa = dbContext.Instrumentos_Divisas.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                    if (Ins_divisa != null)
                    {
                        dbContext.Instrumentos_Divisas.Remove(Ins_divisa);
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

        public static bool Update(Instrumentos_Divisas NVtoupdate)
        {
            bool result = true;

            if (NVtoupdate != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtoupdate.Id != null)
                {
                    var Ins_divisa = dbContext.Instrumentos_Divisas.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_divisa != null)
                    {

                        Ins_divisa.Codigo = NVtoupdate.Codigo;
                        Ins_divisa.Descripcion = NVtoupdate.Descripcion;
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

        public static int Insert(Instrumentos_Divisas NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changues to Db

                Instrumentos_Divisas toInsert = new Instrumentos_Divisas
                {
                    Codigo = NVtoinsert.Codigo,
                    Descripcion = NVtoinsert.Descripcion
                };
                dbContext.Instrumentos_Divisas.Add(toInsert);
                dbContext.SaveChanges();
                result = toInsert.Id;
                GetAll();
                //var PP = dbContext.GetValidationErrors();
            }

            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            return result;
        }
    }
}
