using System;
using System.Net.Http;
using RestSharp;
using System.Text.Json;

namespace infracciones.modelos
{
    public class ClientApiPeru
    {
        public class Consulta
        {
            public Dni GetDni(string dni)
            {
                var client = new RestClient($"https://apiperu.dev/api/dni/{dni}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer 55d321167120327342d266d9f48a453fef009aff4c30e411548069ca672737e5");
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    DniHeader header = JsonSerializer.Deserialize<DniHeader>(response.Content);
                    return header.data;
                }
                return null;
            }
        }
    }
    class DniHeader
    {
        public bool success { get; set; }
        public Dni data { get; set; }
    }
}
