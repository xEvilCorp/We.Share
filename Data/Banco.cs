using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Banco
    {
        public Banco()
        {
            Pagamento = new HashSet<Pagamento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Pagamento> Pagamento { get; set; }
    }
}
