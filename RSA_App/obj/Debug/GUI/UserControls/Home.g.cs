﻿#pragma checksum "..\..\..\..\GUI\UserControls\Home.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D502E5D6F3457AF90F65077F51260B2C88B5CA52"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using De.TorstenMandelkow.MetroChart;
using RSA_App.GUI.UserControls;
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


namespace RSA_App.GUI.UserControls {
    
    
    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInYear;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalYearIn;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblOutYear;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalYearOut;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInMonth;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalMonthIn;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblOutMonth;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalMonthOut;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbYear;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbMonth;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\..\GUI\UserControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal De.TorstenMandelkow.MetroChart.ClusteredColumnChart Graph;
        
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
            System.Uri resourceLocater = new System.Uri("/RSA_App;component/gui/usercontrols/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\UserControls\Home.xaml"
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
            this.lblInYear = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblTotalYearIn = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblOutYear = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblTotalYearOut = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblInMonth = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblTotalMonthIn = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblOutMonth = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblTotalMonthOut = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.cbYear = ((System.Windows.Controls.ComboBox)(target));
            
            #line 138 "..\..\..\..\GUI\UserControls\Home.xaml"
            this.cbYear.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbYear_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cbMonth = ((System.Windows.Controls.ComboBox)(target));
            
            #line 163 "..\..\..\..\GUI\UserControls\Home.xaml"
            this.cbMonth.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbMonth_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Graph = ((De.TorstenMandelkow.MetroChart.ClusteredColumnChart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
