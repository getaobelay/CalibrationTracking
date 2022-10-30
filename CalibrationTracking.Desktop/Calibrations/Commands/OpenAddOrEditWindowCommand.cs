using CalibrationTracking.Desktop.Base;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using System;
using CalibrationTracking.Desktop.Calibrations.Views;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class OpenAddOrEditWindowCommand : AsyncCommand
    {
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        private readonly CalibrationTableView _calibrationTableView;

        public OpenAddOrEditWindowCommand(Views.CalibrationTableView calibrationTableView, CalibrationAddOrEditWindow calibrationAddOrEditWindow)
        {
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow;
            _calibrationTableView = calibrationTableView;
        }



        public override bool CanExecute()
        {
            return  
                    RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {


            _calibrationAddOrEditWindow.Title.Text = "מכשיר חדש";

            _calibrationAddOrEditWindow.DataContext = new CalibrationAddOrEditViewModel(_calibrationAddOrEditWindow, null, _calibrationTableView);


            _calibrationAddOrEditWindow.Show();

        }
    }
}
