using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
    }
}
