using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Entidades
{
    public class CheckOut : EntidadeBase, IComplementoEntidades<Hospedagem>
    {
        public Guid? CodHospedagem { get; set; }
        public Hospedagem Hospedagem { get; private set; }

        public CheckOut() { }

        public CheckOut(Guid cod, Guid? codHosp, Hospedagem hosp, bool ativo)
        {
            Codigo = cod;
            CodHospedagem = codHosp;
            Hospedagem = hosp;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new CheckOutValido().Validate(this);
            return Validacao.IsValid;
        }

        public void AdicionarComplemento(Hospedagem hosp)
        {
            Hospedagem = hosp;
            CodHospedagem = hosp.Codigo;
        }

        public static bool VerificarDataSaidaHospedagemValida(DateTime data)
        {
            return data.Date.Equals(DateTime.Now.Date);
        }
    }

    public class CheckOutValido : AbstractValidator<CheckOut>
    {
        public CheckOutValido()
        {
            RuleFor(c => c.Hospedagem)
                .NotNull().WithMessage("Dados da Hospedagem são obrigatórios").SetValidator(new HospedagemValida());
        }
    }
}
