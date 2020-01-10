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

namespace ContabilidadPymes.Controles.ControlReportesCrystal
{
    /// <summary>
    /// Lógica de interacción para rptcProveedor.xaml
    /// </summary>
    public partial class rptcProveedor : UserControl
    {
        public rptcProveedor()
        {
            InitializeComponent();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }


        public void Actualizar()
        {
            ReportDocument report = new ReportDocument();
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\ReporteCrystalProveedor.rpt";

            report.Load(path);
            ReporteCrystal.ViewerCore.ReportSource = report;
        }
    }
}
