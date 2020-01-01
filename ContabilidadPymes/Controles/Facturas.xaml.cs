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
        ClassFacturas classFacturas = new ClassFacturas();
        bool ModoBusqueda;

        public Facturas(int nitContribuyente)
        {
            InitializeComponent();
            txtNit.Text = nitContribuyente.ToString();
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

        public void Ingresar()
        {
            DateTime fecha = DateTime.Parse(txtCreacion.Text);
            DateTime fecha2 = DateTime.Parse(fecha.ToString("yyyy/MM/dd"));
            classFacturas.Parametros(int.Parse(txtNit.Text.Trim()),txtTipo.Text.Trim(),txtSerie.Text.Trim(),fecha2);
            classFacturas.Ingresar();
        }

        public void Modificar()
        {
            DateTime fecha = DateTime.Parse(txtCreacion.Text);
            DateTime fecha2 = DateTime.Parse(fecha.ToString("yyyy/MM/dd"));
            classFacturas.Parametros(int.Parse(txtNit.Text.Trim()), txtTipo.Text.Trim(), txtSerie.Text.Trim(), fecha2);
            classFacturas.Modificar();
        }

        public void Eliminar()
        {
            classFacturas.ParametrosBusqueda(int.Parse(txtNit.Text.Trim()),txtSerie.Text.Trim(), txtTipo.Text.Trim());
            classFacturas.Eliminar();
        }

        public void Buscar()
        {
            classFacturas.ParametrosBusqueda(int.Parse(txtNit.Text.Trim()), txtSerie.Text.Trim(),txtTipo.Text.Trim());
            classFacturas.Buscar();
            txtTipo.Text = classFacturas.tipo;
            txtSerie.Text = classFacturas.serie;
            txtCreacion.Text = classFacturas.creacion.ToString("dd/MM/yyyy");
        }

        public void Vista()
        {
            classFacturas.ParametrosVista(int.Parse(txtNit.Text.Trim()));
            VistaLibrosData.ItemsSource = classFacturas.Vista().Tables[0].DefaultView;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            LimpiarTxt();
            Vista();
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
                        LimpiarTxt();
                        //Variable para verificar si esta en modo busqueda y Bloqueo de Botones o Desbloqueo
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en Fecha
                        txtSerie.Focus();
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
                        txtSerie.Focus();
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
                    ModoBusqueda = false;
                    Buscar();
                    BloqueoTxt(true);
                    BloqueoBtnGuardar(false);
                    BloqueoBtnBusqueda(true);
                }

            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Modificar();
            ModoBusqueda = false;
            BloqueoBtnBusqueda(false);
            BloqueoBtnGuardar(true);
            LimpiarTxt();
            Vista();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            ModoBusqueda = false;
            BloqueoBtnBusqueda(false);
            BloqueoBtnGuardar(true);
            LimpiarTxt();
            Vista();
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
