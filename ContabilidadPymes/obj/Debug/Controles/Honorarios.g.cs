﻿#pragma checksum "..\..\..\Controles\Honorarios.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1BF96838C1C99FAF7A1993B6E467532F58EC9D77"
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
    /// Honorarios
    /// </summary>
    public partial class Honorarios : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_guardar2;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_eliminar;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_editar;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_refrescar;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVista;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReporte;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_nit;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_contribuyentes;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_honorario;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_guardar;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\Controles\Honorarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid VistaData;
        
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
            System.Uri resourceLocater = new System.Uri("/ContabilidadPymes;component/controles/honorarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controles\Honorarios.xaml"
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
            this.btn_guardar2 = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Controles\Honorarios.xaml"
            this.btn_guardar2.Click += new System.Windows.RoutedEventHandler(this.Btn_guardar2_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_eliminar = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Controles\Honorarios.xaml"
            this.btn_eliminar.Click += new System.Windows.RoutedEventHandler(this.Btn_eliminar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_editar = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Controles\Honorarios.xaml"
            this.btn_editar.Click += new System.Windows.RoutedEventHandler(this.Btn_editar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_refrescar = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Controles\Honorarios.xaml"
            this.btn_refrescar.Click += new System.Windows.RoutedEventHandler(this.Btn_refresh_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnVista = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Controles\Honorarios.xaml"
            this.btnVista.Click += new System.Windows.RoutedEventHandler(this.BtnVista_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnReporte = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Controles\Honorarios.xaml"
            this.btnReporte.Click += new System.Windows.RoutedEventHandler(this.BtnReporte_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.combo_nit = ((System.Windows.Controls.ComboBox)(target));
            
            #line 98 "..\..\..\Controles\Honorarios.xaml"
            this.combo_nit.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combo_nit_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_contribuyentes = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\Controles\Honorarios.xaml"
            this.btn_contribuyentes.Click += new System.Windows.RoutedEventHandler(this.Btn_contribuyentes_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txt_honorario = ((System.Windows.Controls.TextBox)(target));
            
            #line 133 "..\..\..\Controles\Honorarios.xaml"
            this.txt_honorario.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_honorario_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_guardar = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\..\Controles\Honorarios.xaml"
            this.btn_guardar.Click += new System.Windows.RoutedEventHandler(this.Btn_guardar_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.VistaData = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

