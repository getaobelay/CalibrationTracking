using CalibrationTracking.Core.Departments;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Employees.Commands;
using CalibrationTracking.Desktop.Employees.Windows;
using CalibrationTracking.Infrastructure.Interfaces;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using MediatR;
using System;
using System.Collections.ObjectModel;

namespace CalibrationTracking.Desktop.Employees.ViewModels
{
    internal class EmployeeAddOrEditViewModel : BaseViewModel<Employee>
    {

        public EmployeeAddOrEditViewModel(Employee model,EmployeeAddOrEditWindow employeeAddOrEditWindow, IMediator mediator) : base(model)
        {

            EmployeeAddOrEditCommand = new EmployeeAddOrEditCommand(employeeAddOrEditWindow, mediator);

            Reload(model);

        }

        private string _firstname;

        public string FirstName
        {
            get
            {
                if (_firstname == null && Model != null)
                {
                    _firstname = Model.FirstName;
                }

                return _firstname;
            }

            set
            {
                if (!string.Equals(_firstname, value))
                {
                    _firstname = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _lastname;

        public string LastName
        {
            get
            {
                if (_lastname == null && Model != null)
                {
                    _lastname = Model.LastName;
                }

                return _lastname;
            }

            set
            {
                if (!string.Equals(_lastname, value))
                {
                    _lastname = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _email;

        public string Email
        {
            get
            {
                if (_email == null && Model != null)
                {
                    _email = Model.Email;
                }

                return _email;
            }

            set
            {
                if (!string.Equals(_email, value))
                {
                    _email = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        private Guid _selectedDepartment;

        public Guid SelectedDepartment
        {
            get
            {
                if (_selectedDepartment == null && Model.DepartmentId != null)
                {
                    _selectedDepartment = Model.DepartmentId;
                }

                return _selectedDepartment;
            }

            set
            {
                if (!string.Equals(_selectedDepartment, value))
                {
                    _selectedDepartment = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get
            {
                if (_phoneNumber == null && Model != null)
                {
                    _phoneNumber = Model.PhoneNumber;
                }

                return _phoneNumber;
            }

            set
            {
                if (!string.Equals(_phoneNumber, value))
                {
                    _phoneNumber = value;
                    RaisePropertyChanged();
                }
            }

        }

        public EmployeeAddOrEditCommand EmployeeAddOrEditCommand { get; protected set; }

        private ObservableCollection<Department>? _departments;

        public ObservableCollection<Department>? Departments
        { get { return _departments; } set { _departments = value; RaisePropertyChanged(); } }


        public override void Reload(Employee model)
        {
            _firstname = string.Empty;
            _lastname = string.Empty;

            RaisePropertyChanged(nameof(FirstName));
            RaisePropertyChanged(nameof(LastName));
            ;

            base.Reload(null);
        }

        public override Employee ToModel()
        {
            return base.ToModel();
        }

        public void Undo()
        {
            Reload(Model);
        }
    }
}