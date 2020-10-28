using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

namespace GuiClient.ViewModels
{
    public class IcuRegistrationViewModel 
    {
        #region Fields

        public string BaseUrl = "http://localhost:5000/api/";
        private static RestClient _client;
        private static RestRequest _request;
        private readonly JsonDeserializer _deserializer = new JsonDeserializer();
        private static IRestResponse _response;

        #endregion

        #region Initializers

        public IcuRegistrationViewModel()
        {
            this.AddIcuCommand = new Commands.DelegateCommandClass(new Action<object>(this.AddIcuWrapper),
                new Func<object, bool>(CanExecuteWrapper) );
        }

        #endregion

        #region Properties



        #endregion

        #region Event



        #endregion

        #region Logic

        public void AddIcu()
        {
            //do the post stuff
            _client = new RestClient(BaseUrl);
            _request = new RestRequest("configuration/PostIcuModelData", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            _request.AddJsonBody(new
            {
                icuId = "ICU06",
                bedCount = 1
            });
            _response = _client.Execute(_request);
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

        private void AddIcuWrapper(object parameter)
        {
            this.AddIcu();
        }

        private static bool CanExecuteWrapper(object parameter)
        {
            return true;
        }

        #endregion
    }
}
