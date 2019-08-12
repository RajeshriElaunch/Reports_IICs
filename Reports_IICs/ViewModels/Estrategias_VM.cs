using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Reports_IICs.ViewModels
{
    public class ActionCombo : INotifyPropertyChanged
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
                    this.OnPropertyChangedCombo("ID");
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
                    this.OnPropertyChangedCombo("Name");
                }
            }
        }

        public ActionCombo()
        {

        }

        public ActionCombo(int id, string name)
        {
            this.id = id;
            this.name = name;

        }

        protected virtual void OnPropertyChangedCombo(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChangedCombo(string propertyName)
        {
            this.OnPropertyChangedCombo(new PropertyChangedEventArgs(propertyName));
        }

        public static ObservableCollection<ActionCombo> GetActions()
        {
            var actions = new ObservableCollection<ActionCombo>();
            ActionCombo action;

            action = new ActionCombo(1, "Eliminar");
            actions.Add(action);
            return actions;
        }

        //public static ObservableCollection<ActionCombo> GetActionsOnlyEdit()
        //{
        //    var actions = new ObservableCollection<ActionCombo>();
        //    ActionCombo action;

        //    action = new ActionCombo(1, "Editar");
        //    actions.Add(action);
        //    return actions;
        //}

        public static ObservableCollection<ActionCombo> GetActionsOnlyDelete()
        {
            var actions = new ObservableCollection<ActionCombo>();
            ActionCombo action;

            action = new ActionCombo(1, "Eliminar");
            actions.Add(action);
            return actions;
        }

    }

    #region CustomClasses for generate combobox multiselect
    public class NotifyPropertyChangedCombo : INotifyPropertyChanged
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
            return string.Join(", ", (value as IEnumerable<DataItemCombo>).Select(item => item.Text).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DataItemCombo : NotifyPropertyChangedCombo
    {
        private string text;
        private bool isChecked;
        private Object item;

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

        public object Item
        {
            get
            {
                return this.item;
            }
            set
            {
                if (this.item != value)
                {
                    this.item = value;
                    this.OnPropertyChanged("Item");
                }
            }
        }
        public DataItemCollectionCombo Owner { get; private set; }

        public void SetOwner(DataItemCollectionCombo owner)
        {
            this.Owner = owner;
        }

        public void ClearOwner()
        {
            this.Owner = null;
        }
    }

    public class DataItemCollectionCombo : ObservableCollection<DataItemCombo>
    {
        private ObservableCollection<DataItemCombo> checkedItems;
        public ObservableCollection<DataItemCombo> CheckedItems
        {
            get
            {
                if (this.checkedItems == null)
                {
                    this.checkedItems = new ObservableCollection<DataItemCombo>();
                }
                return this.checkedItems;
            }
        }

        protected override void ClearItems()
        {
            base.ClearItems();

            foreach (DataItemCombo item in this)
            {
                item.ClearOwner();
                item.PropertyChanged -= this.OnItemPropertyChanged;
            }
        }

        protected override void InsertItem(int index, DataItemCombo item)
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

        protected override void SetItem(int index, DataItemCombo item)
        {
            base.SetItem(index, item);

            item.SetOwner(this);
            item.PropertyChanged += this.OnItemPropertyChanged;
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                var item = sender as DataItemCombo;
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


    public class DataViewModelCombo : NotifyPropertyChangedCombo
    {
        public DataViewModelCombo()
        {
            this.DataItemsCombo = new DataItemCollectionCombo();
            //foreach (var item in Secciones_DA.GetAll())
            //{
            //    this.DataItems.Add(new DataItem() { Text = item.Descripcion,Seccion=(Seccione)item });
            //}

        }

        public DataItemCollectionCombo DataItemsCombo { get; private set; }
    }

    #endregion
    public class Estrategias_VM : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Actions

        private ObservableCollection<ActionCombo> _actions;


        public ObservableCollection<ActionCombo> Actions
        {
            get
            {
                if (this._actions == null)
                {
                    this._actions = ActionCombo.GetActions();
                }

                return this._actions;
            }
        }

        private ObservableCollection<ActionCombo> _actionsonlydelete;

        public ObservableCollection<ActionCombo> ActionsOnlyDelete
        {
            get
            {
                if (this._actionsonlydelete == null)
                {
                    this._actionsonlydelete = ActionCombo.GetActionsOnlyDelete();
                }

                return this._actionsonlydelete;
            }
        }
        
        #endregion

        
        #region Estrategias


        private ObservableCollection<Plantillas_Estrategias> estrategias;

        public ObservableCollection<Plantillas_Estrategias> Estrategias
        {
            get
            {
                if (this.estrategias == null)
                {
                    this.estrategias = GetEstrategias();
                }

                return this.estrategias;
            }
        }
        
        public static ObservableCollection<Plantillas_Estrategias> GetEstrategias()
        {
            var estrategias = new ObservableCollection<Plantillas_Estrategias>(Plantillas_DA.GetEstrategias());

            return estrategias;
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
