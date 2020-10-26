using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for PatientRegistrationView.xaml
    /// </summary>
    public partial class PatientRegistrationView
    {
        private readonly PatientRegistrationViewModel
            _patientRegistrationViewModel = new PatientRegistrationViewModel();
        //private AccessingData _accessing = new AccessingData();

        public PatientRegistrationView()
        {
            InitializeComponent();
            DataContext = _patientRegistrationViewModel;
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            EmailBox.Text = "";
            NameBox.Text = "";
            AgeBox.Text = "";
            //GenderBox.Text = "";
            AddressBox.Text = "";
            PhoneBox.Text = "";
        }

        
        //private void IcuListDropDown_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    this._patientRegistrationViewModel.FreeBedIdsOfSelectedIcu;
        //}
        private void IcuListDropDown_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._patientRegistrationViewModel.FreeBedsInParticularIcu();
        }

        private void AdmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (_patientRegistrationViewModel.Admit_CanExecute())
            {
                _patientRegistrationViewModel.Admit_Executed();
                MessageBox.Show("Patient Admitted.");
                //may be show the pid generated.
                //all the fields clear.
                _patientRegistrationViewModel.Clear();
            }
            else
            {
                MessageBox.Show("Something is wrong.");
            }
        }

    }
}
