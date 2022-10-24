using CalibrationTracking.Desktop.Login.ViewModels;
using CalibrationTracking.Infrastructure.UserRepostories;
using System.Windows;

namespace CalibrationTracking.Desktop.Login.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            DataContext = new LoginViewModel(new AuthenticationService());

        }
    }

}