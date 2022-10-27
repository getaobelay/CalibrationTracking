using CalibrationTracking.Application.Departments.CreateDepartment;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Departments.Windows;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Departments.ViewModels;
using CalibrationTracking.Application.Calibrations.Commands.CreateCalibration;
using CalibrationTracking.Desktop.Calibrations.Windows;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class CalibrationAddOrEditCommand : AsyncCommand
    {
        private readonly IMediator _mediator;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;

        public CalibrationAddOrEditCommand(CalibrationAddOrEditWindow calibrationAddOrEditWindow, IMediator mediator)
        {
            _mediator = mediator;
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow;
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
            };

            var result = await _mediator.Send(command);


            if (result is not null)
            {
                ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Reload(result);

                _calibrationAddOrEditWindow.Close();
            }

        }
    }
}
