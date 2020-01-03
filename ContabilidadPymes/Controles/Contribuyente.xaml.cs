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
using ContabilidadPymes.Ventanas;

namespace ContabilidadPymes.Controles
{
    /// <summary>
    /// Lógica de interacción para Contribuyente.xaml
    /// </summary>
    public partial class Contribuyente : UserControl
    {
        #region Variables

        bool ModoBusqueda;
        Validaciones validaciones = new Validaciones();
        ClassMensajes classMensajes = new ClassMensajes();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        #endregion

        #region Constructor

        public Contribuyente()
        {
            InitializeComponent();
            BloqueoBtn(true);
            BloqueoTxt(true);
            BloqueoBtnBusqueda(false);
        }

        #endregion

        #region Controles

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
            ModoBusqueda = false;
            BloqueoTxt(true);
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
            ValidacionIngresar();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionEliminar();
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionModificar();
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
                        BloqueoBtnBusqueda(false);
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        LimpiarTxt();
                        txt_nit.Focus();
                    }
                    else if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        ValidacionIngresarBusqueda();
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
                    BloqueoBtnGuardar(true);
                }
                else
                {
                    ValidacionBusqueda();
                }

            }
        }

        private void Reporte_contribuyente_Click(object sender, RoutedEventArgs e)
        {
            ListaContribuyentes listaContribuyentes = new ListaContribuyentes();
            listaContribuyentes.Show();
        }

        private void Txt_nit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void Txt_cui_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void Txt_telefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void Txt_usuario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        #endregion

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

        public void ValidacionIngresar()
        {
            if (txt_nit.Text!=""||txt_razon.Text!=""||txt_cui.Text!=""||txt_nombre.Text!=""||txt_telefono.Text!=""||txt_direccion.Text!=""||txt_municipio.Text!=""||txt_departamento.Text!=""||txt_usuario.Text!=""||txt_contraseña.Text!="")
            {
                classContribuyente.ParametrosBusqueda(txt_nit.Text.Trim());
                if (classContribuyente.ValidacionDuplicadosContribuyentes()==false)
                {
                    Ingresar();
                    LimpiarTxt();
                    classMensajes.MensajesCortos("Exito", "Se registro un nuevo contribuyente.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro duplicado.");
                }
 
            }
            else
            {
                classMensajes.MensajesCortos("Error","Campos vacios.");
            }
        }

        public void ValidacionIngresarBusqueda()
        {
            if (txt_nit.Text!=""||txt_razon.Text!=""||txt_cui.Text!=""||txt_nombre.Text!=""||txt_telefono.Text!=""||txt_direccion.Text!=""||txt_municipio.Text!=""||txt_departamento.Text!=""||txt_usuario.Text!=""||txt_contraseña.Text!="")
            {
                classContribuyente.ParametrosBusqueda(txt_nit.Text.Trim());
                if (classContribuyente.ValidacionDuplicadosContribuyentes()==false)
                {
                    Ingresar();                                       
                    BloqueoTxt(false);
                    BloqueoTxtBusqueda(true);                    
                    BloqueoBtnGuardar(false);
                    ModoBusqueda = true;
                    LimpiarTxt();                    
                    txt_nit.Focus();
                    classMensajes.MensajesCortos("Exito", "Se registro un nuevo contribuyente.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro duplicado.");
                }
 
            }
            else
            {
                classMensajes.MensajesCortos("Error","Campos vacios.");
            }
        }

        public void ValidacionModificar()
        {
            if (txt_nit.Text != "" || txt_razon.Text != "" || txt_cui.Text != "" || txt_nombre.Text != "" || txt_telefono.Text != "" || txt_direccion.Text != "" || txt_municipio.Text != "" || txt_departamento.Text != "" || txt_usuario.Text != "" || txt_contraseña.Text != "")
            {
                Modificar();
                LimpiarTxt();
                BloqueoBtnBusqueda(false);
                BloqueoBtnGuardar(true);
                classMensajes.MensajesCortos("Exito", "Se modifico el registro.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionEliminar()
        {
            if (txt_nit.Text != "")
            {
                Eliminar();
                LimpiarTxt();
                BloqueoBtnBusqueda(false);
                BloqueoBtnGuardar(true);
                classMensajes.MensajesCortos("Exito", "Se elimino el registro.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionBusqueda()
        {
            if (txt_nit.Text != "")
            {
                classContribuyente.ParametrosBusqueda(txt_nit.Text.Trim());
                if (classContribuyente.SiExiste()==true)
                {
                    Buscar();
                    ModoBusqueda = false;
                    BloqueoTxt(true);
                    BloqueoBtnGuardar(false);
                    BloqueoBtnBusqueda(true);
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "No existe el registro.");
                }
             
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void Ingresar()
        {
            string nit = txt_nit.Text.Trim();
            string razon = txt_razon.Text.Trim();
            string cui = txt_cui.Text.Trim();
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
            string usuario = txt_usuario.Text.Trim();
            string password = txt_contraseña.Text.Trim();

            classContribuyente.NuevoContribuyente(nit,razon,cui,nombre_comercial,telefono,estado,direccion,municipio,departamento,usuario,password);
            classContribuyente.Ingresar();

        }

        public void Modificar()
        {
            string nit = txt_nit.Text.Trim();
            string razon = txt_razon.Text.Trim();
            string cui = txt_cui.Text.Trim();
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
            string usuario = txt_usuario.Text.Trim();
            string password = txt_contraseña.Text.Trim();

            classContribuyente.NuevoContribuyente(nit, razon, cui, nombre_comercial, telefono, estado, direccion, municipio, departamento, usuario, password);
            classContribuyente.Modificar();
        }

        public void Eliminar()
        {
            string nit = txt_nit.Text.Trim();

            classContribuyente.ParametrosBusqueda(nit);
            classContribuyente.Eliminar();
        }

        public void Buscar()
        {
            string nit = txt_nit.Text.Trim();

            classContribuyente.ParametrosBusqueda(nit);
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
            reporte_contribuyente.IsEnabled = Estado;
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
    }
}
