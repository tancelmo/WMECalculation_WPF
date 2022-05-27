using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            lbCalcGears.Content = string.Format("{0:0.00}", 0) + " %";
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
