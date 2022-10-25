using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;

namespace CalibrationTracking.Desktop.Main.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public MainWindowViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

    }
}
