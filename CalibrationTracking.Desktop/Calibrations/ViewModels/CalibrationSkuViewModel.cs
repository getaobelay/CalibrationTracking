using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Commands;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.Main.Commands;
using System;

namespace CalibrationTracking.Desktop.Calibrations.ViewModels
{
    internal class CalibrationSkuViewModel : BaseViewModel
    {
        private readonly CalibrationSkuWindow _calibrationSkuWindow;
        private readonly CalibrationAddOrEditWindow _calibrationAddOrEditWindow;

        public CalibrationSkuViewModel(CalibrationSkuWindow calibrationSkuWindow, CalibrationAddOrEditWindow calibrationAddOrEditWindow)
        {

            _calibrationAddOrEditWindow = calibrationAddOrEditWindow;
            _calibrationSkuWindow = calibrationSkuWindow;

            CalibrationSkuCommand = new CalibrationSkuCommand(_calibrationSkuWindow, _calibrationAddOrEditWindow);
        }

    

       
        private string? _calibrationSku;

        public string? CalibrationSku
        {
            get
            {    
                return _calibrationSku;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != _calibrationSku)
                {
                    _calibrationSku = value;
                    RaisePropertyChanged();
                }
            }
        }


        public CalibrationSkuCommand CalibrationSkuCommand { get; protected set; }



    }
}
