using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GuiClient.Commands;
using GuiClient.ServerWrapper;
// ReSharper disable All
namespace GuiClient.ViewModels
{
   public class BedDeletionViewModel :INotifyPropertyChanged
   {
        #region Fields

        private readonly BedsWrapper _bedsWrapper = new BedsWrapper();
        private readonly IcuWrapper _icuWrapper = new IcuWrapper();
        private string _selectedIcu;
        private List<int> _freeBedModelsIds;
        private int _selectedBedId;
        private List<string> _listOfIcu;

        #endregion

        #region Initializers

        public BedDeletionViewModel()
        {
            ListOfIcu = _icuWrapper.GetAllIcu();
            //this.DeleteBedCommand = new DelegateCommandClass(new Action<object>(this.DeleteBedWrapper),
              //  new Func<object, bool>(this.CanExecuteWrapper));
              this.RefreshCommand = new RelayCommand(this.RefreshCommandWrapper);
              this.DeleteBedCommand=new RelayCommand(this.DeleteBedWrapper);
            //this.IcuSelectionChangedCommand = new DelegateCommandClass(new Action<object>(this.IcuSelectionChangedWrapper),
              //  new Func<object, bool>(this.CanExecuteWrapper));
        }

        #endregion

        #region Properties

        public List<string> ListOfIcu
        {
            get => _listOfIcu;
            set
            {
                _listOfIcu = value;
                OnPropertyChanged(nameof(ListOfIcu));
            }
        }
        public string SelectedIcu
        {
            get => _selectedIcu;
            set
            {
                _selectedIcu = value;
                OnPropertyChanged(nameof(SelectedIcu));
                GetAllBedsOfSpecificIcu();
            }
        }

        public List<int> FreeBedList
        {
            get => _freeBedModelsIds;
            set
            {
                _freeBedModelsIds = value;
                OnPropertyChanged(nameof(FreeBedList));
            }
        }

        public int SelectedBedId
        {
            get => _selectedBedId;
            set
            {
                _selectedBedId = value;
                OnPropertyChanged(nameof(SelectedBedId));
            }
        }

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Logic
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void GetAllBedsOfSpecificIcu()
        {
            var bedWrapper = new BedsWrapper();
            var allBedsInIcu = bedWrapper.GetListOfBedsForIcu(SelectedIcu);
            if (allBedsInIcu == null) return;
            var result = from bed in allBedsInIcu
                where bed.BedStatus == "False"
                select bed.BedId;
            FreeBedList = result.ToList();
        }

        #endregion

        #region Commands

        public ICommand DeleteBedCommand
        {
            get;
            set;
        }

        public ICommand RefreshCommand
        {
            get;
            set;
        }

        #endregion
        #region Command Helper Methods

        public void RefreshCommandWrapper(object parameter)
        {
            ListOfIcu = _icuWrapper.GetAllIcu();
        }

        public void DeleteBedWrapper(object parameter)
        {
            _bedsWrapper.RemoveBed(SelectedBedId);
            GetAllBedsOfSpecificIcu();
        }

        #endregion
    }
}
