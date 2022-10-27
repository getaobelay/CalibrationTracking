using CalibrationTracking.Application.Calibrations.Commands.CreateCalibration;
using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using CalibrationTracking.Application.Employees.Queries.GetAllEmployees;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Commands;
using CalibrationTracking.Desktop.Calibrations.Windows;
using MediatR;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CalibrationTracking.Desktop.Calibrations.ViewModels
{
    internal class CalibrationListViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public CalibrationListViewModel(CalibrationAddOrEditWindow calibrationAddOrEditWindow, CalibrationListWindow calibrationListWindow, IMediator mediator)
        {

            _mediator = mediator;

            OpenCreateCalibrationWindowCommand = new OpenCreateCalibrationWindowCommand(calibrationListWindow, calibrationAddOrEditWindow, mediator);
            PrintCalibrationCommand = new PrintCalibrationCommand(calibrationListWindow, mediator);
            LoadData();

        }

        public async void LoadData()
        {
            await GetAllCalibration();
        }


        public OpenCreateCalibrationWindowCommand OpenCreateCalibrationWindowCommand { get; protected set; }
        public PrintCalibrationCommand PrintCalibrationCommand { get; protected set; }

        private ObservableCollection<Calibration>? _calibrations;

        public ObservableCollection<Calibration>? Calibrations
        { get { return _calibrations; } set { _calibrations = value; RaisePropertyChanged(); } }




        private async Task GetAllCalibration()
        {
            _calibrations = null;

            var query = new GetAllCalibrationsQuery();

            var calibrations = await _mediator.Send(query);

            _calibrations = new(calibrations);

            RaisePropertyChanged(nameof(Calibrations));
        }


    }
}
