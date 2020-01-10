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
using ContabilidadPymes.Controles.ControlReportesCrystal;

namespace ContabilidadPymes.Ventanas.vtnReportes
{
    /// <summary>
    /// Lógica de interacción para vtnReportesCompras.xaml
    /// </summary>
    public partial class vtnReportesCompras : Window
    {
        public string nit { get; set; }
        public string contribuyente { get; set; }

        public vtnReportesCompras()
        {
            InitializeComponent();
        }

        public vtnReportesCompras(string _nit, string _contribuyente)
        {
            InitializeComponent();
            nit = _nit;
            contribuyente = _contribuyente;
        }

        public string _nit { get { return nit; } set { nit = value; } }
        public string _contribuyente { get { return contribuyente; } set { contribuyente = value; } }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new rptcCompras(_nit,_contribuyente));
        }
    }
}
