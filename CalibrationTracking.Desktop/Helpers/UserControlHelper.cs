using AutoMapper;
using CalibrationTracking.Desktop.Main.Windows;
using CalibrationTracking.Desktop.Services.CustomeMessageBox;
using MediatR;

namespace CalibrationTracking.Desktop.Helpers
{
    public static class UserControlHelper
    {
        public static IMediator Mediator { get; internal set; }
        public static IMapper Mapper { get; internal set; }
        public static IDialogService? DialogService { get; internal set; }
        public static MainWindow? MainWindow { get; internal set; }
        public static ScanBarcodeWindow? ScanBarcodeWindow { get; internal set; }



    }
}