using System;

namespace ControleHotel.Dominio.Entidades
{
    public abstract class PessoaBase : EntidadeBase
    {
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Cpf { get; protected set; }
        public string Rg { get; protected set; }
        public string Email { get; protected set; }
        public Guid? CodEndereco { get; protected set; }
        public Endereco Endereco { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
    }
}
