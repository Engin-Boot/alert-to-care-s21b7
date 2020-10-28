using System.Collections.Generic;
using System.Linq;
using GuiClient.Models;
using RestSharp;

namespace GuiClient.ServerWrapper
{
    
    public class IcuWrapper:Wrapper
    {
        public List<string> GetAllIcu()
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("configuration/GetIcuModelInformation", Method.GET){RequestFormat = DataFormat.Json};
            Response = Client.Execute(Request);
            var dictionaryOfIcuModels = Deserializer.Deserialize<Dictionary<string, IcuModel>>(Response);
            var listOfIcu = dictionaryOfIcuModels.Keys.ToList();
            return listOfIcu;
        }
    }
}
