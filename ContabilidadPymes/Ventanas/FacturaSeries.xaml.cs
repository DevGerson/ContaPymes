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
using System.Windows.Shapes;

namespace ContabilidadPymes.Ventanas
{
    /// <summary>
    /// Lógica de interacción para FacturaSeries.xaml
    /// </summary>
    public partial class FacturaSeries : Window
    {
        public int nit { get; set; }

        public FacturaSeries(int nitC_)
        {
            InitializeComponent();
            Abrir(nitC_);
        }

        public void Abrir(int nitC)
        {
            _datagrid.Children.Clear();
            _datagrid.Children.Add(new Controles.Facturas(nitC));
        }
    }
}
