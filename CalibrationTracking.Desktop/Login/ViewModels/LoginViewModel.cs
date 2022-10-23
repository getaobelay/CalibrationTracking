using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace CalibrationTracking.Desktop.Login.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private string _username;

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {

                if (!string.Equals(_username, value))
                {
                    _username = value;
                    RaisePropertyChanged();
                }

            }
        }


        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (!string.Equals(_password, value))
                {
                    _password = value;

                    RaisePropertyChanged();

                }
                RaisePropertyChanged();

            }
        }
    }
}
