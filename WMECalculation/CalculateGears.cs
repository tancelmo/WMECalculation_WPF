using System;
using System.Data.OleDb;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WMECalculation
{
    public class CalculateGears
    {

        public static double r1 = 0, r2 = 0, resultGear = 0;
        public static bool checkCalutateBtn;

        public static void CalculateGears1(ComboBox cb1, Window mainWindow)
        {
            var iniFile = new IniFile("config.ini");
            if (iniFile.Read("Database") == "Access")
            {
                Connection conn = new Connection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from CalibrationGears where StringGear='" + cb1.SelectedItem + "'";

                try
                {
                    cmd.Connection = conn.Connect();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        r1 = Convert.ToDouble(reader["Correction"]);
                    }
                    conn.disconnect();
                }
                catch
                {
                    _ = MessageBox.Show(Convert.ToString(mainWindow.FindResource("connectionError03")));
                }
            }
            else
            {
               
                    r1 = Convert.ToDouble(iniFile.Read(Convert.ToString(cb1.SelectedItem), "Gears_Correction"), CultureInfo.InvariantCulture);
                    
                    
                

            }

        }

        public static void CalculateGears2(ComboBox cb2, Window mainWindow)
        {
            var iniFile = new IniFile("config.ini");
            if (iniFile.Read("Database") == "Access")
            {
                Connection conn = new Connection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from CalibrationGears where StringGear='" + cb2.SelectedItem + "'";

                try
                {
                    cmd.Connection = conn.Connect();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        r2 = Convert.ToDouble(reader["Correction"]);
                    }
                    conn.disconnect();
                }
                catch
                {
                    MessageBox.Show(Convert.ToString(mainWindow.FindResource("connectionError03")));
                }
            }
            else
            {
                
                    r2 = Convert.ToDouble(iniFile.Read(Convert.ToString(cb2.SelectedItem), "Gears_Correction"), CultureInfo.InvariantCulture);
                
            }

        }

        public static void ResultGears(ComboBox cb1, ComboBox cb2, Label lbResult)
        {
            if (cb1.Text == "" || cb2.Text == "")
            {

            }
            else
            {
                if (r1 + r2 <= 0 && r1 > r2)
                {
                    resultGear = Math.Abs(r1 - r2) * -1;
                }
                else if (r1 + r2 >= 0 && r1 > r2)
                {
                    resultGear = Math.Abs(r1 - r2) * -1;
                }

                else
                {
                    resultGear = Math.Abs(r1 - r2);
                }
                lbResult.Content = string.Format("{0:0.00}", resultGear) + " %";
            }
        }

        public static void ApplyCalculatedGears(TextBox Qmax, TextBox Q07, TextBox Q04, TextBox Q025, TextBox Q015, TextBox Q01, TextBox Q005, TextBox Qmin, double resultFromGears, Image imgGear1, Image imgGear2, Label lbTittle, Label arrow, Label gear1, Label gear2, Button btnClear)
        {
            if (Qmax.Text == "")
            {

            }
            else
            {
                Qmax.Text = string.Format("{0:0.00}", Convert.ToDouble(Qmax.Text) + resultFromGears);
            }
            if (Q07.Text == "")
            {

            }
            else
            {
                Q07.Text = string.Format("{0:0.00}", ((Convert.ToDouble(Q07.Text) + resultFromGears)));
            }
            if (Q04.Text == "")
            {

            }
            else
            {
                Q04.Text = string.Format("{0:0.00}", ((Convert.ToDouble(Q04.Text) + resultFromGears)));
            }
            if (Q025.Text == "")
            {

            }
            else
            {
                Q025.Text = string.Format("{0:0.00}", ((Convert.ToDouble(Q025.Text) + resultFromGears)));
            }
            if (Q015.Text == "")
            {

            }
            else
            {
                Q015.Text = string.Format("{0:0.00}", ((Convert.ToDouble(Q015.Text) + resultFromGears)));
            }
            if (Q01.Text == "")
            {

            }
            else
            {
                Q01.Text = string.Format("{0:0.00}", ((Convert.ToDouble(Q01.Text) + resultFromGears)));
            }
            if (Q005.Text == "")
            {

            }
            else
            {
                Q005.Text = string.Format("{0:0.00}", ((Convert.ToDouble(Q005.Text) + resultFromGears)));
            }
            if (Qmin.Text == "")
            {

            }
            else
            {
                Qmin.Text = string.Format("{0:0.00}", ((Convert.ToDouble(Qmin.Text) + resultFromGears)));
            }

            imgGear1.Visibility = Visibility.Visible;
            imgGear2.Visibility = Visibility.Visible;
            lbTittle.Visibility = Visibility.Visible;

            arrow.Visibility = Visibility.Visible;
            gear1.Visibility = Visibility.Visible;
            gear2.Visibility = Visibility.Visible;
            btnClear.Visibility = Visibility.Visible;

        }

        public static void ResetCalc(Image imgGear1, Image imgGear2, Label arrow, Label lbTittle, Label gear1, Label gear2, Button btnClear)
        {
            imgGear1.Visibility = Visibility.Hidden;
            imgGear2.Visibility = Visibility.Hidden;
            lbTittle.Visibility = Visibility.Hidden;
            btnClear.Visibility = Visibility.Hidden;
            arrow.Visibility = Visibility.Hidden;
            gear1.Visibility = Visibility.Hidden;
            gear2.Visibility = Visibility.Hidden;

        }
    }
}
