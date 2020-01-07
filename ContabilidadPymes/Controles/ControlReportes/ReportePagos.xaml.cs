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
    /// Lógica de interacción para ReportePagos.xaml
    /// </summary>
    public partial class ReportePagos : UserControl
    {
        string parametros;
        ClassFiltros classFiltros = new ClassFiltros();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        public ReportePagos()
        {
            InitializeComponent();
            CargarComboContribuyente();
        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            Filtro();
        }

        private void BtnQuitarFiltro_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
            VistaGeneral();
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

        public void Filtro()
        {
            if (txtContribuyente.Text != "")
            {
                parametros = "";
                if (txtContribuyente.SelectedIndex >= 0)
                {
                    if (parametros != "")
                    {
                        parametros += " and nit = " + txtContribuyente.SelectedValue;
                    }
                    else
                    {
                        parametros += " nit = " + txtContribuyente.SelectedValue;
                    }
                }
                if (txtFecha.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and fecha = '" + txtFecha.Text + "'";
                    }
                    else
                    {
                        parametros += " fecha = '" + txtFecha.Text + "'";
                    }
                }
                if (txtAño.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and año = " + txtAño.Text;
                    }
                    else
                    {
                        parametros += " año = " + txtAño.Text;
                    }
                }
                if (txtMes.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and mes = '" + txtMes.Text + "'";
                    }
                    else
                    {
                        parametros += " mes = '" + txtMes.Text + "'";
                    }
                }
                if (txtVentas.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and ventas = " + txtVentas.Text;
                    }
                    else
                    {
                        parametros += " ventas = " + txtVentas.Text;
                    }
                }
                if (txtImpuesto.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and impuesto = " + txtImpuesto.Text;
                    }
                    else
                    {
                        parametros += " impuesto = " + txtImpuesto.Text;
                    }
                }
                if (txtMulta.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and multa = " + txtMulta.Text;
                    }
                    else
                    {
                        parametros += " multa = " + txtMulta.Text;
                    }
                }
                if (txtHonorario.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and honorarios = " + txtHonorario.Text;
                    }
                    else
                    {
                        parametros += " honorarios = " + txtHonorario.Text;
                    }
                }
                if (txtRecibo.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and recibo = " + txtRecibo.Text;
                    }
                    else
                    {
                        parametros += " recibo = " + txtRecibo.Text;
                    }
                }
                VistaData.ItemsSource = null;
                VistaData.ItemsSource = classFiltros.FiltrosPagos(parametros).Tables[0].DefaultView;
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
            txtAño.Text = "";
            txtMes.Text = "";
            txtVentas.Text = "";
            txtImpuesto.Text = "";
            txtMulta.Text = "";
            txtHonorario.Text = "";
            txtRecibo.Text = "";
        }

        public void VistaGeneral()
        {
            parametros = "";
            if (txtContribuyente.SelectedIndex >= 0)
            {
                if (parametros != "")
                {
                    parametros += " and nit = " + txtContribuyente.SelectedValue;
                }
                else
                {
                    parametros += " nit = " + txtContribuyente.SelectedValue;
                }
            }
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltrosPagos(parametros).Tables[0].DefaultView;
        }

        private void TxtContribuyente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtContribuyente.SelectedIndex>=0)
            {
                LimpiarTxt();
                VistaGeneral();
            }
        }
    }
}
