﻿#pragma checksum "..\..\..\View\AddItem.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56663A9C40CF43907CC97F5121C855CF702F4F50"
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
    /// AddItem
    /// </summary>
    public partial class AddItem : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\View\AddItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNameAddItem;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\View\AddItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNumberAddItem;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\View\AddItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDescriptionAddItem;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\View\AddItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelAddItem;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View\AddItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOkAddItem;
        
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
            System.Uri resourceLocater = new System.Uri("/boxitem;component/view/additem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AddItem.xaml"
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
            this.tbNameAddItem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbNumberAddItem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbDescriptionAddItem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnCancelAddItem = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\View\AddItem.xaml"
            this.btnCancelAddItem.Click += new System.Windows.RoutedEventHandler(this.btnCancelAddItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnOkAddItem = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\View\AddItem.xaml"
            this.btnOkAddItem.Click += new System.Windows.RoutedEventHandler(this.btnOkAddItem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

