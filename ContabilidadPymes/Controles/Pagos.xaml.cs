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
    /// Lógica de interacción para Pagos.xaml
    /// </summary>
    public partial class Pagos : UserControl
    {
        ClassHonorarios classHonorarios = new ClassHonorarios();
        ClassContribuyente classContribuyente = new ClassContribuyente();
        ClassPagos classPagos = new ClassPagos();
        DateTime fecha, fecha2;
        bool ModoBusqueda = false;

        public Pagos()
        {
            InitializeComponent();
            CargarComboContribuyentes();
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            LimpiarTxt();
            txt_año.Focus();
            Vista();
        }

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
            ModoBusqueda = false;
            BloqueoBusquedaBtn(false);
            BloqueoBtnGuardar(true);
            txt_año.Focus();
        }

        private void Btn_limpieza_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTxt();
        }

        private void Btn_guardar2_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
            LimpiarTxt();
            txt_año.Focus();
            Vista();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            LimpiarTxt();
            BloqueoBusquedaBtn(false);
            BloqueoBtnGuardar(true);
            Vista();
        }

        private void Btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Modificar();
            LimpiarTxt();
            BloqueoBusquedaBtn(false);
            BloqueoBtnGuardar(true);
            Vista();
        }

        private void Btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            //Modo Busqueda en Falso
            if (ModoBusqueda == false)
            {
                //Verifica si esta vacios los campos
                if (txt_recibo.Text != "")
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
                        txt_recibo.Focus();
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
                        txt_recibo.Focus();
                    }
                }
                else
                {
                    //Si no hay ningun dato en campos, se pondra en modo Busqueda
                    BloqueoTxt(false);
                    BloqueoBusquedaTxt(true);
                    BloqueoBtnGuardar(false);
                    ModoBusqueda = true;
                    txt_recibo.Focus();
                }
            }
            else if (ModoBusqueda == true)
            {
                //Si el modo busqueda es true entonecs verificara si hay campos vacios
                if (txt_recibo.Text == "")
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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            Vista();
        }

        private void Combo_nit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            classHonorarios.ParametrosVista(Convert.ToInt32(combo_nit.SelectedValue.ToString()));
            if (classHonorarios.VerificarHonorario() == false)
            {
                LimpiarTxt();
                txt_honorario.Text = "Registra un monto de honorario";
                BloqueoBtn(false);
                BloqueoTxt(false);
                Vista();
            }
            else
            {
                classHonorarios.Buscar();
                txt_honorario.Text = classHonorarios.honorario.ToString();
                BloqueoBtn(true);
                BloqueoTxt(true);
                BloqueoBusquedaBtn(false);
                Vista();
            }
            
        }

        private void Txt_ventas_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal porcentaje, impuesto, ventas, multa, honorario, total;
            if (txt_ventas.Text != "")
            {
                porcentaje = Convert.ToDecimal(0.05);
                impuesto = decimal.Parse(txt_ventas.Text.Trim()) * porcentaje;
                txt_impuesto.Text = impuesto.ToString("N2");

                //Convertir en formato de moneda
                ventas = decimal.Parse(txt_ventas.Text.Trim());
                txt_ventas.Text = ventas.ToString("N2");                            
            }
            //Suma
            if (txt_impuesto.Text != "")
            {
                impuesto = decimal.Parse(txt_impuesto.Text.Trim());
            }
            else
            {
                impuesto = 0;
            }
            if (txt_multa.Text != "")
            {
                multa = decimal.Parse(txt_multa.Text.Trim());
            }
            else
            {
                multa = 0;
            }
            if (txt_honorarios_pago.Text != "")
            {
                honorario = decimal.Parse(txt_honorarios_pago.Text.Trim());
            }
            else
            {
                honorario = 0;
            }
            total = impuesto + multa + honorario;
            txt_total.Text = total.ToString("N2");
        }

        private void Txt_impuesto_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal impuesto_txt;
            decimal impuesto, multa, honorario, total;
            if (txt_impuesto.Text != "")
            {
                impuesto_txt = decimal.Parse(txt_impuesto.Text.Trim());
                txt_impuesto.Text = impuesto_txt.ToString("N2");
            }
            //Suma
            if (txt_impuesto.Text != "")
            {
                impuesto = decimal.Parse(txt_impuesto.Text.Trim());
            }
            else
            {
                impuesto = 0;
            }
            if (txt_multa.Text != "")
            {
                multa = decimal.Parse(txt_multa.Text.Trim());
            }
            else
            {
                multa = 0;
            }
            if (txt_honorarios_pago.Text != "")
            {
                honorario = decimal.Parse(txt_honorarios_pago.Text.Trim());
            }
            else
            {
                honorario = 0;
            }
            total = impuesto + multa + honorario;
            txt_total.Text = total.ToString("N2");
        }

        private void Txt_multa_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal multa_txt;
            decimal impuesto, multa, honorario, total;
            if (txt_multa.Text != "")
            {
                multa_txt = decimal.Parse(txt_multa.Text.Trim());
                txt_multa.Text = multa_txt.ToString("N2");
            }
            //Suma
            if (txt_impuesto.Text != "")
            {
                impuesto = decimal.Parse(txt_impuesto.Text.Trim());
            }
            else
            {
                impuesto = 0;
            }
            if (txt_multa.Text != "")
            {
                multa = decimal.Parse(txt_multa.Text.Trim());
            }
            else
            {
                multa = 0;
            }
            if (txt_honorarios_pago.Text != "")
            {
                honorario = decimal.Parse(txt_honorarios_pago.Text.Trim());
            }
            else
            {
                honorario = 0;
            }
            total = impuesto + multa + honorario;
            txt_total.Text = total.ToString("N2");
        }

        private void Txt_honorarios_pago_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal honorario_txt;
            decimal impuesto, multa, honorario, total;
            if (txt_honorario.Text != "")
            {
                honorario_txt = decimal.Parse(txt_honorarios_pago.Text.Trim());
                txt_honorarios_pago.Text = honorario_txt.ToString("N2");
            }
            //Suma
            if (txt_impuesto.Text != "")
            {
                impuesto = decimal.Parse(txt_impuesto.Text.Trim());
            }
            else
            {
                impuesto = 0;
            }
            if (txt_multa.Text != "")
            {
                multa = decimal.Parse(txt_multa.Text.Trim());
            }
            else
            {
                multa = 0;
            }
            if (txt_honorarios_pago.Text != "")
            {
                honorario = decimal.Parse(txt_honorarios_pago.Text.Trim());
            }
            else
            {
                honorario = 0;
            }
            total = impuesto + multa + honorario;
            txt_total.Text = total.ToString("N2");
        }



        public void Ingresar()
        {
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            classPagos.ParametrosPagos(Convert.ToInt32(combo_nit.SelectedValue.ToString()),Convert.ToInt32(txt_año.Text.Trim()),txt_mes.Text.Trim(),Convert.ToDecimal(txt_ventas.Text.Trim()),
                Convert.ToDecimal(txt_impuesto.Text.Trim()),Convert.ToDecimal(txt_multa.Text.Trim()),Convert.ToDecimal(txt_honorarios_pago.Text.Trim()),Convert.ToDecimal(txt_total.Text.Trim()),
                txt_recibo.Text.Trim(),fecha2);
            classPagos.Ingresar();
        }

        public void Modificar()
        {
            fecha = Convert.ToDateTime(txt_fecha.Text);
            fecha2 = Convert.ToDateTime(fecha.ToString("yyyy/MM/dd"));
            classPagos.ParametrosPagos(Convert.ToInt32(combo_nit.SelectedValue.ToString()), Convert.ToInt32(txt_año.Text.Trim()), txt_mes.Text.Trim(), Convert.ToDecimal(txt_ventas.Text.Trim()),
                Convert.ToDecimal(txt_impuesto.Text.Trim()), Convert.ToDecimal(txt_multa.Text.Trim()), Convert.ToDecimal(txt_honorarios_pago.Text.Trim()), Convert.ToDecimal(txt_total.Text.Trim()),
                txt_recibo.Text.Trim(), fecha2);
            classPagos.Modificar();
        }

        public void Eliminar()
        {
            classPagos.ParametrosBusqueda(Convert.ToInt32(combo_nit.SelectedValue.ToString()),txt_recibo.Text.Trim());
            classPagos.Eliminar();
        }

        public void Buscar()
        {
            classPagos.ParametrosBusqueda(Convert.ToInt32(combo_nit.SelectedValue.ToString()), txt_recibo.Text.Trim());
            classPagos.Buscar();

            txt_año.Text = classPagos.año.ToString();
            txt_mes.Text = classPagos.mes   ;
            txt_ventas.Text = classPagos.ventas.ToString();
            txt_impuesto.Text = classPagos.impuesto.ToString();
            txt_multa.Text = classPagos.multa.ToString();
            txt_honorarios_pago.Text = classPagos.honorarios.ToString();
            txt_total.Text = classPagos.total.ToString();
            txt_fecha.Text = classPagos.fecha.ToString();
            txt_recibo.Text = classPagos.recibo;
        }

        public void Vista()
        {
            classPagos.ParametrosVista(Convert.ToInt32(combo_nit.SelectedValue.ToString()));
            VistaData.ItemsSource = null;
            VistaData.ItemsSource = classPagos.Vista().Tables[0].DefaultView;
        }

        public void CargarComboContribuyentes()
        {
            combo_nit.ItemsSource = classContribuyente.Reporte().Tables[0].DefaultView;
            combo_nit.DisplayMemberPath = "razon_social";
            combo_nit.SelectedValuePath = "nit";
        }

        public void LimpiarTxt()
        {
            txt_año.Text = "";
            txt_mes.Text = "";
            txt_ventas.Text = "";
            txt_impuesto.Text = "";
            txt_multa.Text = "";
            txt_honorarios_pago.Text = "";
            txt_total.Text = "";
            txt_fecha.Text = "";
            txt_recibo.Text = "";
        }

        public void BloqueoTxt(bool Estado)
        {
            txt_año.IsEnabled = Estado;
            txt_mes.IsEnabled = Estado;
            txt_ventas.IsEnabled = Estado;
            txt_impuesto.IsEnabled = Estado;
            txt_multa.IsEnabled = Estado;
            txt_honorarios_pago.IsEnabled = Estado;
            txt_total.IsEnabled = Estado;
            txt_fecha.IsEnabled = Estado;
            txt_recibo.IsEnabled = Estado;
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
            btn_refresh.IsEnabled = Estado;            
        }

        public void BloqueoBtnGuardar(bool Estado)
        {
            btn_guardar.IsEnabled = Estado;
            btn_guardar2.IsEnabled = Estado;
        }

        public void BloqueoBusquedaBtn(bool Estado)
        {
            btn_eliminar.IsEnabled = Estado;
            btn_editar.IsEnabled = Estado;
        }

        public void BloqueoBusquedaTxt(bool Estado)
        {
            txt_recibo.IsEnabled = Estado;
        }
    }
}
