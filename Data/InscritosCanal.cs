using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class InscritosCanal
    {
        public int Id { get; set; }
        public int? Canal { get; set; }
        public string User { get; set; }
        public int? Notificar { get; set; }

        public Canal CanalNavigation { get; set; }
        public User UserNavigation { get; set; }
    }
}
