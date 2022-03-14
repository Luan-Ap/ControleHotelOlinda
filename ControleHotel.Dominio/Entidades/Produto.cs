using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public double Valor { get; private set; }
        public TipoProduto TipoProduto { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public ICollection<Produto_Hospedagem> Produtos_Hospedagens { get; set; }

        public Produto() { }

        public Produto(Guid cod, string nome, int qtd, double valor, TipoProduto tipo, DateTime dataCadastro, bool ativo)
        {
            Codigo = cod;
            Nome = nome;
            Quantidade = qtd;
            Valor = valor;
            TipoProduto = tipo;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new ProdutoValido().Validate(this);
            return Validacao.IsValid;
        }
    }

    public class ProdutoValido : AbstractValidator<Produto>
    {
        public ProdutoValido()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Campo Nome do Produto é obrigatório")
                .MaximumLength(150).WithMessage("Campo Nome do Produto pode ter, no máximo, 150 caracteres");

            RuleFor(p => p.Quantidade)
                .GreaterThan(0).WithMessage("Quantidade precisa ser maior que 0");

            RuleFor(p => p.Valor)
                .GreaterThan(0).WithMessage("Valor do Produto precisa ser maior que 0");

            RuleFor(p => p.TipoProduto)
                .NotNull().WithMessage("Campo Tipo de Produto é obrigatório");

        }
    }

    public enum TipoProduto
    {
        Mercadoria,
        Serviço
    }
}
