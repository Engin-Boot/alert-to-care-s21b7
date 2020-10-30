using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using GuiClient.Commands;
using GuiClient.Models;
using GuiClient.ServerWrapper;
using RestSharp.Deserializers;

namespace GuiClient.ViewModels
{
    public class BedRegistrationViewModel : INotifyPropertyChanged
    {

        #region Fields

            private string _selectedIcu;
            private List<string> _listOfIcu;

            private string _bedNumber;

            //private string _bedStatus;
            private string _selectedBedLayout;
            private List<string> _listOfBedLayouts;

            #endregion

            #region Initializers

            public BedRegistrationViewModel()
            {
                GetAllIcu();
                GetAllLayouts();
                this.AddBedCommand = new DelegateCommandClass(new Action<object>(this.AddBedWrapper),
                    new Func<object, bool>(this.CanExecuteWrapper));
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
                }
            }

            public string BedNumber
            {
                get => _bedNumber;
                set
                {
                    _bedNumber = value;
                    OnPropertyChanged(nameof(BedNumber));
                }
            }

            public List<string> StatusOfBeds
            {
                get => _listOfBedLayouts;
                set
                {
                    _listOfBedLayouts = value;
                    OnPropertyChanged(nameof(StatusOfBeds));
                }
            }

            public string SelectedBedLayOut
            {
                get => _selectedBedLayout;
                set
                {
                    _selectedBedLayout = value;
                    OnPropertyChanged(nameof(_selectedBedLayout));
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

            public void GetAllIcu()
            {
                var icuWrapper = new IcuWrapper();
                ListOfIcu = icuWrapper.GetAllIcu();
            }

            public void GetAllLayouts()
            {
                var bedWrapper = new BedsWrapper();
                StatusOfBeds = bedWrapper.GetBedLayouts();
            }

            public bool GetAllBedsOfSpecificIcu()
            {

                var bedWrapper = new BedsWrapper();

                var resultant = bedWrapper.GetListOfBedsForIcu(SelectedIcu); //add to some property
                return resultant.All(bed => !bed.BedNumber.Equals(BedNumber));
            }

            #endregion

            #region Commands

            public ICommand AddBedCommand { get; set; }

            #endregion

            #region Command Helper Methods

            public void AddBedWrapper(object parameter)
            {
                // this.AddIcu();
                if (!GetAllBedsOfSpecificIcu())
                    MessageBox.Show("Bed Number Already Present.");
                else
                {
                    var bedWrapper = new BedsWrapper();
                    var newBed = new BedModel()
                    {
                        BedNumber = _bedNumber,
                        IcuId = _selectedIcu,
                        BedLayout = _selectedBedLayout
                    };
                    bedWrapper.AddBed(newBed);
                    BedNumber = "";
                }
            }

            public bool CanExecuteWrapper(object parameter)
            {
                return true;
            }

            #endregion

    }
}
