using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;

namespace ControleHotel.Dominio.Entidades
{
    public class Produto_Hospedagem : EntidadeBase, IComplementoEntidades<Hospedagem>, IComplementoEntidades<Produto>
    {
        public Guid? CodHospedagem { get; private set; }
        public Hospedagem Hospedagem { get; private set; }
        public Guid? CodProduto { get; private set; }
        public Produto Produto { get; private set; }
        public int QuantidadeConsumida { get; private set; }
        public double ValorTotal { get; private set; }
        public DateTime DataConsumo { get; private set; }

        public Produto_Hospedagem() { }

        public Produto_Hospedagem(Guid cod, Guid? codHosp, Hospedagem hosp, Guid? codProd, Produto produto, int qtd, double total, DateTime dataConsumo, bool ativo)
        {
            Codigo = cod;
            CodHospedagem = codHosp;
            Hospedagem = hosp;
            CodProduto = codProd;
            Produto = produto;
            QuantidadeConsumida = qtd;
            ValorTotal = total;
            DataConsumo = dataConsumo;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new Produto_Hospedagem_Valido().Validate(this);
            return Validacao.IsValid;
        }

        public void AdicionarComplemento(Produto prod)
        {
            Produto = prod;
            CodProduto = prod.Codigo;
        }

        public void AdicionarComplemento(Hospedagem hosp)
        {
            Hospedagem = hosp;
            CodHospedagem = hosp.Codigo;
        }
    }

    public class Produto_Hospedagem_Valido : AbstractValidator<Produto_Hospedagem>
    {
        public Produto_Hospedagem_Valido()
        {
            RuleFor(ph => ph.Hospedagem)
                .NotNull().WithMessage("Dados da Hospedagem são obrigatórios").SetValidator(new HospedagemValida());

            RuleFor(ph => ph.Produto)
                .NotNull().WithMessage("Dados do Produto são obrigatórios").SetValidator(new ProdutoValido());

            RuleFor(ph => ph.QuantidadeConsumida)
                .GreaterThan(0).WithMessage("Quantidade Consumida deve ser maior que 0");

            RuleFor(ph => ph.ValorTotal)
                .GreaterThan(0).WithMessage("Valor Total deve ser maior que 0");
        }
    }
}
