using GuiClient.Models;
using RestSharp;

namespace GuiClient.ServerWrapper
{
    // ReSharper disable once UnusedType.Global
    public class EmailAleterWrapper
    {
        private readonly RestClient _client;
        private RestRequest _request;

        public EmailAleterWrapper()
        {
            _client = new RestClient("http://localhost:5000/api");
        }

        // ReSharper disable once UnusedMember.Global
        public void SendEmailAlert(VitalAlertEmailFormat email)
        {
            
            _request = new RestRequest("AlertService/SendEmailAlert", Method.POST) { RequestFormat = DataFormat.Json };
            _request.AddJsonBody(email);
           _client.Execute(_request);
        }
    }
}
