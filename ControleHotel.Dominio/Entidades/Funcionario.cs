using ControleHotel.Dominio.Entidades.Service;
using FluentValidation;
using System;

namespace ControleHotel.Dominio.Entidades
{
    public class Funcionario : PessoaBase, IComplementoEntidades<Endereco>
    {
        public string Ctps { get; protected set; }
        public double Salario { get; protected set; }
        public string Cargo { get; protected set; }

        public Funcionario(){}

        public Funcionario(Guid cod, string nome, string sobrenome, string cpf, string rg, string ctps, Guid? codEndereco, Endereco endereco, string email, double salario, string cargo, DateTime dataNasc, DateTime dataCad, bool ativo)
        {
            Codigo = cod;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Rg = rg;
            Ctps = ctps;
            CodEndereco = codEndereco;
            Endereco = endereco;
            Email = email;
            Salario = salario;
            Cargo = cargo;
            Ativo = ativo;
            DataNascimento = dataNasc;
            DataCadastro = dataCad;
        }

        public override bool Validar()
        {
            Validacao = new FuncionarioValido().Validate(this);
            return Validacao.IsValid;
        }

        public void AdicionarComplemento(Endereco endereco)
        {
            Endereco = endereco;
            CodEndereco = endereco.Codigo;
        }
    }

    public class FuncionarioValido : AbstractValidator<Funcionario>
    {
        public FuncionarioValido()
        {
            RuleFor(f => f.Nome)
                 .NotEmpty().WithMessage("Campo Nome é obrigatório")
                 .MinimumLength(3).WithMessage("Campo Nome presita ter, no mínimo, 3 caracteres")
                 .MaximumLength(150).WithMessage("Campo Nome pode ter, no máximo, 150 caracteres");

            RuleFor(f => f.Sobrenome)
                .NotEmpty().WithMessage("Campo Sobrenome é obrigatório")
                .MinimumLength(3).WithMessage("Campo Sobrenome presita ter, no mínimo, 3 caracteres")
                .MaximumLength(150).WithMessage("Campo Sobrenome pode ter, no máximo, 150 caracteres");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Campo CPF é obrigatório")
                .Must(ValidarCpf)
                .WithMessage("Campo CPF inválido");

            RuleFor(f => f.Rg)
                .NotEmpty().WithMessage("Campo RG é obrigatório")
                .Must(ValidarRg).WithMessage("Campo RG inválido");

            RuleFor(f => f.Endereco)
                .NotNull().WithMessage("Dados de Endereço são obrigatórios").SetValidator(new EnderecoValido());

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Campo Email é obrigatório")
                .MaximumLength(150).WithMessage("Campo E-mail pode ter, no máximo, 150 caracteres");

            RuleFor(a => a.Email).EmailAddress()
                .When(a => !string.IsNullOrEmpty(a.Email))
                .When(a => a.Email.Length <= 150)
                .WithMessage("Campo Email é inválido");

            RuleFor(f => f.Ctps)
                .NotEmpty().WithMessage("Campo Ctps é obrigatório")
                .Must(ValidarCtps)
                .WithMessage("Campo Ctps inválido");

            RuleFor(f => f.Cargo)
                .NotEmpty().WithMessage("Campo Cargo é obrigatório")
                .MaximumLength(150).WithMessage("Campo Cargo pode ter, no mácimo, 150 caracteres");

            RuleFor(f => f.Salario)
                .NotEmpty().WithMessage("Campo Salário é obrigatório")
                .GreaterThan(0).WithMessage("Campo Salário precisa ser maior que 0");

            RuleFor(f => f.DataNascimento)
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

        private bool ValidarCtps(string ctps)
        {
            if (string.IsNullOrEmpty(ctps)) return false;

            return ctps.Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).Length == 13;
        }
    }
}
