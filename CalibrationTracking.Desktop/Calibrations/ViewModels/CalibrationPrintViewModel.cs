using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Commands;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Calibrations.Windows;
using System;

namespace CalibrationTracking.Desktop.Calibrations.ViewModels
{
    internal class CalibrationPrintViewModel : BaseViewModel<Calibration>
    {
        private readonly CalibrationPrintWindow _calibrationPrintWindow;

        public CalibrationPrintViewModel(CalibrationPrintWindow calibrationPrintWindow, Calibration model) : base(model)
        {

            _calibrationPrintWindow = calibrationPrintWindow;

            CalibrationPrintCommand = new CalibrationPrintCommand(calibrationPrintWindow);

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
                if (!string.IsNullOrWhiteSpace(value) && value != _frequency)
                {
                    _frequency = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string? _orderSku;


        public string? OrderSku
        {
            get
            {

                return _orderSku;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != _orderSku)
                {
                    _orderSku = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string? _employeeId;


        public string? EmployeeId
        {
            get
            {

                return _employeeId;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != _employeeId)
                {
                    _employeeId = value;
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

        private DateTime? _printDate = DateTime.Now;

        public DateTime? PrintDate
        {
            get
            {

               
                return _printDate;
            }

            set
            {
                if (!_printDate.Equals(value))
                {
                    _printDate = value;
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
            _remarks = string.Empty;
            _frequency = string.Empty;
            _description = string.Empty;
            _calibrationSKU = string.Empty;
            _description = string.Empty;
            _reciver = string.Empty;

            RaisePropertyChanged(nameof(Remarks));
            RaisePropertyChanged(nameof(Frequency));
            RaisePropertyChanged(nameof(SelectedDevice));
            RaisePropertyChanged(nameof(SelectedEmployee));
            RaisePropertyChanged(nameof(SelectedDepartment));
            RaisePropertyChanged(nameof(Description));
            RaisePropertyChanged(nameof(Reciver));
            ;

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


        public CalibrationPrintCommand CalibrationPrintCommand { get; protected set; }



    }
}
