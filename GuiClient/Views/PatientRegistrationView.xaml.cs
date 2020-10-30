using System.Windows;
using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for PatientRegistrationView.xaml
    /// </summary>
    public partial class PatientRegistrationView
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public PatientRegistrationViewModel
            PatientRegistrationViewModel;
        //private AccessingData _accessing = new AccessingData();

        public PatientRegistrationView()
        {
            InitializeComponent();
            PatientRegistrationViewModel = new PatientRegistrationViewModel();
            DataContext = PatientRegistrationViewModel;
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

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            PatientRegistrationViewModel.InitDetails();
        }


        //private void IcuListDropDown_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    this._patientRegistrationViewModel.FreeBedIdsOfSelectedIcu;
        //}
        //private void IcuListDropDown_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //this.PatientRegistrationViewModel.FreeBedsInParticularIcu();
        //}

        //private void AdmitButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //if (PatientRegistrationViewModel.Admit_CanExecute())
        //    //{
        //    //    PatientRegistrationViewModel.Admit_Executed();
        //    //    MessageBox.Show("Patient Admitted.");
        //    //    //may be show the pid generated.
        //    //    //all the fields clear.
        //    //    PatientRegistrationViewModel.Clear();
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Something is wrong.");
        //    //}
        //}

    }
}
