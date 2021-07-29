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

namespace WMECalculation.View
{
    /// <summary>
    /// Lógica interna para FormulaInfo.xaml
    /// </summary>
    public partial class FormulaInfo : Window
    {
        public FormulaInfo()
        {
            InitializeComponent();
            StdFunctions.LoadGearWMEInfo(this, WMEInfoImg);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
