using FluentValidation;
using System;
using System.Collections.Generic;

namespace ControleHotel.Dominio.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string TextoEndereco { get; private set; }
        public string Numero { get; private set; }
        public string Cep { get; private set; }
        public string Telefone { get; private set; }
        public string Estado { get; private set; }

        public Endereco() { }

        public Endereco(Guid cod, string textEndereco, string num, string cep, string telefone, string estado, bool ativo)
        {
            Codigo = cod;
            TextoEndereco = textEndereco;
            Numero = num;
            Cep = cep;
            Telefone = telefone;
            Estado = estado;
            Ativo = ativo;
        }

        public override bool Validar()
        {
            Validacao = new EnderecoValido().Validate(this);
            return Validacao.IsValid;
        }
    }

    public class EnderecoValido : AbstractValidator<Endereco>
    {
        public EnderecoValido()
        {
            RuleFor(c => c.TextoEndereco)
                .NotEmpty().WithMessage("Campo Rua é obrigatório")
                .MinimumLength(5).WithMessage("Campo Rua presita ter, no mínimo, 5 caracteres")
                .MaximumLength(150).WithMessage("Campo Rua pode ter, no máximo, 150 caracteres");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("Campo Número é obrigatório")
                .MaximumLength(6).WithMessage("Campo Número pode ter, no máximo, 6 números");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("Campo Cep é obrigatório")
                .Must(ValidarCep).WithMessage("Campo Cep inválido");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Campo Telefone é obrigatório")
                .Must(ValidarTelefone).WithMessage("Campo Telefone inválido");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("Campo Estado é obrigatório")
                .Length(2).WithMessage("Campo Estado pode ter apenas 2 caractres");
        }

        private bool ValidarCep(string cep)
        {
            if (string.IsNullOrEmpty(cep)) return true;

            return cep.Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).Length == 8;
        }

        private bool ValidarTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone)) return true;

            var tamanho = telefone.Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty)
                .Replace("-", string.Empty).Length;

            return tamanho >= 10 && tamanho <= 11;
        }
    }
}