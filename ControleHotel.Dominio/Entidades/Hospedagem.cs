using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Entidades
{
    public class Hospedagem : EntidadeBase, IComplementoEntidades<Cliente>, IComplementoEntidades<Quarto>
    {
        public Guid? CodCliente { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime DataSaida { get; private set; }
        public Guid? CodQuarto { get; private set; }
        public Quarto Quarto { get; private set; }
        public double ConsumoTotal { get; private set; }

        public ICollection<Produto_Hospedagem> Produtos_Hospedagens { get; set; }

        public Hospedagem() { }

        public Hospedagem(Guid cod, Guid? codCliente, Cliente cliente, DateTime entrada, DateTime saida, Guid? codQuarto,
                    Quarto quarto, double consumo, bool ativo)
        {
            Codigo = cod;
            CodCliente = codCliente;
            Cliente = cliente;
            DataEntrada = entrada;
            DataSaida = saida;
            CodQuarto = codQuarto;
            Quarto = quarto;
            ConsumoTotal = consumo;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new HospedagemValida().Validate(this);
            return Validacao.IsValid;
        }

        public void AdicionarComplemento(Cliente cliente)
        {
            Cliente = cliente;
            CodCliente = cliente.Codigo;
        }

        public void AdicionarComplemento(Quarto quarto)
        {
            Quarto = quarto;
            CodQuarto = quarto.Codigo;
        }

        public static bool VerificarHaConsumos(double valor)
        {
            return valor > 0;
        }
    }

    public class HospedagemValida : AbstractValidator<Hospedagem>
    {
        public HospedagemValida()
        {
            RuleFor(h => h.Cliente)
                .NotNull().WithMessage("Dados do Cliente são obrigatórios").SetValidator(new ClienteValido());

            RuleFor(h => h.Quarto)
                .NotNull().WithMessage("Dados do Quarto são obrigatórios").SetValidator(new QuartoValido());
        }
    }
}
