using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Bairros
    {
        public Bairros()
        {
            Logradouros = new HashSet<Logradouros>();
        }

        public int Id { get; set; }
        public int Cidade { get; set; }
        public string Nome { get; set; }

        public Cidades CidadeNavigation { get; set; }
        public ICollection<Logradouros> Logradouros { get; set; }
    }
}
