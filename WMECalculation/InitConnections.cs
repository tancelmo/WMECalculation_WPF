using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WMECalculation
{
    
    public class InitConnections
    {
        readonly Connection conn = new Connection();
        readonly OleDbCommand cmd = new OleDbCommand();
		


		public void ConnectComboBox(ComboBox cbCalibre, ComboBox cbRange, Window mainWindow)
        {
            cmd.CommandText = "select * from Data";

			try
			{
				cmd.Connection = conn.Connect();
                

				

				OleDbDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					cbCalibre.Items.Add(reader["G_Calibre"]);
				}
				for (int index = 3; index < reader.FieldCount; index++)
				{
					cbRange.Items.Add(reader.GetName(index));
				}
                conn.disconnect();

			}
			catch (Exception)
			{
				MessageBox.Show(Convert.ToString(mainWindow.FindResource("connectionError01")) + " " +Convert.ToString(Environment.CurrentDirectory) + "\\WMEData.accdb");
				mainWindow.Close();

			}
		}

    }
}
