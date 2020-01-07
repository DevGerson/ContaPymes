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
using ContabilidadPymes.Controles.ControlReportes;

namespace ContabilidadPymes.Ventanas
{
    /// <summary>
    /// Lógica de interacción para vtnReporteCompras.xaml
    /// </summary>
    public partial class vtnReporteCompras : Window
    {
        public vtnReporteCompras()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Contenedor.Children.Clear();
            Contenedor.Children.Add(new ReporteCompras());
        }
    }
}
