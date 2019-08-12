using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reports_IICs.Pages.Previews.ParticipesSalat
{
    /// <summary>
    /// Lógica de interacción para EditableTextBox.xaml
    /// </summary>
    public partial class EditableTextBox : UserControl
    {
        public string Text { get; internal set; }

        public event EventHandler TextChanged;
        //public event EventHandler MouseLeftButtonDown;

        public EditableTextBox()
        {
            InitializeComponent();
            Txt_Texto.Text = Text;
        }

        private void IMG_Pencil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Txt_Texto.Focus();
        }

        private void Txt_Texto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
