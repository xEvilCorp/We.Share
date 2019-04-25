using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Logradouros
    {
        public Logradouros()
        {
            Endereco = new HashSet<Endereco>();
        }

        public string Cep { get; set; }
        public int Bairro { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }

        public Bairros BairroNavigation { get; set; }
        public TipoLogradouro TipoNavigation { get; set; }
        public ICollection<Endereco> Endereco { get; set; }
    }
}
