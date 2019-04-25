using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Canal
    {
        public Canal()
        {
            CanalUser = new HashSet<CanalUser>();
            InscritosCanal = new HashSet<InscritosCanal>();
        }

        public int Id { get; set; }
        public string Noime { get; set; }
        public string Banner { get; set; }
        public string Icone { get; set; }
        public int? AllowAds { get; set; }

        public ICollection<CanalUser> CanalUser { get; set; }
        public ICollection<InscritosCanal> InscritosCanal { get; set; }
    }
}
