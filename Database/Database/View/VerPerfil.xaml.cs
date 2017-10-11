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
    /// Interaction logic for VerPerfil.xaml
    /// </summary>
    public partial class VerPerfil : Window
    {
        public VerPerfil()
        {
            InitializeComponent();
        }

        private void bttEmail_Click(object sender, RoutedEventArgs e)
        {
            NovaMensagem tmp = new NovaMensagem();
            tmp.txtDestino.Text = tbEmail.Text;

            this.Visibility = Visibility.Hidden;
            tmp.Owner = this.Owner.Owner;


            this.Owner.Visibility = Visibility.Visible;
            this.Close();

            tmp.Show();
        }

        private void btnClick_Voltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
