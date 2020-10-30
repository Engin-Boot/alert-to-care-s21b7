using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for PatientMonitoringView.xaml
    /// </summary>
    ///
    
    public partial class PatientMonitoringView : UserControl
    {
        public  readonly PatientMonitoringViewModel PatientMonitoringVm = new PatientMonitoringViewModel();
        //public ObservableCollection<PatientDataMonitor> Pd;
        public PatientMonitoringView()
        {
            InitializeComponent();
            DataContext = PatientMonitoringVm;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            PatientMonitoringVm.Try();
        }

    }
}
