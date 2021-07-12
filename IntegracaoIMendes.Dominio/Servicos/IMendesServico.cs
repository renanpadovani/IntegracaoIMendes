using IntegracaoIMendes.Dominio.Entidades.IMendes;
using RestSharp;
using System.Text.Json;

namespace IntegracaoIMendes.Dominio.Servicos
{
    public class IMendesServico
    {
        string _login;
        string _password;

        public IMendesServico(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public TributosRetorno PesquisarTributos(TributosRequisicao productRequest)
        {
            TributosRetorno retornoIMendes = new TributosRetorno();

            try
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

                retornoIMendes = JsonSerializer.Deserialize<TributosRetorno>(response.Content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    retornoIMendes.ErroRetorno = false;
                }
                else
                {
                    retornoIMendes.ErroRetorno = true;
                    retornoIMendes.MensagemErro = "Error Message: " + response.ErrorMessage + " - Content/Type: " + response.Content.ToString();
                }
            }
            catch (System.Exception ex)
            {
                retornoIMendes.ErroRetorno = true;
                retornoIMendes.MensagemErro = ex.Message;
            }

            return retornoIMendes;
        }
    }
}
