﻿#pragma checksum "..\..\..\..\Custom\CategoriesPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FD5F0002A9DAA20B6202D59EF862E331755B3807"
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
    /// CategoriesPanel
    /// </summary>
    public partial class CategoriesPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Custom\CategoriesPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TabControl TabControlContainer;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Custom\CategoriesPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TabItem CategoryTab;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Custom\CategoriesPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.CategoryPanel CategoryPanel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Custom\CategoriesPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TabItem SubCategoryTab;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Custom\CategoriesPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.SubCategory SubCategoryPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/WrcaySalesInventorySystem;component/custom/categoriespanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Custom\CategoriesPanel.xaml"
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
            this.TabControlContainer = ((HandyControl.Controls.TabControl)(target));
            return;
            case 2:
            this.CategoryTab = ((HandyControl.Controls.TabItem)(target));
            return;
            case 3:
            this.CategoryPanel = ((WrcaySalesInventorySystem.custom.CategoryPanel)(target));
            return;
            case 4:
            this.SubCategoryTab = ((HandyControl.Controls.TabItem)(target));
            return;
            case 5:
            this.SubCategoryPanel = ((WrcaySalesInventorySystem.custom.SubCategory)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

