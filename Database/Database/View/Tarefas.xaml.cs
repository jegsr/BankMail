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
    /// Classe responsavél por toda a lógica de interacção com o Tarefas.xaml
    /// </summary>
    public partial class Tarefas : Window
    {
        public Tarefas(string user)
        {
            InitializeComponent();
            DataContext = new VMtarefas(user);
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            
            this.Owner.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as VMtarefas).DeleteTarefa();
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            AdicionarTarefa tmp = new AdicionarTarefa();
            tmp.Owner = this;
            tmp.Show();
        }

        private void Ver_Click(object sender, RoutedEventArgs e)
        {
            VerTarefa a = new VerTarefa(false);
            this.Visibility = Visibility.Hidden;
            a.Owner = this;
            a.DataContext = this.DataContext;
            a.ShowDialog();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Voltar_Click(null, new RoutedEventArgs());
            }
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            VerTarefa a = new VerTarefa(true);
            this.Visibility = Visibility.Hidden;
            a.Owner = this;
            a.DataContext = this.DataContext;
            a.ShowDialog();
        }
    }
}
