using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for IcuRegisterationView.xaml
    /// </summary>
    public partial class IcuRegisterationView : UserControl
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public readonly ViewModels.IcuRegistrationViewModel _icuRegistrationViewModel = new ViewModels.IcuRegistrationViewModel();
        public IcuRegisterationView()
        {
            InitializeComponent();
            DataContext = _icuRegistrationViewModel;
        }
    }
}
