﻿#pragma checksum "..\..\..\Controles\Ventas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F5516D7E3DD25A897C86073CAF375899C5910FD0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ContabilidadPymes.Controles;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RootLibrary.WPF.Localization;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ContabilidadPymes.Controles {
    
    
    /// <summary>
    /// Ventas
    /// </summary>
    public partial class Ventas : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_nuevo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_limpiar;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_guardar2;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_eliminar;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_editar;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_buscar;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_actualizar;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVista;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReporte;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_razon;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_contribuyentes;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txt_fecha;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txt_tipoDoc;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_serie;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_factura;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_cliente;
        
        #line default
        #line hidden
        
        
        #line 266 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Monto;
        
        #line default
        #line hidden
        
        
        #line 288 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton txt_Exento;
        
        #line default
        #line hidden
        
        
        #line 303 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_guardar;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\..\Controles\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid VistaVentas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ContabilidadPymes;component/controles/ventas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controles\Ventas.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_nuevo = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Controles\Ventas.xaml"
            this.btn_nuevo.Click += new System.Windows.RoutedEventHandler(this.Btn_nuevo_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_limpiar = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Controles\Ventas.xaml"
            this.btn_limpiar.Click += new System.Windows.RoutedEventHandler(this.Btn_limpiar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_guardar2 = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Controles\Ventas.xaml"
            this.btn_guardar2.Click += new System.Windows.RoutedEventHandler(this.Btn_guardar2_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_eliminar = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Controles\Ventas.xaml"
            this.btn_eliminar.Click += new System.Windows.RoutedEventHandler(this.Btn_eliminar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_editar = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Controles\Ventas.xaml"
            this.btn_editar.Click += new System.Windows.RoutedEventHandler(this.Btn_editar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_buscar = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\Controles\Ventas.xaml"
            this.btn_buscar.Click += new System.Windows.RoutedEventHandler(this.Buscar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_actualizar = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Controles\Ventas.xaml"
            this.btn_actualizar.Click += new System.Windows.RoutedEventHandler(this.Btn_actualizar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnVista = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\Controles\Ventas.xaml"
            this.btnVista.Click += new System.Windows.RoutedEventHandler(this.BtnVista_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnReporte = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\Controles\Ventas.xaml"
            this.btnReporte.Click += new System.Windows.RoutedEventHandler(this.BtnReporte_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.combo_razon = ((System.Windows.Controls.ComboBox)(target));
            
            #line 135 "..\..\..\Controles\Ventas.xaml"
            this.combo_razon.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combo_razon_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btn_contribuyentes = ((System.Windows.Controls.Button)(target));
            
            #line 148 "..\..\..\Controles\Ventas.xaml"
            this.btn_contribuyentes.Click += new System.Windows.RoutedEventHandler(this.Btn_contribuyentes_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.txt_fecha = ((System.Windows.Controls.DatePicker)(target));
            
            #line 182 "..\..\..\Controles\Ventas.xaml"
            this.txt_fecha.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_fecha_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 13:
            this.txt_tipoDoc = ((System.Windows.Controls.ComboBox)(target));
            
            #line 193 "..\..\..\Controles\Ventas.xaml"
            this.txt_tipoDoc.LostFocus += new System.Windows.RoutedEventHandler(this.Txt_tipoDoc_LostFocus);
            
            #line default
            #line hidden
            return;
            case 14:
            this.combo_serie = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.txt_factura = ((System.Windows.Controls.TextBox)(target));
            
            #line 229 "..\..\..\Controles\Ventas.xaml"
            this.txt_factura.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_factura_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 16:
            this.combo_cliente = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 17:
            this.txt_Monto = ((System.Windows.Controls.TextBox)(target));
            
            #line 263 "..\..\..\Controles\Ventas.xaml"
            this.txt_Monto.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_Monto_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 18:
            this.txt_Exento = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 19:
            this.btn_guardar = ((System.Windows.Controls.Button)(target));
            
            #line 304 "..\..\..\Controles\Ventas.xaml"
            this.btn_guardar.Click += new System.Windows.RoutedEventHandler(this.Btn_guardar_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.VistaVentas = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

