using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WMECalculation
{
    /// <summary>
    /// Lógica interna para GearCorrection.xaml
    /// </summary>
    public partial class GearCorrection : Window
    {
        public GearCorrection()
        {
            InitializeComponent();
            StdFunctions.LoadGearCorrection(this);
            StdFunctions.AddGears(cbCurrentGears, cbNewGears, this);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbCurrentGears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StdFunctions.GearsImg(gears1, cbCurrentGears);
            CalculateGears.CalculateGears1(cbCurrentGears, this);
            CalculateGears.ResultGears(cbCurrentGears,cbNewGears, lbCalcGears);
        }

        private void cbNewGears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StdFunctions.GearsImg(gears2, cbNewGears);
            CalculateGears.CalculateGears2(cbNewGears, this);
            CalculateGears.ResultGears(cbCurrentGears, cbNewGears, lbCalcGears);
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            CalculateGears.checkCalutateBtn = true;
            CalculateGears.ResultGears(cbCurrentGears, cbNewGears, lbCalcGears);
            Close();
            
        }

        private void cbCurrentGears_MouseEnter(object sender, MouseEventArgs e)
        {
            _ = cbCurrentGears.Focus();
        }

        private void cbNewGears_MouseEnter(object sender, MouseEventArgs e)
        {
            _ = cbNewGears.Focus();
        }
    }
}
