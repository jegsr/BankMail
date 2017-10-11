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
    /// Classe responsavél por toda a lógica de interacção com o Registo.xaml
    /// </summary>
    public partial class Registo : Window
    {
        public Registo()
        {
            InitializeComponent();

        }
        private void gotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).GotFocus -= gotFocus;
                ((TextBox)sender).Foreground = Brushes.Black;
                ((TextBox)sender).ClearValue(Border.BorderBrushProperty);
            }else
            {
                ((PasswordBox)sender).GotFocus -= gotFocus;
                ((PasswordBox)sender).Foreground = Brushes.Black;
                ((PasswordBox)sender).ClearValue(Border.BorderBrushProperty);
            }

        }

        private void bttRegisto_click(object sender, RoutedEventArgs e)
        {
            bool erros = false;

            if (tbNome.Text.Trim().Equals("") || tbNome.Text.Trim().Equals("Por favor, insira algum nome!"))
            {
                tbNome.BorderBrush = Brushes.Red;
                tbNome.Foreground = Brushes.Red;
                tbNome.Text = "Por favor, insira algum nome!";
                tbNome.GotFocus += gotFocus;
                erros = true;
            }

            if (tbUsername.Text.Trim().Equals("") || tbUsername.Text.Trim().Equals("Por favor, insira um username!"))
            {
                tbUsername.BorderBrush = Brushes.Red;
                tbUsername.Foreground = Brushes.Red;
                tbUsername.Text = "Por favor, insira algum username!";
                tbUsername.GotFocus += gotFocus;
                erros = true;
            }

            if (tbPassword.Password.Trim().Equals("") )
            {
                tbPassword.BorderBrush = Brushes.Red;
                tbPassword.Foreground = Brushes.Red;
                tbPassword.GotFocus += gotFocus;
                erros = true;
            }

            if (tbMorada.Text.Trim().Equals("") || tbMorada.Text.Trim().Equals("Por favor, insira uma morada!"))
            {
                tbMorada.BorderBrush = Brushes.Red;
                tbMorada.Foreground = Brushes.Red;
                tbMorada.Text = "Por favor, insira uma morada!";
                tbMorada.GotFocus += gotFocus;
                erros = true;
            }

            if (!Regex.Match(tbTelemovel.Text, @"^([2-8][0-9]{8}|9([1-3]|6)[0-9]{7})$").Success)
            {
                tbTelemovel.BorderBrush = Brushes.Red;
                tbTelemovel.Foreground = Brushes.Red;
                tbTelemovel.Text = "Por favor, insira um número! [9 digitos]";
                tbTelemovel.GotFocus += gotFocus;
                erros = true;
            }
            
            if(!erros)
            {
                bool result = (this.Owner.DataContext as VMlogin).addRegisto(tbNome.Text, tbUsername.Text, tbPassword.Password, tbMorada.Text, tbTelemovel.Text);

                if (result)
                {
                    MessageBox.Show("Registo Efectuado com Sucesso!", "Registo Valido", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Owner.Visibility = Visibility.Visible;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esse username já existe. Por favor tente novamente!","Username Invalido",MessageBoxButton.OK,MessageBoxImage.Warning);
                }


            }
        }

        private void bttCancelar_click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Visibility = Visibility.Visible;



        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape) { 
                this.bttCancelar_click(null,new RoutedEventArgs());
            }
        }
    }
}
