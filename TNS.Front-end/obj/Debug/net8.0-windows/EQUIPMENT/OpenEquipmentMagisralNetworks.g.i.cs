﻿#pragma checksum "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A59EAEB38314F081AA14111E5EFEF182190C1909"
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
using TNS.Front_end.EQUIPMENT;


namespace TNS.Front_end.EQUIPMENT {
    
    
    /// <summary>
    /// OpenEquipmentMagisralNetworks
    /// </summary>
    public partial class OpenEquipmentMagisralNetworks : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image MinimizedBtn;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFrequency;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCoefficien;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDTT;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAddress;
        
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
            System.Uri resourceLocater = new System.Uri("/TNS.Front-end;component/equipment/openequipmentmagisralnetworks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
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
            
            #line 31 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
            this.MinimizedBtn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown_Minimized);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CloseBtn = ((System.Windows.Controls.Image)(target));
            
            #line 46 "..\..\..\..\EQUIPMENT\OpenEquipmentMagisralNetworks.xaml"
            this.CloseBtn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown_Close);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbFrequency = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbCoefficien = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbDTT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

