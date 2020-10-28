using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;

namespace GuiClient.ServerWrapper
{
    public class BedsWrapper:Wrapper
    {
        public IEnumerable<int> GetListOfBedsForIcu(string icuId)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("Occupancy/GetBedDetailsForIcu/{IcuId}");
            Request.AddUrlSegment("IcuId", icuId);
            Response = Client.Execute(Request);
            if (!Response.StatusCode.Equals(HttpStatusCode.OK)) return null;
            var result = Deserializer.Deserialize<Dictionary<int, BedModel>>(Response);
            return result.Keys.ToList();
        }
    }
}
