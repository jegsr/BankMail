using BankService.Model;
using Database.ServiceReference;
using Microsoft.Reporting.WinForms;
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
    /// Classe responsavél por toda a lógica de interacção com o EmailReport.xaml
    /// </summary>
    public partial class EmailReport : UserControl
    {
        private Utilizador UserLogged;
        public EmailReport(Utilizador UserLogged)
        {
            InitializeComponent();
            this.UserLogged = UserLogged;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            var d = (new BankServiceClient()).SearchMensagensLidas("",UserLogged.Email).ToList();
            var c = (new BankServiceClient()).SearchMensagensNaoLidas("", UserLogged.Email).ToList();
            var es = (new BankServiceClient()).SearchMensagensEliminados("", UserLogged.Email).ToList();
            var tudo =  d.Union(c).Union(es).ToList();

            string exeFolder = (System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath)).Substring(0, (System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath)).Length - 3);
            string reportPath = System.IO.Path.Combine(exeFolder, @"ReportEmails.rdlc");


            ReportDataSource rds = new ReportDataSource("DataSetEmails", tudo);
            ReportParameter p = new ReportParameter("dateCriacaoConta", UserLogged.DataRegisto.ToString());
            this.reportViewer2.LocalReport.ReportPath = reportPath;
            this.reportViewer2.LocalReport.DataSources.Add(rds);
            this.reportViewer2.LocalReport.SetParameters(p);

            this.reportViewer2.RefreshReport();
        }
    }
}
