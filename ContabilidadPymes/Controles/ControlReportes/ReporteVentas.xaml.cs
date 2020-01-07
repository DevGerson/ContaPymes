using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
    /// Lógica de interacción para ReporteVentas.xaml
    /// </summary>
    public partial class ReporteVentas : UserControl
    {
        ClassFiltros classFiltros = new ClassFiltros();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        public ReporteVentas()
        {
            InitializeComponent();
            CargarComboContribuyente();
        }
        string parametros;
        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            Filtro();
        }

        public void Filtro()
        {
            if (txtContribuyente.Text != "")
            {
                parametros = "";
                if (txtContribuyente.SelectedIndex >= 0)
                {
                    if (parametros != "")
                    {
                        parametros += " and v.nit = " + txtContribuyente.SelectedValue;
                    }
                    else
                    {
                        parametros += " v.nit = " + txtContribuyente.SelectedValue;
                    }
                }
                if (txtFecha.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and v.fecha = '" + txtFecha.Text + "'";
                    }
                    else
                    {
                        parametros += " v.fecha = '" + txtFecha.Text + "'";
                    }
                }
                if (txtTipo.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and v.Tipo_Doc = '" + txtTipo.Text + "'";
                    }
                    else
                    {
                        parametros += " v.Tipo_Doc = '" + txtTipo.Text + "'";
                    }
                }
                if (txtSerie.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and v.serie = '" + txtSerie.Text + "'";
                    }
                    else
                    {
                        parametros += " v.serie = '" + txtSerie.Text + "'";
                    }
                }
                if (txtFactura.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and v.factura = " + txtFactura.Text;
                    }
                    else
                    {
                        parametros += " v.factura = " + txtFactura.Text;
                    }
                }
                if (txtNitCliente.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and v.cliente = " + txtNitCliente.Text;
                    }
                    else
                    {
                        parametros += " v.cliente = " + txtNitCliente.Text;
                    }
                }
                if (txtCreacion.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and v.fechaCreacion = '" + txtCreacion.Text + "'";
                    }
                    else
                    {
                        parametros += " v.fechaCreacion = '" + txtCreacion.Text + "'";
                    }
                }
                if (txtModificacion.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and v.fechaModificacion = '" + txtModificacion.Text + "'";
                    }
                    else
                    {
                        parametros += " v.fechaModificacion = '" + txtModificacion.Text + "'";
                    }
                }
                if (txtExento.IsChecked == true)
                {
                    if (parametros != "")
                    {
                        parametros += " and v.exento <> 0";
                    }
                    else
                    {
                        parametros += " v.exento <> 0";
                    }
                }
                VistaData.ItemsSource = null;
                VistaData.ItemsSource = classFiltros.FiltroVentas(parametros).Tables[0].DefaultView;
            }
        }

        public void CargarComboContribuyente()
        {
            txtContribuyente.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            txtContribuyente.DisplayMemberPath = "razon_social";
            txtContribuyente.SelectedValuePath = "nit";
        }

        public void LimpiarTxt()
        {
            txtFecha.Text = "";
            txtTipo.Text = "";
            txtSerie.Text = "";
            txtFactura.Text = "";
            txtNitCliente.Text = "";
            txtExento.IsChecked = false;
            txtCreacion.Text = "";
            txtModificacion.Text = "";
        }

        private void BtnQuitarFiltro_Click(object sender, RoutedEventArgs e)
        {
            VistaGeneral();
            LimpiarTxt();
        }

        public void VistaGeneral()
        {
            parametros = "";
            if (txtContribuyente.SelectedIndex >= 0)
            {
                if (parametros != "")
                {
                    parametros += " and v.nit = " + txtContribuyente.SelectedValue;
                }
                else
                {
                    parametros += " v.nit = " + txtContribuyente.SelectedValue;
                }
            }
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltroVentas(parametros).Tables[0].DefaultView;
        }

        private void TxtContribuyente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtContribuyente.SelectedIndex>=0)
            {
                VistaGeneral();
                LimpiarTxt();
            }
        }

        private void BtnBorrarFiltros_Click(object sender, RoutedEventArgs e)
        {
            VistaGeneral();
            LimpiarTxt();
        }

        private void BtnActualizarBD_Click(object sender, RoutedEventArgs e)
        {
            Filtro();
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
