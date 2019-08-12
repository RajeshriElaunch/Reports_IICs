using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using MahApps.Metro.Controls;
using Reports_IICs.Helpers;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Plantillas;
using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.Managers;

namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Interaction logic for PlantillasPage.xaml
    /// </summary>
    public partial class PlantillasPage : UserControl
    {
        private Utils.Elemento _elemento;
       private PlantillasPage_VM DataSource = new PlantillasPage_VM();
       
        public PlantillasPage(Utils.Elemento elemento)
        {
            InitializeComponent();
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

            _elemento = elemento;
            if (_elemento != null)
            {
                populateData();
            }
        }

        private void populateData()
        {
            #region Preparing Colums

            Telerik.Windows.Controls.GridViewDataColumn C_id = new Telerik.Windows.Controls.GridViewDataColumn();
            C_id.Header = "IIC";
            C_id.Name = "IIC";
            C_id.DataMemberBinding = new System.Windows.Data.Binding("CodigoIc");
            C_id.IsReadOnly = true;
            C_id.IsVisible = true;
            C_id.Width = 50;
           
            Telerik.Windows.Controls.GridViewDataColumn C_Descripcion = new Telerik.Windows.Controls.GridViewDataColumn();
            C_Descripcion.Header = "Descripción";
            C_Descripcion.Name = "Descripcion";
            C_Descripcion.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
            C_Descripcion.DataMemberBinding = new System.Windows.Data.Binding("Descripcion");
            C_Descripcion.IsReadOnly = true;

            this.radGridViewPlantilla.AutoGenerateColumns = false;
            this.radGridViewPlantilla.GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            this.radGridViewPlantilla.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;



            #region remove colums before insert

            Telerik.Windows.Controls.RadGridView GridtoRemove = new Telerik.Windows.Controls.RadGridView();

            for (int i = 0; i < this.radGridViewPlantilla.Columns.Count; i++)
            {

                if (this.radGridViewPlantilla.Columns[i].UniqueName != "DeleteRow")
                {
                    if (this.radGridViewPlantilla.Columns[i].UniqueName != "EditRow")
                    {
                        this.radGridViewPlantilla.Columns.RemoveAt(i);
                        i--;
                    }

                }

            }

            #endregion

            #endregion

            ListadoTitulo.Text = _elemento.ToString();

            this.radGridViewPlantilla.ItemsSource = DataSource.Plantillas.OrderBy(c => c.Descripcion);
            this.radGridViewPlantilla.Columns.Add(C_id);
            this.radGridViewPlantilla.Columns.Add(C_Descripcion);
    
            
        }

        private void StackPanel_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //populateData();
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {

            #region Add new Row

            #region showWindow
            //int IdInserted = 0;
            //Instrumentos_Empresas EmpresatoAdd = new Instrumentos_Empresas();
            


            switch (_elemento)
            {
                
                default:
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.radGridViewPlantilla.ChildrenOfType<GridViewRow>();
                    List<string> ListaCodigo = new List<string>();
                    foreach (GridViewRow item in rows)
                    {
                        ListaCodigo.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    }

                    #endregion

                    Plantilla Addplantilla = new Plantilla();

                    var window = new AddEditPlantilla(Addplantilla, ListaCodigo);

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
                            ownerMetroWindow.MaxHeight = window.MaxHeight;
                            ownerMetroWindow.MaxWidth = window.MaxWidth;

                            if (!ownerMetroWindow.IsOverlayVisible())
                                ownerMetroWindow.ShowOverlayAsync();
                        }

                        window.ShowDialog();

                        window.Owner = Application.Current.MainWindow;
                        var ownerMetroWindow2 = (window.Owner as MetroWindow);

                        if (ownerMetroWindow2.IsOverlayVisible())
                            ownerMetroWindow2.HideOverlayAsync();

                        if (!window.Cancel)
                        {
                            #region Retrieve Values from window
                            //Plantilla plantilla_updated;
                            //if (DataSource.GuardarPlantilla((Plantilla)window._plantilla, ((Plantilla)window._plantilla).CodigoIc, out plantilla_updated))
                            //    {
                                    DataSource.Plantillas.Add((Plantilla)window._plantilla);
                               
                                    this.radGridViewPlantilla.ItemsSource = null;
                                    this.radGridViewPlantilla.ItemsSource = DataSource.Plantillas.OrderBy(c => c.Descripcion);
                                    // (Plantilla)window.Plantilla = plantilla_updated;

                            //}
                            //    else
                            //    {
                            //        RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });
                                
                            //    }
                            #endregion
                            #region go to last row after insert
                            this.radGridViewPlantilla.ScrollIntoViewAsync(this.radGridViewPlantilla.Items[this.radGridViewPlantilla.Items.Count - 1], //the row
                            this.radGridViewPlantilla.Columns[this.radGridViewPlantilla.Columns.Count - 1], //the column
                            new Action<FrameworkElement>((f) =>
                            {
                                (f as GridViewRow).IsSelected = true; // the callback method; if it is not necessary, you may set that parameter to null;
                            }));
                            #endregion
                        }
                    }
                    #endregion
                    break;

            }


            #endregion

            #endregion

        }


        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            var selectedValue = this.radGridViewPlantilla.SelectedItem;

            if (e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    
                    switch (_elemento)
                    {
                       
                        default:
                            #region default

                            #region Fill List with List of Codes

                            var rows = this.radGridViewPlantilla.ChildrenOfType<GridViewRow>();
                            var selectedrow = this.radGridViewPlantilla.SelectedItem;
                            List<string> ListadoNoselected = new List<string>();
                            foreach (GridViewRow item in rows)
                            {
                                ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                            }
                            ListadoNoselected.Remove(((Reports_IICs.DataModels.Plantilla)selectedrow).CodigoIc);
                            #endregion


                            #region Create Custom object to take values
                            //switch (_elemento)
                            //{
                            //    case Utils.Elemento.Secciones:
                            //        SecciontoUpdate = (Seccione)this.radGridViewPlantilla.SelectedItem;
                            //        wcodigo = SecciontoUpdate.Id.ToString();
                            //        //window.Descripcion = SecciontoUpdate.DescripcionLarga;

                            //        break;

                            #endregion

                            string codigoICBeforeUpdate = ((Plantilla)this.radGridViewPlantilla.SelectedItem).CodigoIc;

                            var plantillaBD = new PlantillaManager().GetPlantilla(codigoICBeforeUpdate);
                            //var plantillaBD = PlantillasPage_VM.GetPlantilla(codigoICBeforeUpdate);
                            //var plantillaBD = new PlantillaManager().Get(codigoICBeforeUpdate);

                           // var window = new AddEditPlantilla((Plantilla)this.radGridViewPlantilla.SelectedItem, ListadoNoselected);
                            var window = new AddEditPlantilla(plantillaBD, ListadoNoselected);

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
                                    ownerMetroWindow.MaxHeight = window.MaxHeight;
                                    ownerMetroWindow.MaxWidth = window.MaxWidth;
                                    if (!ownerMetroWindow.IsOverlayVisible())
                                        ownerMetroWindow.ShowOverlayAsync();
                                }

                                #region Create Custom object to take values
                                //switch (_elemento)
                                //{
                                //    case Utils.Elemento.Secciones:
                                //        SecciontoUpdate = (Seccione)this.radGridViewPlantilla.SelectedItem;
                                //        window.Codigo = SecciontoUpdate.Id.ToString();
                                //        //window.Descripcion = SecciontoUpdate.DescripcionLarga;

                                //        break;

                                #endregion


                                window.textBoxICC.IsReadOnly = true;
                                window.ShowDialog();

                                window.Owner = Application.Current.MainWindow;
                                var ownerMetroWindow2 = (window.Owner as MetroWindow);

                                if (ownerMetroWindow2.IsOverlayVisible())
                                    ownerMetroWindow2.HideOverlayAsync();

                                if (!window.Cancel)
                                {
                                    #region Retrieve Values from window
                                   
                                    try
                                    {
                                        // Do not initialize this variable here.
                                        /*Plantilla plantilla_updated;
                                        if (DataSource.GuardarPlantilla((Plantilla)window._plantilla, codigoICBeforeUpdate, out plantilla_updated))
                                        {
                                            //DataSource.Plantillas.Remove((Plantilla)this.radGridViewPlantilla.SelectedItem);
                                            //DataSource.Plantillas.Add((Plantilla)window._plantilla);
                                            this.radGridViewPlantilla.ItemsSource = null;
                                            this.radGridViewPlantilla.ItemsSource = (Plantilla)window._plantilla;
                                            //this.radGridViewPlantilla.ItemsSource = DataSource.Plantillas.OrderBy(c => c.Descripcion);
                                            
                                        }
                                        else
                                        {
                                            RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                                        }
                                        */
                                    }
                                    catch(Exception ex)
                                    {
                                        throw ex;
                                    }


                                    
                                    #endregion
                                }
                            }
                            #endregion
                            break;
                    }



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
                        DataSource.Plantillas.Remove((Plantilla)this.radGridViewPlantilla.SelectedItem);
                        Plantillas_DA.DeletePlantilla((Plantilla)this.radGridViewPlantilla.SelectedItem);
                        this.radGridViewPlantilla.ItemsSource = null;
                        this.radGridViewPlantilla.ItemsSource = DataSource.Plantillas.OrderBy(c => c.Descripcion);

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

    }
}
