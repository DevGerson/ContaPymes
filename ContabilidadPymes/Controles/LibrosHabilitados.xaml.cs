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
    /// Lógica de interacción para LibrosHabilitados.xaml
    /// </summary>
    public partial class LibrosHabilitados : UserControl
    {
        ClassLibros classLibros = new ClassLibros();
        ClassContribuyente classContribuyente = new ClassContribuyente();
        DateTime fecha, fecha2;
        bool ModoBusqueda=false;

        public LibrosHabilitados()
        {
            InitializeComponent();
            CargarComboContribuyentes();
        }

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            BloqueoTxt(true);            
            BloqueoBtn(true);
            BloqueoBusquedaBtn(false);
            LimpiarTxt();
            ModoBusqueda = false;

        }

        private void Btn_guardar2_Click(object sender, RoutedEventArgs e)
        {
            if (txt_fecha.Text=="" || txt_hojas.Text=="" || txt_tipo.Text=="" ||txt_resolucion.Text == "")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                Ingresar();
                LimpiarTxt();
                VistaLibros();
            }

        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (combo_nit.Text == "" || txt_resolucion.Text == "")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                Eliminar();
                LimpiarTxt();
                VistaLibros();
                BloqueoBusquedaBtn(false);
                BloqueoBtnGuardar(true);
            }

        }

        private void Btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            //Modo Busqueda en Falso
            if (ModoBusqueda == false)
            {
                //Verifica si esta vacios los campos
                if (txt_resolucion.Text != "")
                {
                    //Pregunta si quiere guardar los datos por si hubiese datos ingresados
                    MessageBoxButton boxButton = MessageBoxButton.YesNo;
                    MessageBoxResult messageBoxResult = MessageBox.Show("Se perderan los datos si no ha guardado. ¿Desea Guardar los datos?", "Buscar", boxButton);
                    if (messageBoxResult == MessageBoxResult.No)
                    {
                        //Bloquea los textbox para resaltar los campos a ingresar
                        BloqueoTxt(false);
                        BloqueoBusquedaTxt(true);
                        LimpiarTxt();
                        //Variable para verificar si esta en modo busqueda y Bloqueo de Botones o Desbloqueo
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en Fecha
                        txt_resolucion.Focus();
                    }
                    else if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        //Ingresa los datos
                        Ingresar();
                        LimpiarTxt();
                        //Bloquea los textbox para resaltar los campos a ingresar
                        BloqueoTxt(false);
                        BloqueoBusquedaTxt(true);
                        //Variable para verificar si esta en modo busqueda y Bloqueo de Botones o Desbloqueo
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en fecha
                        txt_resolucion.Focus();
                    }
                }
                else
                {
                    //Si no hay ningun dato en campos, se pondra en modo Busqueda
                    BloqueoTxt(false);
                    BloqueoBusquedaTxt(true);
                    BloqueoBtnGuardar(false);
                    ModoBusqueda = true;
                    txt_resolucion.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txt_resolucion.Text=="")
                {
                    ModoBusqueda = false;
                    BloqueoTxt(true);
                }
                else
                {
                    ModoBusqueda = false;
                    Buscar();
                    BloqueoTxt(true);
                    BloqueoBtnGuardar(false);
                    BloqueoBusquedaBtn(true);
                }

            }
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            if (combo_nit.Text == "" || txt_fecha.Text == "" || txt_hojas.Text == "" || txt_tipo.Text == "" || txt_resolucion.Text == "")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                Modificar();
                LimpiarTxt();
                VistaLibros();
                BloqueoBusquedaBtn(false);
                BloqueoBtnGuardar(true);
            }
        }

        private void Btn_vista_Click(object sender, RoutedEventArgs e)
        {
            if (combo_nit.Text == "")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                VistaLibros();
            }
        }

        private void Combo_nit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_nit.SelectedIndex >= 0)
            {
                BloqueoTxt(true);
                BloqueoBtn(true);
                BloqueoBusquedaBtn(false);
            }
            else
            {
                BloqueoTxt(false);
                BloqueoBtn(false);
            }
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_fecha.Text == "" || txt_hojas.Text == "" || txt_tipo.Text == "" || txt_resolucion.Text == "")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                Ingresar();
                LimpiarTxt();
                VistaLibros();
            }
        }

        #region Funciones

        public void Ingresar()
        {
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            classLibros.NuevoLibro(Convert.ToInt32(combo_nit.SelectedValue.ToString()),fecha2,Convert.ToInt32(txt_hojas.Text.Trim()),txt_tipo.Text.Trim(),txt_resolucion.Text.Trim());
            classLibros.Ingresar();
        }

        public void Modificar()
        {
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            classLibros.NuevoLibro(Convert.ToInt32(combo_nit.SelectedValue.ToString()), fecha2, Convert.ToInt32(txt_hojas.Text.Trim()), txt_tipo.Text.Trim(), txt_resolucion.Text.Trim());
            classLibros.Modificar();
        }

        public void Eliminar()
        {
            classLibros.BuscarLibro(Convert.ToInt32(combo_nit.SelectedValue.ToString()), txt_resolucion.Text.Trim());
            classLibros.Eliminar();
        }

        public void Buscar()
        {
            classLibros.BuscarLibro(Convert.ToInt32(combo_nit.SelectedValue.ToString()), txt_resolucion.Text.Trim());
            classLibros.Buscar();
            txt_fecha.Text = classLibros.fecha.ToString("dd/MM/yyyy");
            txt_hojas.Text = classLibros.hojas.ToString();
            txt_tipo.Text = classLibros.tipoDoc;
            txt_resolucion.Text = classLibros.resolucion;
        }

        public void VistaLibros()
        {
            classLibros.ParametrosVistaLibro(Convert.ToInt32(combo_nit.SelectedValue.ToString()));
            VistaLibrosData.ItemsSource = null;
            VistaLibrosData.ItemsSource = classLibros.Vista().Tables[0].DefaultView;
        }

        public void LimpiarTxt()
        {
            txt_fecha.Text = "";
            txt_hojas.Text = "";
            txt_tipo.Text = "";
            txt_resolucion.Text = "";
        }

        public void BloqueoTxt(bool Estado)
        {
            txt_fecha.IsEnabled = Estado;
            txt_hojas.IsEnabled = Estado;
            txt_tipo.IsEnabled = Estado;
            txt_resolucion.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btn_guardar.IsEnabled = Estado;
            btn_guardar2.IsEnabled = Estado;
            btn_nuevo.IsEnabled = Estado;
            btn_limpiar.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
            btn_buscar.IsEnabled = Estado;
            btn_vista.IsEnabled = Estado;
        }

        public void CargarComboContribuyentes()
        {
            combo_nit.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            combo_nit.DisplayMemberPath = "razon_social";
            combo_nit.SelectedValuePath = "nit";
        }

        public void BloqueoBusquedaTxt(bool Estado)
        {
            txt_resolucion.IsEnabled = Estado;
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


        #endregion

    }
}
