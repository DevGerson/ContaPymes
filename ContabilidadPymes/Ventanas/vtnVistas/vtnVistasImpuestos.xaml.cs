﻿using System;
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
using System.Windows.Shapes;
using ContabilidadPymes.Controles.ControlReportes;

namespace ContabilidadPymes.Ventanas.vtnVistas
{
    /// <summary>
    /// Lógica de interacción para vtnVistasImpuestos.xaml
    /// </summary>
    public partial class vtnVistasImpuestos : Window
    {
        public vtnVistasImpuestos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contenedor.Children.Clear();
            contenedor.Children.Add(new ReporteImpuesto());
        }
    }
}
