using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Entidades
{
    public class CheckIn : EntidadeBase, IComplementoEntidades<Reserva>
    {
        public Guid? CodReserva { get; set; }
        public Reserva Reserva { get; private set; }

        public CheckIn() { }

        public CheckIn(Guid cod, Guid? codReserva, Reserva reserva, bool ativo)
        {
            Codigo = cod;
            CodReserva = codReserva;
            Reserva = reserva;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new CheckInValido().Validate(this);
            return Validacao.IsValid;
        }

        public void AdicionarComplemento(Reserva reserva)
        {
            Reserva = reserva;
            CodReserva = reserva.Codigo;
        }

        public static bool VerificarDataEntradaReservaValida(DateTime data)
        {
            return data.Date.Equals(DateTime.Now.Date);
        }
    }

    public class CheckInValido : AbstractValidator<CheckIn>
    {
        public CheckInValido()
        {
            RuleFor(c => c.Reserva)
                .NotNull().WithMessage("Dados da Reserva são obrigatórios").SetValidator(new ReservaValida());
        }
    }
}
