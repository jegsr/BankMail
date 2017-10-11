using BankService.Framework;
using BankService.Model;
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
    /// Classe responsavél por toda a lógica de interacção com o Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new VMlogin();
        }


        private void bttLogin_Click(object sender, RoutedEventArgs e)
        {

            if ((DataContext as VMlogin).processLogin(tbUsername.Text, tbPassword.Password))
            {
                MessageBox.Show("Seja Bem-Vindo " + tbUsername.Text + "!","Boas Vindas",MessageBoxButton.OK, MessageBoxImage.Information);

                MailBox mail = new MailBox();
                mail.DataContext = new VMmanager((DataContext as VMlogin).UserLogged);
                this.Close();
                mail.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Login Inválido! Tente Novamente!","Login Invalido",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Manda para o registo
        private void bttRegist_Click(object sender, RoutedEventArgs e)
        {
            Registo a = new Registo();
            this.Visibility = Visibility.Hidden;
            a.Owner = this;
            a.ShowDialog();

        }

        private void pressEnter(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter)
            {
                this.bttLogin_Click(sender,e);
            }
        }
    }
}
