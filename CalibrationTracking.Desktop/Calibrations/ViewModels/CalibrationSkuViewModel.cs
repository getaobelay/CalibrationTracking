using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Calibrations.Commands;
using CalibrationTracking.Desktop.Calibrations.Views;
using CalibrationTracking.Desktop.Calibrations.Windows;
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


        public CalibrationPrintCommand CalibrationPrintCommand { get; protected set; }



    }
}
