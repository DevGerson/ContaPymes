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
        #region Variables y Constantes

        DateTime fecha, fecha2;
        bool ModoBusqueda = false;
        ClassLibros classLibros = new ClassLibros();
        Validaciones validaciones = new Validaciones();
        ClassMensajes classMensajes = new ClassMensajes();        
        ClassContribuyente classContribuyente = new ClassContribuyente();

        #endregion

        #region Constructor

        public LibrosHabilitados()
        {
            InitializeComponent();
            CargarComboContribuyentes();
        }

        #endregion

        #region Eventos y Controles

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            BloqueoTxt(true);
            BloqueoBtn(true);
            BloqueoBusquedaBtn(false);
            LimpiarTxt();
            ModoBusqueda = false;
            txt_fecha.Focus();
        }

        private void Btn_guardar2_Click(object sender, RoutedEventArgs e)
        {
            ValidacionIngresar();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionEliminar();

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
                        BloqueoTxt(false);
                        BloqueoBusquedaTxt(true);
                        BloqueoBusquedaBtn(false);                        
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        LimpiarTxt();
                        txt_resolucion.Focus();
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
                    BloqueoBusquedaTxt(true);
                    BloqueoBtnGuardar(false);
                    ModoBusqueda = true;
                    txt_resolucion.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txt_resolucion.Text == "")
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

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionModificar();
        }

        private void Btn_vista_Click(object sender, RoutedEventArgs e)
        {
            VistaLibros();
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
            ValidacionIngresar();
        }

        private void Txt_fecha_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionFechas(e);
        }

        private void Txt_hojas_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void Txt_resolucion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //validaciones.ValidacionNumeroDeFacturas(e);
        }

        #endregion

        #region Funciones

        public void ValidacionIngresar()
        {
            if (txt_fecha.Text == "" || txt_hojas.Text == "" || txt_tipo.Text == "" || txt_resolucion.Text == "")
            {
                classMensajes.MensajesCortos("Error","Campos vacios.");
            }
            else
            {
                ClassLibros cLibros = new ClassLibros();
                cLibros.BuscarLibro(combo_nit.SelectedValue.ToString().Trim(), txt_resolucion.Text.Trim());
                if (cLibros.ValidacionDuplicadosLibros() == false)
                {
                    Ingresar();
                    LimpiarTxt();
                    VistaLibros();

                    classMensajes.MensajesCortos("Exito", "Se Ingreso .");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro Duplicada");
                }

            }
        }

        public void ValidacionIngresarBusqueda()
        {
            if (txt_fecha.Text == "" || txt_hojas.Text == "" || txt_tipo.Text == "" || txt_resolucion.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                ClassLibros cLibros = new ClassLibros();
                cLibros.BuscarLibro(combo_nit.SelectedValue.ToString().Trim(), txt_resolucion.Text.Trim());
                if (cLibros.ValidacionDuplicadosLibros() == false)
                {
                    //Proceso de Ingresar
                    Ingresar();
                    //Limpia los Textbox
                    LimpiarTxt();
                    //Bloquea los Textbox
                    BloqueoTxt(false);
                    //Desbloque los Textbox para su busqueda
                    BloqueoBusquedaTxt(true);
                    //Bloquea los Buttons de guardar
                    BloqueoBtnGuardar(false);
                    //Se pone en modo Busqueda
                    ModoBusqueda = true;
                    //Focus en fecha
                    txt_resolucion.Focus();
                    //Mensaje de alerta
                    classMensajes.MensajesCortos("Exito", "Se Ingreso.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro Duplicada");
                }
            }
        }

        public void ValidacionModificar()
        {
            if (combo_nit.Text == "" || txt_fecha.Text == "" || txt_hojas.Text == "" || txt_tipo.Text == "" || txt_resolucion.Text == "")
            {
                classMensajes.MensajesCortos("Exito", "Se modifico la factura.");
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

        public void ValidacionEliminar()
        {
            if (combo_nit.Text == "" || txt_resolucion.Text == "")
            {
                classMensajes.MensajesCortos("Exito", "Se elimino la factura.");
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

        public void ValidacionBusqueda()
        {
            if (txt_resolucion.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos Vasillos");
            }
            else
            {
                classLibros.BuscarLibro(combo_nit.SelectedValue.ToString().Trim(), txt_resolucion.Text.Trim());
                if (classLibros.FacturaEncontrada() == true)
                {
                    Busqueda();

                    BloqueoTxt(true);
                    BloqueoBtnGuardar(false);
                    BloqueoBusquedaBtn(true);
                    ModoBusqueda = false;
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "No existe factura.");
                    ModoBusqueda = true;
                }

            }
        }

        public void Ingresar()
        {
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            classLibros.NuevoLibro(combo_nit.SelectedValue.ToString(),fecha2,Convert.ToInt32(txt_hojas.Text.Trim()),txt_tipo.Text.Trim(),txt_resolucion.Text.Trim());
            classLibros.Ingresar();
        }

        public void Modificar()
        {
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            classLibros.NuevoLibro(combo_nit.SelectedValue.ToString(), fecha2, Convert.ToInt32(txt_hojas.Text.Trim()), txt_tipo.Text.Trim(), txt_resolucion.Text.Trim());
            classLibros.Modificar();
        }

        public void Eliminar()
        {
            classLibros.BuscarLibro(combo_nit.SelectedValue.ToString(), txt_resolucion.Text.Trim());
            classLibros.Eliminar();
        }

        public void Busqueda()
        {
            classLibros.BuscarLibro(combo_nit.SelectedValue.ToString(), txt_resolucion.Text.Trim());
            classLibros.Buscar();
            txt_fecha.Text = classLibros.fecha.ToString("dd/MM/yyyy");
            txt_hojas.Text = classLibros.hojas.ToString();
            txt_tipo.Text = classLibros.tipoDoc;
            txt_resolucion.Text = classLibros.resolucion;
        }

        public void VistaLibros()
        {
            classLibros.ParametrosVistaLibro(combo_nit.SelectedValue.ToString());
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
            btn_contribuyentes.IsEnabled = Estado;
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

        private void Btn_contribuyentes_Click(object sender, RoutedEventArgs e)
        {
            string d = combo_nit.SelectedValue.ToString();
            classMensajes.MensajesCortos("NIT", d);
        }

        public void BloqueoBtnGuardar(bool Estado)
        {
            btn_guardar.IsEnabled = Estado;
            btn_guardar2.IsEnabled = Estado;
        }

        #endregion
    }
}
