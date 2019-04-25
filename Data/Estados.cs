using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Estados
    {
        public Estados()
        {
            Cidades = new HashSet<Cidades>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public ICollection<Cidades> Cidades { get; set; }
    }
}
