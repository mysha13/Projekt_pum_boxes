﻿#pragma checksum "..\..\..\View\FindItem.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78FA7B917C26B6F476767345BC3744FDA3BFF5A5"
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
    /// FindItem
    /// </summary>
    public partial class FindItem : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\View\FindItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNameFindItem;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\FindItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridBoxesListFindItem;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\View\FindItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelFindItem;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\View\FindItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGotoFindItem;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\FindItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageAddPhoto;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\FindItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSerachFindItem;
        
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
            System.Uri resourceLocater = new System.Uri("/boxitem;component/view/finditem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\FindItem.xaml"
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
            this.tbNameFindItem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.datagridBoxesListFindItem = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btnCancelFindItem = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\View\FindItem.xaml"
            this.btnCancelFindItem.Click += new System.Windows.RoutedEventHandler(this.btnCancelFindItem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnGotoFindItem = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\View\FindItem.xaml"
            this.btnGotoFindItem.Click += new System.Windows.RoutedEventHandler(this.btnGotoFindItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.imageAddPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.btnSerachFindItem = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\View\FindItem.xaml"
            this.btnSerachFindItem.Click += new System.Windows.RoutedEventHandler(this.btnSerachFindItem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

