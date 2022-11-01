using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Application.Calibrations.Commands.CreateCalibration;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Calibrations.Views;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class CalibrationAddOrEditCommand : AsyncCommand
    {
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        private readonly CalibrationTableView _calibrationTableView;
        public CalibrationAddOrEditCommand(CalibrationAddOrEditWindow calibrationAddOrEditWindow, CalibrationTableView calibrationTableView)
        {
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow;
            _calibrationTableView = calibrationTableView;
        }



        public override bool CanExecute()
        {
            var viewModel = (CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext;

            return  !string.IsNullOrWhiteSpace(viewModel.Frequency) &&
                    !string.IsNullOrWhiteSpace(viewModel.SelectedDevice) &&
                    !string.IsNullOrWhiteSpace(viewModel.SelectedEmployee) &&
                    !string.IsNullOrWhiteSpace(viewModel.Description) 
                    && RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            var viewModel = (CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext;

            var command = new CreateCalibrationCommand
            {
                Device = viewModel.SelectedDevice,
                Employee = viewModel.SelectedEmployee,
                Frequency = viewModel.Frequency,
                Description = viewModel.Description,
                Remarks = viewModel.Remarks,
                CalibrationSKU = viewModel.CalibrationSKU,
                Department = viewModel.SelectedDepartment,
            };

            var result = await UserControlHelper.Mediator.Send(command);


            if (result is not null)
            {
                ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Reload(result);

                _calibrationAddOrEditWindow.Close();

                ((CalibrationListViewModel)_calibrationTableView.DataContext).LoadData();


            }

        }
    }
}
