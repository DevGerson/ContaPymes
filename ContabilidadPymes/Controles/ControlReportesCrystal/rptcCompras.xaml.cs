using CrystalDecisions.CrystalReports.Engine;
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
using ContabilidadPymes.Clases;

namespace ContabilidadPymes.Controles.ControlReportesCrystal
{
    /// <summary>
    /// Lógica de interacción para rptcCompras.xaml
    /// </summary>
    public partial class rptcCompras : UserControl
    {
        ClassConvertidoFechas CDates = new ClassConvertidoFechas();

        public rptcCompras()
        {
            InitializeComponent();
        }

        public rptcCompras(string nit, string contribuyente)
        {
            InitializeComponent();
            txtNit.Text = nit;
            txtNombre.Text = contribuyente;
        }

        public void Actualizar()
        {
            ReportDocument report = new ReportDocument();
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\ReportesCrystalCompras.rpt";

            report.Load(path);
            report.SetParameterValue("@nit", txtNit.Text);
            report.SetParameterValue("@fechaDe", CDates.DateString(txtFechaDe.Text,"yyyy/MM/dd"));
            report.SetParameterValue("@fechaAl", CDates.DateString(txtFechaAl.Text, "yyyy/MM/dd"));
            report.SetParameterValue("Mes", 12);
            report.SetParameterValue("Folio", 12);
            ReporteCrystal.ViewerCore.ReportSource = report;
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }
    }
}
