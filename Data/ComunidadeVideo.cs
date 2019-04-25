using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class ComunidadeVideo
    {
        public int Id { get; set; }
        public int? Comunidade { get; set; }
        public int? Video { get; set; }
        public DateTime? PostDate { get; set; }
        public string Usuario { get; set; }

        public Comunidade ComunidadeNavigation { get; set; }
        public User UsuarioNavigation { get; set; }
        public Video VideoNavigation { get; set; }
    }
}
