using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class OpenCreateCalibrationWindowCommand : AsyncCommand
    {
        private readonly IMediator _mediator;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        private readonly CalibrationListWindow _calibrationListWindow;
    
        public OpenCreateCalibrationWindowCommand(CalibrationListWindow calibrationListWindow, CalibrationAddOrEditWindow calibrationAddOrEditWindow, IMediator mediator)
        {
            _mediator = mediator;
            _calibrationListWindow = calibrationListWindow;
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow;
        }


        public override bool CanExecute()
        {
            return  RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
           ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Reload(null);


            _calibrationAddOrEditWindow.Show();
        }
    }
}
