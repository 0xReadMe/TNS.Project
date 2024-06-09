﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5076A04AF2897C28A4D4EEE355CE992CDFB5C73D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace TNS.Front_end {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image MinimizedBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid sidePanel;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ContentFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TNS.Front-end;V1.0.0.0;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
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
            
            #line 27 "..\..\..\MainWindow.xaml"
            this.MinimizedBtn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown_Minimized);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CloseBtn = ((System.Windows.Controls.Image)(target));
            
            #line 42 "..\..\..\MainWindow.xaml"
            this.CloseBtn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown_Close);
            
            #line default
            #line hidden
            return;
            case 4:
            this.sidePanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            
            #line 70 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListView)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListView_MouseEnter);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListView)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.ListView_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 72 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Profile_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 81 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Abonentter_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 91 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Equipment_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 101 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CRM_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 111 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Employee_MouseDown);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 122 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Help_MouseDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ContentFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

