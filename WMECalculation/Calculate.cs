using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WMECalculation
{
    public class Calculate
    {


        public static void ExecuteCalc(TextBox tbQmax, TextBox tbQ07, TextBox tbQ04, TextBox tbQ025, TextBox tbQ015, TextBox tbQ010, TextBox tbQ005, TextBox tbQm, ComboBox cbG, ComboBox cbR, Label lbResult)
        {
            double check, result, Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qmin, Flow, QiQmin, QiQmax = 0, QiQ07 = 0, QiQ04 = 0, QiQ025 = 0, QiQ015 = 0, QiQ010 = 0, QiQ005 = 0, QiQm = 0;

            /// TryParse
            
            #region
            if (!double.TryParse(tbQmax.Text, out check))
            {
                Qmax = 0;
            }
            else
            {
                Qmax = Convert.ToDouble(tbQmax.Text);
                QiQmax = 0.4;
            }
            if (!double.TryParse(tbQ07.Text, out check))
            {
                Q07 = 0;
            }
            else
            {
                Q07 = Convert.ToDouble(tbQ07.Text);
                QiQ07 = 0.7;
            }
            if (!double.TryParse(tbQ04.Text, out check))
            {
                Q04 = 0;
            }
            else
            {
                Q04 = Convert.ToDouble(tbQ04.Text);
                QiQ04 = 0.4;
            }
            if (!double.TryParse(tbQ025.Text, out check))
            {
                Q025 = 0;
            }
            else
            {
                Q025 = Convert.ToDouble(tbQ025.Text);
                QiQ025 = 0.25;
            }
            if (!double.TryParse(tbQ015.Text, out check))
            {
                Q015 = 0;
            }
            else
            {
                Q015 = Convert.ToDouble(tbQ015.Text);
                QiQ015 = 0.15;
            }
            if (!double.TryParse(tbQ010.Text, out check))
            {
                Q010 = 0;
            }
            else
            {
                Q010 = Convert.ToDouble(tbQ010.Text);
                QiQ010 = 0.1;
            }
            if (!double.TryParse(tbQ005.Text, out check))
            {
                Q005 = 0;
            }
            else
            {
                Q005 = Convert.ToDouble(tbQ005.Text);
                QiQ005 = 0.05;
            }
            if (!double.TryParse(tbQm.Text, out check))
            {
                Qmin = 0;
                
            }
            else
            {
                Qmin = Convert.ToDouble(tbQm.Text);

                var iniFile = new IniFile("config.ini");

                if (iniFile.Read("Database") == "Access")
                {
                    Connection conn = new Connection();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn.Connect();
                    cmd.CommandText = "select* from Data where G_Calibre = '" + cbG.Text + "'";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Flow = Convert.ToDouble(reader["Qmax"]);
                        QiQmin = Convert.ToDouble(reader[Convert.ToString(cbR.Text)]);

                        QiQm = QiQmin / Flow;
                    }
                    conn.disconnect();
                }
                else
                {
                    Flow = Convert.ToDouble(iniFile.Read(Convert.ToString(cbG.SelectedItem), "Qmax_Flow"));
                    QiQmin = Convert.ToDouble(iniFile.Read(Convert.ToString(cbR.SelectedItem), "Qmin_" + Convert.ToString(cbG.SelectedItem)));

                    QiQm = QiQmin / Flow;
                }

                
            }
            #endregion



            double[] lbValues = new double[8] { Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qmin, };
            double[] QiValues = new double[8] { QiQmax, QiQ07, QiQ04, QiQ025, QiQ015, QiQ010, QiQ005, QiQm };

            double sum = 0;



            for (int i = 0; i < 8; i++)
            {
                sum += QiValues[i] * lbValues[i];
            }

            result = sum / (QiValues.Sum());
            lbResult.Content = String.Format("{0:0.00}", result);
            //MessageBox.Show(Convert.ToString(result));

            if (Double.IsNaN(result))
            {
                lbResult.Content = "0,00";
            }

            if (result > 0.404 || result < -0.404)
            {
                lbResult.Foreground = Brushes.Red;
            }
            else if (result <= 0.404 && result >= 0.40 || result > -0.404 && result < -0.4)
            {
                lbResult.Foreground = Brushes.Orange;
            }
            else
            {
                var readIni = new IniFile("config.ini");
                var currentTheme = readIni.Read("Theme");

                if (currentTheme == "Light")
                {
                    lbResult.Foreground = Brushes.Black;
                }
                else
                {

                    lbResult.Foreground = Brushes.White;
                }

            }
        }
    }
}
