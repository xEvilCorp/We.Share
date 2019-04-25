using System;
using System.Collections.Generic;

namespace WeShare.Web
{
    public class Gender
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> User { get; set; }
        public Gender()
        {
            User = new HashSet<ApplicationUser>();
        }
    }
}

