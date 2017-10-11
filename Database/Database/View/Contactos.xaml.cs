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
    /// Classe responsavél por toda a lógica de interacção com o Contactos.xaml
    /// </summary>
    public partial class Contactos : Window
    {
        public Contactos()
        {
            InitializeComponent();
        }


        private void btnClick_Voltar(object sender, RoutedEventArgs e)
        {
            this.Owner.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.btnClick_Voltar(null, new RoutedEventArgs());
            }

            if (e.Key == Key.Enter && (DataContext as VMmanager).SelectedUtilizadorAdicionar != null)
            {
                (DataContext as VMmanager).addContato();
                autoComplete.Text ="";
            }
        }

        private void btnVer_Perfil_click(object sender, RoutedEventArgs e)
        {
            VerPerfil a = new VerPerfil();
            a.Owner = this;
            a.DataContext = this.DataContext;

            a.Show();
        }

        private void doube_click_event(object sender, RoutedEventArgs e)
        {
            this.btnVer_Perfil_click(sender, e);

        }
    }
}
