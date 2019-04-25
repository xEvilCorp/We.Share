using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class AcessoCanalUser
    {
        public AcessoCanalUser()
        {
            CanalUser = new HashSet<CanalUser>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<CanalUser> CanalUser { get; set; }
    }
}
