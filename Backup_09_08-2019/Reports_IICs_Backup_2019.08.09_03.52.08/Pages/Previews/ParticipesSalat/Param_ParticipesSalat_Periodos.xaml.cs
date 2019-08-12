using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using MahApps.Metro.Controls;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Instrumentos;

namespace Reports_IICs.Pages.Previews.ParticipesSalat
{
    /// <summary>
    /// Lógica de interacción para Param_ParticipesSalat_Periodos.xaml
    /// </summary>
    public partial class Param_ParticipesSalat_Periodos : UserControl
    {
        public ParticipesSalat_Periodos paramParticipesSalat_Periodos;
        public List<ParticipesSalat_Periodos_Lineas> paramParticipesSalat_Periodos_Lineas;
        public bool Cancel = true;
        public int _noOfErrorsOnScreen = 0;
        private VM_Instrumentos DataSource = new VM_Instrumentos();

        public event EventHandler HasAddedaNewRow;

        public Param_ParticipesSalat_Periodos()
        {
            InitializeComponent();
        }

        public Param_ParticipesSalat_Periodos(ParticipesSalat_Periodos ParamParticipesSalat_Periodos, List<ParticipesSalat_Periodos_Lineas> ParamParticipesSalat_Periodos_Lineas)
        {
            InitializeComponent();
            //Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

            
            paramParticipesSalat_Periodos = ParamParticipesSalat_Periodos;
            paramParticipesSalat_Periodos_Lineas = ParamParticipesSalat_Periodos_Lineas;
            if(paramParticipesSalat_Periodos==null)
            {
                DpFechaSaldo.SelectedDate = DateTime.Now;
            }
            else

            {
                DpFechaSaldo.SelectedDate = paramParticipesSalat_Periodos.FechaSaldo;
               
            }

            GVDCAportNetasRealizadas.Header = "APORTACIONES " + Environment.NewLine + "NETAS" + Environment.NewLine + "REALIZADAS";
            if(DpFechaSaldo.SelectedDate!=null)
            {
                var fechaPeriodoAnterior = new DateTime(((DateTime)DpFechaSaldo.SelectedDate.Value).Year - 1, 12, 31);
                GVDCValorSicavEfectivo.Header = "VALOR SICAV +" + Environment.NewLine + "EFECTIVO A" + Environment.NewLine + fechaPeriodoAnterior.ToShortDateString();
                GVDCValorSicav.Header = "VALOR EN SICAV A" + Environment.NewLine + DpFechaSaldo.SelectedDate.Value.ToShortDateString();
                GVDCSaldoEfectivo.Header = "SALDO EFECTIVO A" + Environment.NewLine + DpFechaSaldo.SelectedDate.Value.ToShortDateString();
                GVDCResultado.Header = "RESULTADO" + Environment.NewLine + DpFechaSaldo.SelectedDate.Value.Year;
            }
            
           
            Loaded += OnLoaded;
            this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = paramParticipesSalat_Periodos_Lineas;
           
            //myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = fondos;

            //if (parametrosEvolucionPatrimonioConjuntoGuissona != null && string.IsNullOrEmpty(parametrosEvolucionPatrimonioConjuntoGuissona.Titulo)) textBoxTitulo.Focus();
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionParticipesSalat_Periodos_FirstChanged));

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {


            if (paramParticipesSalat_Periodos.Descripcion != null)
            {
                this.textBoxTitulo.Text = paramParticipesSalat_Periodos.Descripcion;
                ExpanderPeriod.Header = paramParticipesSalat_Periodos.Descripcion;
            }
            if (paramParticipesSalat_Periodos.FechaSaldo != null) this.DpFechaSaldo.SelectedDate = paramParticipesSalat_Periodos.FechaSaldo;

            Loaded -= OnLoaded;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void myEvolucionPatrimonioConjuntoGuissona_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        {

            bool? dialogResult = null;
            Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
            parameters.Content = "¿Esta seguro que desea eliminar?";

            parameters.Closed = (w, a) =>
            {
                dialogResult = a.DialogResult;
            };

            parameters.Header = "Eliminar";

            Telerik.Windows.Controls.RadWindow.Confirm(parameters);

            if (dialogResult == true)
            {
                #region Delete

                #endregion
            }
            else
            {
                //cancel
                e.Cancel = true;


            }

        }

        private void OnSelectionParticipesSalat_Periodos_FirstChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedValue = this.myEvolucionPatrimonioConjuntoGuissonaGrid.SelectedItem;

            if (e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    ParticipesSalat_Periodos_Lineas param_periodos_Lineas = new ParticipesSalat_Periodos_Lineas();
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myEvolucionPatrimonioConjuntoGuissonaGrid.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myEvolucionPatrimonioConjuntoGuissonaGrid.SelectedItem;
                    List<string> ListadoNoselected = new List<string>();
                    //foreach (GridViewRow item in rows)
                    //{
                    //    ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    //}
                    //ListadoNoselected.Remove(((Reports_IICs.DataModels.Temp_ParticipesSalat_Periodos_Lineas)selectedrow).Titular);
                    #endregion

                    //string wCodigoIC = string.Empty;
                    //string wCodigoICFondo = string.Empty;
                    //string wIsinFondo = string.Empty;
                    //string wdescripcion = string.Empty;
                    //DateTime wFechaDescripcion;
                    #region Create Custom object to take values

                    param_periodos_Lineas = (ParticipesSalat_Periodos_Lineas)this.myEvolucionPatrimonioConjuntoGuissonaGrid.SelectedItem;
                    //wCodigoIC = param_fondos.CodigoIC;
                    //wdescripcion = param_fondos.Descripcion;
                    //wFechaDescripcion = param_fondos.FechaConstitucion;
                    //wCodigoICFondo = param_fondos.CodigoICFondo;
                    //wIsinFondo = param_fondos.IsinFondo;
                    #endregion

                    bool first = false;

                    var window = new AddEditParticipesSalat_Periodos(paramParticipesSalat_Periodos.Id, param_periodos_Lineas, first, DpFechaSaldo.SelectedDate.Value);

                    if (window != null)
                    {
                        if (Application.Current.MainWindow != window)
                        {
                            window.Owner = Application.Current.MainWindow;
                            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            var ownerMetroWindow = (window.Owner as MetroWindow);
                            ownerMetroWindow.Height = window.Height;
                            ownerMetroWindow.Width = window.Width;
                            ownerMetroWindow.MinHeight = window.MinHeight;
                            ownerMetroWindow.MinWidth = window.MinWidth;
                            if (!ownerMetroWindow.IsOverlayVisible())
                                ownerMetroWindow.ShowOverlayAsync();
                        }

                        #region Create Custom object to take values

                        //plantilla_isins = (Plantillas_Isins)this.RadGridViewIsin.SelectedItem;
                        //wcodigo = plantilla_isins.Isin;
                        //wdescripcion = plantilla_isins.Descripcion;


                        #endregion


                        window.ShowDialog();

                        window.Owner = Application.Current.MainWindow;
                        var ownerMetroWindow2 = (window.Owner as MetroWindow);

                        if (ownerMetroWindow2.IsOverlayVisible())
                            ownerMetroWindow2.HideOverlayAsync();

                        if (!window.Cancel)
                        {
                            #region Retrieve Values from window

                            paramParticipesSalat_Periodos_Lineas.Remove(param_periodos_Lineas);

                            ParticipesSalat_Periodos_Lineas temp_item = new ParticipesSalat_Periodos_Lineas();
                            //temp_item.CodigoIC = window.CodigoIC;
                            //temp_item.Descripcion = window.Descripcion;
                            //temp_item.FechaConstitucion = window.FechaConstitucion;
                            //temp_item.CodigoICFondo = window.CodigoICFondo;
                            //temp_item.IsinFondo = window.IsinFondo;

                            param_periodos_Lineas = window.Param_Linea;

                            paramParticipesSalat_Periodos.Descripcion = this.textBoxTitulo.Text;
                            paramParticipesSalat_Periodos.FechaSaldo = (this.DpFechaSaldo.SelectedDate != null) ? this.DpFechaSaldo.SelectedDate.Value : DateTime.Now;
                            
                            paramParticipesSalat_Periodos_Lineas.Add(param_periodos_Lineas);
                            this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = null;
                            this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = paramParticipesSalat_Periodos_Lineas.OrderBy(c=>c.Id);

                            #endregion
                        }
                    }
                    #endregion

                    #endregion
                }
                #endregion

                #region Eliminar

                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Eliminar")
                {
                    bool? dialogResult = null;
                    Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
                    parameters.Content = "¿Esta seguro que desea eliminar?";

                    parameters.Closed = (w, a) =>
                    {
                        dialogResult = a.DialogResult;
                    };

                    parameters.Header = "Eliminar";

                    Telerik.Windows.Controls.RadWindow.Confirm(parameters);

                    if (dialogResult == true)
                    {
                        #region Delete

                        ParticipesSalat_Periodos_Lineas param_Peri_Lineas = new ParticipesSalat_Periodos_Lineas();
                        param_Peri_Lineas = (ParticipesSalat_Periodos_Lineas)this.myEvolucionPatrimonioConjuntoGuissonaGrid.SelectedItem;

                        //Borramos de DB
                        new Reports_IICs.DataAccess.Managers.ParticipesSalat_Periodos_Lineas_MNG().Delete(param_Peri_Lineas.Id);

                        paramParticipesSalat_Periodos_Lineas.Remove(param_Peri_Lineas);

                        this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = null;
                        this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = paramParticipesSalat_Periodos_Lineas;

                        #endregion
                    }
                    else
                    {
                        //cancel
                        //e.Cancel = true;


                    }

                }
                #endregion

            }

        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {

            #region Add new Row
            #region showWindow

            #region Fill List with List of Codes

            var rows = this.myEvolucionPatrimonioConjuntoGuissonaGrid.ChildrenOfType<GridViewRow>();

            List<string> ListadoNoselected = new List<string>();
            foreach (GridViewRow item in rows)
            {
                ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            }

            #endregion

            bool first = false;
            ParticipesSalat_Periodos_Lineas param_periodos_Lineas = new ParticipesSalat_Periodos_Lineas();

            var windowEvoPatrimConjGuissona = new AddEditParticipesSalat_Periodos(paramParticipesSalat_Periodos.Id, param_periodos_Lineas, first, DpFechaSaldo.SelectedDate.Value);
            if (windowEvoPatrimConjGuissona != null)
            {
                if (Application.Current.MainWindow != windowEvoPatrimConjGuissona)
                {
                    windowEvoPatrimConjGuissona.Owner = Application.Current.MainWindow;
                    windowEvoPatrimConjGuissona.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    var ownerMetroWindow = (windowEvoPatrimConjGuissona.Owner as MetroWindow);
                    ownerMetroWindow.Height = windowEvoPatrimConjGuissona.Height;
                    ownerMetroWindow.Width = windowEvoPatrimConjGuissona.Width;
                    ownerMetroWindow.MinHeight = windowEvoPatrimConjGuissona.MinHeight;
                    ownerMetroWindow.MinWidth = windowEvoPatrimConjGuissona.MinWidth;
                    if (!ownerMetroWindow.IsOverlayVisible())
                        ownerMetroWindow.ShowOverlayAsync();
                }

                #region Create Custom object to take values
                //switch (_elemento)
                //{
                //    case Utils.Elemento.Secciones:
                //        //SecciontoUpdate = (Seccione)this.radGridViewListado.SelectedItem;
                //        //window.Codigo = SecciontoUpdate.Id.ToString();
                //        //window.Descripcion = SecciontoUpdate.DescripcionLarga;

                //        break;

                //}
                #endregion



                windowEvoPatrimConjGuissona.ShowDialog();

                windowEvoPatrimConjGuissona.Owner = Application.Current.MainWindow;
                var ownerMetroWindow2 = (windowEvoPatrimConjGuissona.Owner as MetroWindow);

                if (ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();

                if (!windowEvoPatrimConjGuissona.Cancel)
                {
                    #region Retrieve Values from window

                    ParticipesSalat_Periodos_Lineas temp_item = new ParticipesSalat_Periodos_Lineas();
                    //temp_item.CodigoICFondo = windowEvoPatrimConjGuissona.CodigoICFondo;
                    //temp_item.Descripcion = windowEvoPatrimConjGuissona.Descripcion;
                    //temp_item.FechaConstitucion = windowEvoPatrimConjGuissona.FechaConstitucion;
                    //temp_item.IsinFondo = windowEvoPatrimConjGuissona.IsinFondo;
                    //temp_item.CodigoIC = windowEvoPatrimConjGuissona.CodigoIC;

                    temp_item = windowEvoPatrimConjGuissona.Param_Linea;
                    temp_item.IdParticipesSalatPeriodo = paramParticipesSalat_Periodos.Id;

                    paramParticipesSalat_Periodos.Descripcion = this.textBoxTitulo.Text;
                    paramParticipesSalat_Periodos.FechaSaldo =(this.DpFechaSaldo.SelectedDate!=null)?this.DpFechaSaldo.SelectedDate.Value:DateTime.Now;
                    
                    paramParticipesSalat_Periodos_Lineas.Add(temp_item);
                    paramParticipesSalat_Periodos.ParticipesSalat_Periodos_Lineas.Add(temp_item);

                    this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = null;
                    this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = paramParticipesSalat_Periodos_Lineas;

                    #endregion
                }
            }
            #endregion
            #endregion
            if (HasAddedaNewRow != null)
            {
                HasAddedaNewRow(this, new EventArgs());
            }            
        }

        private void DpFechaSaldo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var fechaPeriodoAnterior = new DateTime(((DateTime)DpFechaSaldo.SelectedDate.Value).Year - 1, 12, 31);
            GVDCValorSicavEfectivo.Header = "VALOR SICAV +" + Environment.NewLine + "EFECTIVO A" + Environment.NewLine + fechaPeriodoAnterior.ToShortDateString();
            GVDCValorSicav.Header = "VALOR EN SICAV A" + Environment.NewLine + DpFechaSaldo.SelectedDate.Value.ToShortDateString();
            GVDCSaldoEfectivo.Header = "SALDO EFECTIVO A" + Environment.NewLine + DpFechaSaldo.SelectedDate.Value.ToShortDateString();
            GVDCResultado.Header = "RESULTADO" + Environment.NewLine + DpFechaSaldo.SelectedDate.Value.Year;
            paramParticipesSalat_Periodos.FechaSaldo = this.DpFechaSaldo.SelectedDate.Value;
            if(DpFechaSaldo.SelectedDate.HasValue)
            {
                btn_ADD.Visibility = Visibility.Visible;
            }
            else
            {
                btn_ADD.Visibility = Visibility.Hidden;
            }
            new Reports_IICs.DataAccess.Managers.ParticipesSalat_Periodos_MNG().Save(paramParticipesSalat_Periodos, null);
        }

        private void textBoxTitulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (paramParticipesSalat_Periodos != null)
            {
                paramParticipesSalat_Periodos.Descripcion = this.textBoxTitulo.Text;
                ExpanderPeriod.Header = this.textBoxTitulo.Text;
                new Reports_IICs.DataAccess.Managers.ParticipesSalat_Periodos_MNG().Save(paramParticipesSalat_Periodos, null);
            }
        }
    }
}
