using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class InscritosComunidade
    {
        public int Id { get; set; }
        public int? Comunidade { get; set; }
        public string User { get; set; }
        public DateTime? Since { get; set; }
        public int? Notificar { get; set; }

        public Comunidade ComunidadeNavigation { get; set; }
        public User UserNavigation { get; set; }
    }
}
