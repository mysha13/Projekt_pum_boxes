﻿#pragma checksum "..\..\Items.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A459323617AB40F32671B819361540117A6C76CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using boxitem;


namespace boxitem {
    
    
    /// <summary>
    /// Items
    /// </summary>
    public partial class Items : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefreshItems;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelItems;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridItems;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddItems;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteItems;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageItems;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddPhotoItems;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeletePhotoItems;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMoveItems;
        
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
            System.Uri resourceLocater = new System.Uri("/boxitem;component/items.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Items.xaml"
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
            this.btnRefreshItems = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.btnCancelItems = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.datagridItems = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btnAddItems = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.btnDeleteItems = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.imageItems = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.btnAddPhotoItems = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnDeletePhotoItems = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnMoveItems = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
