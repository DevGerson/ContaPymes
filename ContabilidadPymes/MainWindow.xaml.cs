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
            contenedor.Children.Add(new Controles.Compras());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_ventas_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.Ventas());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_habilitacion_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.LibrosHabilitados());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_impuestos_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.Impuesto());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_honorarios_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.Honorarios());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_pagos_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.Pagos());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_factura_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.FacturasDetalles());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_contribuyente_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.Contribuyente());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void Bt_usuario_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.Usuario());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnProveedor_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.Proveedores());
            btn_cerrar_menu.Command.Execute(null);
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new Controles.Clientes());
            btn_cerrar_menu.Command.Execute(null);
        }
    }
}
