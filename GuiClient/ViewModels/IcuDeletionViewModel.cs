using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        #endregion
    }
}
