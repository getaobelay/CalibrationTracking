using CalibrationTracking.Desktop.Interfaces;
using System;

namespace CalibrationTracking.Desktop.Services
{
    public class WindowManagerService : IWindowManagerService
    {
        public void CloseWindow(Guid id)
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                var w_id = window.DataContext as IRequireViewIdentification;
                if (w_id != null && w_id.ViewId.Equals(id))
                {
                    window.Close();
                }
            }
        }

        public void Hide(Guid id)
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                var w_id = window.DataContext as IRequireViewIdentification;

                if (w_id != null && w_id.ViewId.Equals(id))
                {
                    window.Hide();
                }
            }
        }
    }
}