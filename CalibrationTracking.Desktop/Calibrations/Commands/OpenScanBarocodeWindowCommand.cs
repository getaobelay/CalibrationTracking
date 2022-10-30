using CalibrationTracking.Desktop.Base;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Main.Windows;
using CalibrationTracking.Desktop.Main.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Views;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class OpenPrintWindowCommand : AsyncCommand
    {
        private readonly ScanBarcodeWindow _scanBarcodeWindow;
        private CalibrationTableView calibrationTableView;

        public OpenPrintWindowCommand(ScanBarcodeWindow scanBarcodeWindow)
        {
            _scanBarcodeWindow = scanBarcodeWindow ??= new ScanBarcodeWindow(calibrationTableView);
        }



        public override bool CanExecute()
        {
            return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {


            _scanBarcodeWindow.ShowDialog();
            ((ScanBarcodeViewModel)_scanBarcodeWindow.DataContext).Barcode = null;


        }
    }
}
