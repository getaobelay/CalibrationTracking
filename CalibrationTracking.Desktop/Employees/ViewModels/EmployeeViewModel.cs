using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;

namespace CalibrationTracking.Desktop.Employees.ViewModels
{
    internal class EmployeeViewModel : BaseViewModel<Employee>
    {
        private readonly IAuthenticationService _authenticationService;

        public EmployeeViewModel(Employee model) : base(model)
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

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

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