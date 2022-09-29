namespace CalibrationTracking.Abstractions.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Id = new Guid();
        }
        public Guid Id { get; }
    }
}