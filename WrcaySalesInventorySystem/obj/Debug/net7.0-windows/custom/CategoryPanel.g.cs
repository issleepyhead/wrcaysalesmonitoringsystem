﻿#pragma checksum "..\..\..\..\Custom\CategoryPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EB3956FEA02CE97FC04D9ADCE27070387B544682"
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
    /// CategoryPanel
    /// </summary>
    public partial class CategoryPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Custom\CategoryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.SearchBar CategorySearch;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Custom\CategoryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.Pagination Pagination;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Custom\CategoryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Custom\CategoryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CategoriesDataGridView;
        
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
            System.Uri resourceLocater = new System.Uri("/WrcaySalesInventorySystem;component/custom/categorypanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Custom\CategoryPanel.xaml"
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
            this.CategorySearch = ((HandyControl.Controls.SearchBar)(target));
            
            #line 25 "..\..\..\..\Custom\CategoryPanel.xaml"
            this.CategorySearch.SearchStarted += new System.EventHandler<HandyControl.Data.FunctionEventArgs<string>>(this.CategorySearch_SearchStarted);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Pagination = ((HandyControl.Controls.Pagination)(target));
            
            #line 34 "..\..\..\..\Custom\CategoryPanel.xaml"
            this.Pagination.PageUpdated += new System.EventHandler<HandyControl.Data.FunctionEventArgs<int>>(this.Pagination_PageUpdated);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\Custom\CategoryPanel.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CategoriesDataGridView = ((System.Windows.Controls.DataGrid)(target));
            
            #line 60 "..\..\..\..\Custom\CategoryPanel.xaml"
            this.CategoriesDataGridView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CategoriesDataGridView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

