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

namespace ContabilidadPymes.Controles.ControlReportes
{
    /// <summary>
    /// Lógica de interacción para ReporteHonorarios.xaml
    /// </summary>
    public partial class ReporteHonorarios : UserControl
    {
        string parametros;
        ClassFiltros classFiltros = new ClassFiltros();

        public ReporteHonorarios()
        {
            InitializeComponent();
            VistaGeneral();
        }

        private void BtnActualizarBD_Click(object sender, RoutedEventArgs e)
        {
            VistaGeneral();
        }

        public void VistaGeneral()
        {
            parametros = "";
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltrosHonorarios(parametros).Tables[0].DefaultView;
        }
    }
}
