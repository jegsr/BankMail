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
    /// Classe responsavél por toda a lógica de interacção com o Perfil.xaml
    /// </summary>
    public partial class Perfil : Window
    {

        public Perfil()
        {
            InitializeComponent();
        }

        
        private void bttVoltar_click(object sender, RoutedEventArgs e)
        {

            this.Owner.Visibility = Visibility.Visible;
            
            this.Close();

            
        }

        private void bttEditar_click(object sender, RoutedEventArgs e)
        {
            PerfilEdit perfilEdit = new PerfilEdit();
            this.Visibility = Visibility.Hidden;
            perfilEdit.Owner = this;
            perfilEdit.DataContext = this.DataContext;

            perfilEdit.ShowDialog();
        }

        private void bttEliminar_click(object sender, RoutedEventArgs e)
        {
            (DataContext as VMmanager).delUtilizador();
            VMtarefas a = new VMtarefas((DataContext as VMmanager).UserLogged.Username);
            a.DeleteTarefas();
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.bttVoltar_click(null,new RoutedEventArgs());
            }
        }
    }
}
