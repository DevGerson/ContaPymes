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
    /// Lógica de interacción para Impuesto.xaml
    /// </summary>
    public partial class Impuesto : UserControl
    {
        ClassContribuyente classContribuyente = new ClassContribuyente();
        ClassImpuestos classImpuestos = new ClassImpuestos();
        bool ModoBusqueda = false;

        public Impuesto()
        {
            InitializeComponent();
            CargarComboContribuyentes();
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            LimpiarTxt();
            Vista();
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
            Ingresar();
            LimpiarTxt();
            Vista();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            LimpiarTxt();
            Vista();
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Modificar();
            LimpiarTxt();
            Vista();
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
                        //Variable para verificar si esta en modo busqueda y Bloqueo de Botones o Desbloqueo
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en Fecha
                        txt_formulario.Focus();
                    }
                    else if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        //Ingresa los datos
                        Ingresar();
                        LimpiarTxt();
                        //Bloquea los textbox para resaltar los campos a ingresar
                        BloqueoTxt(false);
                        BloqueoBusquedaTxt(true);
                        //Variable para verificar si esta en modo busqueda y Bloqueo de Botones o Desbloqueo
                        BloqueoBtnGuardar(false);
                        ModoBusqueda = true;
                        //Focus en fecha
                        txt_formulario.Focus();
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
                }
                else
                {
                    ModoBusqueda = false;
                    Buscar();
                    BloqueoTxt(true);
                    BloqueoBtnGuardar(false);
                    BloqueoBusquedaBtn(true);
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


        public void Ingresar()
        {
            if (txt_ventas.Text=="" || txt_impuesto.Text=="" || txt_multa.Text=="" || txt_formulario.Text=="" || txt_acceso.Text=="")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                classImpuestos.ParametrosImpuestos(Convert.ToInt32(combo_nit.SelectedValue.ToString()), Convert.ToDecimal(txt_ventas.Text.Trim()), Convert.ToDecimal(txt_impuesto.Text.Trim()),
                Convert.ToDecimal(txt_multa.Text.Trim()), txt_formulario.Text.Trim(), txt_acceso.Text.Trim());
                classImpuestos.IngresarImpuesto();
            }

        }


        public void Modificar()
        {
            if (txt_ventas.Text == "" || txt_impuesto.Text == "" || txt_multa.Text == "" || txt_formulario.Text == "" || txt_acceso.Text == "")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                classImpuestos.ParametrosImpuestos(Convert.ToInt32(combo_nit.SelectedValue.ToString()), Convert.ToDecimal(txt_ventas.Text.Trim()), Convert.ToDecimal(txt_impuesto.Text.Trim()),
                    Convert.ToDecimal(txt_multa.Text.Trim()), txt_formulario.Text.Trim(), txt_acceso.Text.Trim());
                classImpuestos.ModificarImpuesto();
            }
        }


        public void Eliminar()
        {
            if(txt_formulario.Text == "")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                classImpuestos.ParametrosBusqueda(Convert.ToInt32(combo_nit.SelectedValue.ToString()), txt_formulario.Text.Trim());
                classImpuestos.EliminarImpuesto();
            }
        }

        public void Buscar()
        {
            if (txt_formulario.Text!="")
            {
                classImpuestos.ParametrosBusqueda(Convert.ToInt32(combo_nit.SelectedValue.ToString()), txt_formulario.Text.Trim());
                classImpuestos.BuscarImpuesto();

                txt_ventas.Text = classImpuestos.ventas.ToString();
                txt_impuesto.Text = classImpuestos.impuesto.ToString();
                txt_multa.Text = classImpuestos.multas.ToString();
                txt_formulario.Text = classImpuestos.formulario;
                txt_acceso.Text = classImpuestos.acceso;
            }
            else
            {
                MessageBox.Show("Campos Vacios");
            }

        }

        public void Vista()
        {
            if (combo_nit.Text=="")
            {
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                classImpuestos.ParametrosVista(Convert.ToInt32(combo_nit.SelectedValue.ToString()));
                VistaData.ItemsSource = null;
                VistaData.ItemsSource = classImpuestos.Vista().Tables[0].DefaultView;
            }           
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
    }
}
