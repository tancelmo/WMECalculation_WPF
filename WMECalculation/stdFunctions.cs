using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WMECalculation
{
    class StdFunctions
    {
        public static void InstanceApp(Window currentWindow)
        {
            // 1 instance of app

            Process proc = Process.GetCurrentProcess();
            int count = Process.GetProcesses().Where(p =>
                p.ProcessName == proc.ProcessName).Count();

            if (count > 1)
            {
                MessageBox.Show(Convert.ToString(currentWindow.FindResource("InstanceApp")));
                App.Current.Shutdown();
            }
        }
        public static void StartUP(Window mainWindow, Image image, Label result)
        {
            IniFile readIni = new IniFile("config.ini");
            string currentLanguage = readIni.Read("Language");
            string currentTheme = readIni.Read("Theme");
            if (currentLanguage == "en-US")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                mainWindow.Resources.MergedDictionaries.Add(newRes);
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                result.Content = "0.00";
            }
            else if (currentLanguage == "pt-BR")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/pt-BR.xaml", UriKind.RelativeOrAbsolute);
                mainWindow.Resources.MergedDictionaries.Add(newRes);
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
                result.Content = "0,00";
            }
            else if (currentLanguage == "es-ES")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/es-ES.xaml", UriKind.RelativeOrAbsolute);
                mainWindow.Resources.MergedDictionaries.Add(newRes);
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
                result.Content = "0,00";
            }
            else
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                mainWindow.Resources.MergedDictionaries.Add(newRes);
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                result.Content = "0.00";
            }

            if (currentTheme == "Light")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/LightTheme.xaml", UriKind.RelativeOrAbsolute);
                mainWindow.Resources.MergedDictionaries.Add(newRes);
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/WMEInfo/wmecen_" + currentLanguage + "_" + currentTheme + ".png"));
                
            }
            else if (currentTheme == "Dark")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
                mainWindow.Resources.MergedDictionaries.Add(newRes);
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/WMEInfo/wmecen_" + currentLanguage + "_" + currentTheme + ".png"));

            }
            else
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/Light.xaml", UriKind.RelativeOrAbsolute);
                mainWindow.Resources.MergedDictionaries.Add(newRes);
            }

        }

        public static void CheckDbFiles(Window mainWindow)
        {
            var iniFile = new IniFile("config.ini");

            if (iniFile.Read("Database") == "Access")
            {
                if (!File.Exists("WMEData.accdb"))
                {
                    MessageBox.Show(Convert.ToString(mainWindow.FindResource("DbNotFound")));
                    Process.GetCurrentProcess().Kill();
                    //Application.Current.Shutdown(0);
                }
            }

                
        }

        public static void CheckConfigFiles(Window mainWindow)
        {
            if (!File.Exists("config.ini"))
            {
                MessageBox.Show(Convert.ToString(mainWindow.FindResource("ConfigNotFound")));
                Process.GetCurrentProcess().Kill();

            }
            if (!File.Exists("StringGears.ini"))
            {
                MessageBox.Show(Convert.ToString(mainWindow.FindResource("StringGearsNotFound")));
                Process.GetCurrentProcess().Kill();

            }

        }

        public static void CheckDataBaseEngine(Window mainWindow)
        {
            Connection conn = new Connection();
            OleDbCommand cmd = new OleDbCommand();

            var iniFile = new IniFile("config.ini");

            if (iniFile.Read("Database") == "Access")
            {
                try
                {
                    conn.Connect();
                    conn.disconnect();

                }
                catch
                {
                    MessageBox.Show(Convert.ToString(mainWindow.FindResource("NoEngine")));
                    var readIni = new IniFile("config.ini");
                    var EngineLink = readIni.Read("AccessDatabaseEngineLink");
                    System.Diagnostics.Process.Start(EngineLink);
                    Process.GetCurrentProcess().Kill();

                }
            }

            
        }

        public static void LoadGearCorrection(Window gearCorrection)
        {
            #region
            var readIni = new IniFile("config.ini");
            var currentLanguage = readIni.Read("Language");
            var currentTheme = readIni.Read("Theme");
            if (currentLanguage == "en-US")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
            else if (currentLanguage == "pt-BR")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/pt-BR.xaml", UriKind.RelativeOrAbsolute);
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
            else if (currentLanguage == "es-ES")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/es-ES.xaml", UriKind.RelativeOrAbsolute);
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
            else
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }

            if (currentTheme == "Light")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/LightTheme.xaml", UriKind.RelativeOrAbsolute);
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
            else if (currentTheme == "Dark")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
            else
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/Light.xaml", UriKind.RelativeOrAbsolute);
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
            #endregion
            
        }

        public static void LoadGearWMEInfo(Window window, Image image)
        {
            #region
            IniFile readIni = new IniFile("config.ini");
            string currentLanguage = readIni.Read("Language");
            string currentTheme = readIni.Read("Theme");
            if (currentLanguage == "en-US")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                window.Resources.MergedDictionaries.Add(newRes);
            }
            else if (currentLanguage == "pt-BR")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/pt-BR.xaml", UriKind.RelativeOrAbsolute);
                window.Resources.MergedDictionaries.Add(newRes);
            }
            else if (currentLanguage == "es-ES")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/es-ES.xaml", UriKind.RelativeOrAbsolute);
                window.Resources.MergedDictionaries.Add(newRes);
            }
            else
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                window.Resources.MergedDictionaries.Add(newRes);
            }

            if (currentTheme == "Light")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/LightTheme.xaml", UriKind.RelativeOrAbsolute);
                window.Resources.MergedDictionaries.Add(newRes);
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/WMEInfo/wmeinfo_" + currentLanguage + "_light.png"));
            }
            else if (currentTheme == "Dark")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
                window.Resources.MergedDictionaries.Add(newRes);
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/WMEInfo/wmeinfo_" + currentLanguage + "_dark.png"));
            }
            else
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Themes/Light.xaml", UriKind.RelativeOrAbsolute);
                window.Resources.MergedDictionaries.Add(newRes);
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/WMEInfo/wmeinfo_en-US_light.png"));
            }
            #endregion

        }

        public static void GearsImg(Image r1, ComboBox cbR1)
        {

            try
            {              
                r1.Source = new BitmapImage(new Uri(Convert.ToString(Directory.GetCurrentDirectory().Replace("\\", "/") + "/images/gears/" + Convert.ToString(cbR1.SelectedItem).Replace(";", "_").Remove(5) + ".png")));
            }
            catch
            {
                r1.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/nogearimg.png"));
            }
        }

        public static void AddGears(ComboBox cbG1, ComboBox cbG2, Window mainWindow)
        {
            var iniFile = new IniFile("config.ini");

            if (iniFile.Read("Database") == "Access")
            {
                Connection conn = new Connection();
                OleDbCommand cmd = new OleDbCommand();
                try
                {
                    cmd.CommandText = "select * from CalibrationGears";
                    cmd.Connection = conn.Connect();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbG1.Items.Add(reader["StringGear"]);
                        cbG2.Items.Add(reader["StringGear"]);
                        cbG1.SelectedIndex = 22;
                        cbG2.SelectedIndex = 22;
                    }
                    conn.disconnect();

                }
                catch
                {
                    MessageBox.Show(Convert.ToString(mainWindow.FindResource("DbNotFound")));
                }
            }
            else
            {                
                cbG1.ItemsSource = File.ReadLines("StringGears.ini");
                cbG2.ItemsSource = File.ReadLines("StringGears.ini");
                cbG1.SelectedIndex = 22;
                cbG2.SelectedIndex = 22;
            }
                
        }

        public static void LoadSplash(Window gearCorrection)
        {
            var readIni = new IniFile("config.ini");
            var currentLanguage = readIni.Read("Language");
            var currentTheme = readIni.Read("Theme");
            if (currentLanguage == "en-US")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                //this.Resources.MergedDictionaries.Clear();
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
            else if (currentLanguage == "pt-BR")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/pt-BR.xaml", UriKind.RelativeOrAbsolute);
                //this.Resources.MergedDictionaries.Clear();
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
            else
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("/Assets/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                //this.Resources.MergedDictionaries.Clear();
                gearCorrection.Resources.MergedDictionaries.Add(newRes);
            }
        }

        public static void SetLanguage(Window window, string language, Label result, Image image)
        {

            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Assets/Languages/" + language + ".xaml", UriKind.RelativeOrAbsolute);
            window.Resources.MergedDictionaries.Add(newRes);
            var readIni = new IniFile("config.ini");
            readIni.Write("Language", language);
            string currentLanguage = readIni.Read("Language");
            string currentTheme = readIni.Read("Theme");
            image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/WMEInfo/wmecen_" + currentLanguage + "_" + currentTheme + ".png"));
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
            if(language == "en-US")
            {
                result.Content = "0.00";
            }
            else
            {
                result.Content = "0,00";
            }
        }

        public static void ChangeTheme(Window window, string theme, TextBox tbQmax, TextBox tbQ07, TextBox tbQ04, TextBox tbQ025, TextBox tbQ015, TextBox tbQ010, TextBox tbQ005, TextBox tbQm, ComboBox cbG, ComboBox cbR, Label lbResult, Image image)
        {
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Themes/" + theme + "Theme.xaml", UriKind.RelativeOrAbsolute);
            window.Resources.MergedDictionaries.Add(newRes);
            var readIni = new IniFile("config.ini");
            readIni.Write("Theme", theme);
            string currentLanguage = readIni.Read("Language");
            string currentTheme = readIni.Read("Theme");
            image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/WMEInfo/wmecen_" + currentLanguage + "_" + currentTheme + ".png"));

            Calculate.ExecuteCalc(tbQmax, tbQ07, tbQ04, tbQ025, tbQ015, tbQ010, tbQ005, tbQm, cbG, cbR, lbResult);

        }

        public static void CheckIsNumber(TextBox textBox, string msg)
        {
            double checkValidValue;

            if (textBox.Text == String.Empty)
            {

            }
            else if (!double.TryParse(textBox.Text, out checkValidValue))
            {
                MessageBox.Show(msg);
                textBox.Clear();
                textBox.Focus();
            }
        }

        public static void CheckKeyPress(TextBox checkKeyPress, KeyEventArgs e)
        {
            var iniFile = new IniFile("config.ini");
            if(iniFile.Read("Language") == "pt-BR" || iniFile.Read("Language") == "es-ES")
            {
                if ((char)e.Key >= 44 && (char)e.Key <= 69) // || (char)e.Key == 88)
                {  //limitar caracteres  a numeros virgula 
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;

                }

                if (e.Key == Key.Enter)
                {
                    SendKeys.Send(Key.Tab);
                }

                if (e.Key == Key.Decimal || e.Key == Key.OemPeriod)
                {
                    e.Handled = true;

                    SendKeys.Send(Key.OemComma);
                    checkKeyPress.Select(5, 5);
                }

                if (e.Key == Key.Decimal || e.Key == Key.OemPeriod)
                {
                    if (checkKeyPress.Text.IndexOf(",") != -1)
                    {
                        e.Handled = true;
                    }

                    if (checkKeyPress.Text.Length < 5 && checkKeyPress.Text.IndexOf(',') == -1)
                    {
                        checkKeyPress.Text += ",";
                        checkKeyPress.Select(5, 5);
                    }


                }

                if (e.Key == Key.OemComma && checkKeyPress.Text.IndexOf(",") != -1)
                {
                    e.Handled = true;

                }
                if (e.Key == Key.OemComma)
                {

                    e.Handled = true;
                    if (checkKeyPress.Text.IndexOf(",") == -1)
                    {
                        checkKeyPress.Text += ",";
                        checkKeyPress.Select(5, 5);
                    }

                }

                if (checkKeyPress.Text == ",")
                {
                    checkKeyPress.Text = "0,";
                    checkKeyPress.Select(5, 5);

                }

                if (checkKeyPress.Text == "-,")
                {
                    checkKeyPress.Text = "-0,";
                    checkKeyPress.Select(5, 5);
                }
            }
            else
            {
                if ((char)e.Key >= 44 && (char)e.Key <= 69) // || (char)e.Key == 88)
                {  //limitar caracteres  a numeros virgula 
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;

                }

                if (e.Key == Key.Enter)
                {
                    SendKeys.Send(Key.Tab);
                }

                if (e.Key == Key.OemComma)
                {
                    e.Handled = true;

                    SendKeys.Send(Key.Decimal);
                    checkKeyPress.Select(5, 5);
                }

                if (e.Key == Key.Decimal || e.Key == Key.OemPeriod )
                {
                    if (checkKeyPress.Text.IndexOf(".") != -1)
                    {
                        e.Handled = true;
                    }

                    if (checkKeyPress.Text.Length < 5 && checkKeyPress.Text.IndexOf('.') == -1)
                    {
                        e.Handled = true;
                        checkKeyPress.Text += ".";
                        checkKeyPress.Select(5, 5);
                    }


                }

                if (e.Key == Key.OemComma && checkKeyPress.Text.IndexOf(".") != -1)
                {
                    e.Handled = true;

                }
                if (e.Key == Key.OemComma)
                {

                    e.Handled = true;
                    if (checkKeyPress.Text.IndexOf(".") == -1)
                    {
                        checkKeyPress.Text += ".";
                        checkKeyPress.Select(5, 5);
                    }

                }

                if (checkKeyPress.Text == ".")
                {
                    checkKeyPress.Text = "0.";
                    checkKeyPress.Select(5, 5);

                }

                if (checkKeyPress.Text == "-.")
                {
                    checkKeyPress.Text = "-0.";
                    checkKeyPress.Select(5, 5);
                }
            }
            

        }

        public static void UpdateComboBox(ComboBox comboBoxG, ComboBox comboBoxR, GroupBox gbErrors, GroupBox gbQi)
        {

            if (comboBoxG.SelectedItem == null)
            {
                comboBoxG.SelectedItem = "G10";
            }
            if (comboBoxR.SelectedItem == null)
            {
                comboBoxR.SelectedItem = "20:1";
            }
            if (gbErrors.IsEnabled == false)
            {
                
                gbErrors.IsEnabled = true;
                gbQi.IsEnabled = true;
            }
        }

        public static void ResizeForm(Window window, Label lbResult, ComboBox comboBoxR, GroupBox gbErrors, GroupBox gbQi, TextBox Qmax, TextBox Q07, TextBox Q04, TextBox Q025, TextBox Q015, TextBox Q01, TextBox Q005, TextBox Qmin, Label lbQ04, Label lbFQ04, Label lbQ25, Label lbFQ25, Label lbQ15, Label lbFQ15, Label lbQ10, Label lbFQ10, Label lbQ05, Label lbFQ05, Label lbQm, Label lbFQm, Label lbwTQ04, Label lbwFQ04, Label lbwTQ25, Label lbwFQ25, Label lbwTQ15, Label lbwFQ15, Label lbwTQ10, Label lbwFQ10, Label lbwTQ05, Label lbwFQ05, Label lbwTQm, Label lbwFQm)
        {

            var readIni = new IniFile("config.ini");
            var currentLanguage = readIni.Read("Language");

            Qmax.Clear();
            Q07.Clear();
            Q04.Clear();
            Q025.Clear();
            Q015.Clear();
            Q01.Clear();
            Q005.Clear();
            Qmin.Clear();
            if (currentLanguage == "en-US")
            {
                lbResult.Content = "0.00";
            }
            else
            {
                lbResult.Content = "0,00";
            }
            
            if (Convert.ToString(comboBoxR.SelectedItem) == "10:1")
            {
                // hide labels forom GroupBox Errors

                lbQ15.Visibility = Visibility.Hidden;
                lbFQ15.Visibility = Visibility.Hidden;
                lbQ10.Visibility = Visibility.Hidden;
                lbFQ10.Visibility = Visibility.Hidden;
                lbQ05.Visibility = Visibility.Hidden;
                lbFQ05.Visibility = Visibility.Hidden;

                // hide labels from GroupBox QiQmax

                lbwTQ15.Visibility = Visibility.Hidden;
                lbwFQ15.Visibility = Visibility.Hidden;
                lbwTQ10.Visibility = Visibility.Hidden;
                lbwFQ10.Visibility = Visibility.Hidden;
                lbwTQ05.Visibility = Visibility.Hidden;
                lbwFQ05.Visibility = Visibility.Hidden;

                //hide textbox

                Q015.Visibility = Visibility.Hidden;
                Q01.Visibility = Visibility.Hidden;
                Q005.Visibility = Visibility.Hidden;

                //chage grid

                Grid.SetRow(lbQm, 4);
                Grid.SetRow(lbFQm, 4);
                Grid.SetRow(Qmin, 4);
                Grid.SetRow(lbwTQm, 4);
                Grid.SetRow(lbwFQm, 4);
                Animation.AnimateGroupBoxHeight(gbErrors, 245, false);
                Animation.AnimateGroupBoxHeight(gbQi, 245, false);
                Animation.AnimateWindowHeight(window, 455, false);
                //window.Height = 445;
            }
            else if (Convert.ToString(comboBoxR.SelectedItem) == "20:1")
            {
                // hide labels forom GroupBox Errors

                lbQ15.Visibility = Visibility.Hidden;
                lbFQ15.Visibility = Visibility.Hidden;
                lbQ05.Visibility = Visibility.Hidden;
                lbFQ05.Visibility = Visibility.Hidden;

                // hide labels from GroupBox QiQmax

                lbwTQ15.Visibility = Visibility.Hidden;
                lbwFQ15.Visibility = Visibility.Hidden;
                lbwTQ05.Visibility = Visibility.Hidden;
                lbwFQ05.Visibility = Visibility.Hidden;

                //hide textbox

                Q015.Visibility = Visibility.Hidden;
                Q005.Visibility = Visibility.Hidden;

                //change grid

                Grid.SetRow(lbQ10, 4);
                Grid.SetRow(lbFQ10, 4);
                Grid.SetRow(Q01, 4);
                Grid.SetRow(lbwTQ10, 4);
                Grid.SetRow(lbwFQ10, 4);

                Grid.SetRow(lbQm, 5);
                Grid.SetRow(lbFQm, 5);
                Grid.SetRow(Qmin, 5);
                Grid.SetRow(lbwTQm, 5);
                Grid.SetRow(lbwFQm, 5);

                Animation.AnimateWindowHeight(window, 492, false);
                Animation.AnimateGroupBoxHeight(gbErrors, 282, false);
                Animation.AnimateGroupBoxHeight(gbQi, 282, false);
                //window.Height = 555;
            }

            else if (Convert.ToString(comboBoxR.SelectedItem) == "30:1")
            {
                // hide labels forom GroupBox Errors

                lbQ15.Visibility = Visibility.Hidden;
                lbFQ15.Visibility = Visibility.Hidden;

                // hide labels from GroupBox QiQmax

                lbwTQ15.Visibility = Visibility.Hidden;
                lbwFQ15.Visibility = Visibility.Hidden;

                //hide textbox

                Q015.Visibility = Visibility.Hidden;

                //change grid

                Grid.SetRow(lbQ10, 4);
                Grid.SetRow(lbFQ10, 4);
                Grid.SetRow(Q01, 4);
                Grid.SetRow(lbwTQ10, 4);
                Grid.SetRow(lbwFQ10, 4);

                Grid.SetRow(lbQ05, 5);
                Grid.SetRow(lbFQ05, 5);
                Grid.SetRow(Q005, 5);
                Grid.SetRow(lbwTQ05, 5);
                Grid.SetRow(lbwFQ05, 5);

                Grid.SetRow(lbQm, 6);
                Grid.SetRow(lbFQm, 6);
                Grid.SetRow(Qmin, 6);
                Grid.SetRow(lbwTQm, 6);
                Grid.SetRow(lbwFQm, 6);

                Animation.AnimateWindowHeight(window, 529, false);
                Animation.AnimateGroupBoxHeight(gbErrors, 319, false);
                Animation.AnimateGroupBoxHeight(gbQi, 319, false);

            }
            else
            {
                // hide labels forom GroupBox Errors

                lbQ04.Visibility = Visibility.Hidden;
                lbFQ04.Visibility = Visibility.Hidden;
                lbQ10.Visibility = Visibility.Hidden;
                lbFQ10.Visibility = Visibility.Hidden;

                // hide labels from GroupBox QiQmax

                lbwTQ04.Visibility = Visibility.Hidden;
                lbwFQ04.Visibility = Visibility.Hidden;
                lbwTQ10.Visibility = Visibility.Hidden;
                lbwFQ10.Visibility = Visibility.Hidden;

                //hide textbox

                Q04.Visibility = Visibility.Hidden;
                Q01.Visibility = Visibility.Hidden;

                //change grid

                Grid.SetRow(lbQ25, 2);
                Grid.SetRow(lbFQ25, 2);
                Grid.SetRow(Q025, 2);
                Grid.SetRow(lbwTQ25, 2);
                Grid.SetRow(lbwFQ25, 2);

                Grid.SetRow(lbQ15, 3);
                Grid.SetRow(lbFQ15, 3);
                Grid.SetRow(Q015, 3);
                Grid.SetRow(lbwTQ15, 3);
                Grid.SetRow(lbwFQ15, 3);

                Grid.SetRow(lbQ05, 4);
                Grid.SetRow(lbFQ05, 4);
                Grid.SetRow(Q005, 4);
                Grid.SetRow(lbwTQ05, 4);
                Grid.SetRow(lbwFQ05, 4);

                Grid.SetRow(lbQm, 5);
                Grid.SetRow(lbFQm, 5);
                Grid.SetRow(Qmin, 5);
                Grid.SetRow(lbwTQm, 5);
                Grid.SetRow(lbwFQm, 5);

                Animation.AnimateWindowHeight(window, 492, false);
                Animation.AnimateGroupBoxHeight(gbErrors, 282, false);
                Animation.AnimateGroupBoxHeight(gbQi, 282, false);
            }
        }

        public static void ResetForm(Window window, Label lbResult, ComboBox comboBoxR, GroupBox gbErrors, GroupBox gbQi, TextBox Qmax, TextBox Q07, TextBox Q04, TextBox Q025, TextBox Q015, TextBox Q01, TextBox Q005, TextBox Qmin, Label lbQ04, Label lbFQ04, Label lbQ25, Label lbFQ25, Label lbQ15, Label lbFQ15, Label lbQ10, Label lbFQ10, Label lbQ05, Label lbFQ05, Label lbQm, Label lbFQm, Label lbwTQ04, Label lbwFQ04, Label lbwTQ25, Label lbwFQ25, Label lbwTQ15, Label lbwFQ15, Label lbwTQ10, Label lbwFQ10, Label lbwTQ05, Label lbwFQ05, Label lbwTQm, Label lbwFQm)
        {
            Qmax.Clear();
            Q07.Clear();
            Q04.Clear();
            Q025.Clear();
            Q015.Clear();
            Q01.Clear();
            Q005.Clear();
            Qmin.Clear();

            // -- labels reset visibility gorupbox Errors

            lbQ04.Visibility = Visibility.Visible;
            lbFQ04.Visibility = Visibility.Visible;
            lbQ25.Visibility = Visibility.Visible;
            lbFQ25.Visibility = Visibility.Visible;
            lbQ15.Visibility = Visibility.Visible;
            lbFQ15.Visibility = Visibility.Visible;
            lbQ10.Visibility = Visibility.Visible;
            lbFQ10.Visibility = Visibility.Visible;
            lbQ05.Visibility = Visibility.Visible;
            lbFQ05.Visibility = Visibility.Visible;

            // --- labels reset visibility groupbox Qi/Qmax
            lbwTQ04.Visibility = Visibility.Visible;
            lbwFQ04.Visibility = Visibility.Visible;
            lbwTQ25.Visibility = Visibility.Visible;
            lbwFQ25.Visibility = Visibility.Visible;
            lbwTQ15.Visibility = Visibility.Visible;
            lbwFQ15.Visibility = Visibility.Visible;
            lbwTQ10.Visibility = Visibility.Visible;
            lbwFQ10.Visibility = Visibility.Visible;
            lbwTQ05.Visibility = Visibility.Visible;
            lbwFQ05.Visibility = Visibility.Visible;

            // --- textbos reset
            Q04.Visibility = Visibility.Visible;
            Q015.Visibility = Visibility.Visible;
            Q01.Visibility = Visibility.Visible;
            Q005.Visibility = Visibility.Visible;

            // -- reset posirions all Q04

            Grid.SetRow(lbQ04, 2);
            Grid.SetRow(lbFQ04, 2);
            Grid.SetRow(Q04, 2);
            Grid.SetRow(lbwTQ04, 2);
            Grid.SetRow(lbwFQ04, 2);

            // -- reset posirions all Q025

            Grid.SetRow(lbQ25, 3);
            Grid.SetRow(lbFQ25, 3);
            Grid.SetRow(Q025, 3);
            Grid.SetRow(lbwTQ25, 3);
            Grid.SetRow(lbwFQ25, 3);

            // -- reset posirions all Q015

            Grid.SetRow(lbQ15, 4);
            Grid.SetRow(lbFQ15, 4);
            Grid.SetRow(Q015, 4);
            Grid.SetRow(lbwTQ15, 4);
            Grid.SetRow(lbwFQ15, 4);

            // -- reset posirions all Q010

            Grid.SetRow(lbQ10, 5);
            Grid.SetRow(lbFQ10, 5);
            Grid.SetRow(Q01, 5);
            Grid.SetRow(lbwTQ10, 5);
            Grid.SetRow(lbwFQ10, 5);

            // -- reset posirions all Q005

            Grid.SetRow(lbQ05, 6);
            Grid.SetRow(lbFQ05, 6);
            Grid.SetRow(Q005, 6);
            Grid.SetRow(lbwTQ05, 6);
            Grid.SetRow(lbwFQ05, 6);

            // --- reset positions all qmin

            Grid.SetRow(lbQm, 7);
            Grid.SetRow(lbFQm, 7);
            Grid.SetRow(Qmin, 7);
            Grid.SetRow(lbwTQm, 7);
            Grid.SetRow(lbwFQm, 7);
            
            lbResult.Content = "0,00";
            lbResult.ClearValue(Control.ForegroundProperty);
            window.Height = 555;
        }

        public static void ClearValues(TextBox Qmax, TextBox Q07, TextBox Q04, TextBox Q025, TextBox Q015, TextBox Q01, TextBox Q005, TextBox Qmin)
        {
            Qmax.Clear();
            Q07.Clear();
            Q04.Clear();
            Q025.Clear();
            Q015.Clear();
            Q01.Clear();
            Q005.Clear();
            Qmin.Clear();
        }

        public static void ColorFromGearsText(TextBox Qmax, TextBox Q07, TextBox Q04, TextBox Q025, TextBox Q015, TextBox Q01, TextBox Q005, TextBox Qmin, bool Check)
        {
            if (Check == true)
            {
                Qmax.Foreground = Brushes.Green;
                Q07.Foreground = Brushes.Green;
                Q04.Foreground = Brushes.Green;
                Q025.Foreground = Brushes.Green;
                Q015.Foreground = Brushes.Green;
                Q01.Foreground = Brushes.Green;
                Q005.Foreground = Brushes.Green;
                Qmin.Foreground = Brushes.Green;
            }
            else
            {
                Qmax.ClearValue(Control.ForegroundProperty);
                Q07.ClearValue(Control.ForegroundProperty);
                Q04.ClearValue(Control.ForegroundProperty);
                Q025.ClearValue(Control.ForegroundProperty);
                Q015.ClearValue(Control.ForegroundProperty);
                Q01.ClearValue(Control.ForegroundProperty);
                Q005.ClearValue(Control.ForegroundProperty);
                Qmin.ClearValue(Control.ForegroundProperty);
            }
            
        }
    }
}
