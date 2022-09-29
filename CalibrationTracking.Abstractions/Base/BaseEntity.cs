namespace CalibrationTracking.Abstractions.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
    }
}