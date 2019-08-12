using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews
{
    public class ColumnaGrid
    {
        public enum TipoColumnaGrid
        {
            Texto,
            Fecha,
            Decimal0,
            Decimal1,
            Decimal2,
            Decimal3,
            Decimal4,
            Decimal8
        };
        // string header = null
        private string dataMemberBinding;
        public string DataMemberBinding
        {
            get
            {
                return this.dataMemberBinding;
            }
            set
            {
                if (value != this.dataMemberBinding)
                {
                    this.dataMemberBinding = value;
                }
            }
        }

        private TipoColumnaGrid tipo;
        public TipoColumnaGrid Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                if (value != this.tipo)
                {
                    this.tipo = value;
                }
            }
        }

        private bool isVisible;
        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                if (value != this.isVisible)
                {
                    this.isVisible = value;
                }
            }
        }

        private Nullable<bool> isReadOnly;
        public Nullable<bool> IsReadOnly
        {
            get
            {
                return this.isReadOnly;
            }
            set
            {
                if (value != this.isReadOnly)
                {
                    this.isReadOnly = value;
                }
            }
        }

        private string header;
        public string Header
        {
            get
            {
                return this.header;
            }
            set
            {
                this.header = value;
            }
        }

        private IEnumerable<object> itemsSource;
        public IEnumerable<object> ItemsSource
        {
            get
            {
                return this.itemsSource;
            }
            set
            {
                this.itemsSource = value;
            }
        }

        public ColumnaGrid(string dataMemberBinding,
                           TipoColumnaGrid tipo,
                           bool isVisible,
                           bool isReadOnly = false,
                           string header = null,
                           IEnumerable<object> itemsSource = null)
        {
            DataMemberBinding = dataMemberBinding;
            Tipo = tipo;
            IsVisible = isVisible;
            IsReadOnly = isReadOnly;
            Header = header;
            ItemsSource = itemsSource;
        }
        
    }    

    public class MyButtonColumn : Telerik.Windows.Controls.GridViewColumn
    {
        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {
            //La imagen tiene que estar en la carpeta Resources 
            //y en propiedades tener "Buid action" = "Resource"
            var uri = new Uri("pack://application:,,,/Resources/Button-Delete-icon.png");
            
            var bitmap = new BitmapImage(uri);

            RadButton button = cell.Content as RadButton;
            if (button == null)
            {
                button = new RadButton();
                //button.Content = "Delete";
                button.Content = new Image
                {
                    Source = bitmap,
                    //Source = new BitmapImage(new Uri("/Images/Button-Delete-icon.png", UriKind.Absolute)),

                    //VerticalAlignment = VerticalAlignment.Center
                    Stretch = System.Windows.Media.Stretch.UniformToFill,
                    Width = 15,
                    Height = 15
                };
                button.Command = RadGridViewCommands.Delete;                
            }

            button.CommandParameter = dataItem;

            return button;
        }
    }

    
    
}
