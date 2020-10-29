using System.Collections.Generic;
using System.Net;
using System.Windows.Navigation;
using GuiClient.Models;
using RestSharp;

namespace GuiClient.ServerWrapper
{
    public class PatientWrapper: Wrapper
    {
        public int AddPatient(PatientModel newPatient)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("Occupancy", Method.POST) { RequestFormat = DataFormat.Json };
            Request.AddJsonBody(newPatient);
            //_request.AddQueryParameter("newPatient", newPatient.ToString());
            var response = Client.Execute(Request);
            return response.StatusCode.Equals(HttpStatusCode.OK) ? 1 : 0;
        }

        public Dictionary<string, PatientModel> GetAllPatients()
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("Occupancy/GetAllPatients", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(Request);
            var result = Deserializer.Deserialize<Dictionary<string, PatientModel>>(response);
            return result;
        }

        public int DischargePatient(string pid)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest($"Occupancy/Discharge/{pid}", Method.DELETE) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(Request);
            return response.StatusCode.Equals(HttpStatusCode.OK) ? 1 : 0;
        }

        public Dictionary<string, PatientVital> GetPatientVitals()
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest("Monitor/GeAllPatientVitals", Method.GET) { RequestFormat = DataFormat.Json };
            Response = Client.Execute(Request);
            return Deserializer.Deserialize<Dictionary<string, PatientVital>>(Response);
        }

        public Dictionary<string, PatientModel> GetPatientsFromIcu(string icuId)
        {
            Client = new RestClient(BaseUrl);
            Request = new RestRequest($"Occupancy/{icuId}", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(Request);
            return Deserializer.Deserialize<Dictionary<string, PatientModel>>(response);
        }
    }
}
