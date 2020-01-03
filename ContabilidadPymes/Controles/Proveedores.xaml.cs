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
    /// Lógica de interacción para Proveedores.xaml
    /// </summary>
    public partial class Proveedores : UserControl
    {
        #region Variables

        bool ModoBusqueda;
        ClassMensajes classMensajes = new ClassMensajes();
        ClassProveedor classProveedor = new ClassProveedor();

        #endregion

        #region Constructor

        public Proveedores()
        {
            InitializeComponent();
            BloqueoBtn(true);
            BloqueoBtnBusqueda(false);
            BloqueoTxt(true);
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
            ValidacionEliminar();
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionModificar();
        }

        private void Btn_refrescar_Click(object sender, RoutedEventArgs e)
        {
            Vista();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            //Modo Busqueda en Falso
            if (ModoBusqueda == false)
            {
                //Verifica si esta vacios los campos
                if (txtNit.Text != "")
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
                        txtNit.Focus();
                    }
                    else if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        //Valida la duplicidad o errores e ingresa la factura de lo contrario arroja una alerta
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
                    txtNit.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txtNit.Text == "")
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

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
            BloqueoTxt(true);
            BloqueoBtnGuardar(true);
            BloqueoBtnBusqueda(false);
            ModoBusqueda = false;
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        #endregion

        #region Funciones

        public void ValidacionIngresar()
        {
            if (txtNit.Text != "")
            {
                classProveedor.ParametrosBusqueda(txtNit.Text.Trim());
                if (classProveedor.ValidacionDuplicadosProveedor() == false)
                {
                    Ingresar();
                    LimpiarTxt();
                    txtNit.Focus();
                    Vista();
                    classMensajes.MensajesCortos("Exito", "Se ingreso correctamente.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro duplicado.");
                }
                    
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionIngresarBusqueda()
        {
            if (txtNit.Text != "")
            {
                classProveedor.ParametrosBusqueda(txtNit.Text.Trim());
                if (classProveedor.ValidacionDuplicadosProveedor()==false)
                {
                    //Ingresa la factura
                    Ingresar();
                    //Limpia los Textbox
                    LimpiarTxt();
                    //Bloquea los textbox
                    BloqueoTxt(false);
                    //Desbloquea los Textbox para la busqueda
                    BloqueoTxtBusqueda(true);
                    //Bloquea los Buttons para no permir guardar mientras las busqueda
                    BloqueoBtnGuardar(false);
                    //Activa el ModoBusqueda
                    ModoBusqueda = true;
                    //Enfoca el Textbox de Serie para la busqueda
                    txtNit.Focus();
                    //Actualiza el datagrid
                    Vista();
                    //Mensaje que se registro la factura
                    classMensajes.MensajesCortos("Exito", "Se ingreso correctamente.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro duplicado.");
                }

            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionModificar()
        {
            if (txtNit.Text != "")
            {
                Modificar();
                LimpiarTxt();
                txtNit.Focus();
                BloqueoBtnBusqueda(false);
                BloqueoBtnGuardar(true);
                Vista();
                classMensajes.MensajesCortos("Exito", "Se modifico correctamente.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionEliminar()
        {
            if (txtNit.Text != "")
            {
                Eliminar();
                LimpiarTxt();
                txtNit.Focus();
                BloqueoBtnBusqueda(false);
                BloqueoBtnGuardar(true);
                Vista();
                classMensajes.MensajesCortos("Exito", "Se elimino correctamente.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionBusqueda()
        {
            if (txtNit.Text != "")
            {
                classProveedor.ParametrosBusqueda(txtNit.Text.Trim());
                if (classProveedor.SiExiste()==true)
                {
                    Buscar();
                    BloqueoTxt(true);
                    BloqueoBtnGuardar(false);
                    BloqueoBtnBusqueda(true);
                    ModoBusqueda = false;
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "No existe registro.");
                }                
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void Ingresar()
        {
            classProveedor.ParametrosProveedor(txtNit.Text.Trim(), txtProveedor.Text.Trim());
            classProveedor.Ingresar();
        }

        public void Modificar()
        {
            classProveedor.ParametrosProveedor(txtNit.Text.Trim(), txtProveedor.Text.Trim());
            classProveedor.Modificar();
        }

        public void Eliminar()
        {
            classProveedor.ParametrosBusqueda(txtNit.Text.Trim());
            classProveedor.Eliminar();
        }

        public void Buscar()
        {
            classProveedor.ParametrosBusqueda(txtNit.Text.Trim());
            classProveedor.Buscar();
            txtProveedor.Text = classProveedor.nombre;
        }

        public void Vista()
        {
            VistaData.ItemsSource = classProveedor.ListProveedor().Tables[0].DefaultView;
        }

        public void LimpiarTxt()
        {
            txtNit.Text = "";
            txtProveedor.Text = "";
        }

        public void BloqueoTxt(bool Estado)
        {
            txtNit.IsEnabled = Estado;
            txtProveedor.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btnNuevo.IsEnabled = Estado;
            btnLimpiar.IsEnabled = Estado;
            btnEliminar.IsEnabled = Estado;
            btnEditar.IsEnabled = Estado;
            btnBuscar.IsEnabled = Estado;
            btnGuardar.IsEnabled = Estado;
            btnGuardar2.IsEnabled = Estado;
            btnRefrescar.IsEnabled = Estado;
        }

        public void BloqueoBtnBusqueda(bool Estado)
        {
            btnEliminar.IsEnabled = Estado;
            btnEditar.IsEnabled = Estado;
        }

        public void BloqueoTxtBusqueda(bool Estado)
        {
            txtNit.IsEnabled = Estado;
        }

        public void BloqueoBtnGuardar(bool Estado)
        {
            btnGuardar.IsEnabled = Estado;
            btnGuardar2.IsEnabled = Estado;
        }

        #endregion
    }
}
