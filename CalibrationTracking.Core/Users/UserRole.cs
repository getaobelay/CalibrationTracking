namespace CalibrationTracking.Core.Users
{
    public class UserRole
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}