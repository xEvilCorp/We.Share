using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Endereco
    {
        public Endereco()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int Id { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Logradouros CepNavigation { get; set; }
        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
