using IntegracaoIMendes.Dominio.Entidades.IMendes;
using RestSharp;
using Newtonsoft.Json;

namespace IntegracaoIMendes.Dominio.Servicos
{
    public class IMendesServico
    {
        private readonly string _login;
        private readonly string _password;
        private const string urlSaneamentoGrades = "http://consultatributos.com.br:8080/api/v3/public/SaneamentoGrades";

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
                if (_login.Trim().Length == 0 || _password.Trim().Length == 0)
                {
                    retornoIMendes.ErroRetorno = true;
                    retornoIMendes.MensagemErro = "Login/Senha não preenchidos.";
                    return retornoIMendes;
                }

                var client = new RestClient(urlSaneamentoGrades);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("login", _login);
                request.AddHeader("senha", _password);
                request.AddHeader("Content-Type", "application/json");

                string jsonString = JsonConvert.SerializeObject(productRequest);

                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                retornoIMendes = JsonConvert.DeserializeObject<TributosRetorno>(response.Content);

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
