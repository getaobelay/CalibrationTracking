using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Commands;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Calibrations.Windows;

namespace CalibrationTracking.Desktop.Calibrations.ViewModels
{
    internal class CalibrationAddOrEditViewModel : BaseViewModel<Calibration>
    {
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditView;
        private readonly CalibrationTableView _calibrationTableView;

        public CalibrationAddOrEditViewModel(CalibrationAddOrEditWindow calibrationAddOrEditView, Calibration model, CalibrationTableView calibrationTableView) : base(model)
        {

            _calibrationTableView = calibrationTableView;
            _calibrationAddOrEditView = calibrationAddOrEditView ??= new CalibrationAddOrEditWindow(calibrationTableView);

            CalibrationAddOrEditCommand = new CalibrationAddOrEditCommand(calibrationAddOrEditView, calibrationTableView);
            CalibrationUndoCommand = new CalibrationUndoCommand(calibrationAddOrEditView, calibrationTableView);

            Reload(model);
        }

        private string? _remarks;
        public string? Remarks
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_remarks) && Model is not null)
                {
                    _remarks = Model.Remarks;
                }


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
                if (string.IsNullOrWhiteSpace(_frequency) && Model is not null)
                {
                    _frequency = Model.Frequency;
                }

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
                if (string.IsNullOrWhiteSpace(_calibrationSKU) && Model is not null)
                {
                    _calibrationSKU = Model.CalibrationSKU;
                }

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
                if (string.IsNullOrWhiteSpace(_selectedDevice) && Model is not null)
                {
                    _selectedDevice = Model.Device;
                }

                return _selectedDevice;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != _selectedDevice)
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

                if (string.IsNullOrWhiteSpace(_selectedEmployee) && Model is not null)
                {
                    _selectedEmployee = Model.Employee;
                }

                return _selectedEmployee;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != _selectedEmployee)
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

                if (string.IsNullOrWhiteSpace(_selectedDepartment) && Model is not null)
                {
                    _selectedDepartment = Model.Department;
                }

                return _selectedDepartment;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != _selectedDepartment)
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

                if (string.IsNullOrWhiteSpace(_description) && Model is not null)
                {
                    _description = Model.Description;
                }

                return _description;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != _description)
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
                if (string.IsNullOrWhiteSpace(_reciver) && Model is not null)
                {
                    _reciver = Model.Employee;
                }


                return _reciver;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != _reciver)
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
            _selectedDepartment = string.Empty;
            _remarks = string.Empty;
            _frequency = string.Empty;
            _description = string.Empty;
            _calibrationSKU = string.Empty;
            _reciver = string.Empty;

            RaisePropertyChanged(nameof(SelectedDevice));
            RaisePropertyChanged(nameof(SelectedEmployee));
            RaisePropertyChanged(nameof(SelectedDepartment));
            RaisePropertyChanged(nameof(Remarks));
            RaisePropertyChanged(nameof(Frequency));
            RaisePropertyChanged(nameof(Description));
            RaisePropertyChanged(nameof(CalibrationSKU));
            RaisePropertyChanged(nameof(Reciver));

            base.Reload(model);
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
        public CalibrationUndoCommand CalibrationUndoCommand { get; protected set; }


    }
}
