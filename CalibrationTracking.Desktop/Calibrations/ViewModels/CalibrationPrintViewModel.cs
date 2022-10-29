using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Commands;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Calibrations.Windows;

namespace CalibrationTracking.Desktop.Calibrations.ViewModels
{
    internal class CalibrationPrintViewModel : BaseViewModel<Calibration>
    {
        private readonly CalibrationPrintWindow _calibrationPrintWindow;

        public CalibrationPrintViewModel(CalibrationPrintWindow calibrationPrintWindow, Calibration model) : base(model)
        {

            _calibrationPrintWindow = calibrationPrintWindow;

            Reload(model);
        }

        private string? _remarks;
        public string? Remarks
        {
            get
            {
                return _remarks;
            }

            set
            {
                if (!string.Equals(_remarks, value))
                {
                    _remarks = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string? _frequency;
        public string? Frequency
        {
            get
            {
                return _frequency;
            }

            set
            {
                if (!string.Equals(_frequency, value))
                {
                    _frequency = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string? _calibrationSKU;


        public string? CalibrationSKU
        {
            get
            {
                return _calibrationSKU;
            }

            set
            {
                if (!string.Equals(_calibrationSKU, value))
                {
                    _calibrationSKU = value;
                    RaisePropertyChanged();
                }
            }
        }



        private string? _selectedDevice;

        public string? SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }

            set
            {
                if (!_selectedDevice.Equals(value))
                {
                    _selectedDevice = value;
                    RaisePropertyChanged();
                }
            }
        }


        private string? _selectedEmployee;

        public string? SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }

            set
            {
                if (!_selectedEmployee.Equals(value))
                {
                    _selectedEmployee = value;
                    RaisePropertyChanged();
                }
            }
        }



        private string? _selectedDepartment;
        public string? SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }

            set
            {
                if (!value.Equals(_selectedDepartment))
                {
                    _selectedDepartment = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string? _description;

        public string? Description
        {
            get
            {
                return _description;
            }

            set
            {
                if (!_description.Equals(value))
                {
                    _description = value;
                    RaisePropertyChanged();
                }
            }
        }


        private string? _reciver;

        public string? Reciver
        {
            get
            {
                return _reciver;
            }

            set
            {
                if (!_reciver.Equals(value))
                {
                    _reciver = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override void Reload(Calibration model)
        {
            _selectedDevice = string.Empty;
            _selectedEmployee = string.Empty;
            _remarks = string.Empty;
            _frequency = string.Empty;
            _description = string.Empty;
            _calibrationSKU = string.Empty;
            _description = string.Empty;

            RaisePropertyChanged(nameof(Remarks));
            RaisePropertyChanged(nameof(Frequency));
            RaisePropertyChanged(nameof(SelectedDevice));
            RaisePropertyChanged(nameof(SelectedEmployee));
            RaisePropertyChanged(nameof(SelectedDepartment));
            RaisePropertyChanged(nameof(Description));
            ;

            base.Reload(null);
        }

        public override Calibration ToModel()
        {
            return base.ToModel();
        }

        public void Undo()
        {
            Reload(Model);
        }


        public CalibrationAddOrEditCommand CalibrationAddOrEditCommand { get; protected set; }



    }
}
