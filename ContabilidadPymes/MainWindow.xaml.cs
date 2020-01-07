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
using ContabilidadPymes.Controles;
using ContabilidadPymes.Controles.ControlReportes;
using ContabilidadPymes.Ventanas;

namespace ContabilidadPymes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow Instancia=null;

        public static MainWindow Instacian
        {
            get
            {
                if (Instancia == null)
                {
                    Instancia = new MainWindow();

                }
                return Instancia;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bt_compras_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Compras());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_ventas_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Ventas());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_habilitacion_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new LibrosHabilitados());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_impuestos_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Impuesto());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_honorarios_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Honorarios());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_pagos_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Pagos());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_factura_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new FacturasDetalles());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_contribuyente_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Contribuyente());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_usuario_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Usuario());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnProveedor_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Proveedores());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Clientes());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnAjsute_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReporteVentas_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteVentas());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnReporteCompras_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteCompras());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ScrollMenu.Height = this.ActualHeight - 200;
        }

        private void BtnReporteProveedor_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteProveedor());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnReporteClientes_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteClientes());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnVistaFacturas_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteFacturasSeries());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnVistaFacturasDetalles_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteFacturasDetalles());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnVistaLibros_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteLibros());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnVistaPagos_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReportePagos());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnVistaHonorarios_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteHonorarios());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnVistaImpuestos_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteImpuesto());
            btn_cerrar_menu.Command.Execute(null);
        }
    }
}
