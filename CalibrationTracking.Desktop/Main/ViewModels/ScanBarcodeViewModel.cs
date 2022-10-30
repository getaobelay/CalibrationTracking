using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Main.Commands;
using CalibrationTracking.Desktop.Main.Windows;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace CalibrationTracking.Desktop.Main.ViewModels
{
    public class ScanBarcodeViewModel : BaseViewModel
    {
        private readonly ScanBarcodeWindow _mainWindow;
        private readonly CalibrationTableView _calibrationTableView;

        public IAsyncCommand ScanBarcodeCommand { get; protected set; }

        public ScanBarcodeViewModel(ScanBarcodeWindow mainWindow, CalibrationTableView calibrationTableView)
        {
            _mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(ScanBarcodeWindow));
            _calibrationTableView = calibrationTableView;
            ScanBarcodeCommand = new ScanBarcodeCommand(_mainWindow, new CalibrationAddOrEditWindow(calibrationTableView));
        }

        private string? _header;

        public string? Header
        {
            get
            {
                return _header;
            }

            set
            {
                if (_header != value)
                {
                    _header = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string? _barcode;

        public string? Barcode
        {
            get
            {
                return _barcode;
            }

            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void BarcodeAction(string barcode = null)
        {
            Barcode = barcode ?? Barcode;

            if (Barcode == null)
            {
                return;
            }

            if (!new Regex(@"^[0-9]+$").IsMatch(Barcode))
            {
                return;
            }
        }
    }
}
