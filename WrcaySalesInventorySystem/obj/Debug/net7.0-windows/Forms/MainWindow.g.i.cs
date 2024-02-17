﻿#pragma checksum "..\..\..\..\Forms\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C3E6844FDAC560A50990D2F85D926FF25F807D6"
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
using WrcaySalesInventorySystem;
using WrcaySalesInventorySystem.ViewModel;
using WrcaySalesInventorySystem.custom;


namespace WrcaySalesInventorySystem {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.ContextMenuButton SettingsButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu SettingsMenu;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem AboutButtonItem;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem UpdateButtonItem;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.SideMenu SideMenuLeft;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.SideMenuItem SettingsViewButton;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.AccountPanel AccountPanel;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.AuditTrailPanel AuditTralPanel;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.CategoryPanel CategoryPanel;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.DeliveryPanel DeliveryPanel;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.InventoryPanel InventoryPanel;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.ProductsPanel ProductsPanel;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.SupplierPanel SupplierPanel;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\Forms\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WrcaySalesInventorySystem.custom.TransactionPanel TransactionPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/WrcaySalesInventorySystem;V1.0.0.0;component/forms/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.SettingsButton = ((HandyControl.Controls.ContextMenuButton)(target));
            return;
            case 2:
            this.SettingsMenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 3:
            this.AboutButtonItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 4:
            this.UpdateButtonItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 5:
            this.SideMenuLeft = ((HandyControl.Controls.SideMenu)(target));
            return;
            case 6:
            
            #line 44 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 54 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 59 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 64 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 69 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 74 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 81 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 101 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 106 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 117 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 122 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 127 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 18:
            this.SettingsViewButton = ((HandyControl.Controls.SideMenuItem)(target));
            return;
            case 19:
            
            #line 138 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 143 "..\..\..\..\Forms\MainWindow.xaml"
            ((HandyControl.Controls.SideMenuItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SelectedPanel);
            
            #line default
            #line hidden
            return;
            case 21:
            this.AccountPanel = ((WrcaySalesInventorySystem.custom.AccountPanel)(target));
            return;
            case 22:
            this.AuditTralPanel = ((WrcaySalesInventorySystem.custom.AuditTrailPanel)(target));
            return;
            case 23:
            this.CategoryPanel = ((WrcaySalesInventorySystem.custom.CategoryPanel)(target));
            return;
            case 24:
            this.DeliveryPanel = ((WrcaySalesInventorySystem.custom.DeliveryPanel)(target));
            return;
            case 25:
            this.InventoryPanel = ((WrcaySalesInventorySystem.custom.InventoryPanel)(target));
            return;
            case 26:
            this.ProductsPanel = ((WrcaySalesInventorySystem.custom.ProductsPanel)(target));
            return;
            case 27:
            this.SupplierPanel = ((WrcaySalesInventorySystem.custom.SupplierPanel)(target));
            return;
            case 28:
            this.TransactionPanel = ((WrcaySalesInventorySystem.custom.TransactionPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

