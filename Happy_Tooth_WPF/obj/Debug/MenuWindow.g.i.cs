// Updated by XamlIntelliSenseFileGenerator 03.04.2025 15:28:29
#pragma checksum "..\..\MenuWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1EB302A5CDD06FA018FD5DDD795FF89B8BBAA07BA893D3FF0BE0DAE95B5A7AD7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Happy_Tooth_WPF;
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


namespace Happy_Tooth_WPF
{


    /// <summary>
    /// MenuWindow
    /// </summary>
    public partial class MenuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 27 "..\..\MenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPatients;

#line default
#line hidden


#line 31 "..\..\MenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDoctors;

#line default
#line hidden


#line 35 "..\..\MenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAppointments;

#line default
#line hidden


#line 39 "..\..\MenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVisits;

#line default
#line hidden


#line 43 "..\..\MenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReports;

#line default
#line hidden


#line 47 "..\..\MenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnProfile;

#line default
#line hidden


#line 51 "..\..\MenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Happy_Tooth_WPF;component/menuwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MenuWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.btnPatients = ((System.Windows.Controls.Button)(target));

#line 29 "..\..\MenuWindow.xaml"
                    this.btnPatients.Click += new System.Windows.RoutedEventHandler(this.btnPatients_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.btnDoctors = ((System.Windows.Controls.Button)(target));

#line 33 "..\..\MenuWindow.xaml"
                    this.btnDoctors.Click += new System.Windows.RoutedEventHandler(this.btnDoctors_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.btnAppointments = ((System.Windows.Controls.Button)(target));

#line 37 "..\..\MenuWindow.xaml"
                    this.btnAppointments.Click += new System.Windows.RoutedEventHandler(this.btnAppointments_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.btnVisits = ((System.Windows.Controls.Button)(target));

#line 41 "..\..\MenuWindow.xaml"
                    this.btnVisits.Click += new System.Windows.RoutedEventHandler(this.btnVisits_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.btnReports = ((System.Windows.Controls.Button)(target));

#line 45 "..\..\MenuWindow.xaml"
                    this.btnReports.Click += new System.Windows.RoutedEventHandler(this.btnReports_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.btnProfile = ((System.Windows.Controls.Button)(target));

#line 49 "..\..\MenuWindow.xaml"
                    this.btnProfile.Click += new System.Windows.RoutedEventHandler(this.btnProfile_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.btnLogout = ((System.Windows.Controls.Button)(target));

#line 53 "..\..\MenuWindow.xaml"
                    this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.btnLogout_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.MainFrame = ((System.Windows.Controls.Frame)(target));
                    return;
            }
            this._contentLoaded = true;
        }
        internal System.Windows.Controls.Frame MainFrame;
    }
}

