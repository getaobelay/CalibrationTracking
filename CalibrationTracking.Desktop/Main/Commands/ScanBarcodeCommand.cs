﻿using CalibrationTracking.Application.Calibrations.Queries.Exceptions;
using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Main.ViewModels;
using CalibrationTracking.Desktop.Main.Windows;
using CalibrationTracking.Desktop.Services.CustomeMessageBox;
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
                var query = new GetSingleCalibrationBySkuQuery
                {
                    CalibrationSKU = barcode
                };


                await _mainWindow.Dispatcher.Invoke(async () =>
                {
                    _mainWindow.Hide();
                    try
                    {
                        var result = await UserControlHelper.Mediator.Send(query);

                        var calibrationPrintWindow = new CalibrationPrintWindow();

                        calibrationPrintWindow.DataContext = new CalibrationPrintViewModel(calibrationPrintWindow, result);

                        calibrationPrintWindow.Title.Text = "ערוך מכשיר";
                        calibrationPrintWindow.Show();
                    }

                    catch (CalibrationNotFoundException ex) 
                    {

                        UserControlHelper.DialogService.ShowMessageBox(ex.Message, "לא ניתן להוסיף מכשיר חדש", MessageBoxButton.OKCancel, MessageBoxIcon.Exclamation);
                    }

                
                });
            }
        }

    
    }

}
