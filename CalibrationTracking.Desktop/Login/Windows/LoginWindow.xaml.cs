using CalibrationTracking.Infrastructure.UserRepostories;
using System.Windows;
using CalibrationTracking.Desktop.Login.ViewModels;
using MediatR;

namespace CalibrationTracking.Desktop.Login.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(IMediator mediator, MainWindow mainWindow)
        {
            InitializeComponent();

            DataContext = new LoginViewModel(new AuthenticationService(), mainWindow, mediator, this);

        }
    }

}