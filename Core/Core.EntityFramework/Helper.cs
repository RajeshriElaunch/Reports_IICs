using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Core.Framework;
using System.Net.Mail;
using System.Data.Entity.Core;

namespace Core.EntityFramework
{
    public static class Helper
    {
        public static BizException ExeptionsHandler(Exception ex)
        {
            BizException bizex = null;
            
            if (ex is DbUpdateException)
            {
                if (ex.InnerException is UpdateException)
                {
                    if (ex.InnerException.InnerException is System.Data.SqlClient.SqlException)
                    {
                        if (ex.InnerException.InnerException.Message.Contains("The INSERT statement conflicted with the FOREIGN KEY constraint"))
                            bizex = new BizException("Ha ocurrido un error. " + ex.InnerException.InnerException.Message, ex);
                        else
                            if (ex.InnerException.InnerException.Message.Contains("FK_") && ex.InnerException.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                                bizex = new BizException("No se puede eliminar, la entidad se encuentra en uso.", ex);
                    }
                }

                if (bizex == null)
                    bizex = new BizException("Hubo un error al actualizar la base de datos.", ex);
            }
            else if (ex is DbEntityValidationException)
            {
                //Solo obtiene el primero.
                var error = ((DbEntityValidationException)ex).EntityValidationErrors.First().ValidationErrors.First();
                bizex = new BizException("Hubo un error de validación." + error.ErrorMessage, ex);
            }
            else
                bizex = new BizException("Error no manejado. Tipo: " + ex.GetType().Name, ex);

            return bizex;
        }

        //public static string DataBaseName()
        //{
        //    return new DBContainer().Database.Connection.DataSource;
        //}

        //public static string ConnectionString()
        //{
        //    return new DBContainer().Database.Connection.ConnectionString;
        //}

        //public static void DataBaseCreateIfNotExists()
        //{
        //    DBContainer db = new DBContainer();

        //    if (db.Database.CreateIfNotExists())
        //    {
        //        //Planta p = new Planta();
        //        //p.Descripcion = "Planta Modelo";
        //        //p.PlantaUsuario.Add(new PlantaUsuario() { UsuarioId = 1 });
        //        //db.Plantas.Add(p);

        //        //db.SaveChanges();
        //    }
        //}
    }

    
}
