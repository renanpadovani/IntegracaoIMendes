using System;
using Microsoft.Data.SqlClient;


namespace IntegracaoIMendes.Domain.DataContext
{
    public class InfastDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }
        
        public InfastDataContext(string server, string dataBase, string user, string password)
        {
            Connection = new SqlConnection("Server=" + server + ";Database=" + dataBase + ";User Id=" + user + ";Password=" + password + ";");
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
