using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Employees.Windows;
using CalibrationTracking.Desktop.Login.ViewModels;
using CalibrationTracking.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HybridTagCreator.DesktopUI.HybridTagViews.Commands
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