using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace ControleHotel.Dominio.Entidades
{
    public class Cliente : PessoaBase, IComplementoEntidades<Endereco>
    {
        public ICollection<Hospedagem> Hospedagens { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

        public Cliente(){}

        public Cliente(Guid cod, string nome, string sobrenome, string cpf, string rg, string email, Guid? codEndereco, Endereco endereco, DateTime dataNasc, DateTime dataCad, bool ativo)
        {
            Codigo = cod;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Rg = rg;
            Email = email;
            CodEndereco = codEndereco;
            Endereco = endereco;
            Ativo = ativo;
            DataNascimento = dataNasc;
            DataCadastro = dataCad;
        }

        public override bool Validar()
        {
            Validacao = new ClienteValido().Validate(this);
            return Validacao.IsValid;
        }

        public void AdicionarComplemento(Endereco endereco)
        {
            Endereco = endereco;
            CodEndereco = endereco.Codigo;
        }
    }

    public class ClienteValido : AbstractValidator<Cliente>
    {
        public ClienteValido()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Campo Nome é obrigatório")
                .MinimumLength(3).WithMessage("Campo Nome presita ter, no mínimo, 3 caracteres")
                .MaximumLength(150).WithMessage("Campo Nome pode ter, no máximo, 150 caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Campo Sobrenome é obrigatório")
                .MinimumLength(3).WithMessage("Campo Sobrenome presita ter, no mínimo, 3 caracteres")
                .MaximumLength(150).WithMessage("Campo Sobrenome pode ter, no máximo, 150 caracteres");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Campo CPF é obrigatório")
                .Must(ValidarCpf)
                .WithMessage("Campo CPF inválido");

            RuleFor(c => c.Rg)
                .NotEmpty().WithMessage("Campo RG é obrigatório")
                .Must(ValidarRg).WithMessage("Campo RG inválido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Campo Email é obrigatório")
                .MaximumLength(150).WithMessage("Campo E-mail pode ter, no máximo, 150 caracteres");

            RuleFor(a => a.Email).EmailAddress()
                .When(a => !string.IsNullOrEmpty(a.Email))
                .When(a => a.Email.Length <= 150)
                .WithMessage("Campo Email é inválido");

            RuleFor(c => c.Endereco)
                .NotNull().WithMessage("Dados de Endereço são obrigatórios").SetValidator(new EnderecoValido());

            RuleFor(c => c.DataNascimento)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("Idade precisa ser maior ou igual a 18 anos");
        }

        private bool ValidarRg(string rg)
        {
            if (string.IsNullOrEmpty(rg)) return false;

            return rg.Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).Length == 9;
        }

        private bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return false;

            return cpf.Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).Length == 11;
        }
    }
}
