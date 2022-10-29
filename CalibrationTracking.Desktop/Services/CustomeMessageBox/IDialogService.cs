using CalibrationTracking.Desktop.CustomeMessageBox;
using Microsoft.Win32;
using Prism.Regions;
using System.Windows;

namespace CalibrationTracking.Desktop.Services.CustomeMessageBox
{
    public interface IDialogService
    {
        bool OpenFileDialog(bool checkFileExists, string Filter, out string FileName);
        MessageBoxResult ShowMessageBox(string message, string caption, MessageBoxButton buttons, MessageBoxIcon icon);
    }

    public class DialogService : IDialogService
    {
        public bool OpenFileDialog(bool checkFileExists, string Filter, out string FileName)
        {
            FileName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            //openFileDialog.Filter = "All Image Files | *.jpg;*.png | All files | *.*";
            openFileDialog.Filter = Filter;
            openFileDialog.CheckFileExists = checkFileExists;
            bool result = ((bool)openFileDialog.ShowDialog());
            if (result)
            {
                FileName = openFileDialog.FileName;
            }
            return result;
        }




        public MessageBoxResult ShowMessageBox(string message, string caption, MessageBoxButton buttons, MessageBoxIcon icon)
        {
            //return (MessageBoxResult)System.Windows.MessageBox.Show(message, caption,
            //    (System.Windows.MessageBoxButton)buttons,
            //    (System.Windows.MessageBoxImage)icon,System.Windows.MessageBoxResult.None, System.Windows.MessageBoxOptions.RtlReading);


            CustomMessageBoxWindow mb = new CustomMessageBoxWindow(caption, message, true)
            {
                Topmost = true,
                WindowState = WindowState.Maximized
            };


           if(mb.ShowDialog() == true) return MessageBoxResult.Yes;
           else return MessageBoxResult.No;


        }
    }
}
