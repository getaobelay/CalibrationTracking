using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Employees.ViewModels;
using CalibrationTracking.Desktop.Employees.Windows;
using CalibrationTracking.Infrastructure.Interfaces;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Application.Employees.Commands.CreateEmployee;
using CalibrationTracking.Desktop.Login.Windows;
using CalibrationTracking.Desktop.Employees.Commands;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;

namespace CalibrationTracking.Desktop.Login.Commands
{
    public class LoginCommand : AsyncCommand
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly LoginWindow _loginWindow;
        private readonly MainWindow _mainWindow;

        public LoginCommand(LoginWindow loginWindow, MainWindow mainWindow, IAuthenticationService authenticationService)
        {
            _loginWindow = loginWindow;
            _mainWindow = mainWindow;
            _authenticationService = authenticationService;
        }

        public override bool CanExecute()
        {

            return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {

            _loginWindow.Close();

            _mainWindow.Show();
            
        }
    }
}
