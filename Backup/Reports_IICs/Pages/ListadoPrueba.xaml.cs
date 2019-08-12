using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.Helpers;
using System;
using System.Windows.Controls;
using Reports_IICs.DataModels;
using System.Linq;
using Reports_IICs.ViewModels.Instrumentos;
using System.Windows.Input;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using MahApps.Metro.Controls;
using Reports_IICs.Pages.Secciones;
using System.Collections.Generic;


namespace Reports_IICs.Pages
{
    /// <summary>
    /// Interaction logic for ListadoPrueba.xaml
    /// </summary>
    public partial class ListadoPrueba : UserControl, IContent
    {
       

        private Utils.Elemento _elemento;
        private VM_Instrumentos DataSource = new VM_Instrumentos();

       

        public ListadoPrueba(Utils.Elemento elemento)
        {
            // Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

            this.DataContext = new VM_Instrumentos();

            InitializeComponent();
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

            _elemento = elemento;
            if (_elemento != null)
            {
                populateData();
            }
        }

        private void Frame_OnNavigated(object sender, NavigationEventArgs e)
        {
        }

     
        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            _elemento = (Utils.Elemento) Enum.Parse(typeof(Utils.Elemento), e.Fragment, true);
            if(_elemento != null)
            {
                populateData();
            }
                
        }
        public void OnNavigatedFrom(NavigationEventArgs e)
        {
           
        }
        public void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }
        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
           

        }

        private void configureGridColums()
        {
            switch (_elemento)
            {
                case Utils.Elemento.Secciones:
                    break;
            }
        }

        private void populateData()
        {
            #region Preparing Colums

            Telerik.Windows.Controls.GridViewDataColumn C_id = new Telerik.Windows.Controls.GridViewDataColumn();
            C_id.Header = "Id";
            C_id.Name = "Id";
            C_id.DataMemberBinding = new System.Windows.Data.Binding("Id");
            C_id.IsReadOnly = true;
            C_id.IsVisible = false;
            

            Telerik.Windows.Controls.GridViewDataColumn C_Descripcion = new Telerik.Windows.Controls.GridViewDataColumn();
            C_Descripcion.Header = "Código";
            C_Descripcion.Name = "Codigo";
            C_Descripcion.DataMemberBinding = new System.Windows.Data.Binding("Codigo");
            C_Descripcion.EditorStyle = (System.Windows.Style)this.Resources["Max3GroupCodeStyle"];
            C_Descripcion.IsReadOnly = true;
           
            Telerik.Windows.Controls.GridViewDataColumn C_DescripcionLarga = new Telerik.Windows.Controls.GridViewDataColumn();
            C_DescripcionLarga.Header = "Descripción";
            C_DescripcionLarga.Name = "Descripcion";
            C_DescripcionLarga.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"]; 
            C_DescripcionLarga.DataMemberBinding = new System.Windows.Data.Binding("Descripcion");
            C_DescripcionLarga.IsReadOnly = true;

            //Telerik.Windows.Controls.GridViewDataColumn C_Category = new Telerik.Windows.Controls.GridViewDataColumn();
            //C_Category.Header = "Categoria";
            //C_Category.Name = "Categoria";
            //C_Category.DataMemberBinding = new System.Windows.Data.Binding("Descripcion");
            //C_Category.EditorStyle = (System.Windows.Style)this.Resources["Max3GroupCodeStyle"];
            //C_Category.IsReadOnly = true;

            this.radGridViewListado.AutoGenerateColumns = false;
            this.radGridViewListado.GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            this.radGridViewListado.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;

            

            #region remove colums before insert

            Telerik.Windows.Controls.RadGridView GridtoRemove = new Telerik.Windows.Controls.RadGridView();

            for (int i = 0; i < this.radGridViewListado.Columns.Count; i++)
            {
                
                 if (this.radGridViewListado.Columns[i].UniqueName != "DeleteRow" )
                 {
                    if(this.radGridViewListado.Columns[i].UniqueName != "EditRow")
                    {
                        if (this.radGridViewListado.Columns[i].UniqueName != "CategoriasRow")
                        {
                            //_elemento!= Utils.Elemento.Instrumentos_Sectores  &&
                            this.radGridViewListado.Columns.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            if (this.radGridViewListado.Columns[i].UniqueName == "CategoriasRow")
                            {
                                if(_elemento != Utils.Elemento.InstrumentosSectores)
                                {
                                    this.radGridViewListado.Columns.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                     
                 }
                    
            }

            #endregion

            #endregion

            ListadoTitulo.Text = _elemento.ToString();
            switch (_elemento)
            {
                case Utils.Elemento.Secciones:

                    C_Descripcion.EditorStyle = (System.Windows.Style)this.Resources["Max100GroupCodeStyle"]; 
                    this.radGridViewListado.ItemsSource = DataSource.Secciones.OrderBy(c => c.Descripcion);
                    this.radGridViewListado.Columns.Add(C_id);
                    //this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 600;
                    break;

                case Utils.Elemento.Instrumentos:

                    this.radGridViewListado.ItemsSource = DataSource.Instrumentos.OrderBy(c => c.Codigo);
                    this.radGridViewListado.Columns.Add(C_id);
                    this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 400;
                    break;

                case Utils.Elemento.InstrumentosCategorias:

                    this.radGridViewListado.ItemsSource = DataSource.instrumentosCategorias.OrderBy(c => c.Codigo);
                    this.radGridViewListado.Columns.Add(C_id);
                    this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 400;
                    break;

                case Utils.Elemento.InstrumentosEmpresas:

                    this.radGridViewListado.ItemsSource = DataSource.instrumentosEmpresas.OrderBy(c => c.Codigo);
                    this.radGridViewListado.Columns.Add(C_id);
                    this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 400;
                    break;

                case Utils.Elemento.InstrumentosPaises:

                    this.radGridViewListado.ItemsSource = DataSource.instrumentosPaises.OrderBy(c => c.Codigo);
                    this.radGridViewListado.Columns.Add(C_id);
                    this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 400;
                    break;
                case Utils.Elemento.InstrumentosDivisas:

                    this.radGridViewListado.ItemsSource = DataSource.instrumentosDivisas.OrderBy(c => c.Codigo);
                    this.radGridViewListado.Columns.Add(C_id);
                    this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 400;
                    break;

                case Utils.Elemento.InstrumentosTipos:

                    this.radGridViewListado.ItemsSource = DataSource.instrumentosTipos.OrderBy(c => c.Codigo);
                    this.radGridViewListado.Columns.Add(C_id);
                    this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 400;
                    break;

                case Utils.Elemento.InstrumentosZonas:

                    this.radGridViewListado.ItemsSource = DataSource.instrumentosZonas.OrderBy(c => c.Codigo);
                    this.radGridViewListado.Columns.Add(C_id);
                    this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 400;
                    break;
                case Utils.Elemento.InstrumentosImportados:
                    
                    this.radGridViewListado.AutoGenerateColumns = true;
                    this.radGridViewListado.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;
                    this.radGridViewListado.ItemsSource = DataSource.InstrumentosImportadosNoJoin;
                    BtnAddNewrow.Visibility = Visibility.Hidden;
                    break;

                case Utils.Elemento.BloombergImportados:

                    this.radGridViewListado.AutoGenerateColumns = true;
                    this.radGridViewListado.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;
                    this.radGridViewListado.ItemsSource = DataSource.Bloombergs;
                    BtnAddNewrow.Visibility = Visibility.Hidden;
                    break;
                case Utils.Elemento.InstrumentosSectores:

                    C_Descripcion.EditorStyle = (System.Windows.Style)this.Resources["Max100GroupCodeStyle"];
                    this.radGridViewListado.ItemsSource = DataSource.instrumentosSectores.OrderBy(c => c.Descripcion);
                    this.radGridViewListado.Columns.Add(C_id);
                    //this.radGridViewListado.Columns.Add(C_Descripcion);
                    this.radGridViewListado.Columns.Add(C_DescripcionLarga);
                    this.radGridViewListado.MaxWidth = 600;
                    break;
            }
        }

        private void radGridViewListado_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            
        }

        private void radGridViewListado_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

           
        }

        private void radGridViewListado_RowEditEnded(object sender, Telerik.Windows.Controls.GridViewRowEditEndedEventArgs e)
        {
            #region Declare 
            Instrumentos_Empresas NVtoupdate = new Instrumentos_Empresas();
            Instrumentos_Categorias NVtoupdateCat = new Instrumentos_Categorias();
            Instrumento NVtoupdateInst = new Instrumento();
            Instrumentos_Paises NVtoupdatePais = new Instrumentos_Paises();
            Instrumentos_Tipos NVtoupdateTipo = new Instrumentos_Tipos();
            Instrumentos_Zonas NVtoupdateZona = new Instrumentos_Zonas();
            Instrumentos_Divisas NVtoupdateDivisa = new Instrumentos_Divisas();
            Seccione NVtoupdateSeccion = new Seccione();

            System.Windows.Controls.TextBlock isTextBlock = new TextBlock();
            Telerik.Windows.Controls.GridView.GridViewEditorPresenter isPresenter = new Telerik.Windows.Controls.GridView.GridViewEditorPresenter();
            System.Windows.Controls.Grid isGrid = new Grid();

            #endregion

            switch (_elemento)
            {
                case Utils.Elemento.Secciones:
                    #region Secciones

                    if (((Seccione)e.Row.DataContext).Id == 0)
                    {
                        #region Insert

                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateSeccion.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateSeccion.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isGrid.GetType())) NVtoupdateSeccion.Descripcion = ((Reports_IICs.DataModels.Seccione)((System.Windows.FrameworkElement)(e.Row.Cells[0].Content)).DataContext).Descripcion;

                        if (!String.IsNullOrEmpty(NVtoupdateSeccion.Descripcion) )
                        {
                            int IdInserted = Secciones_DA.Insert(NVtoupdateSeccion);
                           
                            DataSource.Secciones.Last().Id = IdInserted;
                            VM_Instrumentos.GetSecciones();
                        }
                        #endregion

                    }
                    else
                    {
                        #region We have to Update

                        NVtoupdateSeccion.Id = ((Seccione)e.Row.DataContext).Id;
                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateSeccion.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateSeccion.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isGrid.GetType())) NVtoupdateSeccion.Descripcion = ((Reports_IICs.DataModels.Seccione)((System.Windows.FrameworkElement)(e.Row.Cells[0].Content)).DataContext).Descripcion;

                        Secciones_DA.Update(NVtoupdateSeccion);



                        #endregion
                    }

                    if (((Seccione)e.Row.DataContext).Id == 0)
                    {
                        if (((Seccione)e.Row.DataContext).Descripcion == null )
                        {
                            if (DataSource.Secciones.Count > 0)
                            {
                                DataSource.Secciones.RemoveAt(DataSource.Secciones.Count - 1);
                            }

                        }

                    }

                   
                    #endregion
                    break;
                case Utils.Elemento.Instrumentos:
                    #region Instrumentos


                    if (((Instrumento)e.Row.DataContext).Id == "0")
                    {
                        #region Insert

                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateInst.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateInst.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateInst.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateInst.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;

                        if (!String.IsNullOrEmpty(NVtoupdateInst.Codigo) || !String.IsNullOrEmpty(NVtoupdateInst.Descripcion))
                        {
                            int IdInserted = Instrumentos_DA.Insert(NVtoupdateInst);
                            
                            DataSource.Instrumentos.Last().Id = IdInserted.ToString();
                            VM_Instrumentos.GetInstrumentos();
                        }
                        #endregion

                    }
                    else
                    {
                        #region We have to Update

                        NVtoupdateInst.Id = ((Instrumento)e.Row.DataContext).Id;
                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateInst.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateInst.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateInst.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateInst.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        Instrumentos_DA.Update(NVtoupdateInst);



                        #endregion
                    }

                    if (((Instrumento)e.Row.DataContext).Id == "0")
                    {
                        if (((Instrumento)e.Row.DataContext).Codigo == null && ((Instrumento)e.Row.DataContext).Descripcion == null)
                        {
                            if (DataSource.Instrumentos.Count > 0)
                            {
                                DataSource.Instrumentos.RemoveAt(DataSource.Instrumentos.Count - 1);
                            }

                        }

                    }
                   
                    #endregion
                    break;
                case Utils.Elemento.InstrumentosCategorias:
                    #region Categorias

                   
                    if (((Instrumentos_Categorias)e.Row.DataContext).Id == 0)
                    {
                        #region Insert

                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateCat.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateCat.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateCat.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateCat.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;

                        if (!String.IsNullOrEmpty(NVtoupdateCat.Codigo) || !String.IsNullOrEmpty(NVtoupdateCat.Descripcion))
                        {
                            int IdInserted = InstrumentosCategorias_DA.Insert(NVtoupdateCat);
                            //((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text = IdInserted.ToString();
                            DataSource.instrumentosCategorias.Last().Id = IdInserted;
                            VM_Instrumentos.GetCategorias();
                        }
                        #endregion

                    }
                    else
                    {
                        #region We have to Update

                        NVtoupdateCat.Id = ((Instrumentos_Categorias)e.Row.DataContext).Id;
                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateCat.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateCat.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateCat.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateCat.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        InstrumentosCategorias_DA.Update(NVtoupdateCat);



                        #endregion
                    }

                    if (((Instrumentos_Categorias)e.Row.DataContext).Id == 0)
                    {
                        if (((Instrumentos_Categorias)e.Row.DataContext).Codigo == null && ((Instrumentos_Categorias)e.Row.DataContext).Descripcion == null)
                        {
                            if (DataSource.instrumentosCategorias.Count > 0)
                            {
                                DataSource.instrumentosCategorias.RemoveAt(DataSource.instrumentosCategorias.Count - 1);
                            }

                        }

                    }
                    #endregion
                    break;
                case Utils.Elemento.InstrumentosEmpresas:
                    #region Empresas

                  


                    if (((Instrumentos_Empresas)e.Row.DataContext).Id == 0)
                    {
                        #region Insert

                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdate.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdate.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        if (e.Row.Cells[2].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdate.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[2].Content)).Text;
                        if (e.Row.Cells[2].Content.GetType().Equals(isPresenter.GetType())) NVtoupdate.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[2].Content)).Content)).Text;

                        if (!String.IsNullOrEmpty(NVtoupdate.Codigo) || !String.IsNullOrEmpty(NVtoupdate.Descripcion))
                        {
                            int IdInserted = InstrumentosEmpresas_DA.Insert(NVtoupdate);
                            //((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text = IdInserted.ToString();
                            DataSource.instrumentosEmpresas.Last().Id = IdInserted;
                            VM_Instrumentos.GetEmpresas();
                        }
                        #endregion

                    }
                    else
                    {
                        #region We have to Update

                        NVtoupdate.Id = ((Instrumentos_Empresas)e.Row.DataContext).Id;
                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdate.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdate.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdate.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdate.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        InstrumentosEmpresas_DA.Update(NVtoupdate);



                        #endregion
                    }

                    if (((Instrumentos_Empresas)e.Row.DataContext).Id == 0)
                    {
                        if (((Instrumentos_Empresas)e.Row.DataContext).Codigo == null && ((Instrumentos_Empresas)e.Row.DataContext).Descripcion == null)
                        {
                            if (DataSource.instrumentosEmpresas.Count > 0)
                            {
                                DataSource.instrumentosEmpresas.RemoveAt(DataSource.instrumentosEmpresas.Count - 1);
                            }

                        }

                    }

                    
                    #endregion

                    break;
                case Utils.Elemento.InstrumentosDivisas:
                    #region Divisas
                    
                    if (((Instrumentos_Divisas)e.Row.DataContext).Id == 0)
                    {
                        #region Insert

                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateDivisa.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateDivisa.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        if (e.Row.Cells[2].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateDivisa.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[2].Content)).Text;
                        if (e.Row.Cells[2].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateDivisa.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[2].Content)).Content)).Text;

                        if (!String.IsNullOrEmpty(NVtoupdateDivisa.Codigo) || !String.IsNullOrEmpty(NVtoupdateDivisa.Descripcion))
                        {
                            int IdInserted = Instrumentos_divisas_DA.Insert(NVtoupdateDivisa);
                            //((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text = IdInserted.ToString();
                            DataSource.instrumentosDivisas.Last().Id = IdInserted;
                            VM_Instrumentos.GetDivisas();
                        }
                        #endregion

                    }
                    else
                    {
                        #region We have to Update

                        NVtoupdateDivisa.Id = ((Instrumentos_Divisas)e.Row.DataContext).Id;
                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateDivisa.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateDivisa.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateDivisa.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateDivisa.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        Instrumentos_divisas_DA.Update(NVtoupdateDivisa);



                        #endregion
                    }

                    if (((Instrumentos_Divisas)e.Row.DataContext).Id == 0)
                    {
                        if (((Instrumentos_Divisas)e.Row.DataContext).Codigo == null && ((Instrumentos_Divisas)e.Row.DataContext).Descripcion == null)
                        {
                            if (DataSource.instrumentosDivisas.Count > 0)
                            {
                                DataSource.instrumentosDivisas.RemoveAt(DataSource.instrumentosDivisas.Count - 1);
                            }

                        }

                    }


                    #endregion

                    break;
                case Utils.Elemento.InstrumentosPaises:
                    #region Paises

                    if (((Instrumentos_Paises)e.Row.DataContext).Id == 0)
                    {
                        #region Insert

                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdatePais.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdatePais.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdatePais.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdatePais.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;

                        if (!String.IsNullOrEmpty(NVtoupdatePais.Codigo) || !String.IsNullOrEmpty(NVtoupdatePais.Descripcion))
                        {
                            int IdInserted = InstrumentosPaises_DA.Insert(NVtoupdatePais);
                            DataSource.instrumentosPaises.Last().Id = IdInserted;
                            VM_Instrumentos.GetPaises();
                        }
                        #endregion

                    }
                    else
                    {
                        #region We have to Update

                        NVtoupdatePais.Id = ((Instrumentos_Paises)e.Row.DataContext).Id;
                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdatePais.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdatePais.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdatePais.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdatePais.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        InstrumentosPaises_DA.Update(NVtoupdatePais);



                        #endregion
                    }

                    if (((Instrumentos_Paises)e.Row.DataContext).Id == 0)
                    {
                        if (((Instrumentos_Paises)e.Row.DataContext).Codigo == null && ((Instrumentos_Paises)e.Row.DataContext).Descripcion == null)
                        {
                            if (DataSource.instrumentosPaises.Count > 0)
                            {
                                DataSource.instrumentosPaises.RemoveAt(DataSource.instrumentosPaises.Count - 1);
                            }

                        }

                    }

                   
                    #endregion
                    break;
                case Utils.Elemento.InstrumentosTipos:
                    #region Tipos

                    if (((Instrumentos_Tipos)e.Row.DataContext).Id == "0")
                    {
                        #region Insert

                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateTipo.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateTipo.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateTipo.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateTipo.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;

                        if (!String.IsNullOrEmpty(NVtoupdateTipo.Codigo) || !String.IsNullOrEmpty(NVtoupdateTipo.Descripcion))
                        {
                            int IdInserted = InstrumentosTipos_DA.Insert(NVtoupdateTipo);
                            
                            DataSource.instrumentosTipos.Last().Id = IdInserted.ToString();
                            VM_Instrumentos.GetTipos();
                        }
                        #endregion

                    }
                    else
                    {
                        #region We have to Update

                        NVtoupdateTipo.Id = ((Instrumentos_Tipos)e.Row.DataContext).Id;
                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateTipo.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateTipo.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateTipo.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateTipo.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        InstrumentosTipos_DA.Update(NVtoupdateTipo);



                        #endregion
                    }

                    if (((Instrumentos_Tipos)e.Row.DataContext).Id == "0")
                    {
                        if (((Instrumentos_Tipos)e.Row.DataContext).Codigo == null && ((Instrumentos_Tipos)e.Row.DataContext).Descripcion == null)
                        {
                            if (DataSource.instrumentosTipos.Count > 0)
                            {
                                DataSource.instrumentosTipos.RemoveAt(DataSource.instrumentosTipos.Count - 1);
                            }

                        }

                    }

                   
                    #endregion
                    break;
                case Utils.Elemento.InstrumentosZonas:
                    #region Zonas

                    if (((Instrumentos_Zonas)e.Row.DataContext).Id == 0)
                    {
                        #region Insert

                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateZona.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateZona.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateZona.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateZona.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;

                        if (!String.IsNullOrEmpty(NVtoupdateZona.Codigo) || !String.IsNullOrEmpty(NVtoupdateZona.Descripcion))
                        {
                            int IdInserted = InstrumentosZonas_DA.Insert(NVtoupdateZona);
                           
                            DataSource.instrumentosZonas.Last().Id = IdInserted;
                            VM_Instrumentos.GetZonas();
                        }
                        #endregion

                    }
                    else
                    {
                        #region We have to Update

                        NVtoupdateZona.Id = ((Instrumentos_Zonas)e.Row.DataContext).Id;
                        if (e.Row.Cells[0].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateZona.Codigo = ((System.Windows.Controls.TextBlock)(e.Row.Cells[0].Content)).Text;
                        if (e.Row.Cells[0].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateZona.Codigo = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[0].Content)).Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isTextBlock.GetType())) NVtoupdateZona.Descripcion = ((System.Windows.Controls.TextBlock)(e.Row.Cells[1].Content)).Text;
                        if (e.Row.Cells[1].Content.GetType().Equals(isPresenter.GetType())) NVtoupdateZona.Descripcion = ((System.Windows.Controls.TextBox)(((System.Windows.Controls.ContentControl)(e.Row.Cells[1].Content)).Content)).Text;
                        InstrumentosZonas_DA.Update(NVtoupdateZona);



                        #endregion
                    }

                    if (((Instrumentos_Zonas)e.Row.DataContext).Id == 0)
                    {
                        if (((Instrumentos_Zonas)e.Row.DataContext).Codigo == null && ((Instrumentos_Zonas)e.Row.DataContext).Descripcion == null)
                        {
                            if (DataSource.instrumentosZonas.Count > 0)
                            {
                                DataSource.instrumentosZonas.RemoveAt(DataSource.instrumentosZonas.Count - 1);
                            }

                        }

                    }
                    
                    #endregion
                    break;

            }
            
        }

        private void StackPanel_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            populateData();
        }

        private void radGridViewListado_BeginningEdit(object sender, Telerik.Windows.Controls.GridViewBeginningEditRoutedEventArgs e)
        {
            switch (_elemento)
            {
                case Utils.Elemento.InstrumentosImportados:
                    e.Row.IsEnabled = false;
                    break;
                case Utils.Elemento.BloombergImportados:
                    e.Row.IsEnabled = false;
                    break;
                case Utils.Elemento.InstrumentosEmpresas:
                    e.Row.IsEnabled = true;
                    foreach (var item in e.Row.Cells)
                    {

                    }
                    
                    break;
                default:
                    e.Row.IsEnabled = true;
                    break;
            }
        }

        private void radGridViewListado_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (_elemento)
            {
                case Utils.Elemento.InstrumentosImportados:
                    this.radGridViewListado.Columns.RemoveAt(0);
                    foreach (var item in this.radGridViewListado.Columns)
                    {
                        item.IsReadOnly = true;
                    }
                    break;
                case Utils.Elemento.BloombergImportados:
                    this.radGridViewListado.Columns.RemoveAt(0);
                    foreach (var item in this.radGridViewListado.Columns)
                    {
                        item.IsReadOnly = true;
                    }
                    break;
               
                default:
                    
                    break;
            }
        }

        private void radGridViewListado_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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
            
            if( dialogResult == true)
            {
                #region Delete
                switch (_elemento)
                {
                    case Utils.Elemento.Secciones:
                        Seccione SecciontoDelete = (Seccione)e.Items.FirstOrDefault();
                        Secciones_DA.Delete(SecciontoDelete);
                        break;
                    case Utils.Elemento.Instrumentos:
                        Instrumento InstrumentotoDelete = (Instrumento)e.Items.FirstOrDefault();
                        Instrumentos_DA.Delete(InstrumentotoDelete);
                        break;
                    case Utils.Elemento.InstrumentosCategorias:
                        Instrumentos_Categorias CategoriatoDelete = (Instrumentos_Categorias)e.Items.FirstOrDefault();
                        InstrumentosCategorias_DA.Delete(CategoriatoDelete);
                        break;
                    case Utils.Elemento.InstrumentosEmpresas:
                        Instrumentos_Empresas EmpresatoDelete = (Instrumentos_Empresas)e.Items.FirstOrDefault();
                        InstrumentosEmpresas_DA.Delete(EmpresatoDelete);
                        break;
                    case Utils.Elemento.InstrumentosDivisas:
                        Instrumentos_Divisas DivisatoDelete = (Instrumentos_Divisas)e.Items.FirstOrDefault();
                        Instrumentos_divisas_DA.Delete(DivisatoDelete);
                        break;

                    case Utils.Elemento.InstrumentosPaises:
                        Instrumentos_Paises PaisestoDelete = (Instrumentos_Paises)e.Items.FirstOrDefault();
                        InstrumentosPaises_DA.Delete(PaisestoDelete);
                        break;
                    case Utils.Elemento.InstrumentosTipos:
                        Instrumentos_Tipos tipotoDelete = (Instrumentos_Tipos)e.Items.FirstOrDefault();
                        InstrumentosTipos_DA.Delete(tipotoDelete);
                        break;
                    case Utils.Elemento.InstrumentosZonas:
                        Instrumentos_Zonas zonatoDelete = (Instrumentos_Zonas)e.Items.FirstOrDefault();
                        InstrumentosZonas_DA.Delete(zonatoDelete);
                        break;
                    case Utils.Elemento.InstrumentosSectores:
                        Instrumentos_Sectores sectortoDelete = (Instrumentos_Sectores)e.Items.FirstOrDefault();
                        InstrumentosSectores_DA.Delete(sectortoDelete);
                        break;
                }
                #endregion
            }
            else 
            {
                //cancel
                e.Cancel = true;

               
            }
           
        }

        private void ActionComboBoxEdit_Click(object sender, RoutedEventArgs e)

        {
            var button = sender as RadButton;
            if(button!=null)
            {
                var rowcb = button.ParentOfType<RadComboBox>();
                if(rowcb!=null)
                {
                    var row = rowcb.ParentOfType<RadGridView>();
                    if (row != null)

                    {
                        var SelectedData= row.SelectedItem;
                    }
                }
           
            }
            radGridViewListado.BeginEdit();

        }

        private void radGridViewListado_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {

            var p = sender as RadGridView;
            foreach (var item in e.AddedItems)
            {
                
            }
        }

        private void radGridViewListado_RowLoaded(object sender, Telerik.Windows.Controls.GridView.RowLoadedEventArgs e)
        {
            var row = e.Row as GridViewRow;

            if (row != null)

            {

                radGridViewListado.AddHandler(GridViewRow.MouseLeftButtonDownEvent,

             new MouseButtonEventHandler(GridViewRow_MouseLeftButtonDown), true);

            }
        }

        private void GridViewRow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)

        {
            var p = (Telerik.Windows.Controls.RadGridView)sender;
            var j = p.CurrentCell;
            var k = ((Telerik.Windows.Controls.DataControl)e.Source).CurrentItem;


        }

         private  void AddNewRow(object sender, RoutedEventArgs e)
         {
            
            #region Add new Row

            #region showWindow
                    int IdInserted = 0;
                    Instrumentos_Empresas EmpresatoAdd = new Instrumentos_Empresas();
                    Seccione SecciontoAdd = new Seccione();
                    Instrumento InstrumentotoAdd = new Instrumento();
                    Instrumentos_Categorias CategoriatoAdd = new Instrumentos_Categorias();
                    Instrumentos_Paises PaistoAdd = new Instrumentos_Paises();
                    Instrumentos_Tipos TipotoAdd = new Instrumentos_Tipos();
                    Instrumentos_Zonas ZonatoAdd = new Instrumentos_Zonas();
                    Instrumentos_Sectores SectortoAdd = new Instrumentos_Sectores();
                    Instrumentos_Divisas DivisatoAdd = new Instrumentos_Divisas();

                    switch (_elemento)
                            {
                                case Utils.Elemento.Secciones:
                                #region Secciones
                                var windowSeccion = new AddEditSeccion(string.Empty,0);
                                if (windowSeccion != null)
                                {
                                    if (Application.Current.MainWindow != windowSeccion)
                                    {
                                        windowSeccion.Owner = Application.Current.MainWindow;
                                        windowSeccion.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                                        var ownerMetroWindow = (windowSeccion.Owner as MetroWindow);
                                        ownerMetroWindow.Height = windowSeccion.Height;
                                        ownerMetroWindow.Width = windowSeccion.Width;
                                        ownerMetroWindow.MinHeight = windowSeccion.MinHeight;
                                        ownerMetroWindow.MinWidth = windowSeccion.MinWidth;
                                    if (!ownerMetroWindow.IsOverlayVisible())
                                            ownerMetroWindow.ShowOverlayAsync();
                                    }

                                    #region Create Custom object to take values
                                    switch (_elemento)
                                    {
                                        case Utils.Elemento.Secciones:
                                            //SecciontoUpdate = (Seccione)this.radGridViewListado.SelectedItem;
                                            //window.Codigo = SecciontoUpdate.Id.ToString();
                                            //window.Descripcion = SecciontoUpdate.DescripcionLarga;

                                            break;
                           
                                    }
                                    #endregion



                                    windowSeccion.ShowDialog();

                                    windowSeccion.Owner = Application.Current.MainWindow;
                                    var ownerMetroWindow2 = (windowSeccion.Owner as MetroWindow);

                                    if (ownerMetroWindow2.IsOverlayVisible())
                                        ownerMetroWindow2.HideOverlayAsync();

                                    if (!windowSeccion.Cancel)
                                    {
                                        #region Retrieve Values from window
                                        switch (_elemento)
                                        {
                                            case Utils.Elemento.Secciones:
                                                #region Secciones
                                                SecciontoAdd.Descripcion = windowSeccion.Descripcion;
                                                // window.textBoxDescription.

                                                IdInserted = Secciones_DA.Insert(SecciontoAdd);
                                                SecciontoAdd.Id = IdInserted;
                                                DataSource.Secciones.Add(SecciontoAdd);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = DataSource.Secciones.OrderBy(c => c.Descripcion);

                                                #region go to last row after insert
                                                //this.radGridViewListado.ScrollIntoViewAsync(this.radGridViewListado.Items[this.radGridViewListado.Items.Count - 1], //the row
                                                //this.radGridViewListado.Columns[this.radGridViewListado.Columns.Count - 1], //the column
                                                //new Action<FrameworkElement>((f) =>
                                                //{
                                                //    (f as GridViewRow).IsSelected = true; // the callback method; if it is not necessary, you may set that parameter to null;
                                                //}));
                                                #endregion
                                            #endregion
                                            break;
                                

                                        }
                                        #endregion
                                    }
                                }
                            #endregion
                                break;
                                case Utils.Elemento.InstrumentosSectores:
                                #region Sectores
                                    var windowSector = new AddEditSeccion(string.Empty,0);
                                    windowSector.Title = "Añadir/Editar sector";
                                    if (windowSector != null)
                                    {
                                        if (Application.Current.MainWindow != windowSector)
                                        {
                                            windowSector.Owner = Application.Current.MainWindow;
                                            windowSector.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                                            var ownerMetroWindow = (windowSector.Owner as MetroWindow);
                                            ownerMetroWindow.Height = windowSector.Height;
                                            ownerMetroWindow.Width = windowSector.Width;
                                            ownerMetroWindow.MinHeight = windowSector.MinHeight;
                                            ownerMetroWindow.MinWidth = windowSector.MinWidth;
                                            if (!ownerMetroWindow.IsOverlayVisible())
                                                ownerMetroWindow.ShowOverlayAsync();
                                        }

                                        #region Create Custom object to take values
                                        switch (_elemento)
                                        {
                                            case Utils.Elemento.InstrumentosSectores:
                                                //SecciontoUpdate = (Seccione)this.radGridViewListado.SelectedItem;
                                                //window.Codigo = SecciontoUpdate.Id.ToString();
                                                //window.Descripcion = SecciontoUpdate.DescripcionLarga;

                                                break;

                                        }
                                #endregion



                                        windowSector.ShowDialog();

                                        windowSector.Owner = Application.Current.MainWindow;
                                        var ownerMetroWindow2 = (windowSector.Owner as MetroWindow);

                                        if (ownerMetroWindow2.IsOverlayVisible())
                                            ownerMetroWindow2.HideOverlayAsync();

                                        if (!windowSector.Cancel)
                                        {
                                            #region Retrieve Values from window
                                            switch (_elemento)
                                            {
                                                case Utils.Elemento.InstrumentosSectores:
                                                    #region Sectores
                                                    SectortoAdd.Descripcion = windowSector.Descripcion;
                                                    // window.textBoxDescription.

                                                    IdInserted = InstrumentosSectores_DA.Insert(SectortoAdd);
                                                    SecciontoAdd.Id = IdInserted;
                                                    DataSource.instrumentosSectores.Add(SectortoAdd);

                                                    this.radGridViewListado.ItemsSource = null;
                                                    this.radGridViewListado.ItemsSource = InstrumentosSectores_DA.GetAll().OrderBy(c => c.Descripcion);
                                                   
                                                    #region go to last row after insert
                                                        //this.radGridViewListado.ScrollIntoViewAsync(this.radGridViewListado.Items[this.radGridViewListado.Items.Count - 1], //the row
                                                        //this.radGridViewListado.Columns[this.radGridViewListado.Columns.Count - 1], //the column
                                                        //new Action<FrameworkElement>((f) =>
                                                        //{
                                                        //    (f as GridViewRow).IsSelected = true; // the callback method; if it is not necessary, you may set that parameter to null;
                                                        //    }));
                                                    #endregion
                                                    #endregion
                                                    break;


                                            }
                                            #endregion
                                        }
                                    }
                            #endregion
                        break;
                    
                        default:
                        #region default

                        #region Fill List with List of Codes

                        var rows = this.radGridViewListado.ChildrenOfType<GridViewRow>();
                        List<string> ListaCodigo = new List<string>();
                        foreach (GridViewRow item in rows)
                        {
                            ListaCodigo.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                        }

                        #endregion

                        var window = new AddEditMaster("ADD", ListaCodigo,string.Empty,string.Empty);
                   
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
                            
                            window.ShowDialog();

                            window.Owner = Application.Current.MainWindow;
                            var ownerMetroWindow2 = (window.Owner as MetroWindow);

                            if (ownerMetroWindow2.IsOverlayVisible())
                                ownerMetroWindow2.HideOverlayAsync();

                            if (!window.Cancel)
                            {
                                #region Retrieve Values from window
                                switch (_elemento)
                                {
                                    case Utils.Elemento.Secciones:
                                        #region Instrumentos
                                        SecciontoAdd.Descripcion = window.Codigo;
                                        // window.textBoxDescription.

                                        IdInserted = Secciones_DA.Insert(SecciontoAdd);
                                        SecciontoAdd.Id = IdInserted;
                                        DataSource.Secciones.Add(SecciontoAdd);

                                        this.radGridViewListado.ItemsSource = null;
                                        this.radGridViewListado.ItemsSource = DataSource.instrumentosEmpresas;
                                        #endregion
                                        break;
                                    case Utils.Elemento.Instrumentos:
                                        #region Instrumentos

                                        InstrumentotoAdd.Codigo = window.Codigo;
                                        InstrumentotoAdd.Descripcion = window.Descripcion;

                                        IdInserted = Instrumentos_DA.Insert(InstrumentotoAdd);
                                        InstrumentotoAdd.Id = IdInserted.ToString();
                                        DataSource.Instrumentos.Add(InstrumentotoAdd);

                                        this.radGridViewListado.ItemsSource = null;
                                        this.radGridViewListado.ItemsSource = DataSource.Instrumentos;
                                        #endregion
                                        break;
                                    case Utils.Elemento.InstrumentosCategorias:
                                        #region Instrumentos_Categorias

                                        CategoriatoAdd.Codigo = window.Codigo;
                                        CategoriatoAdd.Descripcion = window.Descripcion;

                                        IdInserted = InstrumentosCategorias_DA.Insert(CategoriatoAdd);
                                        CategoriatoAdd.Id = IdInserted;
                                        DataSource.instrumentosCategorias.Add(CategoriatoAdd);

                                        this.radGridViewListado.ItemsSource = null;
                                        this.radGridViewListado.ItemsSource = DataSource.instrumentosCategorias;
                                        #endregion
                                        break;
                                    case Utils.Elemento.InstrumentosEmpresas:
                                        #region Empresas

                                        EmpresatoAdd.Codigo = window.Codigo;
                                        EmpresatoAdd.Descripcion = window.Descripcion;

                                        IdInserted = InstrumentosEmpresas_DA.Insert(EmpresatoAdd);
                                        EmpresatoAdd.Id = IdInserted;
                                        DataSource.instrumentosEmpresas.Add(EmpresatoAdd);

                                        this.radGridViewListado.ItemsSource = null;
                                        this.radGridViewListado.ItemsSource = DataSource.instrumentosEmpresas;
                                        #endregion
                                        break;
                                    case Utils.Elemento.InstrumentosPaises:
                                        #region Instrumentos_Paises

                                        PaistoAdd.Codigo = window.Codigo;
                                        PaistoAdd.Descripcion = window.Descripcion;

                                        IdInserted = InstrumentosPaises_DA.Insert(PaistoAdd);
                                        PaistoAdd.Id = IdInserted;
                                        DataSource.instrumentosPaises.Add(PaistoAdd);

                                        this.radGridViewListado.ItemsSource = null;
                                        this.radGridViewListado.ItemsSource = DataSource.instrumentosPaises;
                                       
                                        #endregion
                                    break;
                                
                                    case Utils.Elemento.InstrumentosDivisas:
                                        #region Instrumentos_Divisas

                                        DivisatoAdd.Codigo = window.Codigo;
                                        DivisatoAdd.Descripcion = window.Descripcion;

                                        IdInserted = Instrumentos_divisas_DA.Insert(DivisatoAdd);
                                        DivisatoAdd.Id = IdInserted;
                                        DataSource.instrumentosDivisas.Add(DivisatoAdd);

                                        this.radGridViewListado.ItemsSource = null;
                                        this.radGridViewListado.ItemsSource = DataSource.instrumentosDivisas;

                                        #endregion
                                        break;
                                    case Utils.Elemento.InstrumentosTipos:
                                        #region Instrumentos_Tipos

                                        TipotoAdd.Codigo = window.Codigo;
                                        TipotoAdd.Descripcion = window.Descripcion;

                                        IdInserted = InstrumentosTipos_DA.Insert(TipotoAdd);
                                        TipotoAdd.Id = IdInserted.ToString();
                                        DataSource.instrumentosTipos.Add(TipotoAdd);

                                        this.radGridViewListado.ItemsSource = null;
                                        this.radGridViewListado.ItemsSource = DataSource.instrumentosTipos;
                                        #endregion
                                        break;
                                    case Utils.Elemento.InstrumentosZonas:
                                        #region Instrumentos_Zonas

                                        ZonatoAdd.Codigo = window.Codigo;
                                        ZonatoAdd.Descripcion = window.Descripcion;

                                        IdInserted = InstrumentosZonas_DA.Insert(ZonatoAdd);
                                        ZonatoAdd.Id = IdInserted;
                                        DataSource.instrumentosZonas.Add(ZonatoAdd);

                                        this.radGridViewListado.ItemsSource = null;
                                        this.radGridViewListado.ItemsSource = DataSource.instrumentosZonas;
                                        #endregion
                                        break;
                                   

                            }
                            #endregion
                            #region go to last row after insert
                            this.radGridViewListado.ScrollIntoViewAsync(this.radGridViewListado.Items[this.radGridViewListado.Items.Count - 1], //the row
                            this.radGridViewListado.Columns[this.radGridViewListado.Columns.Count - 1], //the column
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
            
            var selectedValue = this.radGridViewListado.SelectedItem;
            Reports_IICs.DataModels.Instrumentos_Categorias isCategorias = new Instrumentos_Categorias();

            if ((e.AddedItems.Count > 0) && (((object[])e.AddedItems)[0].GetType().Equals(isCategorias.GetType())))
            {
                //do nothing
            }
            else
            {
                if (e.AddedItems.Count > 0)
                {

                    #region Editar
                    if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                    {
                        #region showWindow

                        Instrumentos_Empresas EmpresatoUpdate = new Instrumentos_Empresas();
                        Instrumento InstrumentotoUpdate = new Instrumento();
                        Seccione SecciontoUpdate = new Seccione();
                        Instrumentos_Categorias CategoriatoUpdate = new Instrumentos_Categorias();
                        Instrumentos_Paises PaistoUpdate = new Instrumentos_Paises();
                        Instrumentos_Divisas DivisatoUpdate = new Instrumentos_Divisas();
                        Instrumentos_Tipos TipotoUpdate = new Instrumentos_Tipos();
                        Instrumentos_Zonas ZonatoUpdate = new Instrumentos_Zonas();
                        Instrumentos_Sectores SectortoUpdate = new Instrumentos_Sectores();

                        switch (_elemento)
                        {
                            case Utils.Elemento.Secciones:
                                #region secciones
                                #region Create Custom object to take values
                                string Wdescripcion = string.Empty;
                                switch (_elemento)
                                {
                                    case Utils.Elemento.Secciones:
                                        SecciontoUpdate = (Seccione)this.radGridViewListado.SelectedItem;
                                        //windowseccion.Codigo = SecciontoUpdate.Id.ToString();
                                        Wdescripcion = SecciontoUpdate.Descripcion;

                                        break;

                                }
                                #endregion

                                var windowseccion = new AddEditSeccion(Wdescripcion,0);

                                if (windowseccion != null)
                                {
                                    if (Application.Current.MainWindow != windowseccion)
                                    {
                                        windowseccion.Owner = Application.Current.MainWindow;
                                        windowseccion.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                                        var ownerMetroWindow = (windowseccion.Owner as MetroWindow);
                                        ownerMetroWindow.Height = windowseccion.Height;
                                        ownerMetroWindow.Width = windowseccion.Width;
                                        ownerMetroWindow.MinHeight = windowseccion.MinHeight;
                                        ownerMetroWindow.MinWidth = windowseccion.MinWidth;
                                        if (!ownerMetroWindow.IsOverlayVisible())
                                            ownerMetroWindow.ShowOverlayAsync();
                                    }

                                    #region Create Custom object to take values
                                    switch (_elemento)
                                    {
                                        case Utils.Elemento.Secciones:
                                            SecciontoUpdate = (Seccione)this.radGridViewListado.SelectedItem;
                                            //windowseccion.Codigo = SecciontoUpdate.Id.ToString();
                                            windowseccion.Descripcion = SecciontoUpdate.Descripcion;

                                            break;

                                    }
                                    #endregion


                                    windowseccion.ShowDialog();

                                    windowseccion.Owner = Application.Current.MainWindow;
                                    var ownerMetroWindow2 = (windowseccion.Owner as MetroWindow);

                                    if (ownerMetroWindow2.IsOverlayVisible())
                                        ownerMetroWindow2.HideOverlayAsync();

                                    if (!windowseccion.Cancel)
                                    {
                                        #region Retrieve Values from window
                                        switch (_elemento)
                                        {
                                            case Utils.Elemento.Secciones:
                                                #region Secciones
                                                DataSource.Secciones.Remove(SecciontoUpdate);
                                                //SecciontoUpdate.Id = int.Parse(windowseccion.Codigo);
                                                SecciontoUpdate.Descripcion = windowseccion.Descripcion;

                                                Secciones_DA.Update(SecciontoUpdate);
                                                DataSource.Secciones.Add(SecciontoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = Secciones_DA.GetAll().OrderBy(c => c.Descripcion);
                                                #endregion
                                                break;

                                        }
                                        #endregion
                                    }
                                }
                                #endregion
                                break;
                            case Utils.Elemento.InstrumentosSectores:
                                #region sectores
                                #region Create Custom object to take values
                                Wdescripcion = string.Empty;
                                int WidCategoria = 0;
                                switch (_elemento)
                                {
                                    case Utils.Elemento.InstrumentosSectores:
                                        SectortoUpdate = (Instrumentos_Sectores)this.radGridViewListado.SelectedItem;
                                        //windowseccion.Codigo = SecciontoUpdate.Id.ToString();
                                        Wdescripcion = SectortoUpdate.Descripcion;
                                        WidCategoria = SectortoUpdate.IdCategoria;
                                        break;

                                }
                                #endregion

                                var windowsector = new AddEditSeccion(Wdescripcion, WidCategoria);
                                windowsector.Title = "Añadir/Editar sector";
                                windowsector.comboBox_Category.Visibility = Visibility.Visible;
                                windowsector.lb_Category.Visibility = Visibility.Visible;
                                if (windowsector != null)
                                {
                                    if (Application.Current.MainWindow != windowsector)
                                    {
                                        windowsector.Owner = Application.Current.MainWindow;
                                        windowsector.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                                        var ownerMetroWindow = (windowsector.Owner as MetroWindow);
                                        ownerMetroWindow.Height = windowsector.Height;
                                        ownerMetroWindow.Width = windowsector.Width;
                                        ownerMetroWindow.MinHeight = windowsector.MinHeight;
                                        ownerMetroWindow.MinWidth = windowsector.MinWidth;
                                        if (!ownerMetroWindow.IsOverlayVisible())
                                            ownerMetroWindow.ShowOverlayAsync();
                                    }

                                    #region Create Custom object to take values
                                    switch (_elemento)
                                    {
                                        case Utils.Elemento.InstrumentosSectores:
                                            SectortoUpdate = (Instrumentos_Sectores)this.radGridViewListado.SelectedItem;
                                            //windowseccion.Codigo = SecciontoUpdate.Id.ToString();
                                            windowsector.Descripcion = SectortoUpdate.Descripcion;
                                            windowsector.IdCategoria = SectortoUpdate.IdCategoria;
                                            break;

                                    }
                                    #endregion


                                    windowsector.ShowDialog();

                                    windowsector.Owner = Application.Current.MainWindow;
                                    var ownerMetroWindow2 = (windowsector.Owner as MetroWindow);

                                    if (ownerMetroWindow2.IsOverlayVisible())
                                        ownerMetroWindow2.HideOverlayAsync();

                                    if (!windowsector.Cancel)
                                    {
                                        #region Retrieve Values from window
                                        switch (_elemento)
                                        {
                                            case Utils.Elemento.InstrumentosSectores:
                                                #region Sectores
                                                DataSource.instrumentosSectores.Remove(SectortoUpdate);
                                                //SecciontoUpdate.Id = int.Parse(windowseccion.Codigo);
                                                SectortoUpdate.Descripcion = windowsector.Descripcion;
                                                SectortoUpdate.IdCategoria = windowsector.IdCategoria;

                                                InstrumentosSectores_DA.Update(SectortoUpdate);
                                                DataSource.instrumentosSectores.Add(SectortoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = InstrumentosSectores_DA.GetAll().OrderBy(c => c.Descripcion);
                                                #endregion
                                                break;

                                        }
                                        #endregion
                                    }
                                }
                                #endregion
                                break;
                            default:
                                #region default

                                #region Fill List with List of Codes

                                var rows = this.radGridViewListado.ChildrenOfType<GridViewRow>();
                                var selectedrow = this.radGridViewListado.SelectedItem;
                                List<string> ListadoNoselected = new List<string>();
                                #endregion

                                string wcodigo = string.Empty;
                                string wdescripcion = string.Empty;
                                #region Create Custom object to take values
                                switch (_elemento)
                                {
                                    case Utils.Elemento.Secciones:
                                        SecciontoUpdate = (Seccione)this.radGridViewListado.SelectedItem;
                                        wcodigo = SecciontoUpdate.Id.ToString();
                                        //window.Descripcion = SecciontoUpdate.DescripcionLarga;

                                        break;
                                    case Utils.Elemento.Instrumentos:
                                        InstrumentotoUpdate = (Instrumento)this.radGridViewListado.SelectedItem;
                                        wcodigo = InstrumentotoUpdate.Codigo;
                                        wdescripcion = InstrumentotoUpdate.Descripcion;
                                        foreach (GridViewRow item in rows)
                                        {
                                            ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                        }
                                        ListadoNoselected.Remove(((Reports_IICs.DataModels.Instrumento)selectedrow).Codigo);

                                        break;
                                    case Utils.Elemento.InstrumentosCategorias:
                                        CategoriatoUpdate = (Instrumentos_Categorias)this.radGridViewListado.SelectedItem;
                                        wcodigo = CategoriatoUpdate.Codigo;
                                        wdescripcion = CategoriatoUpdate.Descripcion;
                                        foreach (GridViewRow item in rows)
                                        {
                                            ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                        }
                                        ListadoNoselected.Remove(((Reports_IICs.DataModels.Instrumentos_Categorias)selectedrow).Codigo);

                                        break;
                                    case Utils.Elemento.InstrumentosEmpresas:
                                        EmpresatoUpdate = (Instrumentos_Empresas)this.radGridViewListado.SelectedItem;
                                        wcodigo = EmpresatoUpdate.Codigo;
                                        wdescripcion = EmpresatoUpdate.Descripcion;
                                        foreach (GridViewRow item in rows)
                                        {
                                            ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                        }
                                        ListadoNoselected.Remove(((Reports_IICs.DataModels.Instrumentos_Empresas)selectedrow).Codigo);

                                        break;
                                   
                                    case Utils.Elemento.InstrumentosDivisas:
                                        DivisatoUpdate = (Instrumentos_Divisas)this.radGridViewListado.SelectedItem;
                                        wcodigo = DivisatoUpdate.Codigo;
                                        wdescripcion = DivisatoUpdate.Descripcion;
                                        foreach (GridViewRow item in rows)
                                        {
                                            ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                        }
                                        ListadoNoselected.Remove(((Reports_IICs.DataModels.Instrumentos_Divisas)selectedrow).Codigo);

                                        break;
                                    case Utils.Elemento.InstrumentosPaises:
                                        PaistoUpdate = (Instrumentos_Paises)this.radGridViewListado.SelectedItem;
                                        wcodigo = PaistoUpdate.Codigo;
                                        wdescripcion = PaistoUpdate.Descripcion;
                                        foreach (GridViewRow item in rows)
                                        {
                                            ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                        }
                                        ListadoNoselected.Remove(((Reports_IICs.DataModels.Instrumentos_Paises)selectedrow).Codigo);

                                        break;
                                    case Utils.Elemento.InstrumentosTipos:
                                        TipotoUpdate = (Instrumentos_Tipos)this.radGridViewListado.SelectedItem;
                                        wcodigo = TipotoUpdate.Codigo;
                                        wdescripcion = TipotoUpdate.Descripcion;
                                        foreach (GridViewRow item in rows)
                                        {
                                            ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                        }
                                        ListadoNoselected.Remove(((Reports_IICs.DataModels.Instrumentos_Tipos)selectedrow).Codigo);

                                        break;
                                    case Utils.Elemento.InstrumentosZonas:
                                        ZonatoUpdate = (Instrumentos_Zonas)this.radGridViewListado.SelectedItem;
                                        wcodigo = ZonatoUpdate.Codigo;
                                        wdescripcion = ZonatoUpdate.Descripcion;
                                        foreach (GridViewRow item in rows)
                                        {
                                            ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                        }
                                        ListadoNoselected.Remove(((Reports_IICs.DataModels.Instrumentos_Zonas)selectedrow).Codigo);

                                        break;
                                }
                                #endregion


                                var window = new AddEditMaster("EDIT", ListadoNoselected, wcodigo, wdescripcion);

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
                                    switch (_elemento)
                                    {
                                        case Utils.Elemento.Secciones:
                                            SecciontoUpdate = (Seccione)this.radGridViewListado.SelectedItem;
                                            window.Codigo = SecciontoUpdate.Id.ToString();
                                            //window.Descripcion = SecciontoUpdate.DescripcionLarga;

                                            break;
                                        case Utils.Elemento.Instrumentos:
                                            InstrumentotoUpdate = (Instrumento)this.radGridViewListado.SelectedItem;
                                            window.Codigo = InstrumentotoUpdate.Codigo;
                                            window.Descripcion = InstrumentotoUpdate.Descripcion;
                                            break;
                                        case Utils.Elemento.InstrumentosCategorias:
                                            CategoriatoUpdate = (Instrumentos_Categorias)this.radGridViewListado.SelectedItem;
                                            window.Codigo = CategoriatoUpdate.Codigo;
                                            window.Descripcion = CategoriatoUpdate.Descripcion;
                                            break;
                                        case Utils.Elemento.InstrumentosEmpresas:
                                            EmpresatoUpdate = (Instrumentos_Empresas)this.radGridViewListado.SelectedItem;
                                            window.Codigo = EmpresatoUpdate.Codigo;
                                            window.Descripcion = EmpresatoUpdate.Descripcion;

                                            break;

                                        case Utils.Elemento.InstrumentosPaises:
                                            PaistoUpdate = (Instrumentos_Paises)this.radGridViewListado.SelectedItem;
                                            window.Codigo = PaistoUpdate.Codigo;
                                            window.Descripcion = PaistoUpdate.Descripcion;
                                            break;
                                        case Utils.Elemento.InstrumentosTipos:
                                            TipotoUpdate = (Instrumentos_Tipos)this.radGridViewListado.SelectedItem;
                                            window.Codigo = TipotoUpdate.Codigo;
                                            window.Descripcion = TipotoUpdate.Descripcion;
                                            break;
                                        case Utils.Elemento.InstrumentosZonas:
                                            ZonatoUpdate = (Instrumentos_Zonas)this.radGridViewListado.SelectedItem;
                                            window.Codigo = ZonatoUpdate.Codigo;
                                            window.Descripcion = ZonatoUpdate.Descripcion;
                                            break;
                                    }
                                    #endregion



                                    window.ShowDialog();

                                    window.Owner = Application.Current.MainWindow;
                                    var ownerMetroWindow2 = (window.Owner as MetroWindow);

                                    if (ownerMetroWindow2.IsOverlayVisible())
                                        ownerMetroWindow2.HideOverlayAsync();

                                    if (!window.Cancel)
                                    {
                                        #region Retrieve Values from window
                                        switch (_elemento)
                                        {
                                            case Utils.Elemento.Secciones:
                                                #region Secciones
                                                DataSource.Secciones.Remove(SecciontoUpdate);
                                                SecciontoUpdate.Id = int.Parse(window.Codigo);
                                                // SecciontoUpdate.DescripcionLarga = window.Descripcion;

                                                Secciones_DA.Update(SecciontoUpdate);
                                                DataSource.Secciones.Add(SecciontoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = Secciones_DA.GetAll().OrderBy(c => c.Descripcion);
                                                #endregion
                                                break;
                                            case Utils.Elemento.Instrumentos:
                                                #region Instrumentos
                                                DataSource.Instrumentos.Remove(InstrumentotoUpdate);
                                                InstrumentotoUpdate.Codigo = window.Codigo;
                                                InstrumentotoUpdate.Descripcion = window.Descripcion;

                                                Instrumentos_DA.Update(InstrumentotoUpdate);
                                                DataSource.Instrumentos.Add(InstrumentotoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = Instrumentos_DA.GetAll().OrderBy(c => c.Codigo);
                                                #endregion
                                                break;
                                            case Utils.Elemento.InstrumentosCategorias:
                                                #region Instrumentos_Categorias
                                                DataSource.instrumentosCategorias.Remove(CategoriatoUpdate);
                                                CategoriatoUpdate.Codigo = window.Codigo;
                                                CategoriatoUpdate.Descripcion = window.Descripcion;

                                                InstrumentosCategorias_DA.Update(CategoriatoUpdate);
                                                DataSource.instrumentosCategorias.Add(CategoriatoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = InstrumentosCategorias_DA.GetAll().OrderBy(c => c.Codigo);
                                                #endregion
                                                break;
                                            case Utils.Elemento.InstrumentosEmpresas:
                                                #region Empresas
                                                DataSource.instrumentosEmpresas.Remove(EmpresatoUpdate);
                                                EmpresatoUpdate.Codigo = window.Codigo;
                                                EmpresatoUpdate.Descripcion = window.Descripcion;

                                                InstrumentosEmpresas_DA.Update(EmpresatoUpdate);
                                                DataSource.instrumentosEmpresas.Add(EmpresatoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = InstrumentosEmpresas_DA.GetAll().OrderBy(c => c.Codigo);
                                                #endregion
                                                break;
                                            case Utils.Elemento.InstrumentosDivisas:
                                                #region Instrumentos_Divisas
                                                DataSource.instrumentosDivisas.Remove(DivisatoUpdate);
                                                DivisatoUpdate.Codigo = window.Codigo;
                                                DivisatoUpdate.Descripcion = window.Descripcion;

                                                Instrumentos_divisas_DA.Update(DivisatoUpdate);
                                                DataSource.instrumentosDivisas.Add(DivisatoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = Instrumentos_divisas_DA.GetAll().OrderBy(c => c.Codigo);
                                                #endregion
                                                break;
                                            case Utils.Elemento.InstrumentosPaises:
                                                #region Instrumentos_Paises
                                                DataSource.instrumentosPaises.Remove(PaistoUpdate);
                                                PaistoUpdate.Codigo = window.Codigo;
                                                PaistoUpdate.Descripcion = window.Descripcion;

                                                InstrumentosPaises_DA.Update(PaistoUpdate);
                                                DataSource.instrumentosPaises.Add(PaistoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = InstrumentosPaises_DA.GetAll().OrderBy(c => c.Codigo);
                                                #endregion
                                                break;
                                            case Utils.Elemento.InstrumentosTipos:
                                                #region Instrumentos_Tipos
                                                DataSource.instrumentosTipos.Remove(TipotoUpdate);
                                                TipotoUpdate.Codigo = window.Codigo;
                                                TipotoUpdate.Descripcion = window.Descripcion;

                                                InstrumentosTipos_DA.Update(TipotoUpdate);
                                                DataSource.instrumentosTipos.Add(TipotoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = InstrumentosTipos_DA.GetAll().OrderBy(c => c.Codigo);
                                                #endregion
                                                break;
                                            case Utils.Elemento.InstrumentosZonas:
                                                #region Instrumentos_Zonas
                                                DataSource.instrumentosZonas.Remove(ZonatoUpdate);
                                                ZonatoUpdate.Codigo = window.Codigo;
                                                ZonatoUpdate.Descripcion = window.Descripcion;

                                                InstrumentosZonas_DA.Update(ZonatoUpdate);
                                                DataSource.instrumentosZonas.Add(ZonatoUpdate);

                                                this.radGridViewListado.ItemsSource = null;
                                                this.radGridViewListado.ItemsSource = InstrumentosZonas_DA.GetAll().OrderBy(c => c.Codigo);
                                                #endregion
                                                break;
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
                            switch (_elemento)
                            {
                                case Utils.Elemento.Secciones:
                                    Seccione SecciontoDelete = (Seccione)this.radGridViewListado.SelectedItem;
                                    Secciones_DA.Delete(SecciontoDelete);
                                    DataSource.Secciones.Remove(SecciontoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = Secciones_DA.GetAll().OrderBy(c => c.Descripcion);
                                    break;
                                case Utils.Elemento.Instrumentos:
                                    Instrumento InstrumentotoDelete = (Instrumento)this.radGridViewListado.SelectedItem;
                                    Instrumentos_DA.Delete(InstrumentotoDelete);
                                    DataSource.Instrumentos.Remove(InstrumentotoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = Instrumentos_DA.GetAll().OrderBy(c => c.Descripcion);

                                    break;
                                case Utils.Elemento.InstrumentosCategorias:
                                    Instrumentos_Categorias CategoriatoDelete = (Instrumentos_Categorias)this.radGridViewListado.SelectedItem;
                                    InstrumentosCategorias_DA.Delete(CategoriatoDelete);
                                    DataSource.instrumentosCategorias.Remove(CategoriatoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = InstrumentosCategorias_DA.GetAll().OrderBy(c => c.Descripcion);
                                    // VM_Instrumentos.GetCategorias();
                                    break;
                                case Utils.Elemento.InstrumentosEmpresas:
                                    Instrumentos_Empresas EmpresatoDelete = (Instrumentos_Empresas)this.radGridViewListado.SelectedItem;
                                    InstrumentosEmpresas_DA.Delete(EmpresatoDelete);
                                    DataSource.instrumentosEmpresas.Remove(EmpresatoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = InstrumentosEmpresas_DA.GetAll().OrderBy(c => c.Descripcion);
                                    //VM_Instrumentos.GetEmpresas();
                                    break;

                                case Utils.Elemento.InstrumentosPaises:
                                    Instrumentos_Paises PaisestoDelete = (Instrumentos_Paises)this.radGridViewListado.SelectedItem;
                                    InstrumentosPaises_DA.Delete(PaisestoDelete);
                                    DataSource.instrumentosPaises.Remove(PaisestoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = InstrumentosPaises_DA.GetAll().OrderBy(c => c.Descripcion);
                                    break;
                                case Utils.Elemento.InstrumentosDivisas:
                                    Instrumentos_Divisas DivisastoDelete = (Instrumentos_Divisas)this.radGridViewListado.SelectedItem;
                                    Instrumentos_divisas_DA.Delete(DivisastoDelete);
                                    DataSource.instrumentosDivisas.Remove(DivisastoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = Instrumentos_divisas_DA.GetAll().OrderBy(c => c.Descripcion);
                                    break;
                                case Utils.Elemento.InstrumentosTipos:
                                    Instrumentos_Tipos tipotoDelete = (Instrumentos_Tipos)this.radGridViewListado.SelectedItem;
                                    InstrumentosTipos_DA.Delete(tipotoDelete);
                                    DataSource.instrumentosTipos.Remove(tipotoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = InstrumentosTipos_DA.GetAll().OrderBy(c => c.Descripcion);
                                    break;
                                case Utils.Elemento.InstrumentosZonas:
                                    Instrumentos_Zonas zonatoDelete = (Instrumentos_Zonas)this.radGridViewListado.SelectedItem;
                                    InstrumentosZonas_DA.Delete(zonatoDelete);
                                    DataSource.instrumentosZonas.Remove(zonatoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = InstrumentosZonas_DA.GetAll().OrderBy(c => c.Descripcion);
                                    break;
                                case Utils.Elemento.InstrumentosSectores:
                                    Instrumentos_Sectores sectortoDelete = (Instrumentos_Sectores)this.radGridViewListado.SelectedItem;
                                    InstrumentosSectores_DA.Delete(sectortoDelete);
                                    DataSource.instrumentosSectores.Remove(sectortoDelete);
                                    this.radGridViewListado.ItemsSource = null;
                                    this.radGridViewListado.ItemsSource = InstrumentosSectores_DA.GetAll().OrderBy(c => c.Descripcion);
                                    break;
                            }
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



}
