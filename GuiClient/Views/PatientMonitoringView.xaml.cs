using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Threading;
using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for PatientMonitoringView.xaml
    /// </summary>
    ///
    
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public partial class PatientMonitoringView
    {
        public readonly PatientMonitoringViewModel PatientMonitoringVm = new PatientMonitoringViewModel();
        //public ObservableCollection<PatientDataMonitor> Pd;
        public PatientMonitoringView()
        {
            InitializeComponent();
            DataContext = PatientMonitoringVm;
            DispatcherTimer timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(10)};
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PatientMonitoringVm.Try();
        }

    }
}
