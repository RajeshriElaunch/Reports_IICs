﻿#pragma checksum "..\..\..\..\..\Pages\Previews\RentaFija\RentaFija_UC_Small.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9EF99871C2D562E3269AC145AD74FCDCE55C1396"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Reports_IICs.Pages.Previews.RentaFija;
using Reports_IICs.ViewModels.Instrumentos;
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
using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Behaviors;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RadialMenu;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Controls.Wizard;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Shapes;


namespace Reports_IICs.Pages.Previews.RentaFija {
    
    
    /// <summary>
    /// RentaFija_UC_Small
    /// </summary>
    public partial class RentaFija_UC_Small : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\Pages\Previews\RentaFija\RentaFija_UC_Small.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTitulo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Pages\Previews\RentaFija\RentaFija_UC_Small.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView myGrid;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Pages\Previews\RentaFija\RentaFija_UC_Small.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.GridViewMaskedInputColumn PosicionCartera;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Pages\Previews\RentaFija\RentaFija_UC_Small.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.GridViewMaskedInputColumn PosicionesCerradas;
        
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
            System.Uri resourceLocater = new System.Uri("/Reports_IICs;component/pages/previews/rentafija/rentafija_uc_small.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Previews\RentaFija\RentaFija_UC_Small.xaml"
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
            this.LabelTitulo = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.myGrid = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 39 "..\..\..\..\..\Pages\Previews\RentaFija\RentaFija_UC_Small.xaml"
            this.myGrid.CellEditEnded += new System.EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(this.myGrid_CellEditEnded);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\..\..\Pages\Previews\RentaFija\RentaFija_UC_Small.xaml"
            this.myGrid.DataLoaded += new System.EventHandler<System.EventArgs>(this.myGrid_DataLoaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PosicionCartera = ((Telerik.Windows.Controls.GridViewMaskedInputColumn)(target));
            return;
            case 4:
            this.PosicionesCerradas = ((Telerik.Windows.Controls.GridViewMaskedInputColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

