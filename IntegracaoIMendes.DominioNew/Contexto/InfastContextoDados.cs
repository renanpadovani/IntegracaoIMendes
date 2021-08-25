using System;
using Newtonsoft.Json;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using System.Data.SqlClient;

namespace IntegracaoIMendes.Dominio.ContextoDados
{
    public class InfastContextoDados : IDisposable
    {
        public SqlConnection Connection { get; set; }
        
        public InfastContextoDados()
        {
            CredenciaisBD credenciais = CarregarCredenciaisBD();

            Connection = new SqlConnection("Server=" + credenciais.Server + ";Database=" + credenciais.Database + ";User Id=" + credenciais.User + ";Password=" + credenciais.Password + ";");

            Connection.Open();
        }

        private CredenciaisBD CarregarCredenciaisBD()
        {
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\IntegracaoImendes.Config"))
            {
                string jSonCredenciais = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"\IntegracaoImendes.Config");

                return JsonConvert.DeserializeObject<CredenciaisBD>(jSonCredenciais);
            }
            else
                throw new Exception("Arquivo com as credenciais de banco de dados não foi encontrado.");
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}

