﻿#pragma checksum "..\..\..\..\Pages\Informes\ShowError.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EF60180EC4ADAD9C8F49484C67CAFE41D9EB8E69"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using Reports_IICs.Pages.Informes;
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


namespace Reports_IICs.Pages.Informes {
    
    
    /// <summary>
    /// ShowError
    /// </summary>
    public partial class ShowError : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Pages\Informes\ShowError.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBox_Error_descript;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\Informes\ShowError.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_header_error;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Pages\Informes\ShowError.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Export;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Pages\Informes\ShowError.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_CopyClip;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Pages\Informes\ShowError.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_OK;
        
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
            System.Uri resourceLocater = new System.Uri("/Reports_IICs;component/pages/informes/showerror.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Informes\ShowError.xaml"
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
            this.TBox_Error_descript = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.lbl_header_error = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btn_Export = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Pages\Informes\ShowError.xaml"
            this.btn_Export.Click += new System.Windows.RoutedEventHandler(this.btn_Export_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_CopyClip = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Pages\Informes\ShowError.xaml"
            this.btn_CopyClip.Click += new System.Windows.RoutedEventHandler(this.btn_CopyClip_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_OK = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

