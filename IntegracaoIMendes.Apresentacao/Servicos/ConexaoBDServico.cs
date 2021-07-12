using System;
using System.Text.Json;
using System.IO;
using IntegracaoIMendes.Apresentacao.Entidades;

namespace IntegracaoIMendes.Apresentacao.Servicos
{
    public static class ConexaoBDServico
    {
        public static void CarregarCredenciais()
        {
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\IntegracaoImendes.Config"))
            {
                string ConnectionString = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"\IntegracaoImendes.Config");

                CredenciaisBD credenciais = JsonSerializer.Deserialize<CredenciaisBD>(ConnectionString);

                if (credenciais != null)
                {
                    Properties.Settings.Default.Server = credenciais.Server;
                    Properties.Settings.Default.Database = credenciais.Database;
                    Properties.Settings.Default.User = credenciais.User;
                    Properties.Settings.Default.Password = credenciais.Password;
                }
            }
        }

        public static void SalvarCredenciais(string server, string database, string user, string password)
        {
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\IntegracaoImendes.Config"))
                ExcluirArquivoCredenciais();

            CredenciaisBD credenciais = new CredenciaisBD();

            credenciais.Server = server;
            credenciais.Database = database;
            credenciais.User = user;
            credenciais.Password = password;
            
            string jsonCredenciais = JsonSerializer.Serialize(credenciais);

            CriarArquivoCredenciais(jsonCredenciais);
        }

        private static void ExcluirArquivoCredenciais()
        {
            System.IO.File.Delete(Environment.CurrentDirectory + @"\IntegracaoImendes.Config");
        }

        private static void CriarArquivoCredenciais(string credenciais)
        {
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\IntegracaoImendes.Config");

            sw.WriteLine(credenciais);

            sw.Close();
        }
    }
}
