using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WMECalculation
{
    

    public class SetFlowRate
    {
        

        public static void SetFlow(ComboBox comboBoxG, ComboBox comboBoxR, Label lbFQmax, Label lbFQ07, Label lbFQ04, Label lbFQ25, Label lbFQ15, Label lbFQ10, Label lbFQ05, Label lbFQm, Label lbwFQm) {

            
            Connection conn = new Connection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from Data where G_Calibre='" + comboBoxG.SelectedItem + "'";
            cmd.Connection = conn.Connect();
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                double flow = Convert.ToDouble(reader["Qmax"]);
                double QiQmin = Convert.ToDouble(reader[Convert.ToString(comboBoxR.SelectedItem)]);

                lbFQmax.Content = (Convert.ToString(flow) + " m³/h");
                lbFQ07.Content = (Convert.ToString(flow * 0.7) + " m³/h");
                lbFQ04.Content = (Convert.ToString(flow * 0.4) + " m³/h");
                lbFQ25.Content = (Convert.ToString(flow * 0.25) + " m³/h");
                lbFQ15.Content = (Convert.ToString(flow * 0.15) + " m³/h");
                lbFQ10.Content = (Convert.ToString(flow * 0.10) + " m³/h");
                lbFQ05.Content = (Convert.ToString(flow * 0.05) + " m³/h");
                lbFQm.Content = (Convert.ToString(reader[Convert.ToString(comboBoxR.SelectedItem)] + " m³/h"));
                lbwFQm.Content = (Convert.ToString(QiQmin / flow));




            }

            conn.disconnect();

        }

    }

}
