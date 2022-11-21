using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.CustomeMessageBox;
using CalibrationTracking.Desktop.Main.ViewModels;
using CalibrationTracking.Desktop.Main.Windows;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Application.Calibrations.Exceptions;
using CalibrationTracking.Application.Calibrations.Queries.GetSingleCalibration;
using CalibrationTracking.Desktop.Helpers;

namespace CalibrationTracking.Desktop.Main.Commands
{
    public class ScanBarcodeCommand : AsyncCommand
    {
        private readonly ScanBarcodeWindow _scanBarcodeWindow;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        
        public ScanBarcodeCommand(ScanBarcodeWindow scanBarcodeWindow, CalibrationAddOrEditWindow calibrationAddOrEditWindow)
        {
            _scanBarcodeWindow = scanBarcodeWindow ?? throw new ArgumentNullException(nameof(ScanBarcodeWindow));
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow ?? throw new ArgumentNullException(nameof(CalibrationAddOrEditWindow));
        }

        public override bool CanExecute()
        {
            return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            var barcode = ((ScanBarcodeViewModel)_scanBarcodeWindow.DataContext).Barcode;
            var calibrationPrintWindow = new CalibrationPrintWindow(_scanBarcodeWindow);

            if (!string.IsNullOrWhiteSpace(barcode))
            {
                var query = new GetSingleCalibrationBySkuQuery
                {
                    CalibrationSKU = barcode
                };

                await _scanBarcodeWindow.Dispatcher.Invoke(async () =>
                {
                    _scanBarcodeWindow.Hide();

                    try
                    {
                        var result = await UserControlHelper.Mediator.Send(query);

                        calibrationPrintWindow.DataContext = new CalibrationPrintViewModel(calibrationPrintWindow, result, _scanBarcodeWindow);

                        calibrationPrintWindow.Title.Text = "הזמנה לטיפול";

                        calibrationPrintWindow.Show();

                    }


                    catch (CalibrationNotFoundException ex)
                    {

                        bool? Result = new CustomMessageBoxWindow($"מכשיר זה אינו קיים במערכת", MessageType.Error, MessageButtons.OkCancel).ShowDialog();

                        ((ScanBarcodeViewModel)_scanBarcodeWindow.DataContext).Barcode = null;

                        _scanBarcodeWindow.Show();

                    }

                    catch (Exception ex)
                    {
                        bool? Result = new CustomMessageBoxWindow(ex.Message, MessageType.Error, MessageButtons.OkCancel).ShowDialog();

                        if (Result.Value)
                        {

                        }

                    }

                });
            }
        }

    
    }

}
