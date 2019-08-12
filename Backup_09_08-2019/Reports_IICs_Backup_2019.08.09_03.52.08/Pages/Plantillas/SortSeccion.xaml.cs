using System.Collections.Generic;
using System.Windows;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Lógica de interacción para SortSeccion.xaml
    /// </summary>
    public partial class SortSeccion : MetroWindow
    {

        public bool Cancel = true;
        private List<string> ListaCodigo = new List<string>();
        public SortSeccion(List<string> listacodigo)
        {
            InitializeComponent();
            ListaCodigo = listacodigo;
            Loaded += OnLoaded;
            

        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            //if (Codigo != null) textBoxCodigo.Text = Codigo.ToString();
            //if (Descripcion != null) textBoxDescription.Text = Descripcion.ToString();
            //if (Tipo != null) ComboBoxTipo.SelectedValue = Tipo;
            // this.SeccionesList.ItemsSource = ListaCodigo;
            foreach (var item in ListaCodigo)
            {
                SeccionesList.Items.Add(item);
            }
            Loaded -= OnLoaded;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }
        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Codigo = this.textBoxCodigo.Text;
            //Descripcion = this.textBoxDescription.Text;
            //Tipo = (int)this.ComboBoxTipo.SelectedValue;
            Cancel = false;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            
            if ((SeccionesList.SelectedIndex > -1) && (SeccionesList.SelectedIndex < SeccionesList.Items.Count - 1))
            {
                int index = SeccionesList.SelectedIndex;
                var current = SeccionesList.SelectedItem;
                SeccionesList.Items.Remove(current);
                SeccionesList.Items.Insert(index + 1, current);
                SeccionesList.SelectedIndex = index + 1;
            }

        }
        private void ButtonUP_Click(object sender, RoutedEventArgs e)
        {
            if (SeccionesList.SelectedIndex > 0)
            {
               
                int index = SeccionesList.SelectedIndex;
                var current = SeccionesList.SelectedItem;
                SeccionesList.Items.Remove(current);
                SeccionesList.Items.Insert(index - 1, current);
                SeccionesList.SelectedIndex = index - 1;
            }


        }



    }
}
