﻿#pragma checksum "..\..\..\..\Custom\DeliveryPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8399AAF31CE3B54A510CC1F872741D1991F1EB74"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WrcaySalesInventorySystem.custom;


namespace WrcaySalesInventorySystem.custom {
    
    
    /// <summary>
    /// DeliveryPanel
    /// </summary>
    public partial class DeliveryPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Custom\DeliveryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.SearchBar SearchDelivery;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Custom\DeliveryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.Pagination Pagination;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Custom\DeliveryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeliveryAddDeliveryButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Custom\DeliveryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DeliveryDataGridView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WrcaySalesInventorySystem;component/custom/deliverypanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Custom\DeliveryPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SearchDelivery = ((HandyControl.Controls.SearchBar)(target));
            return;
            case 2:
            this.Pagination = ((HandyControl.Controls.Pagination)(target));
            
            #line 32 "..\..\..\..\Custom\DeliveryPanel.xaml"
            this.Pagination.PageUpdated += new System.EventHandler<HandyControl.Data.FunctionEventArgs<int>>(this.Pagination_PageUpdated);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeliveryAddDeliveryButton = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Custom\DeliveryPanel.xaml"
            this.DeliveryAddDeliveryButton.Click += new System.Windows.RoutedEventHandler(this.DeliveryAddDeliveryButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeliveryDataGridView = ((System.Windows.Controls.DataGrid)(target));
            
            #line 59 "..\..\..\..\Custom\DeliveryPanel.xaml"
            this.DeliveryDataGridView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DeliveryDataGridView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

