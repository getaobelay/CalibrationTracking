using CalibrationTracking.Desktop.Base;
using System.Linq;
using System.Threading.Tasks;
using CalibrationTracking.Desktop.Main.Windows;
using CalibrationTracking.Desktop.Main.ViewModels;

namespace CalibrationTracking.Desktop.Calibrations.Commands
{
    public class OpenScanBarocodeWindowCommand : AsyncCommand
    {
        private readonly ScanBarcodeWindow _scanBarcodeWindow;
        public OpenScanBarocodeWindowCommand(ScanBarcodeWindow scanBarcodeWindow)
        {
            _scanBarcodeWindow = scanBarcodeWindow ??= new ScanBarcodeWindow();
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
