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
using ContabilidadPymes.Ventanas;
using ContabilidadPymes.Clases;


namespace ContabilidadPymes.Controles
{
    /// <summary>
    /// Lógica de interacción para Facturas.xaml
    /// </summary>
    public partial class Facturas : UserControl
    {
        bool ModoBusqueda;
        ClassMensajes classMensajes = new ClassMensajes();
        ClassFacturas classFacturas = new ClassFacturas();

        public Facturas(string nitContribuyente)
        {
            InitializeComponent();
            txtNit.Text = nitContribuyente.ToString();
            Vista();
        }

        public void LimpiarTxt()
        {
            txtCreacion.Text = "";
            txtSerie.Text = "";
            txtTipo.Text = "";
        }

        public void BloqueoTxt(bool Estado)
        {
            txtCreacion.IsEnabled = Estado;
            txtSerie.IsEnabled = Estado;
            txtTipo.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btnBuscar.IsEnabled = Estado;
            btnEditar.IsEnabled = Estado;
            btnGuardar.IsEnabled = Estado;
            btnLimpiar.IsEnabled = Estado;
            btnEliminar.IsEnabled = Estado;
            btnNuevo.IsEnabled = Estado;
        }

        public void BloqueoBtnGuardar(bool Estado)
        {
            btnGuardar.IsEnabled = Estado;
        }

        public void BloqueoBtnBusqueda(bool Estado)
        {
            btnEditar.IsEnabled = Estado;
            btnEliminar.IsEnabled = Estado;
        }

        public void BloqueoTxtBusqueda(bool Estado)
        {
            txtSerie.IsEnabled = Estado;
            txtTipo.IsEnabled = Estado;
        }

        public void ValidacionIngresar()
        {
            if (txtCreacion.Text!=""||txtSerie.Text!=""||txtTipo.Text!="")
            {
                Ingresar();
                LimpiarTxt();
                Vista();
                classMensajes.MensajesCortos("Exito","Se registraron los datos.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionIngresarBusqueda()
        {
            if (txtCreacion.Text != "" || txtSerie.Text != "" || txtTipo.Text != "")
            {
                Ingresar();
                LimpiarTxt();                
                BloqueoTxt(false);
                BloqueoTxtBusqueda(true);
                BloqueoBtnGuardar(false);
                ModoBusqueda = true;                
                txtSerie.Focus();
                classMensajes.MensajesCortos("Exito", "Se registraron los datos.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionModificar()
        {
            if (txtSerie.Text!=""||txtTipo.Text!="")
            {
                Modificar();
                ModoBusqueda = false;
                BloqueoBtnBusqueda(false);
                BloqueoBtnGuardar(true);
                LimpiarTxt();
                Vista();
                classMensajes.MensajesCortos("Exito","Se modifico el registro.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionEliminar()
        {
            if (txtSerie.Text!=""||txtTipo.Text!="")
            {
                Eliminar();
                ModoBusqueda = false;
                BloqueoBtnBusqueda(false);
                BloqueoBtnGuardar(true);
                LimpiarTxt();
                Vista();
                classMensajes.MensajesCortos("Exito","Se elimino el registro.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionBusqueda()
        {
            if (txtSerie.Text != "" || txtTipo.Text != "")
            {
                Buscar();
                ModoBusqueda = false;                
                BloqueoTxt(true);
                BloqueoBtnGuardar(false);
                BloqueoBtnBusqueda(true);
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void Ingresar()
        {
            DateTime fecha = DateTime.Parse(txtCreacion.Text);
            DateTime fecha2 = DateTime.Parse(fecha.ToString("yyyy/MM/dd"));
            classFacturas.Parametros(txtNit.Text.Trim(),txtTipo.Text.Trim(),txtSerie.Text.Trim(),fecha2);
            classFacturas.Ingresar();
        }

        public void Modificar()
        {
            DateTime fecha = DateTime.Parse(txtCreacion.Text);
            DateTime fecha2 = DateTime.Parse(fecha.ToString("yyyy/MM/dd"));
            classFacturas.Parametros(txtNit.Text.Trim(), txtTipo.Text.Trim(), txtSerie.Text.Trim(), fecha2);
            classFacturas.Modificar();
        }

        public void Eliminar()
        {
            classFacturas.ParametrosBusqueda(txtNit.Text.Trim(),txtSerie.Text.Trim(), txtTipo.Text.Trim());
            classFacturas.Eliminar();
        }

        public void Buscar()
        {
            classFacturas.ParametrosBusqueda(txtNit.Text.Trim(), txtSerie.Text.Trim(),txtTipo.Text.Trim());
            classFacturas.Buscar();
            txtTipo.Text = classFacturas.tipo;
            txtSerie.Text = classFacturas.serie;
            txtCreacion.Text = classFacturas.creacion.ToString("dd/MM/yyyy");
        }

        public void Vista()
        {
            classFacturas.ParametrosVista(txtNit.Text.Trim());
            VistaLibrosData.ItemsSource = classFacturas.Vista().Tables[0].DefaultView;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionIngresar();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            //Modo Busqueda en Falso
            if (ModoBusqueda == false)
            {
                //Verifica si esta vacios los campos
                if (txtCreacion.Text!="" || txtSerie.Text !="" || txtTipo.Text != "")
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
                        txtSerie.Focus();
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
                    txtSerie.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txtSerie.Text == "" || txtTipo.Text == "")
                {
                    ModoBusqueda = false;
                    BloqueoTxt(true);
                }
                else
                {
                    ValidacionBusqueda();
                }
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionModificar();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionEliminar();
        }   

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ModoBusqueda = false;
            BloqueoTxt(true);
            BloqueoBtnBusqueda(false);
            BloqueoBtnGuardar(true);
            LimpiarTxt();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        private void BtnVista_Click(object sender, RoutedEventArgs e)
        {
            Vista();
        }
    }
}
