using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using GuiClient.Models;
using RestSharp;
using DataFormat = RestSharp.DataFormat;

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

        public void AddIcu(IcuModel icuModel)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("Configuration/PostIcuModelData", Method.POST) { RequestFormat = DataFormat.Json };
            Request.AddJsonBody(icuModel);
            Response = Client.Execute(Request);
            MessageBox.Show(Response.StatusCode.Equals(HttpStatusCode.OK)
                ? "ICU is Added."
                : "ICU already present.");

        }

        public void RemoveIcu(string icuId)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest($"Configuration/RemoveIcu/{icuId}", Method.DELETE) { RequestFormat = DataFormat.Json };
            Response = Client.Execute(Request);
            MessageBox.Show(Response.StatusCode.Equals(HttpStatusCode.OK)
                ? "ICU is Removed."
                : "Internal Server Error.");
        }
    }
}
