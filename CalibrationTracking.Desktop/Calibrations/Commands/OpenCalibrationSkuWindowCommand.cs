using CalibrationTracking.Desktop.Base;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Calibrations.Views;

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
            ((CalibrationSkuViewModel)_calibrationSkuWindow.DataContext).CalibrationSku = null;

            _calibrationSkuWindow.ShowDialog();

            await Task.CompletedTask;

        }
    }
}
