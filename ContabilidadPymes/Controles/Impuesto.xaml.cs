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
using ContabilidadPymes.Ventanas.vtnReportes;
using ContabilidadPymes.Ventanas.vtnVistas;

namespace ContabilidadPymes.Controles
{
    /// <summary>
    /// Lógica de interacción para Impuesto.xaml
    /// </summary>
    public partial class Impuesto : UserControl
    {
        #region Variables

        bool ModoBusqueda = false;
        Validaciones validaciones = new Validaciones();
        ClassMensajes classMensajes = new ClassMensajes();
        ClassImpuestos classImpuestos = new ClassImpuestos();
        ClassContribuyente classContribuyente = new ClassContribuyente();

        #endregion

        #region Constructor

        public Impuesto()
        {
            InitializeComponent();
            CargarComboContribuyentes();
        }

        #endregion

        #region Controles y Eventos

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionIngresar();
        }

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            BloqueoTxt(true);
            BloqueoBtn(true);
            BloqueoBusquedaBtn(false);
            LimpiarTxt();
            txt_ventas.Focus();
            ModoBusqueda = false;
        }

        private void Btn_limpieza_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        private void Btn_guardar2_Click(object sender, RoutedEventArgs e)
        {
            ValidacionIngresar();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            LimpiarTxt();
            Vista();
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
                if (txt_formulario.Text != "")
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
                        BloqueoBusquedaBtn(false);
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en Fecha
                        txt_formulario.Focus();
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
                    txt_formulario.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txt_formulario.Text == "")
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

        private void Btn_refrescar_Click(object sender, RoutedEventArgs e)
        {
            Vista();
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

        private void Txt_ventas_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionMontos(e);
        }

        private void Txt_impuesto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionMontos(e);
        }

        private void Txt_multa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionMontos(e);
        }

        private void Txt_formulario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void Txt_acceso_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
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
            if (txt_ventas.Text=="" || txt_impuesto.Text=="" || txt_multa.Text=="" || txt_formulario.Text=="" || txt_acceso.Text=="")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                ClassImpuestos cImpuestos = new ClassImpuestos();
                cImpuestos.ParametrosBusqueda(combo_nit.SelectedValue.ToString().Trim(), txt_formulario.Text.Trim());
                if (cImpuestos.ValidacionDuplicadosImpuestos() == false)
                {
                    Ingresar();
                    LimpiarTxt();
                    Vista();                    
                    classMensajes.MensajesCortos("Exito", "Se registro los datos.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro duplicado.");
                }
            }
        }

        public void ValidacionIngresarBusqueda()
        {
            if (txt_ventas.Text == "" || txt_impuesto.Text == "" || txt_multa.Text == "" || txt_formulario.Text == "" || txt_acceso.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                ClassImpuestos cImpuestos = new ClassImpuestos();
                cImpuestos.ParametrosBusqueda(combo_nit.SelectedValue.ToString().Trim(), txt_formulario.Text.Trim());
                if (cImpuestos.ValidacionDuplicadosImpuestos() == false)
                {
                    //Ingresa los datos
                    Ingresar();
                    //Se limpia los Textbox
                    LimpiarTxt();
                    //Bloquea los Textbox
                    BloqueoTxt(false);
                    //Se desbloqueo los Textbox para su busqueda
                    BloqueoBusquedaTxt(true);
                    //Se bloque los buttons para guardar
                    BloqueoBtnGuardar(false);
                    //Se pone en Modo Busqueda
                    ModoBusqueda = true;
                    //Focus en Textbox formulario
                    txt_formulario.Focus();
                    //Mensaje
                    classMensajes.MensajesCortos("Exito", "Se registro los datos.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro duplicado.");
                }
            }
        }

        public void ValidacionModificar()
        {
            if (txt_ventas.Text == "" || txt_impuesto.Text == "" || txt_multa.Text == "" || txt_formulario.Text == "" || txt_acceso.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                Modificar();
                LimpiarTxt();
                Vista();

                BloqueoBusquedaBtn(false);
                BloqueoBtnGuardar(true);
                classMensajes.MensajesCortos("Exitos", "Se modifico el registro.");
            }
        }

        public void ValidacionEliminar()
        {
            if (txt_formulario.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                Eliminar();
                LimpiarTxt();
                Vista();
                BloqueoBusquedaBtn(false);
                BloqueoBtnGuardar(true);
                classMensajes.MensajesCortos("Exitos", "Se modifico el registro.");
            }
        }

        public void ValidacionBusqueda()
        {
            if (txt_formulario.Text != "")
            {
                classImpuestos.ParametrosBusqueda(combo_nit.SelectedValue.ToString().Trim(), txt_formulario.Text.Trim());
                if (classImpuestos.RegistroEncontrado() == true)
                {
                    Busqueda();
                    ModoBusqueda = false;
                    BloqueoTxt(true);
                    BloqueoBtnGuardar(false);
                    BloqueoBusquedaBtn(true);
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "No existe factura.");
                    ModoBusqueda = true;
                }
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void Ingresar()
        {
            classImpuestos.ParametrosImpuestos(combo_nit.SelectedValue.ToString(), Convert.ToDecimal(txt_ventas.Text.Trim()), Convert.ToDecimal(txt_impuesto.Text.Trim()),
                Convert.ToDecimal(txt_multa.Text.Trim()), txt_formulario.Text.Trim(), txt_acceso.Text.Trim());
            classImpuestos.IngresarImpuesto();
        }

        public void Modificar()
        {
            classImpuestos.ParametrosImpuestos(combo_nit.SelectedValue.ToString(), Convert.ToDecimal(txt_ventas.Text.Trim()), Convert.ToDecimal(txt_impuesto.Text.Trim()),
                Convert.ToDecimal(txt_multa.Text.Trim()), txt_formulario.Text.Trim(), txt_acceso.Text.Trim());
            classImpuestos.ModificarImpuesto();
        }

        public void Eliminar()
        {
            classImpuestos.ParametrosBusqueda(combo_nit.SelectedValue.ToString(), txt_formulario.Text.Trim());
            classImpuestos.EliminarImpuesto();
        }

        public void Busqueda()
        {
            classImpuestos.ParametrosBusqueda(combo_nit.SelectedValue.ToString(), txt_formulario.Text.Trim());
            classImpuestos.BuscarImpuesto();
            txt_ventas.Text = classImpuestos.ventas.ToString();
            txt_impuesto.Text = classImpuestos.impuesto.ToString();
            txt_multa.Text = classImpuestos.multas.ToString();
            txt_formulario.Text = classImpuestos.formulario;
            txt_acceso.Text = classImpuestos.acceso;
        }

        public void Vista()
        {       
            classImpuestos.ParametrosVista(combo_nit.SelectedValue.ToString());
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classImpuestos.Vista().Tables[0].DefaultView;                      
        }

        public void LimpiarTxt()
        {
            txt_ventas.Text = "";
            txt_impuesto.Text = "";
            txt_multa.Text = "";
            txt_formulario.Text = "";
            txt_acceso.Text = "";
        }

        public void BloqueoTxt(bool Estado)
        {
            txt_ventas.IsEnabled = Estado;
            txt_impuesto.IsEnabled = Estado;
            txt_multa.IsEnabled = Estado;
            txt_formulario.IsEnabled = Estado;
            txt_acceso.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btn_nuevo.IsEnabled = Estado;
            btn_limpieza.IsEnabled = Estado;
            btn_guardar.IsEnabled = Estado;
            btn_guardar2.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
            btn_buscar.IsEnabled = Estado;
            btn_refrescar.IsEnabled = Estado;
            btn_contribuyentes.IsEnabled = Estado;
            btnVista.IsEnabled = Estado;
            btnReporte.IsEnabled = Estado;
        }

        public void BloqueoBusquedaTxt(bool Estado)
        {
            txt_formulario.IsEnabled = Estado;
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

        private void BtnVista_Click(object sender, RoutedEventArgs e)
        {
            vtnVistasImpuestos vtnVistasImpuestos = new vtnVistasImpuestos();
            vtnVistasImpuestos.Show();
        }

        private void BtnReporte_Click(object sender, RoutedEventArgs e)
        {
            vtnReportesImpuestos vtnReportesImpuestos = new vtnReportesImpuestos();
            vtnReportesImpuestos.Show();
        }
    }
}
