using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.RentaFija;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;
using Reports_IICs.DataAccess.Managers;


namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class RentaFijaVM
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static DateTime _fechaInf;
        private static DateTime _fechaIni;
        private static Plantilla _plantilla;
        private static List<usp_gestio_pro_21_Result> _pro21;
        private static List<usp_gestio_pro_22_Result> _pro22;
        private static IEnumerable<usp_gestio_pro_11_Result> _cart;
        private static List<CuentasContablesDerivado> _ctasDerivados;
        private static List<usp_gestio_pro_13_Result> _pro13r;
        private const string G1Text = "GRUPO-01-Valor en cartera no vendido en el periodo";
        private const string G2Text = "GRUPO-02-Valor en cartera vendido en el periodo";
        private const string G3Text = "GRUPO-03-Valor comprado y vendido en el periodo";
        private const string G4Text = "GRUPO-04-Valor comprado en el periodo y no vendido";        
        //public static void Insert_Temp(string codigoIC, DateTime? fecha, ref List<TempTableBase> listaTmp)
        //{
        //    var plantilla = Plantillas_DA.GetPlantilla(codigoIC);
        //    Insert_Temp(plantilla, fecha, ref listaTmp);
        //}
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {

                _fechaInf = Convert.ToDateTime(fecha);
                _fechaIni = Utils.GetFechaInicio(plantilla, _fechaInf);
                _plantilla = plantilla;
                //_pro21 = pro21;
                //Filtramos para no mostrar los que no son de RF
                //Tenemos que generar Pro21_Local porque es una preview y no se ha cargado el procedimiento
                if (VariablesGlobales.Pro21_Local == null)
                {
                    VariablesGlobales.SetVariablesGlobales(typeof(usp_gestio_pro_21_Result), plantilla, fecha);
                }
                if (VariablesGlobales.Pro21_Local != null)
                    _pro21 = VariablesGlobales.Pro21_Local.Where(p =>
                        VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("RFI") || i.Instrumento.Codigo.Equals("RFM"))
                            .Select(s => s.ISIN.ToUpper()).Contains(p.Isin.ToUpper())).ToList();

                //Tenemos que generar Pro22_Local porque es una preview y no se ha cargado el procedimiento
                if (VariablesGlobales.Pro22_Local == null)
                {
                    VariablesGlobales.SetVariablesGlobales(typeof(usp_gestio_pro_22_Result), plantilla, fecha);
                }
                if (VariablesGlobales.Pro22_Local != null)
                    _pro22 = VariablesGlobales.Pro22_Local.Where(p =>
                        VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("RFI"))
                            .Select(s => s.ISIN.ToUpper()).Contains(p.b3001_cod.ToUpper().Trim())).Distinct().ToList();
                //_pro22 = VariablesGlobales.Pro22_Local.Where(p=> InstrumentosImportados_DA.EsRF_ByIsin(p.b3001_cod.ToUpper().Trim())).ToList();

                if (VariablesGlobales.Pro11_Local == null)
                {
                    VariablesGlobales.SetVariablesGlobales(typeof(usp_gestio_pro_11_Result), plantilla, fecha);
                }
                _cart = VariablesGlobales.Pro11_Local;
                _ctasDerivados = Reports_DA.GetCuentasDerivados();

                Tratar601();

        //foreach (var isin in plantilla.Plantillas_Isins)
        //{
        var proc2122 = UnirPro21Pro22();

                    ActualizarCodsInstr(ref proc2122);
                    var lista = ClasificarGrupos(proc2122);
                    //Actualizamos el isinPlantilla para cada elemento de la lista
                    //lista.ForEach(f => f.IsinPlantilla = isin.Isin.ToUpper());
                    listaTmp.AddRange(lista);
                    AgruparDerivados(ref listaTmp);
                ActualizarConPreview(ref listaTmp);
                //ponerDescrGrupos(ref listaTmp);
                //}


            }
            catch (Exception ex)
            {
                Log.Error("Error RentaFija_VM/Insert_Temp", ex);
                throw;
            }
        }

        /// <summary>
        /// Actualizamos con los datos que se hayan modificado alguna vez en la preview. Los datos que se modifiquen en la preview de esta sección deben mantenerse.
        /// </summary>
        /// <param name="listaTmp"></param>
        //public static Reports_IICSEntities dbcontext1 = new Reports_IICSEntities();

        private static void ActualizarConPreview(ref List<TempTableBase> listaTmp)
        {
            var itemsInforme = listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList();
            //var itemsPrev = _plantilla.Preview_RentaFija.Where(w=>w.FechaInforme <= _fechaInf)
            //                    .OrderBy(o => o.Isin).ThenByDescending(t => t.FechaInforme).ToList();

            //Tengo que agrupar por Grupo también, además de por Isin
          // var itemsPrev = _plantilla.Preview_RentaFija.Where(w => w.FechaInforme <= _fechaInf && w.IsVisible)
            var itemsPrev = _plantilla.Preview_RentaFija.Where(w => w.FechaInforme == _fechaInf)
                        .GroupBy(x => new
                        {
                            x.Isin,
                            x.Grupo
                        }, (key, g) => g.OrderByDescending(e => e.FechaInforme).First());

           
            var listaEliminar = new List<Temp_RentaFija>();
            var listaAñadir = new List<Temp_RentaFija>();
          

            
            foreach (var itemPrev in itemsPrev)
            
            {
                //Tendremos que comprobar primero que no 
                var itemInforme = itemsInforme.Where(w =>
                        w.CodigoIC == itemPrev.CodigoIC
                        //&& w.Isin.ToUpper() == itemPrev.Isin.ToUpper()
                        && w.Grupo == itemPrev.Grupo
                        //&& w.NumTit == itemPrev.NumTit
                        //&& w.EfectivoIni == itemPrev.EfectivoIni
                        //&& w.EfectivoFin == itemPrev.EfectivoFin
                        //&& w.BoPDivisa == itemPrev.BoPDivisa
                        //&& w.BoPPrecio == itemPrev.BoPPrecio
                        //&& w.PosicionCartera == itemPrev.PosicionCartera
                        //&& w.PosicionCarteraNew == itemPrev.PosicionCartera
                        //&& w.PosicionesCerradas == itemPrev.PosicionesCerradas
                        //&& w.PosicionesCerradasNew == itemPrev.PosicionesCerradas
                        ).FirstOrDefault();
                

                if (itemPrev.Grupo == 7)
                {
                     itemInforme = itemsInforme.Where(w =>
                        w.CodigoIC == itemPrev.CodigoIC
                        && w.Descripcion == itemPrev.Descripcion
                        && w.Grupo == itemPrev.Grupo
                        //&& w.NumTit == itemPrev.NumTit
                        //&& w.EfectivoIni == itemPrev.EfectivoIni
                        //&& w.EfectivoFin == itemPrev.EfectivoFin
                        //&& w.BoPDivisa == itemPrev.BoPDivisa
                        //&& w.BoPPrecio == itemPrev.BoPPrecio
                        //&& w.PosicionCartera == itemPrev.PosicionCartera
                        //&& w.PosicionCarteraNew == itemPrev.PosicionCartera
                        //&& w.PosicionesCerradas == itemPrev.PosicionesCerradas
                        //&& w.PosicionesCerradasNew == itemPrev.PosicionesCerradas
                        ).FirstOrDefault();

                    if (itemInforme == null)
                    {
                        itemInforme = new Temp_RentaFija();
                    }

                    if (itemPrev.IsVisible)
                    {
                        //Actualizamos nuestro resultado con lo que teníamos almacenado de alguna vez en la preview
                        //Vale para el caso de que hubiera sido un item modificado o añadido en la Preview
                        Utils.CopyPropertyValues(itemsPrev, itemInforme, "Id");



                        //em de buscar a la llista del parametre de entrada en registre que tenim
                        // a iteminforme


                        if (itemInforme != null)
                        {
                            var existitem = listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                          w.CodigoIC == itemInforme.CodigoIC
                          && w.Descripcion == itemInforme.Descripcion
                          && w.Grupo == itemInforme.Grupo
                          //&& w.NumTit == itemInforme.NumTit
                          //&& w.EfectivoIni == itemInforme.EfectivoIni
                          //&& w.EfectivoFin == itemInforme.EfectivoFin
                          // && w.PosicionCartera == itemInforme.PosicionCartera
                          //&& w.PosicionesCerradas == itemInforme.PosicionesCerradas 
                          ).FirstOrDefault();

                            if (existitem != null)
                            {
                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                               ).FirstOrDefault().PosicionCarteraNew = itemPrev.PosicionCarteraNew;

                                //listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                //w.CodigoIC == itemInforme.CodigoIC
                                //&& w.Descripcion == itemInforme.Descripcion
                                //&& w.Grupo == itemInforme.Grupo
                                //).FirstOrDefault().PosicionesCerradasNew = itemPrev.PosicionCarteraNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                               ).FirstOrDefault().PosicionesCerradasNew = itemPrev.PosicionesCerradasNew;


                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().BoPPrecioNew = itemPrev.EfectivoFinNew- itemPrev.EfectivoIniNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().BoPDivisaNew = itemPrev.BoPDivisaNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().EfectivoIniNew = itemPrev.EfectivoIniNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().EfectivoFinNew = itemPrev.EfectivoFinNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().NumTitNew = itemPrev.NumTitNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().IsinNew = itemPrev.IsinNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().GrupoNew = itemPrev.GrupoNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                               w.CodigoIC == itemInforme.CodigoIC
                               && w.Descripcion == itemInforme.Descripcion
                               && w.Grupo == itemInforme.Grupo
                               ).FirstOrDefault().DescripcionNew = itemPrev.DescripcionNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Descripcion == itemInforme.Descripcion
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().BoPTotal = itemPrev.EfectivoFinNew - itemPrev.EfectivoIniNew + itemPrev.BoPDivisaNew;
                            }


                        }


                        //itemPrev.CodigoIC
                        //itemInforme.IsinNew = itemPrev.IsinNew;
                        //itemInforme.FechaNew = itemPrev.FechaNew;
                        //itemInforme.TipoNew = itemPrev.TipoNew;
                        //itemInforme.TitulosNew = itemPrev.TitulosNew;
                        //itemInforme.DescripcionValorNew = itemPrev.DescripcionValorNew;
                        //itemInforme.AdquisicionNew = itemPrev.AdquisicionNew;
                        //itemInforme.EfectivoFinNew = itemPrev.EfectivoFinNew;

                        // Aquí farem l'actualització de taula de variació patrimonial
                        //a partir de les dades que s'han agafat de la taula preview de renta fixe


                        //fi de les modificacions de taula de variació patrimonial


                        if (itemPrev.Added)
                        {
                            listaAñadir.Add(itemInforme);
                        }
                    }
                    else
                    {
                        listaEliminar.Add(itemInforme);
                    }

                }
                else
                {
                       itemInforme = itemsInforme.Where(w =>
                       w.CodigoIC == itemPrev.CodigoIC
                       && w.Isin.ToUpper() == itemPrev.Isin.ToUpper()
                       && w.Grupo == itemPrev.Grupo
                       //&& w.NumTit == itemPrev.NumTit
                       //&& w.EfectivoIni == itemPrev.EfectivoIni
                       //&& w.EfectivoFin == itemPrev.EfectivoFin
                       //&& w.BoPDivisa == itemPrev.BoPDivisa
                       //&& w.BoPPrecio == itemPrev.BoPPrecio
                       //&& w.PosicionCartera == itemPrev.PosicionCartera
                       //&& w.PosicionCarteraNew == itemPrev.PosicionCartera
                       //&& w.PosicionesCerradas == itemPrev.PosicionesCerradas
                       //&& w.PosicionesCerradasNew == itemPrev.PosicionesCerradas
                       ).FirstOrDefault();
                     var itemPro21 = _pro21.Where(w =>
                        w.Isin == itemPrev.Isin.ToUpper()
                        && w.Grupo.Contains(Convert.ToString(itemPrev.Grupo))
                        && w.EfectivoIAEUR == itemPrev.EfectivoIni
                        ).FirstOrDefault();
                    if (itemInforme == null)
                    {
                        itemInforme = new Temp_RentaFija();
                    }

                    if (itemPrev.IsVisible)
                    {
                        //Actualizamos nuestro resultado con lo que teníamos almacenado de alguna vez en la preview
                        //Vale para el caso de que hubiera sido un item modificado o añadido en la Preview
                        Utils.CopyPropertyValues(itemsPrev, itemInforme, "Id");



                        //em de buscar a la llista del parametre de entrada en registre que tenim
                        // a iteminforme


                        if (itemInforme != null)
                        {
                            var existitem = listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                          w.CodigoIC == itemInforme.CodigoIC
                          && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                          && w.Grupo == itemInforme.Grupo
                          //&& w.NumTit == itemInforme.NumTit
                          //&& w.EfectivoIni == itemInforme.EfectivoIni
                          //&& w.EfectivoFin == itemInforme.EfectivoFin
                          // && w.PosicionCartera == itemInforme.PosicionCartera
                          //&& w.PosicionesCerradas == itemInforme.PosicionesCerradas 
                          ).FirstOrDefault();

                            if (existitem != null)
                            {
                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                && w.Grupo == itemInforme.Grupo
                               ).FirstOrDefault().PosicionCarteraNew = itemPrev.PosicionCarteraNew;

                                //listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                //w.CodigoIC == itemInforme.CodigoIC
                                //&& w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                //&& w.Grupo == itemInforme.Grupo
                                //).FirstOrDefault().PosicionesCerradasNew = itemPrev.PosicionCarteraNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                && w.Grupo == itemInforme.Grupo
                                && w.GrupoNew == itemInforme.GrupoNew
                               ).FirstOrDefault().PosicionesCerradasNew = itemPrev.PosicionesCerradasNew;

                                if (itemPro21!=null)
                                { 
                                    listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                    w.CodigoIC == itemInforme.CodigoIC
                                    && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                    && w.Grupo == itemInforme.Grupo
                                    ).FirstOrDefault().BoPPrecioNew = itemPrev.EfectivoFinNew - itemPrev.EfectivoIniNew * (itemPro21.CambioF / itemPro21.CambioO);

                                    listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                    w.CodigoIC == itemInforme.CodigoIC
                                    && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                    && w.Grupo == itemInforme.Grupo
                                    ).FirstOrDefault().BoPDivisaNew = itemPrev.EfectivoIniNew * ((itemPro21.CambioF / itemPro21.CambioO) - 1);//itemPrev.BoPDivisaNew;
                                }
                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().EfectivoIniNew = itemPrev.EfectivoIniNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().EfectivoFinNew = itemPrev.EfectivoFinNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().NumTitNew = itemPrev.NumTitNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().IsinNew = itemPrev.IsinNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().GrupoNew = itemPrev.GrupoNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                               w.CodigoIC == itemInforme.CodigoIC
                               && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                               && w.Grupo == itemInforme.Grupo
                               ).FirstOrDefault().DescripcionNew = itemPrev.DescripcionNew;

                                listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList().Where(w =>
                                w.CodigoIC == itemInforme.CodigoIC
                                && w.Isin.ToUpper() == itemInforme.Isin.ToUpper()
                                && w.Grupo == itemInforme.Grupo
                                ).FirstOrDefault().BoPTotal = itemPrev.EfectivoFinNew - itemPrev.EfectivoIniNew + itemPrev.BoPDivisaNew;
                            }


                        }


                        //itemPrev.CodigoIC
                        //itemInforme.IsinNew = itemPrev.IsinNew;
                        //itemInforme.FechaNew = itemPrev.FechaNew;
                        //itemInforme.TipoNew = itemPrev.TipoNew;
                        //itemInforme.TitulosNew = itemPrev.TitulosNew;
                        //itemInforme.DescripcionValorNew = itemPrev.DescripcionValorNew;
                        //itemInforme.AdquisicionNew = itemPrev.AdquisicionNew;
                        //itemInforme.EfectivoFinNew = itemPrev.EfectivoFinNew;

                        // Aquí farem l'actualització de taula de variació patrimonial
                        //a partir de les dades que s'han agafat de la taula preview de renta fixe


                        //fi de les modificacions de taula de variació patrimonial


                        if (itemPrev.Added)
                        {
                            listaAñadir.Add(itemInforme);
                        }
                    }
                    else
                    {
                        listaEliminar.Add(itemInforme);
                    }
                }
                
               
            }
            //Borramos de la lista que se va a mostrar en el informe (listaTmp)
            //los que se han eliminado en la Preview
            
            listaTmp.RemoveAll(w => listaEliminar.Contains(w));
            //Añadimos los que se insertaron nuevos desde la Preview
            listaTmp.AddRange(listaAñadir);
            itemsPrev = null;

        }
        /// <summary>
        /// Agrupa los derivados por código subyacente
        /// </summary>
        /// <param name="listaTmp"></param>
        private static void AgruparDerivados(ref List<TempTableBase> listaTmp)
        {
            //Tenemos que agrupar los DER por código subyacente
            var listaRF = listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList();            
            var listaDer = listaRF.Where(w => w.Grupo == 7).ToList();

            if (listaDer.Any())
            {
                var listaDerAgrup = listaDer.GroupBy(g => new
                {
                    g.CodigoIC,
                    //g.IsinPlantilla,
                    g.CodigoSubyacente,
                    g.Descripcion,
                    g.DescripcionNew,
                    g.Grupo,
                    g.GrupoNew,
                    g.IdInstrumento,
                    g.IdTipoInstrumento
                }).Select(s => new Temp_RentaFija
                {
                    CodigoIC = s.Key.CodigoIC,
                    //IsinPlantilla = s.Key.IsinPlantilla,
                    CodigoSubyacente = s.Key.CodigoSubyacente,
                    Descripcion = s.Key.Descripcion,
                    DescripcionNew = s.Key.DescripcionNew,
                    Grupo = s.Key.Grupo,
                    GrupoNew = s.Key.GrupoNew,
                    IdInstrumento = s.Key.IdInstrumento,
                    IdTipoInstrumento = s.Key.IdTipoInstrumento,
                    PosicionCartera = s.Sum(a => a.PosicionCartera),
                    PosicionCarteraNew = s.Sum(a => a.PosicionCartera),
                    PosicionesCerradas = s.Sum(a => a.PosicionesCerradas),
                    PosicionesCerradasNew = s.Sum(a => a.PosicionesCerradas)

                });

                //Borramos todos los derivados de la listaTmp. Remove One List from another
                listaTmp.RemoveAll(a => listaDer.Exists(e => e == a));
                //Los añadimos agrupados
                listaTmp.AddRange(listaDerAgrup);
            }

            
        }

        private static List<usp_gestio_pro_21_Result> UnirPro21Pro22()
        {
            //obtenemos los códigos de valor del fondo/sicav
            var codsVal = _pro22.Select(s => s.b3001_cod.ToUpper().Trim());

            //Creamos un objeto como _pro21 que contenga los isins de p21 y p22
            var proc2122 = _pro21;
            foreach (var isin in codsVal)
            {
                var isinsAdded = proc2122.Select(s => s.Isin.ToUpper());
                //Si ya se encontraba en pro21 no lo añadimos
                if (!isinsAdded.Contains(isin.ToUpper()))
                {
                    var p21 = new usp_gestio_pro_21_Result();
                    p21.Isin = isin.ToUpper();
                    proc2122.Add(p21);
                }
            }

            return proc2122;
        }

        private static void ActualizarCodsInstr(ref List<usp_gestio_pro_21_Result> proc2122)
        {
            var distinctIsins = proc2122.Select(s => s.Isin).Distinct().ToList();

            var instrum = InstrumentosImportados_DA.GetInstrumentosImportadosByIsin(distinctIsins).ToList();

            //Actualizamos el pro21 asignando a cada ISIN el IdInstrumento y el IdTipoInstrumento que le corresponda            
            //var isinsFaltan = new List<string>();
            foreach (var item in proc2122)
            {
                var ins = instrum.FirstOrDefault(w => w.ISIN == item.Isin);
                if (ins != null)
                {
                    item.CodInstrumento = ins.Instrumento.Codigo;
                    item.CodTipoInstrumento = ins.Instrumentos_Tipos.Codigo;
                }
                else
                {
                    item.CodInstrumento = "NO ESTÁ IMPORTADO";
                    item.CodTipoInstrumento = "NO ESTÁ IMPORTADO";
                }


                if (item.Grupo == null)
                    item.Grupo = string.Empty;
                if (item.Nombre == null)
                    item.Nombre = string.Empty;
            }
        }

        private static List<Temp_RentaFija> ClasificarGrupos(List<usp_gestio_pro_21_Result> proc2122)
        {
            try
            {
                var lista = new List<Temp_RentaFija>();
                
                //Si son IICs van al Grupo 6
                var iics = proc2122.Where(w => w.CodTipoInstrumento == "IIC").ToList();
                lista.AddRange(GetTemp(iics, 6));
                //Los eliminamos de nuestro "proc" temporal
                //proc.RemoveAll(r => r.CodInstrumento == "IIC");
                proc2122.RemoveAll(r => iics.Contains(r));

                //Si son Derivados van al Grupo 7 (RFI && DER)
                //agrupar por cod subyacente
                var der = proc2122.Where(w => w.CodInstrumento == "RFI" && w.CodTipoInstrumento == "DER").ToList();                
                lista.AddRange(GetTemp(der, 7));
                proc2122.RemoveAll(r => der.Contains(r));

                //1 - Deuda que teníamos en cartera a 01/01/XXXX y no se han vendido en XXXX
                //Muestro todos los que devuelve el procedimiento de Martí como GRUPO-01.
                //Sin agrupar.
                var g1 = proc2122.Where(w => w.Grupo.Contains("GRUPO-01")).ToList();
                lista.AddRange(GetTemp(g1, 1));
                //Los eliminamos de nuestro "proc" temporal
                proc2122.RemoveAll(r => g1.Contains(r));

                //2 - Deuda que teníamos en cartera el 31/12/XXXX y se ha amortizado en XXXX
                //Pintamos los del Grupo 02 y ClavMovF = VT
                //Agrupados por FechaC
                var g2 = proc2122.Where(w => w.Grupo.Contains("-02") && w.ClamovF == "VT").GroupBy(g => new
                {
                    g.Isin,
                    g.Nombre,
                    g.Grupo,
                    g.Divisa,
                    g.FechaC
                }).Select(s => new usp_gestio_pro_21_Result
                {
                    Isin = s.Key.Isin,
                    Nombre = s.Key.Nombre,
                    Grupo = s.Key.Grupo,
                    FechaC = s.Key.FechaC,
                    NumTit = s.Sum(a => a.NumTit),
                    EfectivoIEUR = s.Sum(a => a.EfectivoIEUR),
                    EfectivoFEUR = s.Sum(a => a.EfectivoFEUR),
                    PLDiv = s.Sum(a => a.PLDiv),
                    PLPrecio = s.Sum(a => a.PLPrecio),
                    PLEur = s.Sum(a => a.PLEur),
                    PLPct = s.Sum(a => a.PLPct)
                }).ToList();
                lista.AddRange(GetTemp(g2, 2));
                //Los eliminamos de nuestro "proc" temporal
                proc2122.RemoveAll(r => g2.Contains(r));

                //3 - Deuda que teníamos en cartera el 31/12/XXXX y se ha vendido en XXXX
                //Pintamos los del Grupo 02 y ClavMovF = VE
                //Agrupados por FechaC
                var g3 = proc2122.Where(w => w.Grupo.Contains("-02") && w.ClamovF == "VE").GroupBy(g => new
                {
                    g.Isin,
                    g.Nombre,
                    g.Grupo,
                    g.Divisa,
                    g.FechaC
                }).Select(s => new usp_gestio_pro_21_Result
                {
                    Isin = s.Key.Isin,
                    Nombre = s.Key.Nombre,
                    Grupo = s.Key.Grupo,
                    FechaC = s.Key.FechaC,
                    NumTit = s.Sum(a => a.NumTit),
                    EfectivoIEUR = s.Sum(a => a.EfectivoIEUR),
                    EfectivoFEUR = s.Sum(a => a.EfectivoFEUR),
                    PLDiv = s.Sum(a => a.PLDiv),
                    PLPrecio = s.Sum(a => a.PLPrecio),
                    PLEur = s.Sum(a => a.PLEur),
                    PLPct = s.Sum(a => a.PLPct)
                }).ToList();
                lista.AddRange(GetTemp(g3, 3));

                //4 - Deuda que se ha comprado en XXXX y no se ha vendido en XXXX
                //Pintamos los del Grupo 04
                //Agrupados por FechaO.
                var g4 = proc2122.Where(w => w.Grupo.Contains("-04")).GroupBy(g => new
                {
                    g.Isin,
                    g.Nombre,
                    g.Grupo,
                    g.Divisa,
                    g.FechaO
                }).Select(s => new usp_gestio_pro_21_Result
                {
                    Isin = s.Key.Isin,
                    Nombre = s.Key.Nombre,
                    Grupo = s.Key.Grupo,
                    FechaO = s.Key.FechaO,
                    NumTit = s.Sum(a => a.NumTit),
                    EfectivoIEUR = s.Sum(a => a.EfectivoIEUR),
                    EfectivoFEUR = s.Sum(a => a.EfectivoFEUR),
                    PLDiv = s.Sum(a => a.PLDiv),
                    PLPrecio = s.Sum(a => a.PLPrecio),
                    PLEur = s.Sum(a => a.PLEur),
                    PLPct = s.Sum(a => a.PLPct)
                }).ToList();
                lista.AddRange(GetTemp(g4, 4));

                //5 - Deuda comprada y vendida en XXXX
                //Pintamos los del Grupo 03
                //Agrupados por FechaC.
                var g5 = proc2122.Where(w => w.Grupo.Contains("-03")).GroupBy(g => new
                {
                    g.Isin,
                    g.Nombre,
                    g.Grupo,
                    g.Divisa,
                    g.FechaC
                }).Select(s => new usp_gestio_pro_21_Result
                {
                    Isin = s.Key.Isin,
                    Nombre = s.Key.Nombre,
                    Grupo = s.Key.Grupo,
                    FechaC = s.Key.FechaC,
                    NumTit = s.Sum(a => a.NumTit),
                    EfectivoIEUR = s.Sum(a => a.EfectivoIEUR),
                    EfectivoFEUR = s.Sum(a => a.EfectivoFEUR),
                    PLDiv = s.Sum(a => a.PLDiv),
                    PLPrecio = s.Sum(a => a.PLPrecio),
                    PLEur = s.Sum(a => a.PLEur),
                    PLPct = s.Sum(a => a.PLPct)
                }).ToList();
                lista.AddRange(GetTemp(g5, 5));

                return lista;
            }
            catch(Exception ex)
            {
                Log.Error("Error RentaFija_VM/clasificarGrupos", ex);
                throw;
            }
        }

        private static void Tratar601()
        {
            var trG4 = _pro21.Where(w => w.TipMovO == "601" && Utils.GetGrupoInt(w.Grupo) == 4).ToList();
            trG4.ForEach(i => ChangeGroup(i, 1));
            var trG3 = _pro21.Where(w => w.TipMovO == "601" && Utils.GetGrupoInt(w.Grupo) == 3).ToList();
            trG3.ForEach(i => ChangeGroup(i, 2));
        }

        private static void ChangeGroup(usp_gestio_pro_21_Result item, int grupoNew)
        {
            switch (grupoNew)
            {
                case 1:
                    item.Grupo = G1Text;
                    break;
                case 2:
                    item.Grupo = G2Text;
                    break;
                case 3:
                    item.Grupo = G3Text;
                    break;
                case 4:
                    item.Grupo = G4Text;
                    break;
            }
        }

        private static List<Temp_RentaFija> GetTemp(List<usp_gestio_pro_21_Result> items, int grupo)
        {
            var lista = new List<Temp_RentaFija>();

            foreach (var item in items)
            {
                try
                {
                    var temp = new Temp_RentaFija();

                    temp.CodigoIC = _plantilla.CodigoIc;
                    temp.Isin = item.Isin;
                    temp.IsinNew = item.Isin;
                    temp.Grupo = grupo;
                    temp.GrupoNew = grupo;
                    temp.NumTit = item.NumTit;
                    temp.NumTitNew = item.NumTit;
                    var instr = VariablesGlobales.InstrumentosImportados_Local.FirstOrDefault(w => String.Equals(w.ISIN, item.Isin, StringComparison.CurrentCultureIgnoreCase));
                    if (instr != null)
                    {
                        temp.IdInstrumento = instr.IdInstrumento;
                        temp.CodInstrumento = instr.Instrumento.Codigo;
                        temp.IdTipoInstrumento = instr.IdTipoInstrumento;
                        temp.CodTipoInstrumento = instr.Instrumentos_Tipos.Codigo;
                    }

                    var cartIsin = _cart.FirstOrDefault(w => String.Equals(w.isin, item.Isin, StringComparison.CurrentCultureIgnoreCase));

                    switch (grupo)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            temp.Descripcion = item.Nombre;
                            temp.DescripcionNew = item.Nombre;
                            temp.EfectivoIni = item.EfectivoIEUR;
                            temp.EfectivoIniNew = item.EfectivoIEUR;
                            temp.EfectivoFin = item.EfectivoFEUR;
                            temp.EfectivoFinNew = item.EfectivoFEUR;
                            temp.BoPDivisa = item.PLDiv;
                            temp.BoPDivisaNew = item.PLDiv;
                            temp.BoPPrecio = item.PLPrecio;
                            temp.BoPPrecioNew = item.PLPrecio;
                            temp.BoPTotal = item.PLEur;
                            temp.BoPTotalPorcentaje = item.PLPct / 100;
                            //temp.BoPTotalPorcentajeNew = item.PLPct / 100;
                            temp.FechaCompra = item.FechaO != DateTime.MinValue ? item.FechaO : (DateTime?)null;
                            temp.FechaVenta = item.FechaC != DateTime.MinValue ? item.FechaC : null;
                            break;
                        case 6:
                            if (!string.IsNullOrEmpty(item.Nombre))
                            {
                                temp.Descripcion = item.Nombre;
                                temp.DescripcionNew = item.Nombre;
                            }
                            else if (!string.IsNullOrEmpty(cartIsin?.descr))
                            {
                                temp.Descripcion = cartIsin.descr;
                                temp.DescripcionNew = cartIsin.descr;
                            }
                            else
                            {
                                temp.Descripcion = "";
                                temp.DescripcionNew = "";
                            }

                            GetDatosGrupo6FromPro21(ref temp, item.Isin);

                            if (temp.PosicionCartera == 0 && temp.PosicionesCerradas == 0 && temp.BoPTotal == 0)
                            {
                                //Si no hemos encontrado datos es porque este ISIN nos viene del PRO22
                                //En este caso puede que en BIA lo tuvieran clasificado como RVA pero en nuestra tabla de instrumentos
                                //lo tengamos como RFI
                                //Probamos a hacer lo mismo que hacemos para los del grupo 6 pero buscando 
                                //este ISIN en el PRO13 (que es de RV)
                                var obj = VariablesGlobales.Pro13_Local.Where(w => w.Isin.ToUpper() == item.Isin.ToUpper()).ToList();

                                if (obj.Count > 0)
                                {
                                    GetDatosGrupo6FromPro13(ref temp, item.Isin);
                                }
                                else
                                {
                                    temp = null;
                                }
                            }

                            
                            break;
                        case 7:
                            var suby = Reports_DA.GetPRO20(item.Isin).FirstOrDefault();
                            if (suby.b3006_cod != null)
                            {
                                temp.Descripcion = suby.b3006_nom;
                                temp.DescripcionNew = suby.b3006_nom;
                                temp.CodigoSubyacente = suby.b3006_cod;                                
                            }
                            else
                            {
                                temp.Descripcion = item.Nombre;
                                temp.DescripcionNew = item.Nombre;
                            }

                            //POSICIÓN EN CARTERA: Es el campo "plusva" de la cartera

                            //Si no encontramos la cartera para este ISIN tendremos que buscarlo por el código subyacente
                            //if (cartIsin == null)
                            //{
                            //    cartIsin = _cart.Where(w => w.isin.ToUpper().Equals(item.Isin.ToUpper())).FirstOrDefault();
                            //}

                            if (cartIsin != null)
                            {
                                temp.PosicionCartera = cartIsin.plusva;
                                temp.PosicionCarteraNew = cartIsin.plusva;
                            }

                            decimal? total = 0;
                            //TOTAL(€): para cada isin del subyacente y para cada CuentaContableDerivados obtener el saldo con el PRO23
                            foreach (var cta in _ctasDerivados)
                            {
                                var saldo = Reports_DA.GetPRO23(_plantilla.CodigoIc, item.Isin, cta.Cuenta, _fechaIni, _fechaInf).FirstOrDefault();

                                if (saldo != null)
                                {
                                    total += -saldo.impeur;//le cambiamos el signo
                                }
                            }

                            //lo calculamos por diferencia
                            var posCart = temp.PosicionCartera != null ? temp.PosicionCartera : 0;
                            temp.PosicionesCerradas = total - posCart;
                            temp.PosicionesCerradasNew = total - posCart;
                            temp.BoPTotal = total;

                            break;
                    }

                    if (temp != null)
                    {
                        lista.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Error RentaFija_VM/getTemp", ex);
                    throw;
                }
            }

            return lista;
        }

        private static void GetDatosGrupo6FromPro21(ref Temp_RentaFija temp, string isin)
        {
            isin = isin.ToUpper();

            //POSICIÓN EN CARTERA: PLEur del G1 y G4
            temp.PosicionCartera = _pro21.Where(w =>
                                    w.Isin.ToUpper() == isin
                                    && (
                                        w.Grupo.Contains("GRUPO-01")
                                        || w.Grupo.Contains("GRUPO-04")
                                    )
                                    ).Sum(s => s.PLEur);
            temp.PosicionCarteraNew = temp.PosicionCartera;

            //POSICIONES CERRADAS: PLEur del G2 y G3
            temp.PosicionesCerradas = _pro21.Where(w =>
                                    w.Isin.ToUpper() == isin
                                    && (
                                        w.Grupo.Contains("GRUPO-02")
                                        || w.Grupo.Contains("GRUPO-03")
                                    )
                                    ).Sum(s => s.PLEur);
            temp.PosicionesCerradasNew = temp.PosicionesCerradas;

            //TOTAL(€): PLEur de todos los grupos (comprobar que es la suma de POSICIÓN EN CARTERA + POSICIONES CERRADAS)
            temp.BoPTotal = _pro21.Where(w => w.Isin.ToUpper().Equals(isin)).Sum(s => s.PLEur);
        }

        private static void GetDatosGrupo6FromPro13(ref Temp_RentaFija temp, string isin)
        {
            isin = isin.ToUpper();

            //POSICIÓN EN CARTERA: PLEur del G1 y G4
            temp.PosicionCartera = VariablesGlobales.Pro13_Local.Where(w =>
                                    w.Isin.ToUpper() == isin
                                    && (
                                        w.Grupo.Contains("GRUPO-01")
                                        || w.Grupo.Contains("GRUPO-04")
                                    )
                                    ).Sum(s => s.PLEur);
            temp.PosicionCarteraNew = temp.PosicionCartera;
            //test ACC 05/04/2019----Start
            //introduir un bucle for que obri una finestra de warning si hi ha un instrument amb PLEur = NULL 

           // foreach (var position in _pro13r)
           // { }
            //test ACC 05/04/2019----End
                //POSICIONES CERRADAS: PLEur del G2 y G3
                temp.PosicionesCerradas = VariablesGlobales.Pro13_Local.Where(w =>
                                    w.Isin.ToUpper() == isin
                                    && (
                                        w.Grupo.Contains("GRUPO-02")
                                        || w.Grupo.Contains("GRUPO-03")
                                    )
                                    ).Sum(s => s.PLEur);
            temp.PosicionesCerradasNew = temp.PosicionesCerradas;

            //TOTAL(€): PLEur de todos los grupos (comprobar que es la suma de POSICIÓN EN CARTERA + POSICIONES CERRADAS)
            temp.BoPTotal = VariablesGlobales.Pro13_Local.Where(w => w.Isin.ToUpper().Equals(isin)).Sum(s => s.PLEur);
        }

        public static IQueryable<Temp_RentaFija> GetTemp(string codigoIC)
        {
            return RentaFija_DA.GetTemp(codigoIC);
        }
        public static Report GetReport(string codigoIC, string isinPlantilla, DateTime fechaInforme, DateTime fechaInicio)
        {
            Report rep = new ReportRentaFija();

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["IsinPlantilla"].Value = isinPlantilla;
            rep.ReportParameters["FechaInicio"].Value = fechaInicio;
            rep.ReportParameters["FechaInforme"].Value = fechaInforme;
            return rep;
        }

        //private static void ponerDescrGrupos(ref List<TempTableBase> listaTmp)
        //{
        //    var temp = listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList();
        //    temp.ForEach(s => s.GrupoDesc = ReportFunctions.TituloGrupoRF(Convert.ToInt64(s.Grupo), _fechaIni, _fechaInf));
        //}

    }
}
