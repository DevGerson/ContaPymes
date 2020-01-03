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
using ContabilidadPymes.Controles;

namespace ContabilidadPymes.Controles
{
    /// <summary>
    /// Lógica de interacción para FacturasDetalles.xaml
    /// </summary>
    public partial class FacturasDetalles : UserControl
    {
        #region Variables

        bool ModoBusqueda;
        Validaciones validaciones = new Validaciones();
        ClassMensajes classMensajes = new ClassMensajes();
        ClassFacturas classFacturas = new ClassFacturas();
        ClassContribuyente classContribuyente = new ClassContribuyente();
        ClassFacturasDetalles classFacturasDetalles = new ClassFacturasDetalles();

        #endregion

        #region Constructor

        public FacturasDetalles()
        {
            InitializeComponent();
            CargarComboContribuyente();
        }

        #endregion

        #region Controles

        private void Btn_contribuyentes_Click(object sender, RoutedEventArgs e)
        {
            string d = combo_nit.SelectedValue.ToString();
            classMensajes.MensajesCortos("NIT",d);
        }

        private void Combo_nit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_nit.SelectedIndex >= 0)
            {
                BloqueoBtn(true);
                BloqueoTxt(true);
                BloqueoBtnBusqueda(false);
                ListTipos();
                txtSerie.ItemsSource = null;
                LimpiarTxt();
            }
            else
            {
                BloqueoBtn(false);
                BloqueoTxt(false);
            }
        }

        private void TxtTipo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTipo.SelectedIndex >= 0)
            {
                ListSeries();
            }
            else
            {
                txtTipo.Text = "";
            }
        }

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            ModoBusqueda = false;
            LimpiarTxt();
            BloqueoTxt(true);
            BloqueoBtnBusqueda(false);
            BloqueoBtnGuardar(true);
        }

        private void Btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        private void Btn2_guardar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionIngresar();       
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

        private void Btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            //Modo Busqueda en Falso
            if (ModoBusqueda == false)
            {
                //Verifica si esta vacios los campos
                if (txtResolucion.Text != "")
                {
                    //Pregunta si quiere guardar los datos por si hubiese datos ingresados
                    MessageBoxButton boxButton = MessageBoxButton.YesNo;
                    MessageBoxResult messageBoxResult = MessageBox.Show("Se perderan los datos si no ha guardado. ¿Desea Guardar los datos?", "Buscar", boxButton);
                    if (messageBoxResult == MessageBoxResult.No)
                    {
                        BloqueoTxt(false);
                        BloqueoTxtBusqueda(true);
                        BloqueoBtnGuardar(false);
                        LimpiarTxt();
                        ModoBusqueda = true;
                        BloqueoBtnBusqueda(false);
                        txtResolucion.Focus();
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
                    txtResolucion.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txtResolucion.Text == "")
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

        private void Btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            Vista();
        }

        private void Btn_seriesRegistradas_Click(object sender, RoutedEventArgs e)
        {
            FacturaSeries facturaSeries = new FacturaSeries(combo_nit.SelectedValue.ToString());
            facturaSeries.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListSeries();
        }

        private void TxtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void TxtDel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void TxtAl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void TxtVigencia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionFechas(e);
        }

        private void TxtCreacion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionFechas(e);
        }

        private void TxtImprenta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        #endregion

        #region Funciones
        public void CargarComboContribuyente()
        {
            combo_nit.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            combo_nit.DisplayMemberPath = "razon_social";
            combo_nit.SelectedValuePath = "nit";
        }

        public void LimpiarTxt()
        {
            txtTipo.Text = "";
            txtSerie.Text = "";
            txtCantidad.Text = "";
            txtDel.Text = "";
            txtAl.Text = "";
            txtResolucion.Text = "";
            txtVigencia.Text = "";
            txtCreacion.Text = "";
            txtImprenta.Text = "";
        }

        public void BloqueoTxt(bool Estado)
        {
            txtTipo.IsEnabled = Estado;
            txtSerie.IsEnabled = Estado;
            txtCantidad.IsEnabled = Estado;
            txtDel.IsEnabled = Estado;
            txtAl.IsEnabled = Estado;
            txtResolucion.IsEnabled = Estado;
            txtVigencia.IsEnabled = Estado;
            txtCreacion.IsEnabled = Estado;
            txtImprenta.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btn2_guardar.IsEnabled = Estado;
            btn_limpiar.IsEnabled = Estado;
            btn_nuevo.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
            btn_buscar.IsEnabled = Estado;
            btn_contribuyentes.IsEnabled = Estado;
            btn_actualizar.IsEnabled = Estado;
            btn_seriesRegistradas.IsEnabled = Estado;
            btn_guardar.IsEnabled = Estado;
            btn_List.IsEnabled = Estado;
        }

        public void BloqueoBtnBusqueda(bool Estado)
        {
            btn_editar.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
        }

        public void BloqueoTxtBusqueda(bool Estado)
        {
            txtResolucion.IsEnabled = Estado;
        }

        public void BloqueoBtnGuardar(bool Estado)
        {
            btn2_guardar.IsEnabled = Estado;
            btn_guardar.IsEnabled = Estado;
        }

        public void ValidacionIngresarBusqueda()
        {
            if (txtTipo.Text!=""||txtSerie.Text!=""||txtCantidad.Text!=""||txtDel.Text!=""||txtAl.Text!=""||txtResolucion.Text!=""||txtVigencia.Text!=""||txtCreacion.Text!=""||txtImprenta.Text!="")
            {
                classFacturasDetalles.ParametrosBusqueda(combo_nit.SelectedValue.ToString(),txtResolucion.Text.Trim());
                if (classFacturasDetalles.ValidacionDuplicadosFacturasDetalles()==false)
                {
                    //Ingresa los datos
                    Ingresar();
                    //Se limpia los Textbox
                    LimpiarTxt();
                    //Se Bloquea los Textbox
                    BloqueoTxt(false);
                    //Se Desbloqueo los Textbox para su busqueda
                    BloqueoTxtBusqueda(true);
                    //Se bloquea los Buttons de guardar
                    BloqueoBtnGuardar(false);
                    //Se pone en modo busqueda falso                    
                    ModoBusqueda = true;
                    //Focus en Textbox Resolucion
                    txtResolucion.Focus();
                    //Mensaje de alerta
                    classMensajes.MensajesCortos("Exito", "Se regitro correctamente.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro Duplicado. Verifique la información");
                }
            }
            else
            {
                classMensajes.MensajesCortos("Exito", "Se regitro correctamente.");
            }
        }

        public void ValidacionIngresar()
        {
            if (txtTipo.Text != "" || txtSerie.Text != "" || txtCantidad.Text != "" || txtDel.Text != "" || txtAl.Text != "" || txtResolucion.Text != "" || txtVigencia.Text != "" || txtCreacion.Text != "" || txtImprenta.Text != "")
            {
                classFacturasDetalles.ParametrosBusqueda(combo_nit.SelectedValue.ToString(), txtResolucion.Text.Trim());
                if (classFacturasDetalles.ValidacionDuplicadosFacturasDetalles() == false)
                {
                    Ingresar();
                    LimpiarTxt();
                    Vista();
                    classMensajes.MensajesCortos("Exito", "Se regitro correctamente.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Registro Duplicado. Verifique la información");
                }
            }
            else
            {
                classMensajes.MensajesCortos("Exito", "Se regitro correctamente.");
            }
        }

        public void ValidacionModificar()
        {
            if (txtTipo.Text != "" || txtSerie.Text != "" || txtCantidad.Text != "" || txtDel.Text != "" || txtAl.Text != "" || txtResolucion.Text != "" || txtVigencia.Text != "" || txtCreacion.Text != "" || txtImprenta.Text != "")
            {
                Modificar();
                LimpiarTxt();
                Vista();
                BloqueoBtnGuardar(true);
                BloqueoBtnBusqueda(false);

                classMensajes.MensajesCortos("Exito","Se modifico correctamente.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionEliminar()
        {
            if (txtResolucion.Text != "")
            {
                Eliminar();
                LimpiarTxt();
                Vista();
                BloqueoBtnGuardar(true);
                BloqueoBtnBusqueda(false);
                classMensajes.MensajesCortos("Exito", "Se modifico correctamente.");
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void ValidacionBusqueda()
        {
            if (txtResolucion.Text!="")
            {
                classFacturasDetalles.ParametrosBusqueda(combo_nit.SelectedValue.ToString(),txtResolucion.Text.Trim());
                if (classFacturasDetalles.FacturaEncontrada()==true)
                {
                    Buscar();
                    ModoBusqueda = false;
                    BloqueoTxt(true);
                    BloqueoBtnGuardar(false);
                    BloqueoBtnBusqueda(true);
                }
                else
                {
                    classMensajes.MensajesCortos("Error","No existe este registro");
                }
            }
            else
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
        }

        public void Ingresar()
        {
            DateTime VigenciaOne, VigenciaTwo;
            DateTime CreacionOne, CreacionTwo;
            VigenciaOne = DateTime.Parse(txtVigencia.Text.Trim());
            VigenciaTwo = DateTime.Parse(VigenciaOne.ToString("yyyy/MM/dd"));
            CreacionOne = DateTime.Parse(txtCreacion.Text.Trim());
            CreacionTwo = DateTime.Parse(CreacionOne.ToString("yyyy/MM/dd"));

            classFacturasDetalles.ParametrosFacturas(combo_nit.SelectedValue.ToString(), txtTipo.Text.Trim(), int.Parse(txtCantidad.Text.Trim()), txtSerie.Text.Trim(), int.Parse(txtDel.Text.Trim()),
                int.Parse(txtAl.Text.Trim()), txtResolucion.Text.Trim(), CreacionTwo, VigenciaTwo, txtImprenta.Text.Trim());
            classFacturasDetalles.Ingresar();
        }

        public void Modificar()
        {
            DateTime VigenciaOne, VigenciaTwo;
            DateTime CreacionOne, CreacionTwo;
            VigenciaOne = DateTime.Parse(txtVigencia.Text.Trim());
            VigenciaTwo = DateTime.Parse(VigenciaOne.ToString("yyyy/MM/dd"));
            CreacionOne = DateTime.Parse(txtCreacion.Text.Trim());
            CreacionTwo = DateTime.Parse(CreacionOne.ToString("yyyy/MM/dd"));

            classFacturasDetalles.ParametrosFacturas(combo_nit.SelectedValue.ToString(), txtTipo.Text.Trim(), int.Parse(txtCantidad.Text.Trim()), txtSerie.Text.Trim(), int.Parse(txtDel.Text.Trim()),
                int.Parse(txtAl.Text.Trim()), txtResolucion.Text.Trim(), CreacionTwo, VigenciaTwo, txtImprenta.Text.Trim());
            classFacturasDetalles.Modificar();
        }

        public void Eliminar()
        {
            classFacturasDetalles.ParametrosBusqueda(combo_nit.SelectedValue.ToString(), txtResolucion.Text.Trim());
            classFacturasDetalles.Eliminar();
        }

        public void Buscar()
        {
            classFacturasDetalles.ParametrosBusqueda(combo_nit.SelectedValue.ToString(), txtResolucion.Text.Trim());
            classFacturasDetalles.Buscar();
            txtTipo.Text = classFacturasDetalles.tipo;
            ListSeries();
            txtSerie.Text = classFacturasDetalles.serie;
            txtCantidad.Text = classFacturasDetalles.cantidad.ToString();
            txtDel.Text = classFacturasDetalles.del.ToString();
            txtAl.Text = classFacturasDetalles.al.ToString();
            txtResolucion.Text = classFacturasDetalles.resolucion;
            txtVigencia.Text = classFacturasDetalles.vigencia.ToString("dd/MM/yyyy");
            txtCreacion.Text = classFacturasDetalles.creacion.ToString("dd/MM/yyyy");
            txtImprenta.Text = classFacturasDetalles.imprenta.ToString();
        }

        public void ListTipos()
        {
            classFacturas.ParametrosVista(combo_nit.SelectedValue.ToString());
            txtTipo.ItemsSource = classFacturas.ListTipos().Tables[0].DefaultView;
            txtTipo.DisplayMemberPath = "tipo_doc";
            txtTipo.SelectedValuePath = "tipo_doc";
        }

        public void ListSeries()
        {
            classFacturas.ParametrosListSeries(combo_nit.SelectedValue.ToString(), txtTipo.Text);
            txtSerie.ItemsSource = classFacturas.ListSeries().Tables[0].DefaultView;
            txtSerie.DisplayMemberPath = "serie";
        }

        public void Vista()
        {
            classFacturasDetalles.ParametrosVista(combo_nit.SelectedValue.ToString());
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFacturasDetalles.Vista().Tables[0].DefaultView;
        }





        #endregion
    }
}
