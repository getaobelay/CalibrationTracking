using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Application.Calibrations.Commands.CreateCalibration;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Application.Calibrations.Commands.UpdateCalibration;

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
            try
            {
                var viewModel = (CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext;

                Core.Calibrations.Calibration? result = null;

                if (viewModel.IsNew)
                {
                    result = await CreateCommand(viewModel);
                }

                else result = await EditCommand(viewModel);

                if (result is not null)
                {
                    ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Reload(result);

                    _calibrationAddOrEditWindow.Close();

                    ((CalibrationListViewModel)_calibrationTableView.DataContext).LoadData();


                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        private static async Task<Core.Calibrations.Calibration> EditCommand(CalibrationAddOrEditViewModel viewModel)
        {
            var command = new UpdateCalibrationCommand
            {
                CalibrationId = viewModel.Model.Id,
                Device = viewModel.SelectedDevice,
                Employee = viewModel.SelectedEmployee,
                Frequency = viewModel.Frequency,
                Description = viewModel.Description,
                Remarks = viewModel.Remarks,
                CalibrationSKU = viewModel.CalibrationSKU,
                Department = viewModel.SelectedDepartment,
            };

            var result = await UserControlHelper.Mediator.Send(command);
            return result;
        }

        private static async Task<Core.Calibrations.Calibration> CreateCommand(CalibrationAddOrEditViewModel viewModel)
        {
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
            return result;
        }
    }
}
