﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            

            /// Initialize Loading page
            Loading loading = new Loading();
            loading.Show();

            /// check files
            /// 

            
            loading.CheckFiles.Visibility = Visibility.Visible;
            StdFunctions.CheckConfigFiles(this);
            StdFunctions.StartUP(this, menuDark, menuLight, menuLang, menuTheme, menuCorrection, menuAbout, img);
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
            
            loading.Close();

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuPt_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.SetLanguagePT(this, "pt-br");
        }

        private void MenuDark_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.ChangeTheme(this, "Dark", "white", menuDark, menuLight, menuLang, menuTheme, menuCorrection, menuAbout, Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult, img);
        }

        private void MenuEn_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.SetLanguagePT(this, "en");
        }

        private void MenuLight_Click(object sender, RoutedEventArgs e)
        {
            StdFunctions.ChangeTheme(this, "Light", "black", menuDark, menuLight, menuLang, menuTheme, menuCorrection, menuAbout, Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult, img);
        }

        private void menuCorrection_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxG.SelectedItem == null || comboBoxR.SelectedItem == null)
            {
                MessageBox.Show(Convert.ToString(this.FindResource("NoGSize")));
            }
            else
            {
                CalculateGears.checkCalutateBtn = false;
                GearCorrection gearCorrection = new GearCorrection();
                gearCorrection.ShowDialog();
                if (CalculateGears.checkCalutateBtn)
                {
                    resultFromGears = CalculateGears.resultGear;
                    CalculateGears.ApplyCalculatedGears(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, resultFromGears);
                    Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
                }
            }
            
            
        }


        private void Qmax_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Qmax, Convert.ToString(this.FindResource("CheckIsNumber")));
            Calculate.ExecuteCalc(Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm, comboBoxG, comboBoxR, lbResult);
        }

        private void Q07_LostFocus(object sender, RoutedEventArgs e)
        {
            StdFunctions.CheckIsNumber(Q07, Convert.ToString(this.FindResource("CheckIsNumber")));
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
            StdFunctions.ResizeForm(this,lbResult, comboBoxR, gbErros, gbQi, Qmax, Q07, Q04, Q025, Q015, Q010, Q005, Qm);
        }

        private void comboBoxG_MouseEnter(object sender, MouseEventArgs e)
        {
            comboBoxG.Focus();
        }

        private void comboBoxR_MouseEnter(object sender, MouseEventArgs e)
        {
            comboBoxR.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
