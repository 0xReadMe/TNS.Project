﻿#pragma checksum "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0C05A62EA354DB3BC38D9860CEE9672A09AF1725"
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
using TNS.Front_end.Employee;


namespace TNS.Front_end.Employee {
    
    
    /// <summary>
    /// EditEmployee
    /// </summary>
    public partial class EditEmployee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image MinimizedBtn;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFullName;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPosition;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPhone;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEmail;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker tbDOB;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPassword;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTelegramm;
        
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
            System.Uri resourceLocater = new System.Uri("/TNS.Front-end;component/employee/actions/editemployee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
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
            this.MinimizedBtn = ((System.Windows.Controls.Image)(target));
            
            #line 33 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
            this.MinimizedBtn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown_Minimized);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CloseBtn = ((System.Windows.Controls.Image)(target));
            
            #line 48 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
            this.CloseBtn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown_Close);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbFullName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbPosition = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.tbPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbDOB = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.tbPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbTelegramm = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 85 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 86 "..\..\..\..\..\EMPLOYEE\ACTIONS\EditEmployee.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

