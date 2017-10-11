
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database.View
{
    /// <summary>
    /// Classe responsavél por toda a lógica de interacção com o MailBox.xaml
    /// </summary>
    public partial class MailBox : Window
    {

        public MailBox()
        {

            InitializeComponent();
        }

        private void Novo_Email_Click(object sender, RoutedEventArgs e)
        {
            NovaMensagem tmp = new NovaMensagem();
            tmp.Owner = this;
            tmp.DataContext = this.DataContext;
            tmp.ShowDialog();
        }

        private void btnClick_Receber(object sender, RoutedEventArgs e)
        {

            txtSearch.SetBinding(TextBox.TextProperty, new Binding("PesquisaMensagensNaoLidas")
            {
                Source = (DataContext as VMmanager),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            ltView.SetBinding(ListView.ItemsSourceProperty, new Binding("MailBoxReceber")
            {
                Source = (DataContext as VMmanager),
                IsAsync = true
            });
        }

        private void btnClick_Rascunho(object sender, RoutedEventArgs e)
        {
            txtSearch.SetBinding(TextBox.TextProperty, new Binding("PesquisaMensagensRascunhos")
            {
                Source = (DataContext as VMmanager),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
            ltView.SetBinding(ListView.ItemsSourceProperty, new Binding("MailBoxRascunhos")
            {
                Source = (DataContext as VMmanager),
                IsAsync = true
            });
        }

        private void btnClick_Enviar(object sender, RoutedEventArgs e)
        {
            txtSearch.SetBinding(TextBox.TextProperty, new Binding("PesquisaMensagensEnviadas")
            {
                Source = (DataContext as VMmanager),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
            ltView.SetBinding(ListView.ItemsSourceProperty, new Binding("MailBoxEnviadas")
            {
                Source = (DataContext as VMmanager),
                IsAsync = true
            });
        }

        private void btnClick_Perfil(object sender, RoutedEventArgs e)
        {
            Perfil perfil = new Perfil();
            this.Visibility = Visibility.Hidden;
            perfil.Owner = this;
            perfil.DataContext = this.DataContext;

            perfil.ShowDialog();
        }

        private void btnClick_Eliminados(object sender, RoutedEventArgs e)
        {
            txtSearch.SetBinding(TextBox.TextProperty, new Binding("PesquisaMensagensEliminados")
            {
                Source = (DataContext as VMmanager),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
            ltView.SetBinding(ListView.ItemsSourceProperty, new Binding("MailBoxEliminados")
            {
                Source = (DataContext as VMmanager),
                IsAsync = true
            });
        }

        private void btnClick_Contactos(object sender, RoutedEventArgs e)
        {

            Contactos contactos = new Contactos();
            this.Visibility = Visibility.Hidden;
            contactos.Owner = this;
            contactos.DataContext = this.DataContext;

            contactos.ShowDialog();
        }

        private void btnClick_ReportContactos(object sender, RoutedEventArgs e)
        {


            Window window = new Window
            {

                Content = new ContactosReport((DataContext as VMmanager).UserLogged.Username)

            };
            window.ShowDialog();
        }

        private void btnClick_ReportEmails(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {

                Content = new EmailReport((DataContext as VMmanager).UserLogged)

            };
            window.ShowDialog();
        }

        private void btnVerMensagem_Click(object sender, RoutedEventArgs e)
        {
            VerMensagem verMensagem = new VerMensagem();
            this.Visibility = Visibility.Hidden;
            verMensagem.Owner = this;
            verMensagem.DataContext = this.DataContext;
            if ((DataContext as VMmanager).SelectedMail.Flag == 2)
            {
                verMensagem.bttResponder.Content = "Editar";
            }
            verMensagem.ShowDialog();
        }

        private void btnClick_Lidas(object sender, RoutedEventArgs e)
        {
            txtSearch.SetBinding(TextBox.TextProperty, new Binding("PesquisaMensagensLidas")
            {
                Source = (DataContext as VMmanager),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
            ltView.SetBinding(ListView.ItemsSourceProperty, new Binding("MailBoxReceberLidas")
            {
                Source = (DataContext as VMmanager),
                IsAsync = true
            });
        }

        private void MenuItem_Click_Logout(object sender, RoutedEventArgs e)
        {
            Login tmp = new Login();
            this.Close();
            tmp.Show();
        }

        private void btnClick_tarefa(object sender, RoutedEventArgs e)
        {
            Tarefas tmp = new Tarefas((DataContext as VMmanager).UserLogged.Username);
            this.Visibility = Visibility.Hidden;
            tmp.Owner = this;
            tmp.ShowDialog();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.MenuItem_Click_Logout(null, new RoutedEventArgs());
            }
        }

        private void doube_click_event(object sender, RoutedEventArgs e)
        {
            this.btnVerMensagem_Click(sender, e);
            (this.DataContext as VMmanager).VerMail.Execute(null);

        }
    }
}
