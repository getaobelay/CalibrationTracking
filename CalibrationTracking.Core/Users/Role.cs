﻿namespace CalibrationTracking.Core.Users
{

    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

    }
}
