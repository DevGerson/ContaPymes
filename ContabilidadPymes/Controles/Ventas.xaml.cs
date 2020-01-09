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
using ContabilidadPymes.Ventanas.vtnReportes;
using ContabilidadPymes.Ventanas.vtnVistas;

namespace ContabilidadPymes.Controles
{
    /// <summary>
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : UserControl
    {
        #region Variables y Constantes

        private bool ModoBusqueda;
        private DateTime fecha, fecha2;
        private ClassFacturas classFacturas = new ClassFacturas();
        private ClassVentas classVentas = new ClassVentas();
        private Validaciones validaciones = new Validaciones();
        private ClassMensajes classMensajes = new ClassMensajes();
        private ClassClientes classClientes = new ClassClientes();
        private ClassContribuyente classContribuyente = new ClassContribuyente();
        private ClassFacturasDetalles classFacturasDetalles = new ClassFacturasDetalles();
        
        #endregion

        #region Constructor

        public Ventas()
        {
            InitializeComponent();
            CargarComboContribuyentes();
            CargarComboCliente();
        }

        #endregion

        #region Controles

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionIngresar();
        }

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            BloqueoTxt(true);
            BloqueoBusquedaBtn(false);
            BloqueoBtnGuardar(true);
            LimpiarTxt();
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
                if (txt_fecha.Text != "" || txt_factura.Text != "" || combo_cliente.Text != "")
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
                        //Focus en serie
                        combo_serie.Focus();
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
                    combo_serie.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (combo_serie.Text == "" || txt_factura.Text == "")
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

