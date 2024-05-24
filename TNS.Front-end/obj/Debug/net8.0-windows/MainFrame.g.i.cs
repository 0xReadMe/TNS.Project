﻿#pragma checksum "..\..\..\MainFrame.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44003E74B132B6E055F85F15D63FCDEB6B2A3A48"
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
using TNS.Front_end;


namespace TNS.Front_end {
    
    
    /// <summary>
    /// MainFrame
    /// </summary>
    public partial class MainFrame : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel btnStack;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ActiveBtn;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InactiveBtn;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ServicesBtn;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BillBtn;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ContractNumberBtn;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FullNameBtn;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid membersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBSort;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TNS.Front-end;V1.0.0.0;component/mainframe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainFrame.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ToolBar = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\MainFrame.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.addButton = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.btnStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.ActiveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\MainFrame.xaml"
            this.ActiveBtn.Click += new System.Windows.RoutedEventHandler(this.ActiveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.InactiveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\MainFrame.xaml"
            this.InactiveBtn.Click += new System.Windows.RoutedEventHandler(this.InactiveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ServicesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\MainFrame.xaml"
            this.ServicesBtn.Click += new System.Windows.RoutedEventHandler(this.ServicesBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BillBtn = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\MainFrame.xaml"
            this.BillBtn.Click += new System.Windows.RoutedEventHandler(this.BillBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ContractNumberBtn = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\MainFrame.xaml"
            this.ContractNumberBtn.Click += new System.Windows.RoutedEventHandler(this.ContractNumberBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.FullNameBtn = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\MainFrame.xaml"
            this.FullNameBtn.Click += new System.Windows.RoutedEventHandler(this.FullNameBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 120 "..\..\..\MainFrame.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RefreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.membersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.CBSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 239 "..\..\..\MainFrame.xaml"
            this.CBSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

