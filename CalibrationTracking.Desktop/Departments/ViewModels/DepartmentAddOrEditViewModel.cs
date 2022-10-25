using CalibrationTracking.Core.Departments;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Departments.Commands;
using CalibrationTracking.Desktop.Departments.Windows;
using MediatR;

namespace CalibrationTracking.Desktop.Departments.ViewModels
{
    internal class DepartmentAddOrEditViewModel : BaseViewModel<Department>
    {
        private readonly IMediator _mediator;

        public DepartmentAddOrEditViewModel(IMediator mediator,DepartmentAddOrEditWindow departmentAddOrEditWindow, Department model) : base(model)
        {
            _mediator = mediator;
            DepartmentAddOrEditCommand = new DepartmentAddOrEditCommand(departmentAddOrEditWindow, mediator);

            Reload(model);

        }

        public DepartmentAddOrEditCommand DepartmentAddOrEditCommand { get; protected set; }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (!string.Equals(_name, value))
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }


        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                if (!string.Equals(_description, value))
                {
                    _description = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}