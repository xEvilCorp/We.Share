using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Comunidade
    {
        public Comunidade()
        {
            ComunidadeVideo = new HashSet<ComunidadeVideo>();
            InscritosComunidade = new HashSet<InscritosComunidade>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
        public string Banner { get; set; }

        public ICollection<ComunidadeVideo> ComunidadeVideo { get; set; }
        public ICollection<InscritosComunidade> InscritosComunidade { get; set; }
    }
}
