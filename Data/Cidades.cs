using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Cidades
    {
        public Cidades()
        {
            Bairros = new HashSet<Bairros>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Estado { get; set; }

        public Estados EstadoNavigation { get; set; }
        public ICollection<Bairros> Bairros { get; set; }
    }
}
