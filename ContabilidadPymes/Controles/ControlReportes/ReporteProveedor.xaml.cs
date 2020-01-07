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
    /// Lógica de interacción para ReporteProveedor.xaml
    /// </summary>
    public partial class ReporteProveedor : UserControl
    {
        ClassFiltros classFiltros = new ClassFiltros();

        public ReporteProveedor()
        {
            InitializeComponent();
            VistaGeneral();
        }

        private void BtnFiltros_Click(object sender, RoutedEventArgs e)
        {
            Filtros();
        }

        private void BtnBorrarFiltros_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
            VistaGeneral();
        }

        private void BtnActualizarBD_Click(object sender, RoutedEventArgs e)
        {
            VistaGeneral();
        }

        string parametros;
        public void Filtros()
        {
            parametros = "";
            if (txtFechas.Text != "")
            {
                if (parametros=="")
                {
                    parametros = " nit = " + txtFechas.Text;
                }
                else
                {
                    parametros += " and nit = " + txtFechas.Text;
                }
            }
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltroProveedor(parametros).Tables[0].DefaultView;           
        }

        public void VistaGeneral()
        {
            parametros = "";
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltroProveedor(parametros).Tables[0].DefaultView;
        }

        public void LimpiarTxt()
        {
            txtFechas.Text = "";
        }
    }
}
