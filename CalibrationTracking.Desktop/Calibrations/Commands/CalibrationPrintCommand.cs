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
    public class CalibrationPrintCommand : AsyncCommand
    {
        private readonly CalibrationPrintWindow _calibrationPrintWindow;

        public CalibrationPrintCommand(CalibrationPrintWindow calibrationPrintWindow)
        {
            _calibrationPrintWindow = calibrationPrintWindow;
        }



        public override bool CanExecute()
        {
            var viewModel = (CalibrationPrintViewModel)_calibrationPrintWindow.DataContext;


            return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            var viewModel = (CalibrationPrintViewModel)_calibrationPrintWindow.DataContext;


            PrintHelper.SetExcelFile(viewModel.CalibrationSKU, viewModel.EmployeeId, viewModel.SelectedEmployee, viewModel.SelectedDepartment,
                viewModel.SelectedDevice,viewModel.Description, viewModel.Frequency, viewModel.Reciver, System.DateTime.Now, viewModel.OrderSku);
        }
    }
}