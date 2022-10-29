using CalibrationTracking.Desktop.Main.ViewModels;
using System.Windows.Controls;


namespace CalibrationTracking.Desktop.Main.Windows
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }
    }
}
