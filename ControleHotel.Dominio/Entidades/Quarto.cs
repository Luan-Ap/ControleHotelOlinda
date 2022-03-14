using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace ControleHotel.Dominio.Entidades
{
    public class Quarto : EntidadeBase, IComplementoEntidades<TipoQuarto>
    {
        public int NumQuarto { get; private set; }
        public string Descricao { get; private set; }
        public Guid? CodTipoQuarto { get; private set; }
        public TipoQuarto TipoQuarto { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public ICollection<Hospedagem> Hospedagens { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

        public Quarto() { }

        public Quarto(Guid cod, int num, string descricao, Guid? tipoId, TipoQuarto tipo, DateTime dataCadastro, bool ativo)
        {
            Codigo = cod;
            NumQuarto = num;
            Descricao = descricao;
            Ativo = ativo;
            CodTipoQuarto = tipoId;
            TipoQuarto = tipo;
            DataCadastro = dataCadastro;
        }

        public override bool Validar()
        {
            Validacao = new QuartoValido().Validate(this);
            return Validacao.IsValid;
        }

        public void AdicionarComplemento(TipoQuarto tipoQuarto)
        {
            TipoQuarto = tipoQuarto;
            CodTipoQuarto = tipoQuarto.Codigo;
        }
    }

    public class QuartoValido : AbstractValidator<Quarto>
    {
        public QuartoValido()
        {
            RuleFor(q => q.NumQuarto)
                .GreaterThan(0).WithMessage("Núm. do Quarto precisa ser maior que 0");

            RuleFor(q => q.Descricao)
                .NotEmpty().WithMessage("Campo Descrição é obrigatório")
                .MinimumLength(10).WithMessage("Campo Descrição precisa ter, no mínimo, 10 caracteres")
                .MaximumLength(250).WithMessage("Campo Descrição pode ter, no máximo, 250 caracteres");

            RuleFor(q => q.TipoQuarto)
                .NotNull().WithMessage("Selecione um Tipo Quarto").SetValidator(new TipoQuartoValido());
        }
    }
}
