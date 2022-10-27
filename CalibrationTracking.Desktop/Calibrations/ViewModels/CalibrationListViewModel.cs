using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using CalibrationTracking.Application.Employees.Queries.GetAllEmployees;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CalibrationTracking.Desktop.Calibrations.ViewModels
{
    internal class CalibrationListViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public CalibrationListViewModel(IMediator mediator)
        {

            _mediator = mediator;

            LoadData();

        }

        private async void LoadData()
        {
            await GetAllCalibration();
        }


        private ObservableCollection<Calibration>? _calibrations;

        public ObservableCollection<Calibration>? Calibrations
        { get { return _calibrations; } set { _calibrations = value; RaisePropertyChanged(); } }




        private async Task GetAllCalibration()
        {
            var query = new GetAllCalibrationsQuery();

            var calibrations = await _mediator.Send(query);

            _calibrations = new(calibrations);

            RaisePropertyChanged(nameof(Calibrations));
        }
    }
}
