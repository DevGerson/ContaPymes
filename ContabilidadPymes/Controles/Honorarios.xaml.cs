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
        #region Variables

        Validaciones validaciones = new Validaciones();
        ClassMensajes classMensajes = new ClassMensajes();
        ClassHonorarios classHonorarios = new ClassHonorarios();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        #endregion

        #region Constructor

        public Honorarios()
        {
            InitializeComponent();
            CargarComboContribuyentes();
            Vista();
        }

        #endregion

        #region Controles y Eventos

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionIngresar();
        }

        private void Btn_guardar2_Click(object sender, RoutedEventArgs e)
        {
            ValidacionIngresar();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionEditar();         
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            Vista();
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
                if (txt_honorario.Text == "")
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

        private void Txt_honorario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionMontos(e);
        }

        private void Btn_contribuyentes_Click(object sender, RoutedEventArgs e)
        {
            string d = combo_nit.SelectedValue.ToString();
            classMensajes.MensajesCortos("NIT", d);
        }

        #endregion

        #region Funciones

        public void ValidacionIngresar()
        {
            if (txt_honorario.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                ClassHonorarios cHonorarios = new ClassHonorarios();
                cHonorarios.ParametrosVista(combo_nit.SelectedValue.ToString());
                if (cHonorarios.ValidacionDuplicadosHonorarios()==false)
                {
                    Ingresar();
                    Vista();
                    Buscar();
                    BloqueoBtnGuardar(false);
                    BloqueoBusquedaBtn(true);
                    classMensajes.MensajesCortos("Exito", "Registro guardado.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error","Registro duplicado.");
                }

            }
        }

        public void ValidacionEditar()
        {
            if (txt_honorario.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                Editar();
                Buscar();
                Vista();
                BloqueoBtnGuardar(false);
                BloqueoBusquedaBtn(true);

                classMensajes.MensajesCortos("Exito", "Registro modificado.");
            }
        }

        public void Ingresar()
        {
            classHonorarios.ParametrosHonorarios(combo_nit.SelectedValue.ToString(), Convert.ToDecimal(txt_honorario.Text.Trim()));
            classHonorarios.Ingresar();
        }

        public void Editar()
        {
            classHonorarios.ParametrosHonorarios(combo_nit.SelectedValue.ToString(), Convert.ToDecimal(txt_honorario.Text.Trim()));
            classHonorarios.Modificar();
        }

        public void Eliminar()
        {
            classHonorarios.ParametrosVista(combo_nit.SelectedValue.ToString());
            classHonorarios.Eliminar();
            Vista();
            LimpiarTxt();
            BloqueoBtnGuardar(true);
            BloqueoBusquedaBtn(false);
            classMensajes.MensajesCortos("Exito", "Registro eliminado.");
        }

        public void Buscar()
        {
            classHonorarios.ParametrosVista(combo_nit.SelectedValue.ToString());
            if (classHonorarios.VerificarHonorario()==false)
            {
                txt_honorario.Text = "";
            }
            else
            {
                classHonorarios.Buscar();
                txt_honorario.Text = classHonorarios.honorario.ToString();
                Vista();
                BloqueoBusquedaBtn(false);
                BloqueoBtnGuardar(true);
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

        #endregion
    }
}
