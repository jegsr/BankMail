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
    /// Classe responsavél por toda a lógica de interacção com o AdicionarTarefa.xaml
    /// </summary>
    public partial class AdicionarTarefa : Window
    {
        public AdicionarTarefa()
        {
            InitializeComponent();
        }

        private void gotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).GotFocus -= gotFocus;
            ((TextBox)sender).Foreground = Brushes.Black;
            ((TextBox)sender).ClearValue(Border.BorderBrushProperty);

        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {

            if (tbTitulo.Text.Trim().Equals("") || tbTitulo.Text.Trim().Equals("Por favor, insira algum titulo"))
            {
                tbTitulo.BorderBrush = Brushes.Red;
                tbTitulo.Foreground = Brushes.Red;
                tbTitulo.Text = "Por favor, insira algum assunto";
                tbTitulo.GotFocus += gotFocus;
            }
            else {
                DateTime tmp = DateTime.Now;

                if (tbData.SelectedDate != null ) {
                    tmp = (tbData.SelectedDate).Value;
                }
                (this.Owner.DataContext as VMtarefas).AddTarefa(tbTitulo.Text, tbCorpo.Text, tmp);
                this.Close();
            }
                
        }

        private void bttVoltar_click(object sender, RoutedEventArgs e)
        {
            this.Owner.Visibility = Visibility.Visible;

            this.Close();
        }
    }
}
