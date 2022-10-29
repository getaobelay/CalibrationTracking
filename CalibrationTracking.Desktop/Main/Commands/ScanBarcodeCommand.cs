using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Main.ViewModels;
using CalibrationTracking.Desktop.Main.Windows;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationTracking.Desktop.Main.Commands
{
    public class ScanBarcodeCommand : AsyncCommand
    {
        private readonly ScanBarcodeWindow _mainWindow;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        public ScanBarcodeCommand(ScanBarcodeWindow mainWindow, CalibrationAddOrEditWindow calibrationAddOrEditWindow)
        {
            _mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(ScanBarcodeWindow));
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow ?? throw new ArgumentNullException(nameof(CalibrationAddOrEditWindow));
        }

        public override bool CanExecute()
        {
            return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            var barcode = ((ScanBarcodeViewModel)_mainWindow.DataContext).Barcode;

            if (!string.IsNullOrWhiteSpace(barcode))
            {
                OpenWindow("1311245");
            }
        }

        private void HandleErorr()
        {
            ((ScanBarcodeViewModel)_mainWindow.DataContext).Barcode = string.Empty;
        }

        private void OpenWindow(string? barcode)
        {
            ((ScanBarcodeViewModel)_mainWindow.DataContext).Barcode = string.Empty;

            _mainWindow.Close();

            _calibrationAddOrEditWindow.Show();

        }
    }

}
