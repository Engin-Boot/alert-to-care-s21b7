using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for IcuDeletionView.xaml
    /// </summary>
    public partial class IcuDeletionView 
    {
        private readonly IcuDeletionViewModel _icuDeletionVm = new IcuDeletionViewModel();
        public IcuDeletionView()
        {
            InitializeComponent();
            DataContext = _icuDeletionVm;
        }
    }
}
