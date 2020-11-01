using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GuiClient.Commands;
using GuiClient.ServerWrapper;

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
            ListOfIcu = _icuWrapper.GetAllIcu();
            this.IcuDeleteCommand=new DelegateCommandClass(
                IcuDeleteWrapper,
                CanExecuteWrapper);
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
