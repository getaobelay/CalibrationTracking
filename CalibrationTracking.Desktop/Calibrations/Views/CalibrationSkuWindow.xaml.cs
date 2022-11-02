using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Main.ViewModels;
using CalibrationTracking.Desktop.Main.Windows;
using CalibrationTracking.Desktop.Services;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalibrationTracking.Desktop.Calibrations.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalibrationSkuWindow : Window
    {
        private readonly CalibrationTableView _calibrationTableView;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;

        public CalibrationSkuWindow(CalibrationTableView calibrationTableView, CalibrationAddOrEditWindow calibrationAddOrEditWindow)
        {
            InitializeComponent();

            DataContext = new CalibrationSkuViewModel(this, calibrationAddOrEditWindow);

            _calibrationTableView = calibrationTableView;
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow;

            Closing += ScanBarcodeWindow_Closing;
        }

        private void ScanBarcodeWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Visibility = Visibility.Hidden;
                e.Cancel = true;
                ShowInTaskbar = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            WindowSizeHelper.Minimize(this);
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            MouseDown += delegate { DragMove(); };
        }

        private void IconButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();


            Show();
        }

        private void txtBarcode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

namespace CalibrationTracking.Desktop.Calibrations.Windows
{
    public static class FocusBehavior
    {
        public static readonly DependencyProperty FocusFirstProperty =
            DependencyProperty.RegisterAttached(
                "FocusFirst",
                typeof(bool),
                typeof(FocusBehavior),
                new PropertyMetadata(false, OnFocusFirstPropertyChanged));

        public static bool GetFocusFirst(Control control)
        {
            return (bool)control.GetValue(FocusFirstProperty);
        }

        public static void SetFocusFirst(Control control, bool value)
        {
            control.SetValue(FocusFirstProperty, value);
        }

        private static void OnFocusFirstPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            Control control = obj as Control;
            if (control == null || !(args.NewValue is bool))
            {
                return;
            }

            if ((bool)args.NewValue)
            {
                control.Loaded += (sender, e) =>
                    control.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
}
