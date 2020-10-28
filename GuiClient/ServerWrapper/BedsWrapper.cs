using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using RestSharp;

namespace GuiClient.ServerWrapper
{
    public class BedsWrapper:Wrapper
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

        public void PostBed(BedModel newBed)
        {
            Client=new RestClient(BaseUrl);
            Request = new RestRequest("Configuration/PostBedModelData");
            //Request.AddJsonBody(new 
            //{
            //    //bedId = 0,
            //    icuId = icuIdPassed,
            //    bedLayout = bedLayoutPassed,
            //    bedNumber = bedNumberPassed,
            //    //bedStatus = "Dummy"
            //});
            Request.AddJsonBody(newBed);
            Response = Client.Execute(Request);
            if (Response.StatusCode.Equals(HttpStatusCode.OK))
                MessageBox.Show("Bed is Added.");
            MessageBox.Show("Internal Server Error.");
        }
    }
}
