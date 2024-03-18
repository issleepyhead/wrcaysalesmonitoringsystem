﻿#pragma checksum "..\..\..\..\Dialogs\CategoryDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF12926B8EC52A62C64F3D385376E3C401A54CD9"
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


namespace WrcaySalesInventorySystem.Dialogs {
    
    
    /// <summary>
    /// CategoryDialog
    /// </summary>
    public partial class CategoryDialog : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Dialogs\CategoryDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Closebtn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Dialogs\CategoryDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CategoryNameError;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Dialogs\CategoryDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TextBox CategoryNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Dialogs\CategoryDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TextBox CategoryDescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Dialogs\CategoryDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteCategoryButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Dialogs\CategoryDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveCategoryButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WrcaySalesInventorySystem;component/dialogs/categorydialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Dialogs\CategoryDialog.xaml"
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
            this.Closebtn = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.CategoryNameError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.CategoryNameTextBox = ((HandyControl.Controls.TextBox)(target));
            
            #line 46 "..\..\..\..\Dialogs\CategoryDialog.xaml"
            this.CategoryNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CategoryDescriptionTextBox = ((HandyControl.Controls.TextBox)(target));
            return;
            case 5:
            this.DeleteCategoryButton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\Dialogs\CategoryDialog.xaml"
            this.DeleteCategoryButton.Click += new System.Windows.RoutedEventHandler(this.DeleteCategoryButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SaveCategoryButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\Dialogs\CategoryDialog.xaml"
            this.SaveCategoryButton.Click += new System.Windows.RoutedEventHandler(this.SaveCategoryButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

