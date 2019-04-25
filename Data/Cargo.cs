using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Cargo
    {
        public Cargo()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Acesso { get; set; }
        public decimal? Salario { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
