using System;

namespace CalibrationTracking.Desktop.Interfaces
{
    public interface IWindowManagerService
    {
        void CloseWindow(Guid id);

        void Hide(Guid id);
    }
}