using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Lógica de interacción para ReporteClientes.xaml
    /// </summary>
    public partial class ReporteClientes : UserControl
    {
        string parametros;
        ClassFiltros classFiltros = new ClassFiltros();

        public ReporteClientes()
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

        public void Filtros()
        {
            parametros = "";
            if (txtFechas.Text != "")
            {
                if (parametros == "")
                {
                    parametros = " nit = " + txtFechas.Text;
                }
                else
                {
                    parametros += " and nit = " + txtFechas.Text;
                }
            }
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltroClientes(parametros).Tables[0].DefaultView;
        }

        public void VistaGeneral()
        {
            parametros = "";
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFiltros.FiltroClientes(parametros).Tables[0].DefaultView;
        }

        public void LimpiarTxt()
        {
            txtFechas.Text = "";
        }

        public void ImprimirDocumento()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument pd = new PrintDocument();
            PrinterSettings ps= new PrinterSettings();
            pd.PrinterSettings = ps;
            pd.PrintPage += Imprimir;
            pd.Print();
        }

        public void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial",14, System.Drawing.FontStyle.Regular,GraphicsUnit.Point);
            e.Graphics.DrawString("Imprimir", font, System.Drawing.Brushes.Black, new RectangleF(0, 10, 120, 50));
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            ImprimirDocumento();
        }
    }
}
