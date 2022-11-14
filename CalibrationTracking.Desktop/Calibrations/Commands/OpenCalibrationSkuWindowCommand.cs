using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Application.Calibrations.Commands.CreateCalibration;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using System;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Main.ViewModels;
using CalibrationTracking.Desktop.Main.Windows;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class OpenCalibrationSkuWindowCommand : AsyncCommand
    {
        private readonly CalibrationSkuWindow _calibrationSkuWindow;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        private readonly CalibrationTableView _calibrationTableView;
        
        public OpenCalibrationSkuWindowCommand(CalibrationSkuWindow calibrationSkuWindow, CalibrationAddOrEditWindow calibrationAddOrEditWindow, CalibrationTableView calibrationTableView)
        {
            _calibrationSkuWindow = calibrationSkuWindow;
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow;
            _calibrationTableView = calibrationTableView;
        }



        public override bool CanExecute()
        {
            var viewModel = (CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext;

            return  
                    RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            _calibrationSkuWindow.ShowDialog();
            ((CalibrationSkuViewModel)_calibrationSkuWindow.DataContext).CalibrationSku = null;

            await Task.CompletedTask;

        }
    }
}
