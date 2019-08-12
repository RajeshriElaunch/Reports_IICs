using Reports_IICs.DataModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;


namespace Reports_IICs.DataAccess.Instrumentos
{
    public class InstrumentosEmpresas_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static DbSet<Instrumentos_Empresas> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Empresas;
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumentos Empresas</param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Instrumentos_Empresas NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtodelete.Id != null)
                {
                    
                    var Ins_empresa = dbContext.Instrumentos_Empresas.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                    if (Ins_empresa != null)
                    {
                        dbContext.Instrumentos_Empresas.Remove(Ins_empresa);
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

        public static bool Update(Instrumentos_Empresas NVtoupdate)
        {
            bool result = true;

            if(NVtoupdate!=null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if(NVtoupdate.Id!=null)
                {
                    var Ins_empresa = dbContext.Instrumentos_Empresas.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_empresa != null)
                    {

                        Ins_empresa.Codigo = NVtoupdate.Codigo;
                        Ins_empresa.Descripcion = NVtoupdate.Descripcion;
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

        public static int Insert(Instrumentos_Empresas NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changues to Db
                
                Instrumentos_Empresas toInsert = new Instrumentos_Empresas
                {
                    Codigo=NVtoinsert.Codigo,
                    Descripcion = NVtoinsert.Descripcion
                };
                dbContext.Instrumentos_Empresas.Add(toInsert);
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
