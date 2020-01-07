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
    /// Lógica de interacción para ReporteImpuesto.xaml
    /// </summary>
    public partial class ReporteImpuesto : UserControl
    {
        string parametros;
        ClassFiltros classFiltros = new ClassFiltros();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        public ReporteImpuesto()
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
                if (txtFormulario.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and formulario = " + txtFormulario.Text;
                    }
                    else
                    {
                        parametros += " formulario = " + txtFormulario.Text;
                    }
                }
                if (txtAcceso.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and acceso = " + txtAcceso.Text;
                    }
                    else
                    {
                        parametros += " acceso = " + txtAcceso.Text;
                    }
                }
                if (txtCreacion.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and creacion = '" + txtCreacion.Text + "'";
                    }
                    else
                    {
                        parametros += " creacion = '" + txtCreacion.Text + "'";
                    }
                }
                if (txtModificacion.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and modificacion = '" + txtModificacion.Text + "'";
                    }
                    else
                    {
                        parametros += " modificacion = '" + txtModificacion.Text + "'";
                    }
                }                
                VistaData.ItemsSource = null;
                VistaData.ItemsSource = classFiltros.FiltrosImpuesto(parametros).Tables[0].DefaultView;
            }
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
            VistaData.ItemsSource = classFiltros.FiltrosImpuesto(parametros).Tables[0].DefaultView;
        }

        public void CargarComboContribuyente()
        {
            txtContribuyente.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            txtContribuyente.DisplayMemberPath = "razon_social";
            txtContribuyente.SelectedValuePath = "nit";
        }

        public void LimpiarTxt()
        {
            txtFormulario.Text = "";
            txtAcceso.Text = "";
            txtCreacion.Text = "";
            txtModificacion.Text = "";
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
