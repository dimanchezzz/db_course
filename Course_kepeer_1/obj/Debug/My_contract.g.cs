﻿#pragma checksum "..\..\My_contract.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C4479F9279E1230DB085E7EDF9437704951507A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Course_kepeer_1;
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


namespace Course_kepeer_1 {
    
    
    /// <summary>
    /// My_contract
    /// </summary>
    public partial class My_contract : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\My_contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox services;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\My_contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock date_start;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\My_contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock date_end;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\My_contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pay;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\My_contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock debt;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\My_contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock status;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\My_contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox payment;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\My_contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button to_pay;
        
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
            System.Uri resourceLocater = new System.Uri("/Course_kepeer_1;component/my_contract.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\My_contract.xaml"
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
            this.services = ((System.Windows.Controls.ListBox)(target));
            
            #line 12 "..\..\My_contract.xaml"
            this.services.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.services_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.date_start = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.date_end = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.pay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.debt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.status = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.payment = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\My_contract.xaml"
            this.payment.SelectionChanged += new System.Windows.RoutedEventHandler(this.payment_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 18 "..\..\My_contract.xaml"
            this.payment.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.payment_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.to_pay = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\My_contract.xaml"
            this.to_pay.Click += new System.Windows.RoutedEventHandler(this.to_pay_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

