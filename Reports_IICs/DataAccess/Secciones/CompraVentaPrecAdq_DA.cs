using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class CompraVentaPrecAdq_DA
    {
        //public static void Insert_Temp(string codigoIC, List<Temp_CompraVentaPrecAdq> lista)
        //{
        //    using (var dbContext = new Reports_IICSEntities())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_CompraVentaPrecAdq.RemoveRange(dbContext.Temp_CompraVentaPrecAdq.Where(e => e.CodigoIC == codigoIC));

        //            dbContext.Temp_CompraVentaPrecAdq.AddRange(lista);
        //            dbContext.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        public static T_CompraVentaPrecAdq Get_Temp_CompraVentaPrecAdqById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            T_CompraVentaPrecAdq CompraVenta_temp = new T_CompraVentaPrecAdq();


            foreach (var item in dbContext.Temp_CompraVentaPrecAdq.Where(r => r.Id == id))
            {
                CompraVenta_temp.Id = item.Id;
                CompraVenta_temp.CodigoIC = item.CodigoIC;
                CompraVenta_temp.Isin = item.Isin;
                CompraVenta_temp.Fecha = item.Fecha;
                CompraVenta_temp.Tipo = item.Tipo;
                CompraVenta_temp.Titulos = item.Titulos;
                CompraVenta_temp.DescripcionValor = item.DescripcionValor;
                CompraVenta_temp.Adquisicion = item.Adquisicion;
                CompraVenta_temp.Efectivo = item.Efectivo;


            }

            return CompraVenta_temp;
        }


        public static void Update_DatoAlmacenadosPreview(T_CompraVentaPrecAdq sel)
        {
            try
            {
                var dbContext = new Reports_IICSEntities();

                int id = sel.Id;
                DateTime? fecha = sel.FechaNew;
                string tipo = sel.TipoNew;
                decimal? titulos = sel.TitulosNew;
                decimal? Adquisicion = sel.AdquisicionNew;
                decimal? Efectivo = sel.EfectivoNew; //(titulos * Adquisicion) * -1;

                sel.Perdida = (sel.EfectivoNew < 0 ? sel.EfectivoNew : 0);
                sel.Beneficio = (sel.EfectivoNew > 0 ? sel.EfectivoNew : 0);

                #region tabla temporal
                //Actualizamos la tabla temporal que se utilizará para pintar el report
                T_CompraVentaPrecAdq CompraVenta_temp = new T_CompraVentaPrecAdq();
                CompraVenta_temp = CompraVentaPrecAdq_DA.Get_Temp_CompraVentaPrecAdqById(id);

                if (CompraVenta_temp != null)
                {
                    try
                    {
                        #region update Object
                        CompraVenta_temp.Fecha = fecha;
                        CompraVenta_temp.Tipo = tipo;
                        CompraVenta_temp.Titulos = titulos;
                        CompraVenta_temp.Adquisicion = Adquisicion;
                        CompraVenta_temp.Efectivo = 0;
                        CompraVenta_temp.Efectivo = Efectivo;
                        #endregion

                        #region update Database

                        var CompraVentaToSave = dbContext.Temp_CompraVentaPrecAdq.Where(c => c.Id == id).FirstOrDefault();
                        if (CompraVentaToSave != null)
                        {
                            CompraVentaToSave.Fecha = fecha;
                            CompraVentaToSave.Tipo = tipo;
                            CompraVentaToSave.Titulos = titulos;
                            CompraVentaToSave.Adquisicion = Adquisicion;
                            //CompraVentaToSave.Efectivo = Efectivo;
                        }

                        dbContext.SaveChanges();


                        #endregion
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                //Ahora actualizamos la tabla permanente que se conserva incluso con las nuevas generaciones
                //de informes
                #region tabla permanente
                var obj = dbContext.Preview_CompraVentaPrecAdq.Where(w =>
                w.CodigoIC == sel.CodigoIC
                        //&& w.IsinPlantilla == sel.IsinPlantilla
                        && w.Isin == sel.Isin
                        && w.Fecha == sel.Fecha
                        && w.Tipo == sel.Tipo
                        && w.Titulos == sel.Titulos
                        && w.DescripcionValor == sel.DescripcionValor
                        && w.Adquisicion == sel.Adquisicion
                        //&& w.Efectivo == sel.Efectivo
                        ).FirstOrDefault();

                bool esNuevo = false;
                if (obj == null)
                {
                    obj = new Preview_CompraVentaPrecAdq();
                    esNuevo = true;
                }

                obj.CodigoIC = sel.CodigoIC;
                //obj.IsinPlantilla = sel.IsinPlantilla;
                obj.Isin = sel.Isin;
                obj.Fecha = sel.Fecha;
                obj.FechaNew = sel.FechaNew;
                obj.Tipo = sel.Tipo;
                obj.TipoNew = sel.TipoNew;
                obj.Titulos = sel.Titulos;
                obj.TitulosNew = sel.TitulosNew;
                obj.DescripcionValor = sel.DescripcionValor;
                obj.DescripcionValorNew = sel.DescripcionValorNew;
                obj.Adquisicion = sel.Adquisicion;
                obj.AdquisicionNew = sel.AdquisicionNew;
                //obj.Efectivo = sel.Efectivo;
                //obj.EfectivoNew = sel.EfectivoNew;

                if (esNuevo)
                {
                    dbContext.Preview_CompraVentaPrecAdq.Add(obj);
                }
                #endregion

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
