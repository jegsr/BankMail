﻿#pragma checksum "..\..\..\View\VerMensagem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A4731D669C5F43C16F7FBE073FB02D24"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Database.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Database.View {
    
    
    /// <summary>
    /// VerMensagem
    /// </summary>
    public partial class VerMensagem : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 103 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Titulo;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbDestination;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDestino;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbAssunto;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAssunto;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbMensagem;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMensagem;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttResponder;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\View\VerMensagem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttVoltar;
        
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
            System.Uri resourceLocater = new System.Uri("/Database;component/view/vermensagem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\VerMensagem.xaml"
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
            
            #line 12 "..\..\..\View\VerMensagem.xaml"
            ((Database.View.VerMensagem)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Window_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Titulo = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lbDestination = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtDestino = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.lbAssunto = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtAssunto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lbMensagem = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.txtMensagem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.bttResponder = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\View\VerMensagem.xaml"
            this.bttResponder.Click += new System.Windows.RoutedEventHandler(this.btnClick_Responder);
            
            #line default
            #line hidden
            return;
            case 10:
            this.bttVoltar = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\View\VerMensagem.xaml"
            this.bttVoltar.Click += new System.Windows.RoutedEventHandler(this.btnClick_Voltar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

