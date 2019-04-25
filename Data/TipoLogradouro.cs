using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class TipoLogradouro
    {
        public TipoLogradouro()
        {
            Logradouros = new HashSet<Logradouros>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Logradouros> Logradouros { get; set; }
    }
}
