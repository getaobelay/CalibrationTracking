using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace CalibrationTracking.Desktop.Login.ViewModels
{
    internal class DepartmentViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public DepartmentViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


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


    }
}
