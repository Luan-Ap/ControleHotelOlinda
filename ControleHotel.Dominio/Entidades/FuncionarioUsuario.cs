using FluentValidation;
using System;

namespace ControleHotel.Dominio.Entidades
{
    public class FuncionarioUsuario : Funcionario
    {
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public int NivelAcesso { get; private set; }

        public FuncionarioUsuario(){}

        public FuncionarioUsuario(Guid cod, string nome, string sobrenome, string cpf, string rg, string ctps, Guid? codEndereco, Endereco endereco, string email, double salario, string cargo, string usuario, string senha, int nivelAcesso, DateTime dataNasc, DateTime dataCad, bool ativo) :
            base(cod, nome, sobrenome, cpf, rg, ctps, codEndereco, endereco, email, salario, cargo, dataNasc, dataCad, ativo)
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
            Usuario = usuario;
            Senha = senha;
            NivelAcesso = nivelAcesso;
        }

        public override bool Validar()
        {
            Validacao = new FuncionarioUsuarioValido().Validate(this);
            return Validacao.IsValid;
        }
    }

    public class FuncionarioUsuarioValido : AbstractValidator<FuncionarioUsuario>
    {
        public FuncionarioUsuarioValido()
        {
            RuleFor(f => f.Nome)
                 .NotEmpty().WithMessage("Campo Nome é obrigatório")
                 .MinimumLength(3).WithMessage("Campo Nome presita ter, no mínimo, 3 caracteres")
                 .MaximumLength(150).WithMessage("Campo Nome pode ter, no máximo, 150 caracteres");

            RuleFor(f => f.Sobrenome)
                .NotEmpty().WithMessage("Campo Sobrenome é obrigatório")
                .MinimumLength(3).WithMessage("Campo Sobrenome presita ter, no mínimo, 3 caracteres")
                .MaximumLength(150).WithMessage("Campo Sobrenome pode ter, no máximo, 150 caracteres");

            RuleFor(f => f.Cpf)
                .NotEmpty().WithMessage("Campo CPF é obrigatório")
                .Must(ValidarCpf)
                .WithMessage("Campo CPF inválido");

            RuleFor(f => f.Rg)
                .NotEmpty().WithMessage("Campo RG é obrigatório")
                .Must(ValidarRg).WithMessage("Campo RG inválido");

            RuleFor(f => f.Endereco)
                .NotNull().WithMessage("Dados de Endereço são obrigatórios").SetValidator(new EnderecoValido());

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("Campo Email é obrigatório")
                .MaximumLength(150).WithMessage("Campo E-mail pode ter, no máximo, 150 caracteres");

            RuleFor(f => f.Email).EmailAddress()
                .When(f => !string.IsNullOrEmpty(f.Email))
                .When(f => f.Email.Length <= 150)
                .WithMessage("Campo Email é inválido");

            RuleFor(f => f.Usuario)
                .NotEmpty().WithMessage("Campo Usuário é obrigatório")
                .MinimumLength(3).WithMessage("Campo Usuário presita ter, no mínimo, 3 caracteres")
                .MaximumLength(150).WithMessage("Campo Usuário pode ter, no máximo, 150 caracteres");

            RuleFor(f => f.Senha)
                 .NotEmpty().WithMessage("Campo Senha é obrigatório")
                 .MinimumLength(3).WithMessage("Campo Senha presita ter, no mínimo, 3 caracteres")
                 .MaximumLength(150).WithMessage("Campo Senha pode ter, no máximo, 150 caracteres");

            RuleFor(f => f.Ctps)
                .NotEmpty().WithMessage("Campo Ctps é obrigatório")
                .Must(ValidarCtps)
                .WithMessage("Campo Ctps inválido");

            RuleFor(f => f.Cargo)
                .NotEmpty().WithMessage("Campo Cargo é obrigatório")
                .MaximumLength(150).WithMessage("Campo Cargo pode ter, no mácimo, 150 caracteres");

            RuleFor(f => f.Salario)
                .NotEmpty().WithMessage("Campo Salário é obrigatório")
                .GreaterThan(0).WithMessage("Salário precisa ser maior que 0");

            RuleFor(f => f.NivelAcesso)
                .ExclusiveBetween(0, 3).WithMessage("Nível de acesso precisa ser 1 ou 2");

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
