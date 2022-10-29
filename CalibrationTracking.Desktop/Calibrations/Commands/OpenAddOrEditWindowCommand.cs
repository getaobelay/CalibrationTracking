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
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow ??= new CalibrationAddOrEditWindow();
            _calibrationTableView = calibrationTableView;
        }



        public override bool CanExecute()
        {
            return  
                    RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {

            var viewModel = ((CalibrationListViewModel)_calibrationTableView.DataContext);


            if (viewModel.SelectedCalibration is not null)
            {
                var query = new GetSingleCalibrationQuery
                {
                    CalibrationId = viewModel.SelectedCalibration.Id,
                };

                var result = await UserControlHelper.Mediator.Send(query);
                ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Reload(result);


            }

            else
            {
                ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Reload(null);


            }

            _calibrationAddOrEditWindow.Show();

        }
    }
}
