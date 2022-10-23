using CalibrationTracking.Core.Departments;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace CalibrationTracking.Desktop.Employees.ViewModels
{
    internal class EmployeeAddOrEditViewModel : BaseViewModel<Employee>
    {
        private readonly IAuthenticationService _authenticationService;

        public EmployeeAddOrEditViewModel(Employee model) : base(model)
        {
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