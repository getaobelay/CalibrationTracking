using CalibrationTracking.Application.Departments.CreateDepartment;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Departments.Windows;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Departments.ViewModels;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class CalibrationAddOrEditCommand : AsyncCommand
    {
        private readonly IMediator _mediator;
        private readonly DepartmentAddOrEditWindow _departmentAddOrEditWindow;
      
        public CalibrationAddOrEditCommand(DepartmentAddOrEditWindow departmentAddOrEditWindow, IMediator mediator)
        {
            _mediator = mediator;
            _departmentAddOrEditWindow = departmentAddOrEditWindow;
        }



        public override bool CanExecute()
        {
            var viewModel = (DepartmentAddOrEditViewModel)_departmentAddOrEditWindow.DataContext;

            bool canSaveForm = !string.IsNullOrWhiteSpace(viewModel.Name) && RunningTasks.Count() == 0;

            return canSaveForm;
        }

        public override async Task ExecuteAsync()
        {
            var viewModel = (CalibrationViewModel)_departmentAddOrEditWindow.DataContext;

            var command = new CreateDepartmentCommand
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
            };

            var result = await _mediator.Send(command);

         
            if(result is not null)
            {
                ((CalibrationViewModel)_departmentAddOrEditWindow.DataContext).Reload(result);

                _departmentAddOrEditWindow.Close();
            }
            
        }
    }
}
