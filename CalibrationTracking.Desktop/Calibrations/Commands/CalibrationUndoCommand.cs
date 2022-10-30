using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Application.Calibrations.Commands.CreateCalibration;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Shared;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class CalibrationUndoCommand : AsyncCommand
    {
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        private readonly CalibrationTableView _calibrationTableView;
        public CalibrationUndoCommand(CalibrationAddOrEditWindow calibrationAddOrEditWindow, CalibrationTableView calibrationTableView)
        {
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow ??= new CalibrationAddOrEditWindow(calibrationTableView);
            _calibrationTableView = calibrationTableView;
        }



        public override bool CanExecute()
        {
            var viewModel = (CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext;

            return  !string.IsNullOrWhiteSpace(viewModel.Frequency) ||
                    !string.IsNullOrWhiteSpace(viewModel.SelectedDevice) ||
                    !string.IsNullOrWhiteSpace(viewModel.SelectedEmployee) ||
                    !string.IsNullOrWhiteSpace(viewModel.Description) 
                    && RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Undo();

        }
    }
}
