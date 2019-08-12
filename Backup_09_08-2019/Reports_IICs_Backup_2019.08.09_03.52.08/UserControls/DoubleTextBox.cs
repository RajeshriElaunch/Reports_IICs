using Core.Framework;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace Reports_IICs.UserControls
{

    public class DoubleTextBox : TextBox
    {
        public decimal? Number;
        public DoubleTextBox()
        {
            VerticalAlignment = VerticalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;            

            activarDesactEventos(true);
            //LostFocus += DoubleTextBox_LostFocus;
            //PreviewTextInput += NumberValidationTextBox;
            //TextChanged += TextChangedTextBox;
        }

        void DoubleTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            //Text = Number.ToString("N2");
        }

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {                        
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != "." && e.Text!=",")
                e.Handled = true;            
        }

        private void activarDesactEventos(bool activar)
        {
            if(activar)
            {
                LostFocus += DoubleTextBox_LostFocus;
                PreviewTextInput += NumberValidationTextBox;
                TextChanged += TextChangedTextBox;
            }
            else
            {
                LostFocus -= DoubleTextBox_LostFocus;
                PreviewTextInput -= NumberValidationTextBox;
                TextChanged -= TextChangedTextBox;
            }
        }

        private void TextChangedTextBox(object sender, TextChangedEventArgs e)
        {
            //Desactivamos los eventos para realizar los cambios
            activarDesactEventos(false);

            //posición actual del cursor (la guardamos porque en ocasiones se mueve al inicio del texto)
            int cursorPos = ((TextBox)sender).CaretIndex;
            //admitimos el '.' como ',' pero sólo uno
            Text = Text.Replace('.', ',');

            //Si existe más de una coma, borramos la última
            int count = Text.Count(f => f == ',');

            
            if (count > 1)
                Text = Text.Remove(Text.LastIndexOf(","), 1);
            

            if (Common.IsDecimal(Text))
                Number = Common.ToDecimal(Text);

            ((TextBox)sender).CaretIndex = cursorPos;

            //Si la longitud del texto que se carga en el control es superior al MaxLength fijado
            //eliminamos los últimos caracteres sobrantes
            if (Text.Length > MaxLength)
                Text = Text.Remove(MaxLength);

            //Volvemos a activar los eventos
            activarDesactEventos(true);
        }

    }
}
