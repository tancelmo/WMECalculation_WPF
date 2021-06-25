using System.Data.OleDb;

namespace WMECalculation
{
    public class Connection
    {
        OleDbConnection connection = new OleDbConnection();

        public Connection()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=WMEData.accdb;Persist Security Info=True";
        }

        public OleDbConnection Connect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
                
            return connection;
        }

        public void disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
