﻿#pragma checksum "..\..\..\..\..\Pages\Previews\Indice Preconfigurado NOVAREX\IndicePreconfiguradoNovarex_UC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ED396CE1A83BB2FBF4C17A486BE3D4E0CF66716"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Reports_IICs.Pages.Previews.Indice_Preconfigurado_NOVAREX;
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Behaviors;
using Telerik.Windows.Controls.Carousel;
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


namespace Reports_IICs.Pages.Previews.Indice_Preconfigurado_NOVAREX {
    
    
    /// <summary>
    /// IndicePreconfiguradoNovarex_UC
    /// </summary>
    public partial class IndicePreconfiguradoNovarex_UC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\..\Pages\Previews\Indice Preconfigurado NOVAREX\IndicePreconfiguradoNovarex_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView myGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Reports_IICs;component/pages/previews/indice%20preconfigurado%20novarex/indicepr" +
                    "econfiguradonovarex_uc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Previews\Indice Preconfigurado NOVAREX\IndicePreconfiguradoNovarex_UC.xaml"
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
            this.myGrid = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 17 "..\..\..\..\..\Pages\Previews\Indice Preconfigurado NOVAREX\IndicePreconfiguradoNovarex_UC.xaml"
            this.myGrid.CellEditEnded += new System.EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(this.myGrid_CellEditEnded);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\..\Pages\Previews\Indice Preconfigurado NOVAREX\IndicePreconfiguradoNovarex_UC.xaml"
            this.myGrid.DataLoaded += new System.EventHandler<System.EventArgs>(this.myGrid_DataLoaded);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\..\Pages\Previews\Indice Preconfigurado NOVAREX\IndicePreconfiguradoNovarex_UC.xaml"
            this.myGrid.RowLoaded += new System.EventHandler<Telerik.Windows.Controls.GridView.RowLoadedEventArgs>(this.myGrid_RowLoaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

