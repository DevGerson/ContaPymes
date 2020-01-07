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
    /// Lógica de interacción para ReporteFacturasDetalles.xaml
    /// </summary>
    public partial class ReporteFacturasDetalles : UserControl
    {
        string parametros;
        ClassFiltros classFiltros = new ClassFiltros();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        public ReporteFacturasDetalles()
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

        private void BtnBorrarFiltros_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
            VistaGeneral();
        }

        private void BtnActualizarBD_Click(object sender, RoutedEventArgs e)
        {
            Filtros();
        }

        private void TxtContribuyente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtContribuyente.SelectedIndex>=0)
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
            if (txtTipo.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " tipo_doc = " + txtTipo.Text;
                }
                else
                {
                    parametros += " and tipo_doc = " + txtTipo.Text;
                }
            }
            if (txtSerie.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " serie = " + txtTipo.Text;
                }
                else
                {
                    parametros += " and serie = " + txtTipo.Text;
                }
            }
            if (txtCantidad.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " cantidad = " + txtCantidad.Text;
                }
                else
                {
                    parametros += " and cantidad = " + txtCantidad.Text;
                }
            }
            if (txtDel.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " del = " + txtDel.Text;
                }
                else
                {
                    parametros += " and del = " + txtDel.Text;
                }
            }
            if (txtAl.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " al = " + txtAl.Text;
                }
                else
                {
                    parametros += " and al = " + txtAl.Text;
                }
            }
            if (txtResolucion.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " resolucion = '" + txtResolucion.Text + "'";
                }
                else
                {
                    parametros += " and resolucion = '" + txtResolucion.Text + "'";
                }
            }
            if (txtCreacion.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " creacion = '" + txtCreacion.Text + "'";
                }
                else
                {
                    parametros += " and creacion = '" + txtCreacion.Text + "'";
                }
            }
            if (txtModificacion.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " modificacion = '" + txtModificacion.Text + "'";
                }
                else
                {
                    parametros += " and modificacion = '" + txtModificacion.Text + "'";
                }
            }
            if (txtvigencia.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " vigencia = '" + txtvigencia.Text + "'";
                }
                else
                {
                    parametros += " and vigencia = '" + txtvigencia.Text + "'";
                }
            }
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltrosFacturaDetalle(parametros).Tables[0].DefaultView;
        }

        public void VistaGeneral()
        {
            parametros = "";
            if (txtContribuyente.SelectedValue.ToString() != "")
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
            VistaData.ItemsSource = classFiltros.FiltrosFacturaDetalle(parametros).Tables[0].DefaultView;
        }

        public void LimpiarTxt()
        {
            txtTipo.Text = "";
            txtSerie.Text = "";
            txtCantidad.Text = "";
            txtDel.Text = "";
            txtAl.Text = "";
            txtResolucion.Text = "";
            txtvigencia.Text = "";
            txtCreacion.Text = "";
            txtModificacion.Text = "";
        }

        public void CargarContribuyentes()
        {
            txtContribuyente.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            txtContribuyente.DisplayMemberPath = "razon_social";
            txtContribuyente.SelectedValuePath = "nit";
        }
    }
}
