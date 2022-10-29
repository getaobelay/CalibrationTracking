using CalibrationTracking.Desktop.Calibrations.ViewModels;
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

namespace CalibrationTracking.Desktop.Calibrations.Windows
{
    /// <summary>
    /// Interaction logic for CalibrationPrintWindow.xaml
    /// </summary>
    public partial class CalibrationPrintWindow : Window
    {
        private bool isDataSaved;

        public CalibrationPrintWindow()
        {
            InitializeComponent();

            Closing += CalibrationAddOrEditWindow_Closing;
            isDataSaved = true;
            DataContext = new CalibrationPrintViewModel(this, null);

        }

        private void CalibrationAddOrEditWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Visibility = Visibility.Hidden;
                e.Cancel = true;
                this.ShowInTaskbar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
