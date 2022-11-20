using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Views;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace CalibrationTracking.Desktop.Calibrations.Windows
{
    /// <summary>
    /// Interaction logic for CalibrationAddOrEditWindow.xaml
    /// </summary>
    public partial class CalibrationAddOrEditWindow : Window
    {
        public CalibrationTableView CalibrationTableView { get; }

        public CalibrationAddOrEditWindow(Views.CalibrationTableView calibrationTableView)
        {
            InitializeComponent();

            Closing += CalibrationAddOrEditWindow_Closing;
            DataContext = new CalibrationAddOrEditViewModel(this, null,calibrationTableView);

            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.LongDatePattern = "MMM.yyyy"; //This can be used for one type of DatePicker
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"; //for the second type
            Thread.CurrentThread.CurrentCulture = ci;

            CalibrationTableView = calibrationTableView;
        }

        private void CalibrationAddOrEditWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Visibility = Visibility.Hidden;
                e.Cancel = true;
                this.ShowInTaskbar = false;

                ((CalibrationAddOrEditViewModel)DataContext).Reload(null);

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
