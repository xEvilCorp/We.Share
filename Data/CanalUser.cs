using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class CanalUser
    {
        public int Id { get; set; }
        public int? Canal { get; set; }
        public string User { get; set; }
        public int? Acesso { get; set; }

        public AcessoCanalUser AcessoNavigation { get; set; }
        public Canal CanalNavigation { get; set; }
        public User UserNavigation { get; set; }
    }
}
