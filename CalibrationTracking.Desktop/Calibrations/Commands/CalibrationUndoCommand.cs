using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Shared;
using CalibrationTracking.Desktop.CustomeMessageBox;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class CalibrationUndoCommand : AsyncCommand
    {
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        private readonly CalibrationTableView _calibrationTableView;
        public CalibrationUndoCommand(CalibrationAddOrEditWindow calibrationAddOrEditWindow, CalibrationTableView calibrationTableView)
        {
            _calibrationAddOrEditWindow = calibrationAddOrEditWindow ??= new CalibrationAddOrEditWindow(calibrationTableView);
            _calibrationTableView = calibrationTableView;
        }



        public override bool CanExecute()
        {
            var viewModel = (CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext;

            return  viewModel.IsDirty && RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {

            bool? Result = new CustomMessageBoxWindow($"האם אתה בטוח שברצונך למחוק שינויים שביצעת בטופס ?", MessageType.Warning, MessageButtons.OkCancel).ShowDialog();

            if (Result.Value)
            {
                ((CalibrationAddOrEditViewModel)_calibrationAddOrEditWindow.DataContext).Undo();
            }

         
        }
    }
}
