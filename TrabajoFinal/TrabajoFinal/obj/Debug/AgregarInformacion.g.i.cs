﻿#pragma checksum "..\..\AgregarInformacion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "208E7245447E276E902FBD028772EDEF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
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
using TrabajoFinal;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace TrabajoFinal {
    
    
    /// <summary>
    /// AgregarInformacion
    /// </summary>
    public partial class AgregarInformacion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\AgregarInformacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSeleccionarArchivo;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AgregarInformacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.IntegerUpDown nudPorcIncremento;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AgregarInformacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGuardar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AgregarInformacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtProveedor;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AgregarInformacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DataGridView dgvProductos;
        
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
            System.Uri resourceLocater = new System.Uri("/TrabajoFinal;component/agregarinformacion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AgregarInformacion.xaml"
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
            this.btnSeleccionarArchivo = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\AgregarInformacion.xaml"
            this.btnSeleccionarArchivo.Click += new System.Windows.RoutedEventHandler(this.btnSeleccionarArchivo_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nudPorcIncremento = ((Xceed.Wpf.Toolkit.IntegerUpDown)(target));
            return;
            case 3:
            this.btnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\AgregarInformacion.xaml"
            this.btnGuardar.Click += new System.Windows.RoutedEventHandler(this.btnGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtProveedor = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.dgvProductos = ((System.Windows.Forms.DataGridView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

