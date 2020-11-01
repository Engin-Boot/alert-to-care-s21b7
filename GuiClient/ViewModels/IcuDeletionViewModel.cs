using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GuiClient.Commands;
using GuiClient.ServerWrapper;
// ReSharper disable All
namespace GuiClient.ViewModels
{
    public class IcuDeletionViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly IcuWrapper _icuWrapper = new IcuWrapper();
        private List<string> _listOfIcuIds;
        private string _selectedIcu;

        #endregion

        #region Initializers

        public IcuDeletionViewModel()
        {
            
            this.IcuDeleteCommand=new DelegateCommandClass(
                IcuDeleteWrapper,
                CanExecuteWrapper);
            RefreshCommand = new RelayCommand(RefreshView);
            InitView();
        }

        

        private void InitView()
        {
            ListOfIcu = _icuWrapper.GetAllIcu();
        }

        #endregion

        #region Properties

        public List<string> ListOfIcu
        {
            get => _listOfIcuIds;
            set
            {
                _listOfIcuIds = value;
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
            }
        }

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Logic

        private void RefreshView(object obj)
        {
            InitView();
        }
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

        #region Commands

        public ICommand IcuDeleteCommand
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

        #region Command Helper methods

        public void IcuDeleteWrapper(object parameter)
        {
            if (SelectedIcu != null)
            {
                _icuWrapper.RemoveIcu(SelectedIcu);
                ListOfIcu = _icuWrapper.GetAllIcu();
            }
            else
            {
                MessageBox.Show("Icu not selected.");
            }
        }

        public bool CanExecuteWrapper(object parameter)
        {
            return true;
        }
        #endregion
    }
}
