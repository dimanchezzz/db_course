﻿#pragma checksum "..\..\Credit_page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F63D41099D2D9EFD872014002385D9528796C11E"
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Course_kepeer_1 {
    
    
    /// <summary>
    /// Credit_page
    /// </summary>
    public partial class Credit_page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Credit_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.WatermarkTextBox amount;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Credit_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.WatermarkTextBox mounth;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Credit_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.WatermarkTextBox persent;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Credit_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.WatermarkTextBox result;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Credit_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button count;
        
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
            System.Uri resourceLocater = new System.Uri("/Course_kepeer_1;component/credit_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Credit_page.xaml"
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
            this.amount = ((Xceed.Wpf.Toolkit.WatermarkTextBox)(target));
            
            #line 13 "..\..\Credit_page.xaml"
            this.amount.SelectionChanged += new System.Windows.RoutedEventHandler(this.amount_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 13 "..\..\Credit_page.xaml"
            this.amount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.persent_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mounth = ((Xceed.Wpf.Toolkit.WatermarkTextBox)(target));
            
            #line 14 "..\..\Credit_page.xaml"
            this.mounth.SelectionChanged += new System.Windows.RoutedEventHandler(this.amount_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 14 "..\..\Credit_page.xaml"
            this.mounth.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.persent_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.persent = ((Xceed.Wpf.Toolkit.WatermarkTextBox)(target));
            
            #line 15 "..\..\Credit_page.xaml"
            this.persent.SelectionChanged += new System.Windows.RoutedEventHandler(this.amount_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 15 "..\..\Credit_page.xaml"
            this.persent.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.persent_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.result = ((Xceed.Wpf.Toolkit.WatermarkTextBox)(target));
            return;
            case 5:
            this.count = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Credit_page.xaml"
            this.count.Click += new System.Windows.RoutedEventHandler(this.count_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

