using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace GuiClient.ServerWrapper
{
    
    public class IcuWrapper:Wrapper
    {
        public List<string> GetAllIcu()
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("configuration/GetIcuModelInformation");
            Response = Client.Execute(Request);
            var dictionaryOfIcuModels = Deserializer.Deserialize<Dictionary<string, IcuModel>>(Response);
            var listOfIcu = dictionaryOfIcuModels.Keys.ToList();
            return listOfIcu;
        }
    }
}
