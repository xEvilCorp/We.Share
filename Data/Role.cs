using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
            UserRoleClaim = new HashSet<UserRoleClaim>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<UserRoleClaim> UserRoleClaim { get; set; }
    }
}
