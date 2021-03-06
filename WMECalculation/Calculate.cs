using System;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace WMECalculation
{
    public class Calculate
    {
        
    public static void GetKFactor()
        {
            IniFile iniFile = new IniFile("config.ini");
            
            if (Convert.ToDouble(iniFile.Read("KFactorType", "WMECalculation")) == 1)
            {
                Globals.KQmax = Convert.ToDouble(iniFile.Read("KQmax", "KFactors"), CultureInfo.InvariantCulture);
                Globals.KQ07 = Convert.ToDouble(iniFile.Read("KQ07", "KFactors"), CultureInfo.InvariantCulture);
                Globals.KQ04 = Convert.ToDouble(iniFile.Read("KQ04", "KFactors"), CultureInfo.InvariantCulture);
                Globals.KQ025 = Convert.ToDouble(iniFile.Read("KQ025", "KFactors"), CultureInfo.InvariantCulture);
                Globals.KQ015 = Convert.ToDouble(iniFile.Read("KQ015", "KFactors"), CultureInfo.InvariantCulture);
                Globals.KQ010 = Convert.ToDouble(iniFile.Read("KQ010", "KFactors"), CultureInfo.InvariantCulture);
                Globals.KQ005 = Convert.ToDouble(iniFile.Read("KQ005", "KFactors"), CultureInfo.InvariantCulture);
                
            }
            else
            {
                Globals.KQmax = 0.4;
                Globals.KQ07 = 0.7;
                Globals.KQ04 = 0.4;
                Globals.KQ025 = 0.25;
                Globals.KQ015 = 0.15;
                Globals.KQ010 = 0.1;
                Globals.KQ005 = 0.05;
            }
            

            

        }
    public static void ExecuteCalc(TextBox tbQmax, TextBox tbQ07, TextBox tbQ04, TextBox tbQ025, TextBox tbQ015, TextBox tbQ010, TextBox tbQ005, TextBox tbQm, ComboBox cbG, ComboBox cbR, Label lbResult)
        {
            IniFile iniFile = new IniFile("config.ini");
            double result, Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qmin, Flow, QiQmin, QiQmax = 0, QiQ07 = 0, QiQ04 = 0, QiQ025 = 0, QiQ015 = 0, QiQ010 = 0, QiQ005 = 0, QiQm = 0;

            /// TryParse
            
            #region
            if (!double.TryParse(tbQmax.Text, out _))
            {
                Qmax = 0;
            }
            else
            {
                Qmax = Convert.ToDouble(tbQmax.Text);
                QiQmax = Globals.KQmax;
            }
            if (!double.TryParse(tbQ07.Text, out _))
            {
                Q07 = 0;
            }
            else
            {
                Q07 = Convert.ToDouble(tbQ07.Text);
                QiQ07 = Globals.KQ07; /*Convert.ToDouble(iniFile.Read("KQ07", "KFactors"), CultureInfo.InvariantCulture);*/ //0.7;
            }
            if (!double.TryParse(tbQ04.Text, out _))
            {
                Q04 = 0;
            }
            else
            {
                Q04 = Convert.ToDouble(tbQ04.Text);
                QiQ04 = Globals.KQ04; 
            }
            if (!double.TryParse(tbQ025.Text, out _))
            {
                Q025 = 0;
            }
            else
            {
                Q025 = Convert.ToDouble(tbQ025.Text);
                QiQ025 = Globals.KQ025; 
            }
            if (!double.TryParse(tbQ015.Text, out _))
            {
                Q015 = 0;
            }
            else
            {
                Q015 = Convert.ToDouble(tbQ015.Text);
                QiQ015 = Globals.KQ015; 
            }
            if (!double.TryParse(tbQ010.Text, out _))
            {
                Q010 = 0;
            }
            else
            {
                Q010 = Convert.ToDouble(tbQ010.Text);
                QiQ010 = Globals.KQ010;
            }
            if (!double.TryParse(tbQ005.Text, out _))
            {
                Q005 = 0;
            }
            else
            {
                Q005 = Convert.ToDouble(tbQ005.Text);
                QiQ005 = Globals.KQ005;
            }
            if (!double.TryParse(tbQm.Text, out _))
            {
                Qmin = 0;
                
            }
            else
            {
                Qmin = Convert.ToDouble(tbQm.Text);

                //IniFile iniFile = new IniFile("config.ini");

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
                    Flow = Convert.ToDouble(iniFile.Read(Convert.ToString(cbG.SelectedItem), "Qmax_Flow"), CultureInfo.InvariantCulture);
                    QiQmin = Convert.ToDouble(iniFile.Read(Convert.ToString(cbR.SelectedItem), "Qmin_" + Convert.ToString(cbG.SelectedItem)), CultureInfo.InvariantCulture);

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

            result = sum / QiValues.Sum();
            lbResult.Content = string.Format("{0:0.00}", result);

            if (double.IsNaN(result))
            {
                lbResult.Content = string.Format("{0:0.00}", 0, CultureInfo.InvariantCulture);

            }

            if (result > 0.404 || result < -0.404)
            {
                lbResult.Foreground = Brushes.Red;
            }
            else if ((result <= 0.404 && result >= 0.40) || result > -0.404 && result < -0.4)
            {
                lbResult.Foreground = Brushes.Orange;
            }
            else
            {

                lbResult.ClearValue(Control.ForegroundProperty);

            }
        }
    }
}
