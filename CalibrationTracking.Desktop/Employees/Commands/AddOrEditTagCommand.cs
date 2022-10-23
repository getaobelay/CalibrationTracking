using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Employees.ViewModels;
using CalibrationTracking.Desktop.Employees.Windows;
using System.Linq;
using System.Threading.Tasks;

namespace CalibrationTracking.Desktop.Employees.Commands
{
    public class AddOrEditEmployeeCommand : BaseAsyncCommand
    {
        private readonly EmployeeAddOrEditWindow _employeeAddOrEditWindow;

        public AddOrEditEmployeeCommand(EmployeeAddOrEditWindow employeeAddOrEditWindow)
        {
            _employeeAddOrEditWindow = employeeAddOrEditWindow;
        }

        public override bool CanExecute()
        {
            var viewModel = (EmployeeAddOrEditViewModel)_employeeAddOrEditWindow.DataContext;

            return viewModel.Model is not null && viewModel.IsDirty && RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            var viewModel = (EmployeeAddOrEditViewModel)_employeeAddOrEditWindow.DataContext;

            await Task.CompletedTask;
        }
    }
}