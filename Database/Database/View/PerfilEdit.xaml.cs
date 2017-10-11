using Database.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Classe responsavél por toda a lógica de interacção com o PerfilEdit.xaml
    /// </summary>
    public partial class PerfilEdit : Window
    {
        public PerfilEdit()
        {
            InitializeComponent();
        }

        private void bttVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Visibility = Visibility.Visible;
            this.Close();
        }
        private void gotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).GotFocus -= gotFocus;
                ((TextBox)sender).Foreground = Brushes.Black;
                ((TextBox)sender).ClearValue(Border.BorderBrushProperty);
            }
            else
            {
                ((PasswordBox)sender).GotFocus -= gotFocus;
                ((PasswordBox)sender).Foreground = Brushes.Black;
                ((PasswordBox)sender).ClearValue(Border.BorderBrushProperty);
            }

        }

        private void bttEditar_Click(object sender, RoutedEventArgs e)
        {
            bool erros = false;

            if (!tbTelemovel.Text.Trim().Equals("") && !Regex.Match(tbTelemovel.Text, @"^([2-8][0-9]{8}|9([1-3]|6)[0-9]{7})$").Success)
            {
                tbTelemovel.BorderBrush = Brushes.Red;
                tbTelemovel.Foreground = Brushes.Red;
                tbTelemovel.GotFocus += gotFocus;
                tbTelemovel.Text= "Por favor, insira um número! [9 digitos]";
                erros = true;
            }
            if (!tbPasswordConfirmar.Password.Equals(tbPassword.Password)) {
                tbPasswordConfirmar.BorderBrush = Brushes.Red;
                tbPassword.BorderBrush = Brushes.Red;
                tbPasswordConfirmar.Password = "";
                tbPassword.Password = "";
                tbPassword.GotFocus += gotFocus;
                tbPasswordConfirmar.GotFocus += gotFocus;
                MessageBox.Show("Password deve ser igual nos 2 campos!","Password Invalida",MessageBoxButton.OK,MessageBoxImage.Warning);
                erros = true;
            }
            if(!erros)
            {

                (DataContext as VMmanager).editarUtilizador(tbPassword.Password);
                this.Owner.Visibility = Visibility.Visible;
                this.Close();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                bttVoltar_Click(null,new RoutedEventArgs());
            }
        }
    }
}
