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
    /// Lógica de interacción para ReporteLibros.xaml
    /// </summary>
    public partial class ReporteLibros : UserControl
    {
        string parametros;
        ClassFiltros classFiltros = new ClassFiltros();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        public ReporteLibros()
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
            txtHojas.Text = "";
            txtResolucion.Text = "";
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
            VistaData.ItemsSource = classFiltros.FiltrosLibros(parametros).Tables[0].DefaultView;
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
                if (txtTipo.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and tipo_libro = '" + txtTipo.Text + "'";
                    }
                    else
                    {
                        parametros += " tipo_libro = '" + txtTipo.Text + "'";
                    }
                }
                if (txtHojas.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and hojas = '" + txtHojas.Text + "'";
                    }
                    else
                    {
                        parametros += " hojas = '" + txtHojas.Text + "'";
                    }
                }
                if (txtResolucion.Text != "")
                {
                    if (parametros != "")
                    {
                        parametros += " and resolucion = " + txtResolucion.Text;
                    }
                    else
                    {
                        parametros += " resolucion = " + txtResolucion.Text;
                    }
                }                
                VistaData.ItemsSource = null;
                VistaData.ItemsSource = classFiltros.FiltrosLibros(parametros).Tables[0].DefaultView;
            }
        }

        private void TxtContribuyente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtContribuyente.SelectedIndex >= 0)
            {
                LimpiarTxt();
                VistaGeneral();
            }
        }
    }
}
