namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for IcuRegisterationView.xaml
    /// </summary>
    public partial class IcuRegisterationView 
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public readonly ViewModels.IcuRegistrationViewModel IcuRegistrationViewModel = new ViewModels.IcuRegistrationViewModel();
        public IcuRegisterationView()
        {
            InitializeComponent();
            DataContext = IcuRegistrationViewModel;
        }
    }
}
