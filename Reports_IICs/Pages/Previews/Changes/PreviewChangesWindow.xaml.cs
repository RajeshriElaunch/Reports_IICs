using MahApps.Metro.Controls;
using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataModels;
using Reports_IICs.Pages.Previews.Changes.UserControls;
using Reports_IICs.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Changes
{
    /// <summary>
    /// Interaction logic for PreviewChangesWindow.xaml
    /// </summary>
    public partial class PreviewChangesWindow : MetroWindow
    {
        private List<string> namesHide = new List<string>() { "Id", "Modificacion" };
        private int _idSeccion;
        protected string _codigoIC;
        protected IEnumerable<Object> _itemsToBeDeleted;
        private RadGridView _myGrid = new RadGridView();
        private DateTime _fechaInforme;
        public bool HasChanged = false;
        public PreviewChangesWindow(int idSeccion, string codigoIC, DateTime fechaInforme)
        {
            InitializeComponent();

            _idSeccion = idSeccion;
            _codigoIC = codigoIC;
            _fechaInforme = fechaInforme;
            HasChanged = false;

            try
            {
                loadUserControls();                                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadUserControls()
        {
            this.StackPanelUC.Children.Clear();
            
            switch (_idSeccion)
            {
                case 13:
                    var uc13 = new RentaVariable_CHN(_codigoIC, _fechaInforme);
                    this.StackPanelUC.Children.Add(uc13);
                    break;
                case 14:
                    var uc14 = new CompraVentaPrecAdq_CHN(_codigoIC, _fechaInforme);
                    this.StackPanelUC.Children.Add(uc14);
                    break;
                case 21:
                    var uc21 = new RentaFija_CHN(_codigoIC, _fechaInforme);
                    this.StackPanelUC.Children.Add(uc21);
                    break;
            }
        }        

        private void myGrid_Deleting(object sender, GridViewDeletingEventArgs e)
        {
            //store the items to be deleted
            _itemsToBeDeleted = e.Items;

            //cancel the event so the item is not deleted
            //and wait for the user confirmation
            e.Cancel = true;
            //open the Confirm dialog
            if (_itemsToBeDeleted.FirstOrDefault() != null)
            {
                var nombre = getItemDesc(_itemsToBeDeleted.FirstOrDefault());
                string mensaje = string.Format("¿Seguro que quieres eliminar {0}?. Este registro no volverá a aparecer en futuras generaciones.", nombre);

                RadWindow.Confirm(new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 }, this.OnRadWindowClosed);                
            }
        }

        private void OnRadWindowClosed(object sender, WindowClosedEventArgs e)
        {
            //check whether the user confirmed
            bool shouldDelete = e.DialogResult.HasValue ? e.DialogResult.Value : false;
            if (shouldDelete)
            {
                foreach (var item in _itemsToBeDeleted)
                {
                    #region sólo para las secciones que guardemos que una fila ha sido eliminada
                    switch (_idSeccion)
                    {
                        case 13://RENTA VARIABLE 
                            //new Temp_RentaVariable_MNG().Delete(((Temp_RentaVariable)item).Id);
                            break;
                        case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN                            
                            //new Preview_CompraVentaPrecAdq_MNG().Save(prev14, null);                            
                            break;
                        case 21://RENTA FIJA
                            //new Preview_RentaFija_MNG().Save(prev21, null);                            
                            break;
                        case 37://CARTERA RV CCR-VOLGA-GAMAR
                            //new Temp_CarteraCcrVolgaGamar_MNG().Delete(((Temp_CarteraCcrVolgaGamar)item).Id);                            
                            break;
                    }

                    #endregion

                    #region general
                    //Lo eliminamos del grid (esto se hace para cualquier sección)
                    _myGrid.Items.Remove(item);
                    #endregion
                }
            }
        }

        /// <summary>
        /// La idea es que esta ventana sea dinámica y valga para todas las secciones y cada vez que 
        /// haya una sección nueva tengamos que tocar lo menos posible
        /// No es aconsejable utilizar dynamic types
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string getItemDesc(dynamic item)
        {
            string output = string.Empty;
            if (!string.IsNullOrEmpty(item.Descripcion))
            {
                output = item.Descripcion;
            }

            return output.Trim();
        }

        private void myGrid_DataLoaded(object sender, EventArgs e)
        {
            //No queremos scroll horizontal
            foreach (var column in _myGrid.Columns)
            {
                column.Width = GridViewLength.SizeToHeader;
                column.Width = GridViewLength.Auto;
            }
        }

        private void radButton_Click(object sender, RoutedEventArgs e)
        {
            string message = "¿Seguro que desea elimar las filas seleccionadas?";
            RadWindow.Confirm(message,
                    delegate (object windowSender, WindowClosedEventArgs args)
                    {
                        if (args.DialogResult == true)
                        {
                            eliminar();
                        }
                    });
            
        }

        private void eliminar()
        {
            var plantilla = Plantillas_DA.GetPlantilla(_codigoIC);
            
            var rgv = this.StackPanelUC.ChildrenOfType<RadGridView>().First();

            if (rgv != null)
            {
                HasChanged = true;

                foreach (var item in rgv.SelectedItems)
                {
                    switch (_idSeccion)
                    {
                        case 13:
                            new Preview_RentaVariable_MNG().Delete(((Get_PreviewChanges_RentaVariable_Result)item).Id);
                            //Regeneramos la sección de RV y las secciones dependientes.                            
                            //Report_VM.CopyPlantillaToTemp(plantilla, _fechaInforme, true, true);
                            break;
                        case 14:
                            new Preview_CompraVentaPrecAdq_MNG().Delete(((Get_PreviewChanges_CompraVentaPrecAdq_Result)item).Id);
                            
                            break;
                        case 21:
                            new Preview_RentaFija_MNG().Delete(((Get_PreviewChanges_RentaFija_Result)item).Id);
                            break;
                    }                 
                }

                if (_idSeccion == 13)
                {
                    //Si se han eliminado cambios de la sección 13 tenemos que regenerar las secciones dependientes
                    ReportVM.CopyPlantillaToTemp(plantilla, _fechaInforme, true, true, false, false);
                }
                else if (_idSeccion == 21)
                {
                    //Si se han eliminado cambios de la sección 21 tenemos que regenerar las secciones dependientes
                    ReportVM.CopyPlantillaToTemp(plantilla, _fechaInforme, false, false, true, true);
                }

                loadUserControls();
            }
        }
    }
}
