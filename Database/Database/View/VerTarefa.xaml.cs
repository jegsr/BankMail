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
    /// Classe responsavél por toda a lógica de interacção com o VerTarefa.xaml
    /// </summary>
    public partial class VerTarefa : Window
    {
        public VerTarefa(bool tmp)
        {
            
            InitializeComponent();
            if (tmp)
            {
                this.editable();
            }
        }

        private void editable() {
            tbTitulo.IsReadOnly = false;
            tbData.IsEnabled = true;
            tbCorpo.IsReadOnly = false;
        }

        private void bttVoltar_click(object sender, RoutedEventArgs e)
        {

            this.Owner.Visibility = Visibility.Visible;
            this.Close();
        }

        private void bttEditar_Click(object sender, RoutedEventArgs e)
        {
            if (tbCorpo.IsReadOnly == true)
            {
                this.editable();
            }
            else
            {
                if (tbTitulo.Text.Trim().Equals("") || tbTitulo.Text.Trim().Equals("Por favor, insira algum titulo"))
                {
                    tbTitulo.BorderBrush = Brushes.Red;
                    tbTitulo.Foreground = Brushes.Red;
                    tbTitulo.Text = "Por favor, insira algum assunto";

                }
                else
                {
                    DateTime tmp = DateTime.Now;

                    if (tbData.SelectedDate != null)
                    {
                        tmp = (tbData.SelectedDate).Value;
                    }
                    (DataContext as VMtarefas).SelectedTarefa.Data = tmp;
                    (DataContext as VMtarefas).EditTarefa();
                    this.Close();
                    this.Owner.Visibility = Visibility.Visible;
                }
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.bttVoltar_click(null, new RoutedEventArgs());
            }
        }
    }
}
