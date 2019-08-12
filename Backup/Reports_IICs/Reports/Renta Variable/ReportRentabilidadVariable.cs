namespace Reports_IICs.Reports.Renta_Variable
{
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Secciones;


    /// <summary>
    /// Summary description for ReportRentabilidadVariable.
    /// </summary>
    public partial class ReportRentabilidadVariable : Telerik.Reporting.Report
    {
        //Esta variable la utilizaremos para ocultar la cabecera en caso de que ningún subreports sea visible
        private List<bool> subreportsVisibles = new List<bool>();
        private List<Temp_RentaVariable> _tempRV;
        private List<Plantillas_Estrategias> _estrategias;        
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();
        public ReportRentabilidadVariable()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportRentabilidadVariable(string isin, string codigoic, DateTime fechaInforme, DateTime fechaInicio)
        {
            InitializeComponent();
            var estr = dbContext.Plantillas_Estrategias.Where(w => w.CodigoIC == codigoic);
            if (estr !=null)
            {
                _estrategias = dbContext.Plantillas_Estrategias.Where(w => w.CodigoIC == codigoic).ToList();
            }
            else
            {
                _estrategias = null;
            }
            
            _tempRV = RentaVariable_DA.GetTemp(codigoic).ToList();
            hideSubreports();

            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.ReportParameters["FechaInforme"].Value = fechaInforme;
            this.ReportParameters["FechaAnterior"].Value = fechaInicio;
            //this.sqlDataSource1.Parameters[0].Value = codigoic;

            //this.sqlDataSource1.Parameters[1].Value = null;

            //this.subReportGRUPO1.Parameters["Title"].Value = "1) Valores que teníamos en cartera a " + fechaInicio.ToShortDateString()+ " y no se han vendido en " + fechaInforme.Year ;
            //this.subReportGRUPO2.Parameters["Title"].Value = "2) Valores que teníamos en cartera el " + fechaInicio.ToShortDateString() + " y se han vendido en " + fechaInforme.Year;
            //this.subReportGRUPO3.Parameters["Title"].Value = "3) Valores que se han comprado y vendido en " + fechaInforme.Year;
            //this.subReportGRUPO4.Parameters["Title"].Value = "4) Valores que se han comprado en " + fechaInforme.Year + " y no se han vendido en " + fechaInforme.Year;

            this.subReportGRUPO1.Parameters["Title"].Value = string.Format(Resources.Resource.RVGrupo01, fechaInicio.ToShortDateString(), fechaInforme.Year);
            this.subReportGRUPO2.Parameters["Title"].Value = string.Format(Resources.Resource.RVGrupo02, fechaInicio.ToShortDateString(), fechaInforme.Year);
            this.subReportGRUPO3.Parameters["Title"].Value = string.Format(Resources.Resource.RVGrupo03, fechaInforme.Year);
            this.subReportGRUPO4.Parameters["Title"].Value = string.Format(Resources.Resource.RVGrupo04, fechaInforme.Year, fechaInforme.Year);
        }

        /// <summary>
        /// Ocultamos los subreports que no tengan datos
        /// </summary>
        private void hideSubreports()
        {
            //RVA && DER
            if(_tempRV.Count(w => w.IdInstrumento=="1" && w.IdTipoInstrumento == "3") == 0)
                this.subReportDerivados.Visible = false;

            //RAB
            if(!_tempRV.Any(w => w.IdInstrumento == "3"))
            {

                //this.subReportRetornoAbsoluto.Visible = false;
                ////añadimos esta línea porque no funciona sólo con Visible
                //this.subReportRetornoAbsoluto.ReportSource = null;

                //Mostrar los subreports referentes a retorno absoluto siempre
                //que el ICC tenga estratégias activadas de retorno absoluto, 
                //o si el IIC ha realizado operaciones con fondos de retorno
                //absoluto (compra, venta...)

                if (_tempRV.Any(w => w.IdTipoInstrumento == "5") || _tempRV.Any(w => w.IdTipoInstrumento == "12") || _tempRV.Any(w => w.IdTipoInstrumento == "11"))
                {
                    if (_estrategias !=null)
                    {
                        this.subReportRetornoAbsoluto.Visible = true;
                    }
                    
                }
                
                else  
                 {
                this.subReportRetornoAbsoluto.Visible = false;                
                this.subReportRetornoAbsoluto.ReportSource = null;
                }
                
            }
            
            //if (_tempRV.Any(w => w.IdTipoInstrumento == "5") || _tempRV.Any(w => w.IdTipoInstrumento == "12") || _tempRV.Any(w => w.IdTipoInstrumento == "11"))
            //{
            //    this.subReportRetornoAbsoluto.Visible = true;
            //}
               
            //GAR
            if (!_tempRV.Any(w => w.IdInstrumento == "12"))
                this.subReportGarantizados_Estructurados.Visible =  false;            

            //DIV && DER
            if(!_tempRV.Any(w => w.IdInstrumento == "13" && w.IdTipoInstrumento=="3"))
                this.subReportDivisas.Visible = false;            

            //COM
            if(!_tempRV.Any(w => w.IdInstrumento == "15"))            
                this.subReportCommodities.Visible = false;
        }

        private void ReportRentabilidadVariable_ItemDataBound(object sender, EventArgs e)
        {
            //si no existe ningún subreport con Visible = true
            //No mostramos nada
            if (!subreportsVisibles.Exists(ex => ex))
            {
                this.Visible = false;
            }
        }

        private void subReportTotalRV_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void subReportTotalRAB_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void subReportTotalGAR_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }
        /*
        private void subReportGRUPO1_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void subReportGRUPO2_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void subReportGRUPO3_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void subReportGRUPO4_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void subReportRetornoAbsoluto_ItemDataBound(object sender, EventArgs e)
        {
            
            //var rabCount = _tempRV.Where(w => w.IdInstrumento == "3").Count();
            //if (rabCount == 0)
            //{
            //    this.subReportRetornoAbsoluto.Visible = false;
            //    //añadimos esta línea porque no funciona sólo con Visible
            //    this.subReportRetornoAbsoluto.ReportSource = null;
            //}
        }

        private void subReportGarantizados_Estructurados_ItemDataBound(object sender, EventArgs e)
        {
            var garCount = _tempRV.Where(w => w.IdInstrumento == "12").Count();
            if (garCount == 0)
            {
                this.subReportGarantizados_Estructurados.Visible = false;
                //añadimos esta línea porque no funciona sólo con Visible
                this.subReportGarantizados_Estructurados.ReportSource = null;
            }
        }
        
        

        private void subReportDerivados_ItemDataBound(object sender, EventArgs e)
        {
            var derCount = _tempRV.Where(w => w.IdTipoInstrumento == "3").Count();
            if (derCount == 0)
            {
                this.subReportDerivados.Visible = false;
                //añadimos esta línea porque no funciona sólo con Visible
                this.subReportDerivados.ReportSource = null;
            }
        }

        private void subReportDivisas_ItemDataBound(object sender, EventArgs e)
        {
            var divCount = _tempRV.Where(w => w.IdInstrumento == "13").Count();
            if (divCount == 0)
            {
                this.subReportDivisas.Visible = false;
                //añadimos esta línea porque no funciona sólo con Visible
                this.subReportDivisas.ReportSource = null;
            }
        }

        private void subReportCommodities_ItemDataBound(object sender, EventArgs e)
        {
            var comCount = _tempRV.Where(w => w.IdInstrumento == "15").Count();
            if (comCount == 0)
            {
                this.subReportCommodities.Visible = false;
                //añadimos esta línea porque no funciona sólo con Visible
                this.subReportCommodities.ReportSource = null;
            }
        }

        private void subReportRetornoAbsoluto_ItemDataBinding(object sender, EventArgs e)
        {
            var garCount = _tempRV.Where(w => w.IdInstrumento == "12").Count();
            if (garCount == 0)
            {
                this.subReportGarantizados_Estructurados.Visible = false;
                //añadimos esta línea porque no funciona sólo con Visible
                this.subReportGarantizados_Estructurados.ReportSource = null;
            }
        }

        private void subReportGarantizados_Estructurados_ItemDataBinding(object sender, EventArgs e)
        {

        }*/
    }
}