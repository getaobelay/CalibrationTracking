using CalibrationTracking.Application.Calibrations.Queries.Exceptions;
using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.CustomeMessageBox;
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
    public class CalibrationSkuCommand : AsyncCommand
    {
        private readonly CalibrationSkuWindow _calibrationSkuWindow;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        public CalibrationSkuCommand(CalibrationSkuWindow calibrationSkuWindow, CalibrationAddOrEditWindow calibrationAddOrEditWindow)
        {
            _calibrationSkuWindow = calibrationSkuWindow ?? throw new ArgumentNullException(nameof(CalibrationSkuWindow));
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow ?? throw new ArgumentNullException(nameof(CalibrationAddOrEditWindow));
        }

        public override bool CanExecute()
        {
            return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            var calibrationSKU = ((CalibrationSkuViewModel)_calibrationSkuWindow.DataContext).CalibrationSku;

            if (!string.IsNullOrWhiteSpace(calibrationSKU))
            {
                var query = new GetSingleCalibrationBySkuQuery
                {
                    CalibrationSKU = calibrationSKU
                };


                var calibration = await UserControlHelper.Mediator.Send(query);

                if(calibration is not null)
                {
                    _calibrationSkuWindow.Hide();

                    bool? Result = new CustomMessageBoxWindow($"מכשיר אם המקט {calibrationSKU} כבר קיים במערכת.", MessageType.Error, MessageButtons.OkCancel).ShowDialog();

                    if (Result.Value)
                    {
                        _calibrationSkuWindow.Show();

                    }
                }

                else
                {

                    _calibrationAddOrEditWindow.Title.Text = "קליטת מכשיר ";

                    ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Reload(null);
                    ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).CalibrationSKU = calibrationSKU;


                    _calibrationSkuWindow.Hide();
                    _calibrationAddOrEditWindow.ShowDialog();

                    await Task.CompletedTask;
                }

            }
        }

    
    }

}
