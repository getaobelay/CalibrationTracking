namespace CalibrationTracking.Core.Users
{

    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public Guid UserRoleId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   UserName == user.UserName &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName;              
        }
    }
}
