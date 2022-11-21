using CalibrationTracking.Desktop.Base;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Services.CustomeMessageBox;
using CalibrationTracking.Desktop.Helpers;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class CalibrationDeleteCommand : AsyncCommand
    {
        private readonly CalibrationTableView _calibrationTableView;
        public CalibrationDeleteCommand(CalibrationTableView calibrationTableView)
        {
            _calibrationTableView = calibrationTableView;
        }



        public override bool CanExecute()
        {
             return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            var result = UserControlHelper.DialogService.ShowMessageBox("האם אתה בטוח שברצנוך למחוק מכשיר זה", "מחק מכשיר", MessageBoxButton.YesNo, MessageBoxIcon.Warning);

         
        }
    }
}
