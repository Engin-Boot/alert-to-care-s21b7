using System.Collections.Generic;
using System.Net;
using System.Windows;
using GuiClient.Models;
using RestSharp;
using DataFormat = RestSharp.DataFormat;

namespace GuiClient.ServerWrapper
{
    public class BedsWrapper : Wrapper
    {
        public List<BedModel> GetListOfBedsForIcu(string icuId)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("Occupancy/GetBedDetailsForIcu/{IcuId}");
            Request.AddUrlSegment("IcuId", icuId);
            Response = Client.Execute(Request);
            if (!Response.StatusCode.Equals(HttpStatusCode.OK)) return null;
            var result = Deserializer.Deserialize<List<BedModel>>(Response);
            return result;
        }

        public void AddBed(BedModel newBed)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("Configuration/PostBedModelData", Method.POST) { RequestFormat = DataFormat.Json };
            Request.AddJsonBody(newBed);
            Response = Client.Execute(Request);
            MessageBox.Show(Response.StatusCode.Equals(HttpStatusCode.OK)
                ? "Bed is Added."
                : "Internal Server Error.");
        }

        public void RemoveBed(int bedId)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest($"Configuration/RemoveBed/{bedId}", Method.DELETE) { RequestFormat = DataFormat.Json };
            Response = Client.Execute(Request);
            MessageBox.Show(Response.StatusCode.Equals(HttpStatusCode.OK)
                ? "Bed is Removed."
                : "Internal Server Error.");
        }

        public List<string> GetBedLayouts()
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("Configuration/GetAllBedLayouts", Method.GET) { RequestFormat = DataFormat.Json };
            Response = Client.Execute(Request);
            return Response.StatusCode.Equals(HttpStatusCode.OK)
                ? Deserializer.Deserialize<List<string>>(Response)
                : null;
        }
    }
}
