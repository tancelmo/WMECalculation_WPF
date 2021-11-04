using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WMECalculation.View;

/// <summary>
/// ToDo Resize Form
/// selected item cb 1 e cb2
/// </summary>

namespace WMECalculation
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public double resultFromGears;

        public MainWindow()
        {
            InitializeComponent();

            ///
            /// 1 instance
            /// 

            StdFunctions.InstanceApp(this);

            /// Initialize Loading page
            Loading loading = new Loading();
            loading.Show();
            loading.CheckFiles.Visibility = Visibility.Visible;
            Thread.Sleep(200);

            /// check files
            /// 

            
            loading.CheckFiles.Visibility = Visibility.Visible;
            StdFunctions.CheckConfigFiles(this);
            StdFunctions.StartUP(this, img, lbResult);
            StdFunctions.CheckDbFiles(this);
            loading.CheckFiles.Visibility = Visibility.Hidden;

            /// check database engine
            /// 
            
            loading.lbDbEngine.Visibility = Visibility.Visible;
            StdFunctions.CheckDataBaseEngine(this);
            loading.lbDbEngine.Visibility = Visibility.Hidden;
            /// 
            /// Read basic config on startup
            /// 

            loading.InitConnections.Visibility = Visibility.Visible;
            InitConnections initConnections = new InitConnections();
            initConnections.ConnectComboBox(comboBoxG, comboBoxR, this);
            loading.InitConnections.Visibility = Visibility.Hidden;
            loading.CheckFiles.Visibility = Visibility.Visible;
            loading.Close();

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuEn_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.SetLanguage(this, "en-US", lbResult, img);
            StdFunctions.ClearValues(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm);
        }
        private void MenuPt_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.SetLanguage(this, "pt-BR", lbResult, img);
            StdFunctions.ClearValues(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm);
        }
        private void MenuES_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.SetLanguage(this, "es-ES", lbResult, img);
            StdFunctions.ClearValues(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm);
        }

        private void MenuDark_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.ChangeTheme(this, "Dark", Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult, img);
        }

        private void MenuLight_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.ChangeTheme(this, "Light", Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult, img);
        }

        private void menuCorrection_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxG.SelectedItem == null || comboBoxR.SelectedItem == null)
            {
                _ = MessageBox.Show(Convert.ToString(FindResource("NoGSize")));
            }
            else
            {
                CalculateGears.checkCalutateBtn = false;
                GearCorrection gearCorrection = new GearCorrection();
                gearCorrection.ShowDialog();
                if (CalculateGears.checkCalutateBtn)
                {
                    resultFromGears = CalculateGears.resultGear;
                    CalculateGears.ApplyCalculatedGears(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, resultFromGears, imgGear1, imgGear2, lbTittle, arrow, gearValue1, gearValue2, btnClear);
                    Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
                    StdFunctions.GearsImg(imgGear1, gearCorrection.cbCurrentGears);
                    StdFunctions.GearsImg(imgGear2, gearCorrection.cbNewGears);
                    lbTittle.Content = Convert.ToString(FindResource("AppliedCorrection")) + " " + string.Format("{0:0.00}", resultFromGears) + " %";
                    gearValue1.Content = gearCorrection.cbCurrentGears.Text.Substring(0, 5);
                    gearValue2.Content = gearCorrection.cbNewGears.Text.Substring(0, 5);
                    StdFunctions.ColorFromGearsText(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, CalculateGears.checkCalutateBtn);
                }
            }
        }


        private void Qmax_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Qmax, Convert.ToString(FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Q07_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Q07, Convert.ToString(FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Q04_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Q04, Convert.ToString(this.FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Q025_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Q025, Convert.ToString(this.FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Q15_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Q015, Convert.ToString(this.FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Q010_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Q010, Convert.ToString(this.FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Q005_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Q005, Convert.ToString(this.FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Qm_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Qm, Convert.ToString(this.FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Qmax_KeyDown(object sender, KeyEventArgs e)
        {
            StdFunctions.CheckKeyPress(Qmax, e);
           
        }

        private void Q07_KeyDown(object sender, KeyEventArgs e)
        {
            StdFunctions.CheckKeyPress(Q07, e);
        }

        private void Q04_KeyDown(object sender, KeyEventArgs e)
        {
            StdFunctions.CheckKeyPress(Q04, e);
        }

        private void Q025_KeyDown(object sender, KeyEventArgs e)
        {
            StdFunctions.CheckKeyPress(Q025, e);
        }

        private void Q015_KeyDown(object sender, KeyEventArgs e)
        {
            StdFunctions.CheckKeyPress(Q015, e);
        }

        private void Q010_KeyDown(object sender, KeyEventArgs e)
        {
            StdFunctions.CheckKeyPress(Q010, e);
        }

        private void Q005_KeyDown(object sender, KeyEventArgs e)
        {
            StdFunctions.CheckKeyPress(Q005, e);
        }

        private void Qm_KeyDown(object sender, KeyEventArgs e)
        {
            StdFunctions.CheckKeyPress(Qm, e);
        }

        private void comboBoxG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StdFunctions.UpdateComboBox(comboBoxG, comboBoxR, gbErros, gbQi);
            SetFlowRate.SetFlow(comboBoxG, comboBoxR, lbFQmax, lbFQ07, lbFQ04, lbFQ25, lbFQ15, lbFQ10, lbFQ05, lbFQm, lbwFQm);
        }

        private void comboBoxR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StdFunctions.UpdateComboBox(comboBoxG, comboBoxR, gbErros, gbQi);
            SetFlowRate.SetFlow(comboBoxG, comboBoxR, lbFQmax, lbFQ07, lbFQ04, lbFQ25, lbFQ15, lbFQ10, lbFQ05, lbFQm, lbwFQm);
            StdFunctions.ResetForm(this, lbResult, comboBoxR, gbErros, gbQi, Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, lbQ04, lbFQ04, lbQ25, lbFQ25, lbQ15, lbFQ15, lbQ10, lbFQ10, lbQ05, lbFQ05, lbQm, lbFQm, lbwTQ04, lbwFQ04, lbwTQ25, lbwFQ25, lbwTQ15, lbwFQ15, lbwTQ10, lbwFQ10, lbwTQ05, lbwFQ05, lbwTQm, lbwFQm);
            StdFunctions.ResizeForm(this, lbResult, comboBoxR, gbErros, gbQi, Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, lbQ04,  lbFQ04,  lbQ25,  lbFQ25,  lbQ15,  lbFQ15,  lbQ10,  lbFQ10,  lbQ05,  lbFQ05,  lbQm,  lbFQm, lbwTQ04, lbwFQ04, lbwTQ25, lbwFQ25, lbwTQ15, lbwFQ15, lbwTQ10, lbwFQ10, lbwTQ05, lbwFQ05, lbwTQm, lbwFQm);
        }

        private void comboBoxG_MouseEnter(object sender, MouseEventArgs e)
        {
            comboBoxG.Focus();
        }

        private void comboBoxR_MouseEnter(object sender, MouseEventArgs e)
        {
            comboBoxR.Focus();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            
            resultFromGears *= -1;
            CalculateGears.ApplyCalculatedGears(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, resultFromGears, imgGear1, imgGear2, arrow, gearValue1, gearValue2, lbTittle, btnClear);
            CalculateGears.ResetCalc(imgGear1, imgGear2, arrow, lbTittle, gearValue1, gearValue2, btnClear);
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
            StdFunctions.ColorFromGearsText(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, CalculateGears.checkCalutateBtn = false);

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FormulaInfo formulaInfo = new FormulaInfo();
            formulaInfo.ShowDialog();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    }
}
