using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for BedDeletionView.xaml
    /// </summary>
    public partial class BedDeletionView
    {
        //bed list get
        public readonly BedDeletionViewModel BedDeletionVm  =  new BedDeletionViewModel();
        public BedDeletionView()
        {
            InitializeComponent();
            DataContext = BedDeletionVm;
        }
    }
}
