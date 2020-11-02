using GuiClient.Models;
using RestSharp;

namespace GuiClient.ServerWrapper
{
    public class EmailAleterWrapper
    {
        private readonly RestClient _client;
        private RestRequest _request;

        public EmailAleterWrapper()
        {
            _client = new RestClient("http://localhost:5000/api");
        }

        public void SendEmailAlert(VitalAlertEmailFormat email)
        {
            
            _request = new RestRequest("AlertService/SendEmailAlert", Method.POST) { RequestFormat = DataFormat.Json };
            _request.AddJsonBody(email);
           _client.Execute(_request);
        }
    }
}
