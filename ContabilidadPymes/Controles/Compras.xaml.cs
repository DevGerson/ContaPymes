using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para Compras.xaml
    /// </summary>
    public partial class Compras : UserControl
    {

        #region Variables

        private decimal iva;
        private DateTime fecha, fecha2;
        private bool ModoBusqueda = false;
        private static Compras instancia = null;
        private Validaciones validaciones = new Validaciones();
        private ClassCompras classCompras = new ClassCompras();
        private ClassMensajes classMensajes = new ClassMensajes();
        private ClassProveedor classProveedor = new ClassProveedor();
        private ClassContribuyente classContribuyente = new ClassContribuyente();        
        #endregion

        #region Singleton

        public static Compras Instacian
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Compras();
                }
                return instancia;
            }
        }

        #endregion

        #region Constructor

        public Compras()
        {
            InitializeComponent();
            CargarCombo();
            CargarComboProveedor();
        }

        #endregion

        #region Funciones

        public void LimpiarTxt()
        {
            txt_fecha.Text = "";
            txt_tipo_doc.Text = "";
            txt_serie.Text = "";
            txt_factura.Text = "";
            txt_monto.Text = "";
            combo_cliente.Text = "";
        }

        public void VistaCompras()
        {
            classCompras.ParametrosVista(combo_razon.SelectedValue.ToString());
            ViewData.ItemsSource = null;
            ViewData.ItemsSource = classCompras.VistaCompras().Tables[0].DefaultView;
        }

        public void BloqueoTxt(bool Estado)
        {
            txt_fecha.IsEnabled = Estado;
            txt_tipo_doc.IsEnabled = Estado;
            txt_serie.IsEnabled = Estado;
            txt_factura.IsEnabled = Estado;
            txt_monto.IsEnabled = Estado;
            btn_guardar.IsEnabled = Estado;
            combo_cliente.IsEnabled = Estado;
        }

        public void BloqueoBtn(bool Estado)
        {
            btn_buscar.IsEnabled = Estado;
            btn_nuevo.IsEnabled = Estado;
            btn_limpiar.IsEnabled = Estado;
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
            btn_buscar.IsEnabled = Estado;
            btn2_guardar.IsEnabled = Estado;
            btn_guardar.IsEnabled = Estado;
            btn_contribuyentes.IsEnabled = Estado;
            btn_actualizar.IsEnabled = Estado;
            ReporteCompras.IsEnabled = Estado;
            btnVistaCompras.IsEnabled = Estado;
        }

        public void BloqueoBusquedaTxt(bool Estado)
        {
            txt_serie.IsEnabled = Estado;
            txt_factura.IsEnabled = Estado;
            combo_cliente.IsEnabled = Estado;
        }

        public void BloqueoBusquedaBtn(bool Estado)
        {
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
        }

        public void BloqueoBtnGuardar(bool Estado)
        {
            btn2_guardar.IsEnabled = Estado;
            btn_guardar.IsEnabled = Estado;
        }

        public void ValidacionIngresarBusqueda()
        {
            if (combo_razon.SelectedValue.ToString() == "" || txt_fecha.Text == "" || txt_tipo_doc.Text == "" || txt_serie.Text == "" || txt_factura.Text == "" || combo_cliente.Text == ""
                || txt_monto.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos Vacios");
            }
            else
            {
                ClassCompras cCompras = new ClassCompras();                
                cCompras.ParametrosDuplicados(combo_razon.SelectedValue.ToString().Trim(), combo_cliente.SelectedValue.ToString().Trim(), txt_serie.Text.Trim(), Convert.ToInt32(txt_factura.Text.Trim()), txt_tipo_doc.Text.Trim());
                //Verifica que no halla deuplicados
                if (cCompras.ValidacionDuplicadosCompras() == false)
                {
                    //Ingresa la factura
                    Ingresar();
                    //Limpia los Textbox
                    LimpiarTxt();
                    //Bloquea los textbox
                    BloqueoTxt(false);
                    //Desbloquea los Textbox para la busqueda
                    BloqueoBusquedaTxt(true);
                    //Bloquea los Buttons para no permir guardar mientras las busqueda
                    BloqueoBtnGuardar(false);
                    //Activa el ModoBusqueda
                    ModoBusqueda = true;
                    //Enfoca el Textbox de Serie para la busqueda
                    txt_serie.Focus();
                    //Actualiza el datagrid
                    VistaCompras();
                    //Mensaje que se registro la factura
                    classMensajes.MensajesCortos("Exito", "Se registro la factura.");
                }
                else
                {
                    //Mensaje de Alerta que hay duplicados
                    classMensajes.MensajesCortos("Error", "Factura Duplicada");
                }
            }
        }

        public void ValidacionIngresar()
        {
            if (combo_razon.SelectedValue.ToString() == "" || txt_fecha.Text == "" || txt_tipo_doc.Text == "" || txt_serie.Text == "" || txt_factura.Text == "" || combo_cliente.Text == ""
                || txt_monto.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos Vacios.");
            }
            else
            {
                ClassCompras cCompras = new ClassCompras();
                cCompras.ParametrosDuplicados(combo_razon.SelectedValue.ToString().Trim(), combo_cliente.SelectedValue.ToString().Trim(), txt_serie.Text.Trim(), Convert.ToInt32(txt_factura.Text.Trim()), txt_tipo_doc.Text.Trim());
                if (cCompras.ValidacionDuplicadosCompras() == false)
                {
                    Ingresar();

                    LimpiarTxt();
                    txt_fecha.Focus();
                    VistaCompras();
                    classMensajes.MensajesCortos("Exito", "Se registro la factura.");
                }
                else
                {
                    classMensajes.MensajesCortos("Error", "Factura Duplicada");
                }
            }
        }

        public void ValidacionModificar()
        {
            if (combo_razon.SelectedValue.ToString() == "" || txt_fecha.Text == "" || txt_tipo_doc.Text == "" || txt_serie.Text == "" || txt_factura.Text == "" || combo_cliente.Text == ""
                || txt_monto.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos Vasillos");
            }
            else
            {
                Modificar();

                //Procesos despues de editar
                LimpiarTxt();
                VistaCompras();
                BloqueoBtnGuardar(true);
                BloqueoBusquedaBtn(false);

                //Mensaje de proceso con exito
                classMensajes.MensajesCortos("Exito", "Factura modificada.");
            }
        }
         
        public void ValidacionBusqueda()
        {
            if (txt_serie.Text==""||txt_factura.Text==""||combo_cliente.Text=="")
            {
                classMensajes.MensajesCortos("Error","Campos Vasillos");
            }
            else
            {
                classCompras.Busqueda(combo_razon.SelectedValue.ToString().Trim(), combo_cliente.SelectedValue.ToString().Trim(), txt_serie.Text.Trim(), Convert.ToInt32(txt_factura.Text.Trim()));
                if (classCompras.FacturaEncontrado()==true)
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

        public void ValidacionEliminar()
        {
            if (combo_razon.SelectedValue.ToString() == "" || txt_fecha.Text == "" || txt_serie.Text == "" || txt_factura.Text == "")
            {
                classMensajes.MensajesCortos("Error", "Campos vacios.");
            }
            else
            {
                Eliminar();

                //Procesos despues de la Eliminacion
                LimpiarTxt();
                VistaCompras();
                BloqueoBtnGuardar(true);
                BloqueoBusquedaBtn(false);

                //Mensaje de proceso con exito
                classMensajes.MensajesCortos("Exito", "Factura eliminada.");
            }
        }

        public void Ingresar()
        {
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            iva = Convert.ToDecimal(txt_monto.Text.Trim()) * Convert.ToDecimal(0.05);
            classCompras.NuevaFacturaCompra(
                combo_razon.SelectedValue.ToString().Trim(),
                fecha2,
                txt_tipo_doc.Text.Trim(),
                txt_serie.Text.Trim(),
                Convert.ToInt32(txt_factura.Text.Trim()),
                combo_cliente.SelectedValue.ToString().Trim(),
                Convert.ToDecimal(txt_monto.Text.Trim()),
                iva);
            classCompras.IngresarFacturaCompras();
        }

        public void Busqueda()
        {
            classCompras.Busqueda(combo_razon.SelectedValue.ToString().Trim(), combo_cliente.SelectedValue.ToString().Trim(), txt_serie.Text.Trim(), Convert.ToInt32(txt_factura.Text.Trim()));
            classCompras.BuscarFacturaCompras();
            txt_fecha.Text = classCompras.fecha.ToString();
            txt_tipo_doc.Text = classCompras.tipo_Doc;
            txt_monto.Text = classCompras.monto.ToString();
            txt_serie.Text = classCompras.serie;
            txt_factura.Text = classCompras.factura.ToString();
            combo_cliente.Text = classCompras.proveedor.ToString() + " - " + classCompras.nombreProveedor;
            txt_monto.Text = classCompras.monto.ToString("N2");
        }

        public void Eliminar()
        {
            classCompras.Busqueda(combo_razon.SelectedValue.ToString().Trim(), combo_cliente.SelectedValue.ToString().Trim(), txt_serie.Text.Trim(), Convert.ToInt32(txt_factura.Text.Trim()));
            classCompras.EliminarFacturaCompras();
        }

        public void Modificar()
        {
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            iva = Convert.ToDecimal(txt_monto.Text.Trim()) * Convert.ToDecimal(0.05);
            classCompras.NuevaFacturaCompra(
                combo_razon.SelectedValue.ToString().Trim(),
                fecha2,
                txt_tipo_doc.Text.Trim(),
                txt_serie.Text.Trim(),
                Convert.ToInt32(txt_factura.Text.Trim()),
                combo_cliente.SelectedValue.ToString().Trim(),
                Convert.ToDecimal(txt_monto.Text.Trim()),
                iva);
            classCompras.ModificarFacturaCompras();
        }

        public void CargarCombo()
        {
            combo_razon.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            combo_razon.DisplayMemberPath = "razon_social";
            combo_razon.SelectedValuePath = "nit";            
        }

        public void CargarComboProveedor()
        {
            combo_cliente.ItemsSource = classProveedor.Reporte().Tables[0].DefaultView;
            combo_cliente.DisplayMemberPath = "Proveedor";
            combo_cliente.SelectedValuePath = "nit";
        }
           
        #endregion

        #region Controles/Eventos

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            BloqueoTxt(true);
            BloqueoBtnGuardar(true);
            LimpiarTxt();
            txt_fecha.Focus();
            BloqueoBusquedaBtn(false);
            ModoBusqueda = false;
        }

        private void Btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        private void Btn_guardar_Click_1(object sender, RoutedEventArgs e)
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
                if (txt_fecha.Text != "" || txt_tipo_doc.Text != "" || txt_serie.Text != "" || txt_factura.Text != "" || combo_cliente.Text != "" || txt_monto.Text != "")
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
                        txt_serie.Focus();
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
                    BloqueoBusquedaTxt(true);
                    BloqueoBtnGuardar(false);
                    ModoBusqueda = true;
                    txt_serie.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txt_serie.Text == "" || txt_factura.Text == "" || combo_cliente.Text == "")
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

        private void Btn_contribuyentes_Click(object sender, RoutedEventArgs e)
        {
            string d = combo_razon.SelectedValue.ToString();
            classMensajes.MensajesCortos("NIT", d);
        }

        private void Combo_razon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_razon.SelectedIndex>=0)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VistaCompras();
        }

        private void Txt_serie_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionSeries(e);
        }

        private void Txt_fecha_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionFechas(e);
        }

        private void Txt_factura_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionNumeroDeFacturas(e);
        }

        private void btnReporteCompras_Click(object sender, RoutedEventArgs e)
        {
            vtnReportesCompras vtnReportesCompras = new vtnReportesCompras(combo_razon.SelectedValue.ToString(),combo_razon.Text);
            vtnReportesCompras.Show();
        }

        private void btnVistaCompras_Click(object sender, RoutedEventArgs e)
        {
            vtnVistasCompras vtnVistasCompras = new vtnVistasCompras();
            vtnVistasCompras.Show();
        }

        private void Txt_monto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validaciones.ValidacionMontos(e);            
        }

        #endregion

    }
}
