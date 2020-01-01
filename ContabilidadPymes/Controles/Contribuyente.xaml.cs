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
    /// Lógica de interacción para Contribuyente.xaml
    /// </summary>
    public partial class Contribuyente : UserControl
    {
        ClassContribuyente classContribuyente = new ClassContribuyente();
        bool ModoBusqueda;

        public Contribuyente()
        {
            InitializeComponent();
            BloqueoBtn(true);
            BloqueoTxt(true);
            BloqueoBtnBusqueda(false);
        }

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
            BloqueoBtnBusqueda(false);
            BloqueoBtnGuardar(true);
            txt_nit.Focus();
        }

        private void Btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            LimpiarTxt();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            LimpiarTxt();

            BloqueoBtnBusqueda(false);
            BloqueoBtnGuardar(true);
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Modificar();
            LimpiarTxt();

            BloqueoBtnBusqueda(false);
            BloqueoBtnGuardar(true);
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            //Modo Busqueda en Falso
            if (ModoBusqueda == false)
            {
                //Verifica si esta vacios los campos
                if (txt_nit.Text!=""||txt_razon.Text!=""||txt_cui.Text!=""||txt_nombre.Text!=""||txt_telefono.Text!=""||txt_direccion.Text!=""||txt_municipio.Text!=""
                    ||txt_departamento.Text!=""||txt_usuario.Text!=""||txt_contraseña.Text!="")
                {
                    //Pregunta si quiere guardar los datos por si hubiese datos ingresados
                    MessageBoxButton boxButton = MessageBoxButton.YesNo;
                    MessageBoxResult messageBoxResult = MessageBox.Show("Se perderan los datos si no ha guardado. ¿Desea Guardar los datos?", "Buscar", boxButton);
                    if (messageBoxResult == MessageBoxResult.No)
                    {
                        //Bloquea los textbox para resaltar los campos a ingresar
                        BloqueoTxt(false);
                        BloqueoTxtBusqueda(true);
                        LimpiarTxt();
                        //Variable para verificar si esta en modo busqueda y Bloqueo de Botones o Desbloqueo
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en Fecha
                        txt_nit.Focus();
                    }
                    else if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        //Ingresa los datos
                        Ingresar();
                        LimpiarTxt();
                        //Bloquea los textbox para resaltar los campos a ingresar
                        BloqueoTxt(false);
                        BloqueoTxtBusqueda(true);
                        //Variable para verificar si esta en modo busqueda y Bloqueo de Botones o Desbloqueo
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en fecha
                        txt_nit.Focus();
                    }
                }
                else
                {
                    //Si no hay ningun dato en campos, se pondra en modo Busqueda
                    BloqueoTxt(false);
                    BloqueoTxtBusqueda(true);
                    BloqueoBtnGuardar(false);
                    ModoBusqueda = true;
                    txt_nit.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txt_nit.Text=="")
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
                    BloqueoBtnBusqueda(true);
                }

            }
        }


        #region Funciones
        public void LimpiarTxt()
        {
            txt_nit.Text = "";
            txt_razon.Text = "";
            txt_cui.Text = "";
            txt_nombre.Text = "";
            txt_telefono.Text = "";
            txt_estado.IsChecked = false;
            txt_direccion.Text = "";
            txt_municipio.Text = "";
            txt_departamento.Text = "";
            txt_usuario.Text = "";
            txt_contraseña.Text = "";
        }

        public void Ingresar()
        {
            int nit = Convert.ToInt32(txt_nit.Text.Trim());
            string razon = txt_razon.Text.Trim();
            int cui = Convert.ToInt32(txt_cui.Text.Trim());
            string nombre_comercial = txt_nombre.Text.Trim();
            int telefono = Convert.ToInt32(txt_telefono.Text.Trim());
            int estado = 0;
            if (txt_estado.IsChecked == true)
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }
            string direccion = txt_direccion.Text.Trim();
            string municipio = txt_municipio.Text.Trim();
            string departamento = txt_departamento.Text.Trim();
            int usuario = Convert.ToInt32(txt_usuario.Text.Trim());
            string password = txt_contraseña.Text.Trim();

            classContribuyente.NuevoContribuyente(nit,razon,cui,nombre_comercial,telefono,estado,direccion,municipio,departamento,usuario,password);
            classContribuyente.Ingresar();

        }

        public void Modificar()
        {
            int nit = Convert.ToInt32(txt_nit.Text.Trim());
            string razon = txt_razon.Text.Trim();
            int cui = Convert.ToInt32(txt_cui.Text.Trim());
            string nombre_comercial = txt_nombre.Text.Trim();
            int telefono = Convert.ToInt32(txt_telefono.Text.Trim());
            int estado = 0;
            if (txt_estado.IsChecked == true)
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }
            string direccion = txt_direccion.Text.Trim();
            string municipio = txt_municipio.Text.Trim();
            string departamento = txt_departamento.Text.Trim();
            int usuario = Convert.ToInt32(txt_usuario.Text.Trim());
            string password = txt_contraseña.Text.Trim();

            classContribuyente.NuevoContribuyente(nit, razon, cui, nombre_comercial, telefono, estado, direccion, municipio, departamento, usuario, password);
            classContribuyente.Modificar();
        }

        public void Eliminar()
        {
            int nit = Convert.ToInt32(txt_nit.Text.Trim());

            classContribuyente.BuscarContribuyente(nit);
            classContribuyente.Eliminar();
        }

        public void Buscar()
        {
            int nit = Convert.ToInt32(txt_nit.Text.Trim());

            classContribuyente.BuscarContribuyente(nit);
            classContribuyente.Buscar();

            txt_razon.Text = classContribuyente.razon_social;
            txt_cui.Text = classContribuyente.cui.ToString();
            txt_nombre.Text = classContribuyente.nombre_Comercial;
            txt_telefono.Text = classContribuyente.telefono.ToString();
            if (classContribuyente.estado_Contable == 1)
            {
                txt_estado.IsChecked = true;
            }
            else
            {
                txt_estado.IsChecked = false;
            }
            txt_direccion.Text = classContribuyente.direccion;
            txt_municipio.Text = classContribuyente.municipio;
            txt_departamento.Text = classContribuyente.departamento;
            txt_usuario.Text = classContribuyente.Sat_Usuario.ToString();
            txt_contraseña.Text = classContribuyente.sat_Password;
        }

        public void BloqueoTxt(bool Estado)
        {
            txt_nit.IsEnabled = Estado;
            txt_razon.IsEnabled = Estado;
            txt_cui.IsEnabled = Estado;
            txt_nombre.IsEnabled = Estado;
            txt_telefono.IsEnabled = Estado;
            txt_estado.IsEnabled = Estado;
            txt_direccion.IsEnabled = Estado;
            txt_municipio.IsEnabled = Estado;
            txt_departamento.IsEnabled = Estado;
            txt_usuario.IsEnabled = Estado;
            txt_contraseña.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btn_guardar.IsEnabled = Estado;
            btn_nuevo.IsEnabled = Estado;
            btn_limpiar.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
            buscar.IsEnabled = Estado;
        }

        public void BloqueoBtnBusqueda(bool Estado)
        {
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
        }

        public void BloqueoTxtBusqueda(bool Estado)
        {
            txt_nit.IsEnabled = Estado;
        }

        public void BloqueoBtnGuardar(bool Estado)
        {
            btn_guardar.IsEnabled = Estado;
        }
        #endregion

        private void Reporte_contribuyente_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
