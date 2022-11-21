﻿using CalibrationTracking.Desktop.Base;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Application.OrderSkus.Commands.IncrementOrderSku;
using CalibrationTracking.Application.ReceivedCalibrations.Commands.CreateReceivedCalibration;
using CalibrationTracking.Desktop.Main.Windows;
using CalibrationTracking.Desktop.Main.ViewModels;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class CalibrationPrintCommand : AsyncCommand
    {
        private readonly CalibrationPrintWindow _calibrationPrintWindow;
        private readonly ScanBarcodeWindow _scanBarcodeWindow;

        public CalibrationPrintCommand(CalibrationPrintWindow calibrationPrintWindow, ScanBarcodeWindow scanBarcodeWindow)
        {
            _calibrationPrintWindow = calibrationPrintWindow;
            _scanBarcodeWindow = scanBarcodeWindow;
        }



        public override bool CanExecute()
        {
            var viewModel = (CalibrationPrintViewModel)_calibrationPrintWindow.DataContext;


            return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            var viewModel = (CalibrationPrintViewModel)_calibrationPrintWindow.DataContext;

            try
            {
                var command = new IncrementOrderSkuCommand
                {
                    CalibrationId = viewModel.Model.Id
                };

                await UserControlHelper.Mediator.Send(command);


                _calibrationPrintWindow.Close();


                PrintHelper.PrintCalibration(viewModel.CalibrationSKU, viewModel.SelectedEmployee, viewModel.SelectedDepartment,
                    viewModel.SelectedDevice, viewModel.Description, viewModel.Frequency, System.DateTime.Now, viewModel.OrderSku.Value);


                ((ScanBarcodeViewModel)_scanBarcodeWindow.DataContext).Barcode = null;

                _scanBarcodeWindow.Show();

            }
            catch (System.Exception)
            {

                throw;
            }
       





        }
    }
}