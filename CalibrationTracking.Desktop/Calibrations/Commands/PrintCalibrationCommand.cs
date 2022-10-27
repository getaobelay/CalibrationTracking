using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using System;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class PrintCalibrationCommand : AsyncCommand
    {
        private readonly IMediator _mediator;
        private readonly CalibrationListWindow _calibrationListWindow;
    
        public PrintCalibrationCommand(CalibrationListWindow calibrationListWindow, IMediator mediator)
        {
            _mediator = mediator;
            _calibrationListWindow = calibrationListWindow;
        }


        public override bool CanExecute()
        {
            return  RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            PrintImageHelper.CreateImage("sku", "employee", "department", "description", "device", "remarks", "frequncy");


            PrintImageHelper.Print(1);
        }
    }
}
