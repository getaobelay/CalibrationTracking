using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Main.ViewModels;
using CalibrationTracking.Desktop.Services;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CalibrationTracking.Desktop.Main.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ScanBarcodeWindow : Window
    {
        private readonly BarcodeManager _barcodeManager;

        public ScanBarcodeWindow(Calibrations.Views.CalibrationTableView calibrationTableView)
        {
            InitializeComponent();
            DataContext = new ScanBarcodeViewModel(this,calibrationTableView);

            _barcodeManager = new((DataContext as ScanBarcodeViewModel).BarcodeAction);
            Closing += ScanBarcodeWindow_Closing;

       
            //ToolTipService.SetInitialShowDelay(button, 10);
            //ToolTipService.SetShowDuration(button, 2000);

        }

        private void ScanBarcodeWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                _barcodeManager.Close(sender, e);

                this.Visibility = Visibility.Hidden;
                e.Cancel = true;
                this.ShowInTaskbar = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void header_Loaded(object sender, RoutedEventArgs e)
        {
            InitHeader(sender as Grid);
        }

        private void InitHeader(Grid header)
        {
            var restoreIfMove = false;

            header.MouseLeftButtonDown += (s, e) =>
            {
                if (e.ClickCount == 2)
                {
                    if (ResizeMode == ResizeMode.CanResize ||
                        ResizeMode == ResizeMode.CanResizeWithGrip)
                    {
                        SwitchState();
                    }
                }
                else
                {
                    if (WindowState == WindowState.Maximized)
                    {
                        restoreIfMove = true;
                    }

                    DragMove();
                }
            };
            header.MouseLeftButtonUp += (s, e) =>
            {
                restoreIfMove = false;
            };
            header.MouseMove += (s, e) =>
            {
                if (restoreIfMove)
                {
                    restoreIfMove = false;
                    var mouseX = e.GetPosition(this).X;
                    var width = RestoreBounds.Width;
                    var x = mouseX - width / 2;

                    if (x < 0)
                    {
                        x = 0;
                    }
                    else
                    if (x + width > SystemParameters.PrimaryScreenWidth)
                    {
                        x = SystemParameters.PrimaryScreenWidth - width;
                    }

                    WindowState = WindowState.Normal;
                    Left = x;
                    Top = 0;
                    DragMove();
                }
            };
        }

        private void SwitchState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    {
                        WindowState = WindowState.Maximized;
                        break;
                    }
                case WindowState.Maximized:
                    {
                        WindowState = WindowState.Normal;
                        break;
                    }
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

namespace CalibrationTracking.Desktop.Main.Windows
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
