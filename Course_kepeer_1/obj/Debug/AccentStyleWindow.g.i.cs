﻿#pragma checksum "..\..\AccentStyleWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DDD018B82DE3B3E50FBCE08D347B3E5B194E7EAF"
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
using MahApps.Metro;
using MahApps.Metro.Actions;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
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
    /// AccentStyleWindow
    /// </summary>
    public partial class AccentStyleWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 111 "..\..\AccentStyleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AccentSelector;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\AccentStyleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ColorsSelector;
        
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
            System.Uri resourceLocater = new System.Uri("/Course_kepeer_1;component/accentstylewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AccentStyleWindow.xaml"
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
            
            #line 61 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeWindowThemeButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 63 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeWindowThemeButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 65 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeWindowAccentButtonClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 67 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeWindowAccentButtonClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 69 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeWindowAccentButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 86 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeAppThemeButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 88 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeAppThemeButtonClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 90 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeAppAccentButtonClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 92 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeAppAccentButtonClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 94 "..\..\AccentStyleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeAppAccentButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.AccentSelector = ((System.Windows.Controls.ComboBox)(target));
            
            #line 114 "..\..\AccentStyleWindow.xaml"
            this.AccentSelector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AccentSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ColorsSelector = ((System.Windows.Controls.ComboBox)(target));
            
            #line 126 "..\..\AccentStyleWindow.xaml"
            this.ColorsSelector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ColorsSelectorOnSelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

