using IntegracaoIMendes.Domain.Entities.IMendes;
using RestSharp;
using System.Text.Json;

namespace IntegracaoIMendes.Domain.Services
{
    public class IMendesService
    {
        string _login;
        string _password;

        public IMendesService(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public TributosRetorno PesquisarTributos(TributosRequisicao productRequest)
        {
            var client = new RestClient("http://consultatributos.com.br:8080/api/v3/public/SaneamentoGrades");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("login", _login);
            request.AddHeader("senha", _password);
            request.AddHeader("Content-Type", "application/json");

            string jsonString = JsonSerializer.Serialize(productRequest);

            request.AddParameter("application/json", jsonString, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return JsonSerializer.Deserialize<TributosRetorno>(response.Content);
        }
    }
}
