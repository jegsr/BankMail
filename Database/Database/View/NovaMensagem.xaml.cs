using Database.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Database.View
{
    /// <summary>
    /// Classe responsavél por toda a lógica de interacção com o NovaMensagem.xaml
    /// </summary>
    public partial class NovaMensagem : Window
    {
        public NovaMensagem()
        {
            InitializeComponent();
        }

        private void btnClick_Enviar(object sender, RoutedEventArgs e)
        {
            bool erros = false;

            if (txtAssunto.Text.Trim().Equals("") || txtAssunto.Text.Trim().Equals("Por favor, insira algum assunto"))
            {
                txtAssunto.BorderBrush = Brushes.Red;
                txtAssunto.Foreground = Brushes.Red;
                txtAssunto.Text = "Por favor, insira algum assunto";
                txtAssunto.GotFocus += gotFocus;
                erros = true;
            }

            if (txtDestino.Text.Trim().Equals("") || txtDestino.Text.Trim().Equals("Por favor, insira algum destinatário"))
            {
                txtDestino.BorderBrush = Brushes.Red;
                txtDestino.Foreground = Brushes.Red;
                txtDestino.Text = "Por favor, insira algum destinatário";
                txtDestino.GotFocus += gotFocus;
                erros = true;
            }
            if (!erros)
            {
              
                (this.Owner.DataContext as VMmanager).addMail(txtAssunto.Text, txtMensagem.Text, txtDestino.Text);
                this.Close();
            }

        }



        private void btnClick_Cancelar(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja guardar nos rascunhos?", "Rascunhos", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                (this.Owner.DataContext as VMmanager).saveMail(txtAssunto.Text, txtMensagem.Text, txtDestino.Text);
            }

            this.Close();

        }

        private void gotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).GotFocus -= gotFocus;
            ((TextBox)sender).Foreground = Brushes.Black;
            ((TextBox)sender).ClearValue(Border.BorderBrushProperty);


        }

        private void btnClick_AdicionarDestino(object sender, RoutedEventArgs e)
        {
            if (autoComplete.Text != "")
            {
                string tmpTxtDestino = txtDestino.Text;
                txtDestino.Text = tmpTxtDestino + autoComplete.Text + ";";
                autoComplete.Text = null;
            }
        }

        private void autoComplete_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                btnClick_AdicionarDestino(null, new RoutedEventArgs());
            }
        }
    }
}
