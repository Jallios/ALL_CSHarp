﻿#pragma checksum "..\..\MaterialProduct.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0E3476C9DADF994EA53BFB1447E01AF88691847C9EEE392E60558D9FDDAB0DA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PlaneBuilder;
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


namespace PlaneBuilder {
    
    
    /// <summary>
    /// MaterialProduct
    /// </summary>
    public partial class MaterialProduct : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgMaterial;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgProduct;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddM;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelM;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRedM;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddP;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelP;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MaterialProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRedP;
        
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
            System.Uri resourceLocater = new System.Uri("/PlaneBuilder;component/materialproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MaterialProduct.xaml"
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
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MaterialProduct.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dtgMaterial = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.dtgProduct = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btnAddM = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\MaterialProduct.xaml"
            this.btnAddM.Click += new System.Windows.RoutedEventHandler(this.btnAddM_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDelM = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\MaterialProduct.xaml"
            this.btnDelM.Click += new System.Windows.RoutedEventHandler(this.btnDelM_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRedM = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\MaterialProduct.xaml"
            this.btnRedM.Click += new System.Windows.RoutedEventHandler(this.btnRedM_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAddP = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\MaterialProduct.xaml"
            this.btnAddP.Click += new System.Windows.RoutedEventHandler(this.btnAddP_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnDelP = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\MaterialProduct.xaml"
            this.btnDelP.Click += new System.Windows.RoutedEventHandler(this.btnDelP_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnRedP = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\MaterialProduct.xaml"
            this.btnRedP.Click += new System.Windows.RoutedEventHandler(this.btnRedP_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

