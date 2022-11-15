using CalibrationTracking.Desktop.Base;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;

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


            PrintHelper.PrintCalibration(viewModel.CalibrationSKU, viewModel.SelectedEmployee, viewModel.SelectedDepartment,
                viewModel.SelectedDevice,viewModel.Description, viewModel.Frequency, System.DateTime.Now);
        }
    }
}