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
    /// Lógica de interacción para ReporteFacturasSeries.xaml
    /// </summary>
    public partial class ReporteFacturasSeries : UserControl
    {
        string parametros;
        ClassFiltros classFiltros = new ClassFiltros();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        public ReporteFacturasSeries()
        {
            InitializeComponent();
            CargarContribuyentes();
        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            Filtros();
        }

        private void BtnQuitarFiltro_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
            VistaGeneral();
        }

        private void BtnFiltros_Click(object sender, RoutedEventArgs e)
        {

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

        private void TxtContribuyente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtContribuyente.SelectedIndex >= 0)
            {
                LimpiarTxt();
                VistaGeneral();
            }
        }

        public void Filtros()
        {
            parametros = "";
            if (txtContribuyente.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " nit = " + txtContribuyente.SelectedValue;
                }
                else
                {
                    parametros += " and nit = " + txtContribuyente.SelectedValue;
                }                
            }
            if (txtCreacion.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " creacion = " + txtCreacion.Text;
                }
                else
                {
                    parametros += " and creacion = " + txtCreacion.Text;
                }
            }
            if (txtSerie.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " serie = '" + txtSerie.Text + "'";
                }
                else
                {
                    parametros += " and serie = '" + txtSerie.Text + "'";
                }
            }
            if (txtTipo.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " tipo_doc = '" + txtTipo.Text + "'";
                }
                else
                {
                    parametros += " and tipo_doc = '" + txtTipo.Text + "'";
                }
            }
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltroFacturas(parametros).Tables[0].DefaultView;
        }

        public void VistaGeneral()
        {
            parametros = "";
            if (txtContribuyente.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " nit = " + txtContribuyente.SelectedValue;
                }
                else
                {
                    parametros += " and nit = " + txtContribuyente.SelectedValue;
                }
            }
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltroFacturas(parametros).Tables[0].DefaultView;
        }

        public void LimpiarTxt()
        {
            txtCreacion.Text = "";
            txtSerie.Text = "";
            txtTipo.Text = "";
        }

        public void CargarContribuyentes()
        {
            txtContribuyente.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            txtContribuyente.DisplayMemberPath = "razon_social";
            txtContribuyente.SelectedValuePath = "nit";
        }


    }
}
