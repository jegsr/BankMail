using BankService;
using Database.ServiceReference;
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
    /// Classe responsavél por toda a lógica de interacção com o ContactosReport.xaml
    /// </summary>
    public partial class ContactosReport : UserControl
    {
        private string UserLogged;
        public ContactosReport(string UserLogged)
        {
            InitializeComponent();
            this.UserLogged = UserLogged;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           

            var d = (new BankServiceClient()).SearchMeusContatos("",UserLogged).ToList();

            string exeFolder = (System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath)).Substring(0, (System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath)).Length - 3);
            string reportPath = System.IO.Path.Combine(exeFolder, @"ReportContactos.rdlc");

            Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetContactos", d);
            this.reportViewer.LocalReport.DataSources.Add(rds);
            this.reportViewer.LocalReport.ReportPath = reportPath;
            this.reportViewer.RefreshReport();
        }
    }
}
