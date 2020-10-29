using System;
using System.Collections.Generic;
using System.Linq;
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
using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for PatientMonitoringView.xaml
    /// </summary>
    public partial class PatientMonitoringView : UserControl
    {
        public  readonly PatientMonitoringViewModel PatientMonitoringViewModel = new PatientMonitoringViewModel();
        public PatientMonitoringView()
        {
            InitializeComponent();
            DataContext = PatientMonitoringViewModel;
        }

        private void PatientMonitoringView_OnLoaded(object sender, RoutedEventArgs e)
        {
            IcuIds.Text = "";
        }

        //private void IcuIds_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    this._patientMonitoringViewModel.PatientsInParticularIcu();
        //}
    }
}
