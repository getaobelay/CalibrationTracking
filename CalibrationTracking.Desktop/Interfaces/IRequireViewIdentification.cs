using System;

namespace CalibrationTracking.Desktop.Interfaces
{
    public interface IRequireViewIdentification
    {
        Guid ViewId { get; }
    }
}