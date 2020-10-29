using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GuiClient.Commands;
using GuiClient.Models;
using GuiClient.ServerWrapper;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

namespace GuiClient.ViewModels
{
    public class IcuRegistrationViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly IcuWrapper _icuWrapper = new IcuWrapper();
        private List<string> _listOfIcuIds;
        private string _selectedIcu;
        private int _numberOfBeds;

        #endregion

        #region Initializers

        public IcuRegistrationViewModel()
        {
            SelectedIcu = "";
            ListOfIcu = _icuWrapper.GetAllIcu();
            this.AddIcuCommand = new DelegateCommandClass(new Action<object>(this.AddIcuWrapper),
                new Func<object, bool>(this.CanExecuteWrapper));
            
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

        public int NumberOfBeds
        {
            get => _numberOfBeds;
            set
            {
                _numberOfBeds = value;
                OnPropertyChanged(nameof(NumberOfBeds));
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

        public bool IsIcuAlreadyPresent()
        {
            return ListOfIcu.Any(icuId => icuId.Equals(SelectedIcu));
        }
        #endregion

        #region Commands

        public ICommand AddIcuCommand
        {
            get;
            set;
        }
        #endregion

        #region CommandHelperMethods

        public void AddIcuWrapper(object parameter)
        {
            if (IsIcuAlreadyPresent())
            {
                MessageBox.Show("ICU is already present.");
            }
            else
            {
                _icuWrapper.AddIcu(new IcuModel(){BedCount = NumberOfBeds,IcuId = SelectedIcu});
                ListOfIcu = _icuWrapper.GetAllIcu();
            }
            NumberOfBeds = 0;
            SelectedIcu = "";
        }

        public bool CanExecuteWrapper(object parameter)
        {
            return true;
        }
        #endregion

    }
}
