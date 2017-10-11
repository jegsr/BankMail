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
    /// Classe responsavél por toda a lógica de interacção com o VerMensagem.xaml
    /// </summary>
    public partial class VerMensagem : Window
    {
        public VerMensagem()
        {
            InitializeComponent();        
        }

        private void btnClick_Voltar(object sender, RoutedEventArgs e)
        {
           
            this.Owner.Visibility = Visibility.Visible;
            this.Close();
        }

        private void btnClick_Responder(object sender, RoutedEventArgs e)
        {
            if( (DataContext as VMmanager).SelectedMail.Flag == 2)
            {
                NovaMensagem tmp = new NovaMensagem();
                tmp.txtDestino.Text = txtDestino.Text;
                tmp.txtAssunto.Text = txtAssunto.Text;
                tmp.txtMensagem.Text = txtMensagem.Text;
                this.Visibility = Visibility.Hidden;
                tmp.Owner = this.Owner;
                this.Close();
                this.Owner.Visibility = Visibility.Visible;
               
                (DataContext as VMmanager).delMail();
                
                tmp.Show();
                
            }
            else{
            

            NovaMensagem tmp = new NovaMensagem();
            tmp.txtDestino.Text = txtDestino.Text;
            tmp.txtAssunto.Text = "[RE]:" + txtAssunto.Text;
            this.Visibility = Visibility.Hidden;
            tmp.Owner = this.Owner;
            

            this.Owner.Visibility = Visibility.Visible;
            this.Close();

            tmp.Show();

            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                this.btnClick_Voltar(null, new RoutedEventArgs());
            }
        }
    }
}
