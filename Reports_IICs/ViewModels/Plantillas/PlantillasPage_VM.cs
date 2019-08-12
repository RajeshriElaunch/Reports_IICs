using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;


namespace Reports_IICs.ViewModels.Plantillas
{
    public class Action : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string name;


        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    this.OnPropertyChanged("ID");
                }
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public Action()
        {

        }

        public Action(int id, string name)
        {
            this.id = id;
            this.name = name;

        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public static ObservableCollection<Action> GetActions()
        {
            ObservableCollection<Action> actions = new ObservableCollection<Action>();
            Action action;


            action = new Action(1, "Editar");
            actions.Add(action);
            action = new Action(2, "Eliminar");
            actions.Add(action);
            return actions;
        }

        public static ObservableCollection<Action> GetActionsParam()
        {
            ObservableCollection<Action> actions = new ObservableCollection<Action>();
            Action action;


            action = new Action(1, "Parámetros");
            actions.Add(action);
            action = new Action(2, "Eliminar");
            actions.Add(action);
            return actions;
        }

        public static ObservableCollection<Action> GetActionsOnlyEdit()
        {
            ObservableCollection<Action> actions = new ObservableCollection<Action>();
            Action action;

            action = new Action(1, "Editar");
            actions.Add(action);
            return actions;
        }

        public static ObservableCollection<Action> GetActionsOnlyDelete()
        {
            ObservableCollection<Action> actions = new ObservableCollection<Action>();
            Action action;
            
            action = new Action(1, "Eliminar");
            actions.Add(action);
            return actions;
        }

    }

    #region CustomClasses for generate combobox multiselect
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class CommaSeparatedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Join(", ", (value as IEnumerable<DataItem>).Select(item => item.Text).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DataItem : NotifyPropertyChanged
    {
        private string text;
        private bool isChecked;
        private Seccione seccion;

        public bool IsChecked
        {
            get
            {
                return this.isChecked;
            }
            set
            {
                if (this.isChecked != value)
                {
                    this.isChecked = value;
                    this.OnPropertyChanged("IsChecked");
                }
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }

        public Seccione Seccion
        {
            get
            {
                return this.seccion;
            }
            set
            {
                if (this.seccion != value)
                {
                    this.seccion = value;
                    this.OnPropertyChanged("Seccion");
                }
            }
        }
        public DataItemCollection Owner { get; private set; }

        public void SetOwner(DataItemCollection owner)
        {
            this.Owner = owner;
        }

        public void ClearOwner()
        {
            this.Owner = null;
        }
    }

    public class DataItemCollection : ObservableCollection<DataItem>
    {
        private ObservableCollection<DataItem> checkedItems;
        public ObservableCollection<DataItem> CheckedItems
        {
            get
            {
                if (this.checkedItems == null)
                {
                    this.checkedItems = new ObservableCollection<DataItem>();
                }
                return this.checkedItems;
            }
        }

        protected override void ClearItems()
        {
            base.ClearItems();

            foreach (DataItem item in this)
            {
                item.ClearOwner();
                item.PropertyChanged -= this.OnItemPropertyChanged;
            }
        }

        protected override void InsertItem(int index, DataItem item)
        {
            base.InsertItem(index, item);

            item.SetOwner(this);
            item.PropertyChanged += this.OnItemPropertyChanged;
        }

        protected override void RemoveItem(int index)
        {
            this[index].ClearOwner();
            this[index].PropertyChanged -= this.OnItemPropertyChanged;

            base.RemoveItem(index);
        }

        protected override void SetItem(int index, DataItem item)
        {
            base.SetItem(index, item);

            item.SetOwner(this);
            item.PropertyChanged += this.OnItemPropertyChanged;
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                DataItem item = sender as DataItem;
                if (item.IsChecked)
                {
                    if (this.checkedItems == null || !this.CheckedItems.Contains(item))
                    {
                        this.CheckedItems.Add(item);
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CheckedItems"));
                    }
                }
                else
                {
                    if (this.checkedItems != null && this.CheckedItems.Contains(item))
                    {
                        this.CheckedItems.Remove(item);
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CheckedItems"));
                    }
                }
            }
        }
    }


    public class DataViewModelComboBoxSeccion : NotifyPropertyChanged
    {
        public DataViewModelComboBoxSeccion()
        {
            this.DataItems = new DataItemCollection();
            //foreach (var item in Secciones_DA.GetAll())
            //{
            //    this.DataItems.Add(new DataItem() { Text = item.Descripcion,Seccion=(Seccione)item });
            //}
          
        }

        public DataItemCollection DataItems { get; private set; }
    }

    #endregion

    public class PlantillasPage_VM : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Actions

        private ObservableCollection<Action> _actions;


        public ObservableCollection<Action> Actions
        {
            get
            {
                if (this._actions == null)
                {
                    this._actions = Action.GetActions();
                }

                return this._actions;
            }
        }




        private ObservableCollection<Action> _actionsparam;

        public ObservableCollection<Action> ActionsParam
        {
            get
            {
                if (this._actionsparam == null)
                {
                    this._actionsparam = Action.GetActionsParam();
                }

                return this._actionsparam;
            }
        }

       
        private ObservableCollection<Action> _actionsonlydelete;

        public ObservableCollection<Action> ActionsOnlyDelete
        {
            get
            {
                if (this._actionsonlydelete == null)
                {
                    this._actionsonlydelete = Action.GetActionsOnlyDelete();
                }

                return this._actionsonlydelete;
            }
        }


        private ObservableCollection<Action> _actionsonlyedit;

        public ObservableCollection<Action> ActionsOnlyEdit
        {
            get
            {
                if (this._actionsonlyedit == null)
                {
                    this._actionsonlyedit = Action.GetActionsOnlyEdit();
                }

                return this._actionsonlyedit;
            }
        }

        #endregion

        #region Plantilla
        public static List<Plantilla> GetPlantillas(string codigoIC = null)
        {            
            //ObservableCollection<Plantilla> plantillas = new ObservableCollection<Plantilla>();
            var plantillas = Plantillas_DA.GetAll().ToList();
            //foreach (var item in Plantillas_DA.GetAll())
            //{
            //    Plantilla tmp_plantilla = new Plantilla();
            //    tmp_plantilla.CodigoIc = item.CodigoIc;
            //    tmp_plantilla.Descripcion = item.Descripcion;
            //    tmp_plantilla.FechaCreacion = item.FechaCreacion;
            //    tmp_plantilla.IdTipo = item.IdTipo;
            //    tmp_plantilla.Plantillas_Indices_Referencia = item.Plantillas_Indices_Referencia;
            //    tmp_plantilla.Plantillas_Isins = item.Plantillas_Isins;
            //    tmp_plantilla.Plantillas_Participes = item.Plantillas_Participes;
            //    tmp_plantilla.Plantillas_Secciones = item.Plantillas_Secciones;
            //    tmp_plantilla.Tipos = item.Tipos;

            //    plantillas.Add(tmp_plantilla);
            //}

            return plantillas;
        }

        public static Plantilla GetPlantilla(string codigoIC)
        {
            try
            {
                return Plantillas_DA.GetPlantilla(codigoIC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        private List<Plantilla> plantillas;

        public List<Plantilla> Plantillas
        {
            get
            {
                if (this.plantillas == null)
                {
                    this.plantillas = GetPlantillas();
                }

                return this.plantillas;
            }
        }

        private List<Plantilla> plantillasSorted;

        public List<Plantilla> PlantillasSorted
        {
            get
            {
                if (this.plantillasSorted == null)
                {
                    this.plantillasSorted = GetPlantillas().OrderBy(o => o.Descripcion).ToList();
                }

                return this.plantillasSorted;
            }
        }

        public  bool GuardarPlantilla(Plantilla plantilla,string CodigoIcBeforeupdate, out Plantilla PlantillaUpdated)
        {
            try
            {
                
                bool result = false;
                //Plantillas_DA.GuardarPlantilla(plantilla);
                Plantilla SPlantillaUpdated;
                result = Plantillas_DA.SavePlantilla(plantilla, CodigoIcBeforeupdate, out SPlantillaUpdated);
                PlantillaUpdated = SPlantillaUpdated;
                return result;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Generaciones
        public static List<Plantilla> GetGeneraciones()
        {
           var plantillas = Plantillas_DA.GetGeneraciones();
           return plantillas;
        }

        private List<Plantilla> generaciones;

        public List<Plantilla> Generaciones
        {
            get
            {
                if (this.generaciones == null)
                {
                    this.generaciones = GetGeneraciones().OrderBy(o=>o.Descripcion).ToList();
                }

                return this.generaciones;
            }
        }
        #endregion

        
        #region Indices referencia Tipos


        private ObservableCollection<Indices_Referencia_Tipos> indicesreferenciatipos;

        public ObservableCollection<Indices_Referencia_Tipos> IndicesReferenciaTipos
        {
            get
            {
                if (this.indicesreferenciatipos == null)
                {
                    this.indicesreferenciatipos = GetIndices_Referencia_Tipos();
                }

                return this.indicesreferenciatipos;
            }
        }
        
        #region ParticipesSalat

        private ObservableCollection<ParticipesSalat> parametrosParticipesSalat;

        public ObservableCollection<ParticipesSalat> ParametrosParticipesSalat
        {
            get
            {
                if (this.parametrosParticipesSalat == null)
                {
                    this.parametrosParticipesSalat = GetParametros_ParticipesSalat();
                }

                return this.parametrosParticipesSalat;
            }
        }

        public static ObservableCollection<ParticipesSalat> GetParametros_ParticipesSalat()
        {

            ObservableCollection<ParticipesSalat> lista = new ObservableCollection<ParticipesSalat>();

            foreach (var item in ParticipesSalat_DA.GetParametros_ParticipesSalat())
            {
                var tmp = new ParticipesSalat();
                Utils.CopyPropertyValues(item, tmp);

                lista.Add(tmp);
            }

            return lista;
        }

        private ObservableCollection<ParticipesSalat_Participes> participesSalat_Participes;

        public ObservableCollection<ParticipesSalat_Participes> ParticipesSalat_Participes
        {
            get
            {
                if (this.parametrosParticipesSalat == null)
                {
                    this.participesSalat_Participes = GetParticipesSalat_Participes();
                }

                return this.participesSalat_Participes;
            }
        }

        public static ObservableCollection<ParticipesSalat_Participes> GetParticipesSalat_Participes()
        {

            var lista = new ObservableCollection<ParticipesSalat_Participes>();

            foreach (var item in ParticipesSalat_DA.GetParticipesSalat_Participes())
            {
                var tmp = new ParticipesSalat_Participes();
                Utils.CopyPropertyValues(item, tmp);

                lista.Add(tmp);
            }

            return lista;
        }

        #endregion

        public static ObservableCollection<Indices_Referencia_Tipos> GetIndices_Referencia_Tipos()
        {

            ObservableCollection<Indices_Referencia_Tipos> IndicesRefTipos = new ObservableCollection<Indices_Referencia_Tipos>();

            foreach (var item in Plantillas_DA.GetIndices_Referencia_Tipos())
            {
                Indices_Referencia_Tipos tmp_indiceRefTipos = new Indices_Referencia_Tipos();
                tmp_indiceRefTipos.Id = item.Id;
                tmp_indiceRefTipos.Descripcion = item.Descripcion;


                IndicesRefTipos.Add(tmp_indiceRefTipos);
            }

            return IndicesRefTipos;
        }


        #endregion

        #region Secciones


        private ObservableCollection<Seccione> secciones;

        public ObservableCollection<Seccione> Secciones
        {
            get
            {
                if (this.secciones == null)
                {
                    this.secciones = GetSecciones();
                }

                return this.secciones;
            }
        }

        public static ObservableCollection<Seccione> GetSecciones()
        {

            ObservableCollection<Seccione> Secciones = new ObservableCollection<Seccione>();

            foreach (var item in Secciones_DA.GetAll())
            {
                Seccione tmp_secciones = new Seccione();
                tmp_secciones.Id = item.Id;
                tmp_secciones.Descripcion = item.Descripcion;
                tmp_secciones.TieneParametrosPrevios = item.TieneParametrosPrevios;
                tmp_secciones.TienePreview = item.TienePreview;
                tmp_secciones.TieneValidacionesPrevias = item.TieneValidacionesPrevias;

                Secciones.Add(tmp_secciones);
            }

            //var Secciones = Secciones_DA.GetAll().ToList();
            return Secciones;
        }

        
        #endregion

        #region IDataErrorInfo Members

        public Plantilla SelectedPlantilla { get; set; }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

               
                if (columnName == "SelectedPlantilla")
                {

                    if (SelectedPlantilla == null)
                        result = Resources.Resource.SeleccionePlantilla_Message;

                }

                return result;
            }
        }
        #endregion

    }
}
