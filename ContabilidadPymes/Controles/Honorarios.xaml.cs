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

namespace ContabilidadPymes.Controles
{
    /// <summary>
    /// Lógica de interacción para Honorarios.xaml
    /// </summary>
    public partial class Honorarios : UserControl
    {
        ClassContribuyente classContribuyente = new ClassContribuyente();
        ClassHonorarios classHonorarios = new ClassHonorarios();

        public Honorarios()
        {
            InitializeComponent();
            CargarComboContribuyentes();
            Vista();
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            Vista();

            BloqueoBtnGuardar(false);
            BloqueoBusquedaBtn(true);
        }

        private void Btn_guardar2_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            Vista();

            Buscar();

            BloqueoBtnGuardar(false);
            BloqueoBusquedaBtn(true);
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            LimpiarTxt();
            Vista();

            BloqueoBusquedaBtn(false);
            BloqueoBtnGuardar(true);
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Editar();            
            Vista();

            BloqueoBtnGuardar(false);
            BloqueoBusquedaBtn(true);
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            Vista();
        }

        public void Ingresar()
        {
            if (txt_honorario.Text=="")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                classHonorarios.ParametrosHonorarios(Convert.ToInt32(combo_nit.SelectedValue.ToString()),Convert.ToDecimal(txt_honorario.Text.Trim()));
                classHonorarios.Ingresar();
            }
        }

        public void Editar()
        {
            if (txt_honorario.Text == "")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                classHonorarios.ParametrosHonorarios(Convert.ToInt32(combo_nit.SelectedValue.ToString()), Convert.ToDecimal(txt_honorario.Text.Trim()));
                classHonorarios.Modificar();
            }
        }

        public void Eliminar()
        {
            classHonorarios.ParametrosVista(Convert.ToInt32(combo_nit.SelectedValue.ToString()));
            classHonorarios.Eliminar();            
        }

        public void Buscar()
        {
            classHonorarios.ParametrosVista(Convert.ToInt32(combo_nit.SelectedValue.ToString()));
            if (classHonorarios.VerificarHonorario()==false)
            {
                txt_honorario.Text = "";
            }
            else
            {
                classHonorarios.Buscar();
                txt_honorario.Text = classHonorarios.honorario.ToString();
            }           
        }

        public void Vista()
        {
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classHonorarios.Vista().Tables[0].DefaultView;           
        }

        public void LimpiarTxt()
        {
            txt_honorario.Text = "";
        }

        public void BloqueoTxt(bool Estado)
        {
            txt_honorario.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btn_guardar.IsEnabled = Estado;
            btn_guardar2.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
            btn_refrescar.IsEnabled = Estado;
            btn_contribuyentes.IsEnabled = Estado;
        }

        public void BloqueoBusquedaTxt(bool Estado)
        {
            txt_honorario.IsEnabled = Estado;
        }

        public void BloqueoBusquedaBtn(bool Estado)
        {
            btn_editar.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
        }

        public void BloqueoBtnGuardar(bool Estado)
        {
            btn_guardar.IsEnabled = Estado;
            btn_guardar2.IsEnabled = Estado;
        }

        public void CargarComboContribuyentes()
        {
            combo_nit.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            combo_nit.DisplayMemberPath = "razon_social";
            combo_nit.SelectedValuePath = "nit";
        }

        private void Combo_nit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_nit.SelectedIndex >= 0)
            {
                BloqueoTxt(true);
                BloqueoBtn(true);
                BloqueoBusquedaBtn(true);
                LimpiarTxt();
                Buscar();
                if (txt_honorario.Text=="")
                {
                    BloqueoBtnGuardar(true);
                    BloqueoBusquedaBtn(false);
                }
                else
                {
                    BloqueoBtnGuardar(false);
                    BloqueoBusquedaBtn(true);
                }
            }
            else
            {
                BloqueoTxt(false);
                BloqueoBtn(false);
            }
        }
    }
}
