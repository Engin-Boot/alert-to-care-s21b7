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
    /// Interaction logic for PatientDischargeView.xaml
    /// </summary>
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
