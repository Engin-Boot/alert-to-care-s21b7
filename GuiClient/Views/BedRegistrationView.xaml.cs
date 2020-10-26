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
    /// Interaction logic for BedRegistrationForm.xaml
    /// </summary>
    
    public partial class BedRegistrationForm : UserControl
    {
        private readonly BedRegistrationViewModel _bedRegistrationVm = new BedRegistrationViewModel();
        public BedRegistrationForm()
        {
            InitializeComponent();
            DataContext = _bedRegistrationVm;
        }
    }
}
