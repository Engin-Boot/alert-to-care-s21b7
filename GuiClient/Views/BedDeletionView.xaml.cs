using GuiClient.ViewModels;
// ReSharper disable All
namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for BedDeletionView.xaml
    /// </summary>
    public partial class BedDeletionView
    {
        
        public readonly BedDeletionViewModel BedDeletionVm  =  new BedDeletionViewModel();
        public BedDeletionView()
        {
            InitializeComponent();
            DataContext = BedDeletionVm;
        }
    }
}
