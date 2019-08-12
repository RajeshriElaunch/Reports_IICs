using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public class Secciones_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();
        public static List<Seccione> GetAll()
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Secciones.ToList();
        }



        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Seccione </param>
        /// <returns> true(ok) or false(fail)</returns>
        public static bool Delete(Seccione NVtodelete)
        {
            bool result = true;
            if (NVtodelete != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtodelete.Id != 0) //null)
                {

                    var Ins_secciones = dbContext.Secciones.Where(n => n.Id == NVtodelete.Id).FirstOrDefault();
                    if (Ins_secciones != null)
                    {
                        dbContext.Secciones.Remove(Ins_secciones);
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

        public static bool Update(Seccione NVtoupdate)
        {
            bool result = true;

            if (NVtoupdate != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                if (NVtoupdate.Id != 0)//null)
                {
                    var Ins_secciones = dbContext.Secciones.Where(n => n.Id == NVtoupdate.Id).FirstOrDefault();

                    if (Ins_secciones != null)
                    {
                        Ins_secciones.Descripcion = NVtoupdate.Descripcion;
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

        public static int Insert(Seccione NVtoinsert)
        {
            int result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            try
            {
                //save changues to Db

                Seccione toInsert = new Seccione
                {
                    Descripcion = NVtoinsert.Descripcion

                };
                dbContext.Secciones.Add(toInsert);
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

        public static IQueryable<Plantillas_Generaciones_Secciones> GetSeccionesGeneradas(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Plantillas_Generaciones_Secciones.Where(s => s.CodigoIC == codigoIC);
        }

        /// <summary>
        /// Devuelve un listado con el IdSeccion de todas las secciones que tenía la plantilla en una fecha
        /// </summary>
        /// <param name="fecha"></param>
        public static IQueryable<int> GetSeccionesIdsByFecha(string codigoIC, DateTime fecha)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            //Tendremos que juntar las fechas que están en Plantillas_Secciones desde antes de la fecha solicitada
            var seccionesPlantilla = dbContext.Plantillas_Secciones.Where(s => s.CodigoIc == codigoIC && s.FechaModificacion < fecha).Select(s => s.IdSeccion);
            //con las que se encuentran en el histórico y pertenecían a la plantilla en dicha fecha
            var seccionesHistorico = dbContext.Plantillas_Secciones_Hist.Where(s => s.CodigoIc == codigoIC && s.FechaInicio < fecha && s.FechaFin > fecha).Select(s => s.IdSeccion);
            var secciones = seccionesPlantilla.Union(seccionesHistorico);

            return secciones;
        }

        public static List<Plantillas_Secciones_Hist> GetSeccionesByFecha(string codigoIC, DateTime fecha)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            var fechaModificacion = dbContext.Plantillas_Secciones.Where(s => s.CodigoIc == codigoIC).Select(s => s.FechaModificacion).FirstOrDefault();
            var lista = new List<Plantillas_Secciones_Hist>();

            //if (fecha >= fechaModificacion)
            //{
                var seccionesPlantilla = dbContext.Plantillas_Secciones.Where(s => s.CodigoIc == codigoIC);
                foreach (var seccion in seccionesPlantilla)
                {
                    var sec = new Plantillas_Secciones_Hist();
                    Utils.CopyPropertyValues(seccion, sec);
                    lista.Add(sec);
                }
            //}
            //else
            //{
            //    var seccionesHistorico = dbContext.Plantillas_Secciones_Hist.Where(s => s.CodigoIc == codigoIC && s.FechaInicio < fecha && s.FechaFin > fecha);
            //    foreach (var seccion in seccionesHistorico)
            //    {
            //        var sec = new Plantillas_Secciones_Hist();
            //        Utils.CopyPropertyValues(seccion, sec);
            //        lista.Add(sec);
            //    }
            //}

            return lista.OrderBy(s => s.Orden).ToList();
        }
    }
}
