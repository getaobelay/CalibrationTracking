using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Main.Windows;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace CalibrationTracking.Desktop.Calibrations.Windows
{
    /// <summary>
    /// Interaction logic for CalibrationPrintWindow.xaml
    /// </summary>
    public partial class CalibrationPrintWindow : Window
    {
        private bool isDataSaved;

        public CalibrationPrintWindow(ScanBarcodeWindow scanBarcodeWindow)
        {
            InitializeComponent();

            Closing += CalibrationAddOrEditWindow_Closing;
            isDataSaved = true;
            DataContext = new CalibrationPrintViewModel(this, null, scanBarcodeWindow);

            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.LongDatePattern = "MMM.yyyy"; //This can be used for one type of DatePicker
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"; //for the second type
            Thread.CurrentThread.CurrentCulture = ci;

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
