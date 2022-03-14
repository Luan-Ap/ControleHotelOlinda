using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Entidades
{
    public class Reserva : EntidadeBase, IComplementoEntidades<Cliente>, IComplementoEntidades<Quarto>
    {
        public Guid? CodCliente { get; set; }
        public Cliente Cliente { get; private set; }
        public Guid? CodQuarto { get; set; }
        public Quarto Quarto { get; private set; }
        public int NumAcompanhantes { get; private set; }
        public double TotalDiaria { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime DataSaida { get; private set; }
        public DateTime DataReserva { get; private set; }
        public StatusReserva Status { get; private set; }

        public Reserva() { }

        public Reserva(Guid cod, Guid? codCliente, Cliente cliente, Guid? codQuarto, Quarto quarto, int acomp, double total, DateTime entrada, DateTime saida, DateTime reserva, StatusReserva status, bool ativo)
        {
            Codigo = cod;
            CodCliente = codCliente;
            Cliente = cliente;
            CodQuarto = codQuarto;
            Quarto = quarto;
            NumAcompanhantes = acomp;
            TotalDiaria = total;
            DataEntrada = entrada;
            DataSaida = saida;
            DataReserva = reserva;
            Status = status;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new ReservaValida().Validate(this);
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

        public static bool VerificarHaMultaParaCancelamento(DateTime data)
        {
            return data.Subtract(DateTime.Now).TotalHours < 24;
        }
    }

    public enum StatusReserva
    {
        Ativa,
        Concluida,
        Cancelada
    }

    public class ReservaValida : AbstractValidator<Reserva>
    {
        public ReservaValida()
        {
            RuleFor(r => r.Cliente)
                .NotNull().WithMessage("Dados do Cliente são obrigatórios").SetValidator(new ClienteValido());

            RuleFor(r => r.Quarto)
                .NotNull().WithMessage("Dados do Quarto são obrigatórios").SetValidator(new QuartoValido());

            RuleFor(r => r.NumAcompanhantes)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(3).WithMessage("A quantidade máxima de acompanhantes é 3");

            RuleFor(r => r.DataEntrada)
                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("A Data de Entrada precisa ser a data de hoje ou uma futura");

            RuleFor(r => r.DataSaida)
                .Must(VerificarDataSaida).WithMessage("A Data de Saída precisa ser, ao menos, um dia após a Data de Entrada");
        }

        private bool VerificarDataSaida(Reserva reserva, DateTime dataSaida)
        {
            return (int)dataSaida.Subtract(reserva.DataEntrada).TotalDays >= 1;
        }
    }
}
