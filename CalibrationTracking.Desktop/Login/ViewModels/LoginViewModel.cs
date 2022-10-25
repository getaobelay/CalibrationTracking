using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Login.Commands;
using CalibrationTracking.Desktop.Login.Windows;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using MediatR;

namespace CalibrationTracking.Desktop.Login.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly LoginWindow _loginWindow;
        private readonly MainWindow _mainWindow;
        public LoginViewModel(IAuthenticationService authenticationService, MainWindow mainWindow, IMediator mediator, LoginWindow loginWindow)
        {
            _authenticationService = authenticationService;

            LoginCommand = new LoginCommand(loginWindow, mainWindow, authenticationService);
            _loginWindow = loginWindow;
        }

        public IAsyncCommand LoginCommand { get; protected set; }

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