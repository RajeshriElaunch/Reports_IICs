﻿#pragma checksum "..\..\..\..\..\Pages\Plantillas\ControlesParametros\Param_DividendosCobrados.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A97443DD294FC28A085D79EA8903DB6B0F0A6096"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Reports_IICs.Pages.Plantillas.ControlesParametros;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace Reports_IICs.Pages.Plantillas.ControlesParametros {
    
    
    /// <summary>
    /// Param_DividendosCobrados
    /// </summary>
    public partial class Param_DividendosCobrados : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\Pages\Plantillas\ControlesParametros\Param_DividendosCobrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\..\Pages\Plantillas\ControlesParametros\Param_DividendosCobrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox Isin;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\Pages\Plantillas\ControlesParametros\Param_DividendosCobrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFechaUltimaReunion;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Pages\Plantillas\ControlesParametros\Param_DividendosCobrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DpFechaUltimaReunion;
        
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
            System.Uri resourceLocater = new System.Uri("/Reports_IICs;component/pages/plantillas/controlesparametros/param_dividendoscobr" +
                    "ados.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Plantillas\ControlesParametros\Param_DividendosCobrados.xaml"
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
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Isin = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.lblFechaUltimaReunion = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.DpFechaUltimaReunion = ((System.Windows.Controls.DatePicker)(target));
            
            #line 26 "..\..\..\..\..\Pages\Plantillas\ControlesParametros\Param_DividendosCobrados.xaml"
            this.DpFechaUltimaReunion.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

