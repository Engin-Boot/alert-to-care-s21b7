using System.Windows.Controls;
using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for PatientDischargeView.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class PatientDischargeView : UserControl
    {
        private readonly PatientDischargeViewModel _patientDischargeViewModel = new PatientDischargeViewModel();
        public PatientDischargeView()
        {
            InitializeComponent();
            DataContext = _patientDischargeViewModel;
        }

    }
}
