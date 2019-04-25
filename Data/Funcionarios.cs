using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Funcionarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int Genero { get; set; }
        public int Status { get; set; }
        public string Imagem { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int Cargo { get; set; }
        public int Endereco { get; set; }
        public int Pagamento { get; set; }

        public Cargo CargoNavigation { get; set; }
        public Endereco EnderecoNavigation { get; set; }
        public Gender GeneroNavigation { get; set; }
        public Pagamento PagamentoNavigation { get; set; }
    }
}
