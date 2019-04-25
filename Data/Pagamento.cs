using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Pagamento
    {
        public Pagamento()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int Id { get; set; }
        public int Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }

        public Banco BancoNavigation { get; set; }
        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
