using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para ReporteCompras.xaml
    /// </summary>
    public partial class ReporteCompras : UserControl
    {
        ClassFiltros classFiltros = new ClassFiltros();
        ClassCompras classCompras = new ClassCompras();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        public ReporteCompras()
        {
            InitializeComponent();
            CargarContribuyentes();
        }

        public void CargarContribuyentes()
        {
            txtContribuyente.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            txtContribuyente.DisplayMemberPath = "razon_social";
            txtContribuyente.SelectedValuePath = "nit";
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
                        parametros += " and c.nit = " + txtContribuyente.SelectedValue;
                    }
                    else
                    {
                        parametros += " c.nit = " + txtContribuyente.SelectedValue;
                    }
                }
                if (txtFecha.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and c.fecha = '" + txtFecha.Text + "'";
                    }
                    else
                    {
                        parametros += " c.fecha = '" + txtFecha.Text + "'";
                    }
                }
                if (txtTipo.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and c.Tipo_Doc = '" + txtTipo.Text + "'";
                    }
                    else
                    {
                        parametros += " c.Tipo_Doc = '" + txtTipo.Text + "'";
                    }
                }
                if (txtSerie.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and c.serie = '" + txtSerie.Text + "'";
                    }
                    else
                    {
                        parametros += " c.serie = '" + txtSerie.Text + "'";
                    }
                }
                if (txtFactura.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and c.factura = " + txtFactura.Text;
                    }
                    else
                    {
                        parametros += " c.factura = " + txtFactura.Text;
                    }
                }
                if (txtNitProveedor.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and c.proveedor = " + txtNitProveedor.Text;
                    }
                    else
                    {
                        parametros += " c.proveedor = " + txtNitProveedor.Text;
                    }
                }
                if (txtCreacion.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and c.fechaCreacion = '" + txtCreacion.Text + "'";
                    }
                    else
                    {
                        parametros += " c.fechaCreacion = '" + txtCreacion.Text + "'";
                    }
                }
                if (txtModificacion.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and c.fechaModificacion = '" + txtModificacion.Text + "'";
                    }
                    else
                    {
                        parametros += " c.fechaModificacion = '" + txtModificacion.Text + "'";
                    }
                }
                VistaData.ItemsSource = null;
                VistaData.ItemsSource = classFiltros.FiltrosCompras(parametros).Tables[0].DefaultView;
            }
        }

        public void Limpiar()
        {
            txtFecha.Text = "";
            txtTipo.Text = "";
            txtSerie.Text = "";
            txtFactura.Text = "";
            txtNitProveedor.Text = "";
            txtCreacion.Text = "";
            txtModificacion.Text = "";
        }

        public void VistaGeneral()
        {
            parametros = "";
            if (txtContribuyente.SelectedIndex >= 0)
            {
                if (parametros != "")
                {
                    parametros += " and c.nit = " + txtContribuyente.SelectedValue;
                }
                else
                {
                    parametros += " c.nit = " + txtContribuyente.SelectedValue;
                }
            }
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltrosCompras(parametros).Tables[0].DefaultView;
        }

        private void BtnBorrarFiltros_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            VistaGeneral();
        }

        private void TxtContribuyente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtContribuyente.SelectedIndex>=0)
            {
                Limpiar();
                VistaGeneral();
            }
        }

        private void BtnQuitarFiltro_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            VistaGeneral();
        }

        private void BtnActualizarBD_Click(object sender, RoutedEventArgs e)
        {
            Filtro();
        }
    }
}
