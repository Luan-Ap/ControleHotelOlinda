using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;

namespace ControleHotel.Dominio.Entidades
{
    public class RegistroPagamento : EntidadeBase, IComplementoEntidades<Reserva>, IComplementoEntidades<Hospedagem>
    {
        public FormaPagto Forma { get; private set; }
        public Guid? CodReserva { get; private set; }
        public Reserva Reserva { get; set; }
        public Guid? CodHospedagem { get; private set; }
        public Hospedagem Hospedagem { get; private set; }
        public double Valor { get; private set; }
        public DateTime DataPagto { get; private set; }

        public RegistroPagamento(){ }

        public RegistroPagamento(Guid cod, Guid? codReserva, Reserva reserva, Guid? codHosp, Hospedagem hosp, FormaPagto pagto, double valor, DateTime dataPagto, bool ativo)
        {
            Codigo = cod;
            CodReserva = codReserva;
            Reserva = reserva;
            CodHospedagem = codHosp;
            Hospedagem = hosp;
            Forma = pagto;
            Valor = valor;
            DataPagto = dataPagto;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new RegistroPagtoValido().Validate(this);
            return Validacao.IsValid;
        }

        public void AdicionarComplemento(Reserva reserva)
        {
            Reserva = reserva;
            CodReserva = reserva.Codigo;
        }

        public void AdicionarComplemento(Hospedagem hosp)
        {
            Hospedagem = hosp;
            CodHospedagem = hosp.Codigo;
        }
    }

    public enum FormaPagto
    {
        Debito,
        Credito,
        Boleto,
        Especie,
        Pix
    }

    public class RegistroPagtoValido : AbstractValidator<RegistroPagamento>
    {
        public RegistroPagtoValido()
        {
            RuleFor(reg => reg.Valor)
                .GreaterThan(0).WithMessage("Valo de pagamento deve ser maior que 0");

            RuleFor(reg => reg.Reserva)
                .SetValidator(new ReservaValida())
                .When(r => r.Reserva is not null);

            RuleFor(reg => reg.Hospedagem)
                .SetValidator(new HospedagemValida())
                .When(reg => reg.Hospedagem is not null);

            RuleFor(reg => reg)
                .Must(ValidarHospedagemReserva).WithMessage("O Registro Pagemento precisa ser de uma Reserva ou de uma Hospedagem");
        }

        private bool ValidarHospedagemReserva(RegistroPagamento registro)
        {
            if((registro.Hospedagem == null && registro.Reserva == null) || (registro.Hospedagem != null && registro.Reserva != null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
