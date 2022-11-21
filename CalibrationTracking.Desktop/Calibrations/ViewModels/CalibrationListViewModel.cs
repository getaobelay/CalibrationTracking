using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Commands;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Helpers;
using CalibrationTracking.Desktop.Main.Commands;
using CalibrationTracking.Desktop.Main.Windows;
using MaterialDesignColors;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using CalibrationTracking.Desktop.Calibrations.Views;

namespace CalibrationTracking.Desktop.Calibrations.ViewModels
{
    internal class CalibrationListViewModel : BaseViewModel
    {
        private readonly CalibrationTableView _calibrationTableView;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;
        private readonly ScanBarcodeWindow _scanBarcodeWindow;
        private readonly CalibrationSkuWindow _calibrationSkuWindow;
        public CalibrationListViewModel(CalibrationTableView calibrationTableView)
        {
            _calibrationTableView = calibrationTableView;
            _calibrationAddOrEditWindow = new CalibrationAddOrEditWindow(calibrationTableView);
            _calibrationSkuWindow = new CalibrationSkuWindow(calibrationTableView, _calibrationAddOrEditWindow);
            _scanBarcodeWindow = new ScanBarcodeWindow(calibrationTableView);
            OpenAddOrEditCommand = new OpenAddOrEditWindowCommand(calibrationTableView, _calibrationAddOrEditWindow, _scanBarcodeWindow);
            OpenScanBarcodeCommand = new OpenPrintWindowCommand(_scanBarcodeWindow);
            OpenCalibrationSkuWindowCommand = new OpenCalibrationSkuWindowCommand(_calibrationSkuWindow, _calibrationAddOrEditWindow, _calibrationTableView);
            LoadData();
        }

        public async void LoadData()
        {
            await GetAllCalibration();
        }

        private ICollectionView collView;

        public string Search
        {
            get => search;
            set
            {
                search = value;

                collView.Filter = e =>
                {
                    var item = (Calibration)e;
                    return item != null && ((item.CalibrationSKU?.StartsWith(search, StringComparison.OrdinalIgnoreCase) ?? false)
                                            || (item.Description?.StartsWith(search, StringComparison.OrdinalIgnoreCase) ?? false));
                };

                collView.Refresh();

                _calibrations = new ObservableCollection<Calibration>(collView.OfType<Calibration>().ToList());

                RaisePropertyChanged(nameof(Search));
                RaisePropertyChanged(nameof(FilterdCalibrations));
            }
        }



        private ObservableCollection<Calibration>? _calibrations;
        private Calibration _selectedCalibration;

        public ObservableCollection<Calibration>? Calibrations
        { get { return _calibrations; } set { _calibrations = value; RaisePropertyChanged(); } }

        private ObservableCollection<Calibration>? _filterdCalibrations;
        private string search;

        public ObservableCollection<Calibration>? FilterdCalibrations
        { get { return _filterdCalibrations; } set { _filterdCalibrations = value; RaisePropertyChanged(); } }




        public Calibration SelectedCalibration { get { return _selectedCalibration; } set { _selectedCalibration = value; RaisePropertyChanged(); } }

        public AsyncCommand OpenAddOrEditCommand { get; protected set; } 
        public AsyncCommand OpenScanBarcodeCommand { get; protected set; } 
        public OpenCalibrationSkuWindowCommand OpenCalibrationSkuWindowCommand { get; protected set; } 

        private async Task GetAllCalibration()
        {
            _calibrations = null;
            _filterdCalibrations = null;
            _selectedCalibration = null;

            var query = new GetAllCalibrationsQuery();

            var calibrations = await UserControlHelper.Mediator.Send(query);

            _calibrations = new(calibrations);



            FilterdCalibrations = new ObservableCollection<Calibration>(_calibrations);
            collView = CollectionViewSource.GetDefaultView(FilterdCalibrations);

            RaisePropertyChanged(nameof(Search));
            RaisePropertyChanged(nameof(Calibrations));
            RaisePropertyChanged(nameof(FilterdCalibrations));
            RaisePropertyChanged(nameof(SelectedCalibration));
        }


    }
}
