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
    /// Lógica de interacción para vtnReportesPagos.xaml
    /// </summary>
    public partial class vtnReportesPagos : Window
    {
        public vtnReportesPagos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new rptcPagos());
        }
    }
}
