using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Entidades
{
    public class TipoQuarto : EntidadeBase
    {
        public double Valor { get; private set; }
        public string Tipo { get; private set; }
        public int MaxAcompanhantes { get; set; }
        public ICollection<Quarto> Quartos { get; set; }

        public TipoQuarto() { }

        public TipoQuarto(Guid cod, double valor, string tipo, int maxAcomp, bool ativo)
        {
            Codigo = cod;
            Valor = valor;
            Tipo = tipo;
            MaxAcompanhantes = maxAcomp;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new TipoQuartoValido().Validate(this);
            return Validacao.IsValid;
        }
    }

    public class TipoQuartoValido : AbstractValidator<TipoQuarto>
    {
        public TipoQuartoValido()
        {
            RuleFor(t => t.Tipo)
                .NotEmpty().WithMessage("Campo Tipo Quarto é obrigatório")
                .MaximumLength(20).WithMessage("Campo Tipo Quarto pode ter, no máximo, 20 caracteres");

            RuleFor(t => t.Valor)
                .GreaterThan(0).WithMessage("Campo Valor precisa ser maior que 0");

            RuleFor(t => t.MaxAcompanhantes)
                .InclusiveBetween(0, 3).WithMessage("Campo Max. Acompanhantes precisa estar entre 0 e 3");
        }
    }
}
