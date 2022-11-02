using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Commands;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Main.Windows;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CalibrationTracking.Desktop.Calibrations.Views
{
    internal class CalibrationListViewModel : BaseViewModel
    {
        private readonly CalibrationTableView _calibrationTableView;
        private readonly ScanBarcodeWindow _scanBarcodeWindow;
        public CalibrationListViewModel(CalibrationTableView calibrationTableView)
        {
            _calibrationTableView = calibrationTableView;
            _scanBarcodeWindow = new ScanBarcodeWindow(calibrationTableView);
            OpenAddOrEditCommand = new OpenAddOrEditWindowCommand(calibrationTableView, new CalibrationAddOrEditWindow(calibrationTableView), _scanBarcodeWindow);
            OpenScanBarcodeCommand = new OpenPrintWindowCommand(_scanBarcodeWindow);
            LoadData();
        }

        public async void LoadData()
        {
            await GetAllCalibration();
        }




        private ObservableCollection<Calibration>? _calibrations;
        private Calibration _selectedCalibration;

        public ObservableCollection<Calibration>? Calibrations
        { get { return _calibrations; } set { _calibrations = value; RaisePropertyChanged(); } }


        public Calibration SelectedCalibration { get { return _selectedCalibration; } set { _selectedCalibration = value; RaisePropertyChanged(); } }

        public AsyncCommand OpenAddOrEditCommand { get; protected set; } 
        public AsyncCommand OpenScanBarcodeCommand { get; protected set; } 

        private async Task GetAllCalibration()
        {
            _calibrations = null;
            _selectedCalibration = null;

            var query = new GetAllCalibrationsQuery();

            var calibrations = await UserControlHelper.Mediator.Send(query);

            _calibrations = new(calibrations);


            RaisePropertyChanged(nameof(SelectedCalibration));
            RaisePropertyChanged(nameof(Calibrations));
        }


    }
}
