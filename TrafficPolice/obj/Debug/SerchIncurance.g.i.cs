﻿#pragma checksum "..\..\SerchIncurance.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "90BD71BAEE448E27C35BEBFCBF73305B2A4DD97E29C1156BDA21D5C5439DD6E4"
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
using TrafficPolice;


namespace TrafficPolice {
    
    
    /// <summary>
    /// SerchIncurance
    /// </summary>
    public partial class SerchIncurance : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\SerchIncurance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IncuranceSeriesTbox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\SerchIncurance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IncuranceNumberTbox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\SerchIncurance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SerchDriverLicence;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\SerchIncurance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PtcSerch;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\SerchIncurance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SetchInsurance;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\SerchIncurance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SerchDriver;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\SerchIncurance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SerchAvto;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\SerchIncurance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DatagridFirst;
        
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
            System.Uri resourceLocater = new System.Uri("/TrafficPolice;component/serchincurance.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SerchIncurance.xaml"
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
            this.IncuranceSeriesTbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\SerchIncurance.xaml"
            this.IncuranceSeriesTbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DriverLicenceSeriesTbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IncuranceNumberTbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\SerchIncurance.xaml"
            this.IncuranceNumberTbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DriverLicenceSeriesTbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SerchDriverLicence = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\SerchIncurance.xaml"
            this.SerchDriverLicence.Click += new System.Windows.RoutedEventHandler(this.SerchDriverLicence_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PtcSerch = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\SerchIncurance.xaml"
            this.PtcSerch.Click += new System.Windows.RoutedEventHandler(this.PtcSerch_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SetchInsurance = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\SerchIncurance.xaml"
            this.SetchInsurance.Click += new System.Windows.RoutedEventHandler(this.SetchInsurance_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SerchDriver = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\SerchIncurance.xaml"
            this.SerchDriver.Click += new System.Windows.RoutedEventHandler(this.SerchDriver_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SerchAvto = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\SerchIncurance.xaml"
            this.SerchAvto.Click += new System.Windows.RoutedEventHandler(this.SerchAvto_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DatagridFirst = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

