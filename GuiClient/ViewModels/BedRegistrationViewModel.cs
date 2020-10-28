using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using System.Windows.Input;
using GuiClient.Annotations;
using GuiClient.Commands;
using RestSharp.Deserializers;

namespace GuiClient.ViewModels
{
   public class BedRegistrationViewModel : INotifyPropertyChanged
   {


        #region Fields

        public string BaseUrl = "http://localhost:5000/api/";
        private static RestClient _client;
        private static RestRequest _request;
        private readonly JsonDeserializer _deserializer = new JsonDeserializer();
        private static IRestResponse _response;
        private string _selectedIcu;
        private List<string> _listOfIcu ;
        private int _bedNumber;
        private string _bedStatus;
        private string _selectedBedStatus;

        #endregion

        #region Initializers

        public BedRegistrationViewModel()
        {
            GetAllIcu();
            
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

        public int BedNumber
        {
            get => _bedNumber;
            set
            {
                _bedNumber = value;
                OnPropertyChanged(nameof(BedNumber));
            }
        }

        public string BedStatus
        {
            get => _bedStatus;
            set
            {
                _bedStatus = value;
                OnPropertyChanged(nameof(BedStatus));
            }
        }

        public List<string> StatusOfBeds { get; } = new List<string>()
        {
            "Left","Right","Center"
        };

        public string SelectedBedStatus
        {
            get => _selectedBedStatus;
            set
            {
                _selectedBedStatus = value;
                OnPropertyChanged(nameof(SelectedBedStatus));
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
            _client= new RestClient(BaseUrl);
            _request = new RestRequest("configuration/GetIcuModelInformation");
            _response = _client.Execute(_request);

            var dictionaryOfIcuModels= _deserializer.Deserialize<Dictionary<string, IcuModel>>(_response);
            ListOfIcu = dictionaryOfIcuModels.Keys.ToList<string>();
        }

        public bool GetAllBedsOfSpecificIcu() ///instead get all bedds and then check in that
        {
            _client = new RestClient(BaseUrl);
            _request = new RestRequest("Occupancy/GetBedDetailsForIcu/{IcuId}")
            {
                RequestFormat = DataFormat.Json
            };
            _request.AddUrlSegment("IcuId", SelectedIcu);
            _response = _client.Execute(_request);

            var resultant = _deserializer.Deserialize<List<BedModel>>(_response); //add to some property
            foreach (var bed in resultant)
            {
                if (bed.BedNumber == BedNumber)
                    return false;
            }

            return true;
        }

        #endregion

        #region Commands

        public ICommand AddBedCommand
        {
            get;
            set;
        }

        #endregion

        #region Command Helper Methods

        public void AddBedWrapper(object parameter)
        {
           // this.AddIcu();
        }

        public bool CanExecuteWrapper(object parameter)
        {
            //return GetAllBedsOfSpecificIcu();
            return true;
        }

        #endregion


    }
}
