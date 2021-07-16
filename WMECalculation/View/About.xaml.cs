using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace WMECalculation.View
{
    /// <summary>
    /// Lógica interna para About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            StdFunctions.LoadGearCorrection(this);
            LbVersion.Content = FindResource("Version") + " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
