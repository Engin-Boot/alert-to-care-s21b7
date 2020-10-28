using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

namespace GuiClient.ServerWrapper
{
    public abstract class Wrapper
    {
        protected RestClient Client;
        protected  RestRequest Request;
        protected readonly JsonDeserializer Deserializer = new JsonDeserializer();
        protected IRestResponse Response;
        protected const string BaseUrl = "http://localhost:5000/api/";

    }
}
