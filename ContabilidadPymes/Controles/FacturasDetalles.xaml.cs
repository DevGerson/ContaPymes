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
        ClassFacturasDetalles classFacturasDetalles = new ClassFacturasDetalles();
        ClassFacturas classFacturas = new ClassFacturas();
        ClassContribuyente classContribuyente = new ClassContribuyente();
        bool ModoBusqueda;

        public FacturasDetalles()
        {
            InitializeComponent();
            CargarComboContribuyente();
        }

        #region Controles
        private void Btn_contribuyentes_Click(object sender, RoutedEventArgs e)
        {

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
            BloqueoBtnBusqueda(false);
            BloqueoBtnGuardar(true);
        }

        private void Btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        private void Btn2_guardar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            LimpiarTxt();
            Vista();            
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            LimpiarTxt();
            Vista();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            LimpiarTxt();
            Vista();

            BloqueoBtnGuardar(true);
            BloqueoBtnBusqueda(false);
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Modificar();
            LimpiarTxt();
            Vista();

            BloqueoBtnGuardar(true);
            BloqueoBtnBusqueda(false);
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
                        //Bloquea los textbox para resaltar los campos a ingresar
                        BloqueoTxt(false);
                        BloqueoTxtBusqueda(true);
                        LimpiarTxt();
                        //Variable para verificar si esta en modo busqueda y Bloqueo de Botones o Desbloqueo
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en Fecha
                        txtResolucion.Focus();
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
                        txtResolucion.Focus();
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

        private void Btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            Vista();
        }

        private void Btn_seriesRegistradas_Click(object sender, RoutedEventArgs e)
        {
            FacturaSeries facturaSeries = new FacturaSeries(int.Parse(combo_nit.SelectedValue.ToString()));
            facturaSeries.ShowDialog();
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

        public void Ingresar()
        {
            DateTime VigenciaOne, VigenciaTwo;
            DateTime CreacionOne, CreacionTwo;
            VigenciaOne = DateTime.Parse(txtVigencia.Text.Trim());
            VigenciaTwo = DateTime.Parse(VigenciaOne.ToString("yyyy/MM/dd"));
            CreacionOne = DateTime.Parse(txtCreacion.Text.Trim());
            CreacionTwo = DateTime.Parse(CreacionOne.ToString("yyyy/MM/dd"));

            classFacturasDetalles.ParametrosFacturas(int.Parse(combo_nit.SelectedValue.ToString()), txtTipo.Text.Trim(), int.Parse(txtCantidad.Text.Trim()), txtSerie.Text.Trim(), int.Parse(txtDel.Text.Trim()),
                int.Parse(txtAl.Text.Trim()), txtResolucion.Text.Trim(), CreacionTwo, VigenciaTwo, int.Parse(txtImprenta.Text.Trim()));
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

            classFacturasDetalles.ParametrosFacturas(int.Parse(combo_nit.SelectedValue.ToString()), txtTipo.Text.Trim(), int.Parse(txtCantidad.Text.Trim()), txtSerie.Text.Trim(), int.Parse(txtDel.Text.Trim()),
                int.Parse(txtAl.Text.Trim()), txtResolucion.Text.Trim(), CreacionTwo, VigenciaTwo, int.Parse(txtImprenta.Text.Trim()));
            classFacturasDetalles.Modificar();
        }

        public void Eliminar()
        {
            classFacturasDetalles.ParametrosBusqueda(int.Parse(combo_nit.SelectedValue.ToString()), txtResolucion.Text.Trim());
            classFacturasDetalles.Eliminar();
        }

        public void Buscar()
        {
            classFacturasDetalles.ParametrosBusqueda(int.Parse(combo_nit.SelectedValue.ToString()), txtResolucion.Text.Trim());
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
            classFacturas.ParametrosVista(int.Parse(combo_nit.SelectedValue.ToString()));
            txtTipo.ItemsSource = classFacturas.ListTipos().Tables[0].DefaultView;
            txtTipo.DisplayMemberPath = "tipo_doc";
            txtTipo.SelectedValuePath = "tipo_doc";
        }

        public void ListSeries()
        {
            classFacturas.ParametrosListSeries(int.Parse(combo_nit.SelectedValue.ToString()), txtTipo.Text);
            txtSerie.ItemsSource = classFacturas.ListSeries().Tables[0].DefaultView;
            txtSerie.DisplayMemberPath = "serie";
        }

        public void Vista()
        {
            classFacturasDetalles.ParametrosVista(int.Parse(combo_nit.SelectedValue.ToString()));
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classFacturasDetalles.Vista().Tables[0].DefaultView;
        }





        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListSeries();
        }
    }
}
