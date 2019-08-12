using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class EvolucionMercados_DA
    {
        public static IQueryable<Parametros_EvolucionMercados> GetParametros(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Parametros_EvolucionMercados.Where(p => p.CodigoIC == codigoIC);            
        }

        public static List<Parametros_EvolucionMercados> GetParametrosPorDefecto()
        {
            var dbContext = new Reports_IICSEntities();
            var predet = dbContext.ParamPredet_EvolucionMercados;

            //queremos devolver List<Parametros_EvolucionMercados>
            List<Parametros_EvolucionMercados> lista = new List<Parametros_EvolucionMercados>();

            foreach(var indicePred in predet.OrderBy(o=>o.Orden))
            {
                var ind = new Parametros_EvolucionMercados();
                ind.Isin = indicePred.Codigo;
                ind.Descripcion = indicePred.Descripcion;
                lista.Add(ind);
            }

            return lista;
        }

        //public static void Insert_Temp_EvolucionMercados(string codigoIC, List<Temp_EvolucionMercados> lista)
        //{
        //    var dbContext = new Reports_IICSEntities();
        //    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_EvolucionMercados.RemoveRange(dbContext.Temp_EvolucionMercados.Where(e => e.CodigoIC == codigoIC));

        //            dbContext.Temp_EvolucionMercados.AddRange(lista);
        //            dbContext.SaveChanges();
        //            dbContextTransaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            dbContextTransaction.Rollback();

        //            throw ex;
        //        }
        //    }
        //}

        public static ObservableCollection<Temp_EvolucionMercados> GetTemp_EvolucionMercados(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (!string.IsNullOrEmpty(isin))
            {
                ObservableCollection<Temp_EvolucionMercados> evomerca = new ObservableCollection<Temp_EvolucionMercados>();

              
                foreach (var item in dbContext.Temp_EvolucionMercados.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                {
                    Temp_EvolucionMercados tmp_evomerca = new Temp_EvolucionMercados();
                    tmp_evomerca.Id = item.Id;
                    tmp_evomerca.CodigoIC = item.CodigoIC;
                    tmp_evomerca.CotizaDivDesde = item.CotizaDivDesde;
                    tmp_evomerca.CotizaDivHasta = item.CotizaDivHasta;
                    tmp_evomerca.Descripcion = item.Descripcion;
                    tmp_evomerca.FechaCotizacionDesde = item.FechaCotizacionDesde;
                    tmp_evomerca.FechaCotizacionHasta = item.FechaCotizacionHasta;
                    tmp_evomerca.Isin = item.Isin;
                    tmp_evomerca.VarCotizaDivisa = item.VarCotizaDivisa;
                    tmp_evomerca.VarCotizaEuros = item.VarCotizaEuros;
                    
                    evomerca.Add(tmp_evomerca);
                }
                return evomerca;
            }
            else
            {
                ObservableCollection<Temp_EvolucionMercados> evomerca = new ObservableCollection<Temp_EvolucionMercados>();


                foreach (var item in dbContext.Temp_EvolucionMercados.Where(r => r.CodigoIC == codigoIC))
                {
                    Temp_EvolucionMercados tmp_evomerca = new Temp_EvolucionMercados();
                    tmp_evomerca.Id = item.Id;
                    tmp_evomerca.CodigoIC = item.CodigoIC;
                    tmp_evomerca.CotizaDivDesde = item.CotizaDivDesde;
                    tmp_evomerca.CotizaDivHasta = item.CotizaDivHasta;
                    tmp_evomerca.Descripcion = item.Descripcion;
                    tmp_evomerca.FechaCotizacionDesde = item.FechaCotizacionDesde;
                    tmp_evomerca.FechaCotizacionHasta = item.FechaCotizacionHasta;
                    tmp_evomerca.Isin = item.Isin;
                    tmp_evomerca.VarCotizaDivisa = item.VarCotizaDivisa;
                    tmp_evomerca.VarCotizaEuros = item.VarCotizaEuros;

                    evomerca.Add(tmp_evomerca);
                }
                return evomerca;
               
            }
        }

        public static Temp_EvolucionMercados GetTemp_EvolucionMercados_Item(int Id_Temp_EvolucionMercados)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            var item = dbContext.Temp_EvolucionMercados.Where(r => r.Id == Id_Temp_EvolucionMercados).FirstOrDefault();
            return item;
        }
        public static void Update_GetTemp_EvolucionMercados_Item(Temp_EvolucionMercados evolMerc_temp_new)
        {
            Reports_IICSEntities dbcontext = new Reports_IICSEntities();
            Temp_EvolucionMercados evolMerc_temp_old = dbcontext.Temp_EvolucionMercados.FirstOrDefault(p => p.Id == evolMerc_temp_new.Id);
            Utils.CopyPropertyValues(evolMerc_temp_new, evolMerc_temp_old);

            try
            {
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