        private void Btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            Vista();
        }

        private void Combo_razon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_razon.SelectedIndex >= 0)
            {
                BloqueoTxt(true);
                BloqueoBtn(true);
                BloqueoBusquedaBtn(false);
                ListTipos();
                combo_serie.ItemsSource = null;
                combo_serie.Items.Clear();
            }
            else
            {
                BloqueoTxt(false);
                BloqueoBtn(false);
            }

        }

        private void Btn_contribuyentes_Click(object sender, RoutedEventArgs e)
        {
            string d = combo_razon.SelectedValue.ToString();
            classMensajes.MensajesCortos("NIT", d);
        }

        private void Txt_fecha_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionFechas(e);
        }

        private void Txt_factura_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void Txt_Monto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionMontos(e);
        }

        private void Txt_tipoDoc_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_tipoDoc.SelectedIndex >= 0)
            {
                ListSeries();
            }
            else
            {
                txt_tipoDoc.Text = "";
            }
        }

        #endregion

        #region Funciones

        public void ValidacionIngresarBusqueda()
        {
            if (txt_fecha.Text == "" || txt_tipoDoc.Text == "" || combo_serie.Text == "" || txt_factura.Text == "" || combo_cliente.Text == "" || txt_Monto.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                if (txt_Exento.IsChecked == false)
                {
                    classVentas.BuscarVentas(combo_razon.SelectedValue.ToString(), combo_serie.SelectedValue.ToString(), int.Parse(txt_factura.Text.Trim()));
                    if (classVentas.ValidacionDuplicadosVentas() == false)
                    {
                        //Ingresa la factura a la bd
                        Ingresar();
                        //Bloquea los Textbox
                        BloqueoTxt(false);
                        //Desbloqueo de los Textbox para la busqueda
                        BloqueoBusquedaTxt(true);
                        //Bloquea los Buttons de ingresar
                        BloqueoBtnGuardar(false);
                        //Valida que esta en modo Busqueda
                        ModoBusqueda = true;
                        //Limpia los Textbox
                        LimpiarTxt();
                        //Enfoca al al campo Fecha
                        txt_fecha.Focus();
                        //Actualiza el datagrid
                        Vista();
                        //Mensaje de Registro
                        classMensajes.MensajesCortos("Exito", "Se registro la factura.");
                    }
                    else
                    {

                        classMensajes.MensajesCortos("Error", "Factura Duplicada. Verifique los datos");
                    }
                }
                else
                {
                    classVentas.BuscarVentas(combo_razon.SelectedValue.ToString(), combo_serie.SelectedValue.ToString(), int.Parse(txt_factura.Text.Trim()));
                    if (classVentas.ValidacionDuplicadosVentas() == false)
                    {
                        //Ingresa la factura exenta a la bd
                        IngresarExento();
                        //Bloquea los Textbox
                        BloqueoTxt(false);
                        //Desbloqueo de los Textbox para la busqueda
                        BloqueoBusquedaTxt(true);
                        //Bloquea los Buttons de ingresar
                        BloqueoBtnGuardar(false);
                        //Valida que esta en modo Busqueda
                        ModoBusqueda = true;
                        //Limpia los Textbox
                        LimpiarTxt();
                        //Enfoca al al campo Fecha
                        txt_fecha.Focus();
                        //Actualiza el datagrid
                        Vista();
                        //Mensaje de Registro
                        classMensajes.MensajesCortos("Exito", "Se registro la factura.");
                    }
                    else
                    {

                        classMensajes.MensajesCortos("Error", "Factura Duplicada. Verifique los datos");
                    }

                }
            }
        }

        public void ValidacionIngresar()
        {
            if (txt_fecha.Text == "" || txt_tipoDoc.Text == "" || combo_serie.Text == "" || txt_factura.Text == "" || combo_cliente.Text == "" || txt_Monto.Text == "")
            {
                classMensajes.MensajesCortos("Error","Campos vacios.");
            }
            else
            {
                if (txt_Exento.IsChecked == false)
                {
                    classVentas.BuscarVentas(combo_razon.SelectedValue.ToString(), combo_serie.SelectedValue.ToString(), int.Parse(txt_factura.Text.Trim()));
                    if (classVentas.ValidacionDuplicadosVentas()==false)
                    {
                        Ingresar();

                        LimpiarTxt();
                        txt_fecha.Focus();
                        Vista();

                        classMensajes.MensajesCortos("Exito", "Se registro la factura.");
                    }
                    else
                    {

                        classMensajes.MensajesCortos("Error", "Factura Duplicada. Verifique los datos");
                    }
                }
                else
                {
                    classVentas.BuscarVentas(combo_razon.SelectedValue.ToString(), combo_serie.SelectedValue.ToString(), int.Parse(txt_factura.Text.Trim()));
                    if (classVentas.ValidacionDuplicadosVentas() == false)
                    {
                        IngresarExento();

                        LimpiarTxt();
                        txt_fecha.Focus();
                        Vista();

                        classMensajes.MensajesCortos("Exito", "Se registro la factura.");
                    }
                    else
                    {

                        classMensajes.MensajesCortos("Error", "Factura Duplicada. Verifique los datos");
                    }
                }
            }
        }

        public void ValidacionBusqueda()
        {
            if (combo_serie.Text == "" || txt_factura.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                classVentas.BuscarVentas(combo_razon.SelectedValue.ToString(),combo_serie.SelectedValue.ToString(),int.Parse(txt_factura.Text.Trim()));
                if (classVentas.ExisteFactura()==true)
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

        public void ValidacionModificar()
        {
            if (txt_fecha.Text == "" || txt_tipoDoc.Text == "" || combo_serie.Text == "" || txt_factura.Text == "" || combo_cliente.Text == "" || txt_Monto.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                if (txt_Exento.IsChecked == false)
                {
                    Modificar();

                    LimpiarTxt();
                    txt_fecha.Focus();
                    Vista();

                    BloqueoBtnGuardar(true);
                    BloqueoBusquedaBtn(false);

                    classMensajes.MensajesCortos("Exito", "Se modifico la factura.");

                }
                else
                {
                    ModificarExento();

                    LimpiarTxt();
                    txt_fecha.Focus();
                    Vista();

                    BloqueoBtnGuardar(true);
                    BloqueoBusquedaBtn(false);

                    classMensajes.MensajesCortos("Exito", "Se modifico la factura.");
                }
            }
        }

        public void ValidacionEliminar()
        {
            if (combo_serie.Text == "" || txt_factura.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                Eliminar();

                LimpiarTxt();
                txt_fecha.Focus();
                Vista();

                BloqueoBtnGuardar(true);
                BloqueoBusquedaBtn(false);

                classMensajes.MensajesCortos("Exito", "Se elimino la facturas.");
            }
        }
        
        public void Ingresar()
        {
            decimal monto = Convert.ToDecimal(txt_Monto.Text.Trim());
            decimal Iva = Convert.ToDecimal(txt_Monto.Text.Trim()) * Convert.ToDecimal(0.05);
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));

            classVentas.NuevaVentas(combo_razon.SelectedValue.ToString().Trim(), fecha2, txt_tipoDoc.Text.Trim(), combo_serie.SelectedValue.ToString().Trim(), Convert.ToInt32(txt_factura.Text.Trim()),
            combo_cliente.SelectedValue.ToString().Trim(), monto, 0, Iva);
            classVentas.Ingresar();
        }

        public void IngresarExento()
        {
            decimal monto = Convert.ToDecimal(txt_Monto.Text.Trim());
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));

            classVentas.NuevaVentas(combo_razon.SelectedValue.ToString().Trim(), fecha2, txt_tipoDoc.Text.Trim(), combo_serie.SelectedValue.ToString().Trim(), Convert.ToInt32(txt_factura.Text.Trim()),
            combo_cliente.SelectedValue.ToString().Trim(), 0, monto, 0);
            classVentas.Ingresar();
        }

        public void Modificar()
        {
            decimal monto = Convert.ToDecimal(txt_Monto.Text.Trim());
            decimal Iva = Convert.ToDecimal(txt_Monto.Text.Trim()) * Convert.ToDecimal(0.05);
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            classVentas.NuevaVentas(combo_razon.SelectedValue.ToString().Trim(), fecha2, txt_tipoDoc.Text.Trim(), combo_serie.SelectedValue.ToString().Trim(), Convert.ToInt32(txt_factura.Text.Trim()),
                combo_cliente.SelectedValue.ToString().Trim(), monto, 0, Iva);
            classVentas.Modificar();

        }

        public void ModificarExento()
        {
            decimal monto = Convert.ToDecimal(txt_Monto.Text.Trim());
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            classVentas.NuevaVentas(combo_razon.SelectedValue.ToString().Trim(), fecha2, txt_tipoDoc.Text.Trim(), combo_serie.SelectedValue.ToString().Trim(), Convert.ToInt32(txt_factura.Text.Trim()),
                combo_cliente.SelectedValue.ToString().Trim(), 0, monto, 0);
            classVentas.Modificar();
        }
           
        public void Eliminar()
        {
            classVentas.BuscarVentas(combo_razon.SelectedValue.ToString().Trim(), combo_serie.SelectedValue.ToString().Trim(), Convert.ToInt32(txt_factura.Text.Trim()));
            classVentas.Eliminar();
        }

        public void Busqueda()
        {
            classVentas.BuscarVentas(combo_razon.SelectedValue.ToString().Trim(), combo_serie.SelectedValue.ToString().Trim(), Convert.ToInt32(txt_factura.Text.Trim()));
            classVentas.Buscar();

            txt_fecha.Text = classVentas.fecha.ToString("dd/MM/yyyy");
            txt_tipoDoc.Text = classVentas.tipoDoc;
            combo_serie.Text = classVentas.serie;
            txt_factura.Text = classVentas.factura.ToString();
            combo_cliente.Text = classVentas.nitCliente.ToString() + " - " + classVentas.nombreCliente;
            txt_Monto.Text = classVentas.monto.ToString("N2");
            if (classVentas.exento == 0)
            {
                txt_Exento.IsChecked = false;
            }
            else
            {
                txt_Exento.IsChecked = true;
                txt_Monto.Text = classVentas.exento.ToString("N2");
            }
        }

        public void LimpiarTxt()
        {
            txt_fecha.Text = "";
            txt_tipoDoc.Text = "";
            combo_serie.Text = "";
            txt_factura.Text = "";
            combo_cliente.Text = "";
            txt_Monto.Text = "";
            txt_Exento.IsChecked = false;
        }

        public void Vista()
        {
            classVentas.ParametroVistaVentas(combo_razon.SelectedValue.ToString());
            VistaVentas.ItemsSource = null;
            VistaVentas.ItemsSource = classVentas.VistaFacturaVentas().Tables[0].DefaultView;
        }

        public void CargarComboContribuyentes()
        {
            combo_razon.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            combo_razon.DisplayMemberPath = "razon_social";
            combo_razon.SelectedValuePath = "nit";
        }

        public void CargarComboCliente()
        {
            combo_cliente.ItemsSource = classClientes.Reporte().Tables[0].DefaultView;
            combo_cliente.DisplayMemberPath = "Clientes";
            combo_cliente.SelectedValuePath = "nit";
        }

        public void BloqueoTxt(bool Estado)
        {
            txt_fecha.IsEnabled = Estado;
            txt_tipoDoc.IsEnabled = Estado;
            combo_serie.IsEnabled = Estado;            
            combo_cliente.IsEnabled = Estado;
            txt_factura.IsEnabled = Estado;
            combo_cliente.IsEnabled = Estado;
            txt_Monto.IsEnabled = Estado;
            txt_Exento.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btn_nuevo.IsEnabled = Estado;
            btn_limpiar.IsEnabled = Estado;
            btn_guardar.IsEnabled = Estado;
            btn_guardar2.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
            btn_buscar.IsEnabled = Estado;
            btn_actualizar.IsEnabled = Estado;
            btn_contribuyentes.IsEnabled = Estado;
        }

        public void BloqueoBusquedaTxt(bool Estado)
        {
            txt_factura.IsEnabled = Estado;
            combo_serie.IsEnabled = Estado;
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
            btnVista.IsEnabled = Estado;
            btnReporte.IsEnabled = Estado;
        }

        public void ListTipos()
        {
            txt_tipoDoc.ItemsSource = null;
            txt_tipoDoc.Items.Clear();
            classFacturasDetalles.ParametrosVista(combo_razon.SelectedValue.ToString());
            txt_tipoDoc.ItemsSource = classFacturasDetalles.ListTipos().Tables[0].DefaultView;
            txt_tipoDoc.DisplayMemberPath = "tipo_doc";
            txt_tipoDoc.SelectedValuePath = "tipo_doc";
        }

        private void BtnVista_Click(object sender, RoutedEventArgs e)
        {
            vtnVistasVentas vtnVistasVentas = new vtnVistasVentas();
            vtnVistasVentas.Show();
        }

        private void BtnReporte_Click(object sender, RoutedEventArgs e)
        {
            vtnReportesVentas vtnReportesVentas = new vtnReportesVentas();
            vtnReportesVentas.Show();
        }

        public void ListSeries()
        {
            classFacturasDetalles.ParametrosListSeries(combo_razon.SelectedValue.ToString(), txt_tipoDoc.Text);
            combo_serie.ItemsSource = classFacturasDetalles.ListSeries().Tables[0].DefaultView;
            combo_serie.DisplayMemberPath = "serie";
            combo_serie.SelectedValuePath = "serie";
        }

        #endregion
    }
}
