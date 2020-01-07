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

namespace ContabilidadPymes.Controles
{
    /// <summary>
    /// Lógica de interacción para ReportContribuyente.xaml
    /// </summary>
    public partial class ReportContribuyente : UserControl
    {
        ClassContribuyente classContribuyente = new ClassContribuyente();

        public ReportContribuyente()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {               
            VistaData.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
        }

        private void VistaData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(VistaData.SelectedIndex.ToString());          
            //string p = ((DataRowView)VistaData.Items[VistaData.SelectedIndex]).Row["razon_social"].ToString();
            //string k = ((DataRowView)VistaData.Items[VistaData.SelectedIndex]).Row["nit"].ToString();
            //MessageBox.Show(k);
            //MessageBox.Show(p);
        }
    }
}
