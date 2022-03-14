using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControleHotel.Tests.Common.Fixtures
{
    [CollectionDefinition(nameof(FuncionarioFixtureColletion))]
    public class FuncionarioFixtureColletion : ICollectionFixture<FuncionarioFixture>, ICollectionFixture<EnderecoFixture>
    {

    }
    public class FuncionarioFixture
    {
        public List<Funcionario> FuncionarioValido(int qtd)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var faker = new Faker<Funcionario>("pt_BR");

            faker.CustomInstantiator(f =>
                new Funcionario(Guid.NewGuid(), f.Name.FirstName(genero), f.Person.LastName, f.Person.Cpf(), "18.333.521-0", "036943.04562-SP", Guid.Empty, null, string.Empty, (double)f.Finance.Amount(1, 10000, 2), f.Random.Word(), f.Date.Past(50, DateTime.Today.AddYears(-18)), DateTime.Now.Date, true)
                )
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));


            return faker.Generate(qtd);
        }

        public List<FuncionarioUsuario> FuncionarioUsuarioValido(int qtd)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var faker = new Faker<FuncionarioUsuario>("pt_BR");

            faker.CustomInstantiator(f =>
                new FuncionarioUsuario(cod: Guid.NewGuid(), nome: f.Name.FirstName(genero), sobrenome: f.Person.LastName, cpf: f.Person.Cpf(), rg: "18.333.521-0", ctps: "036943.04562-SP", codEndereco: Guid.Empty, endereco: null, email: string.Empty, salario: (double)f.Finance.Amount(1, 10000, 2), cargo: f.Random.Word(), usuario: string.Empty, senha: f.Internet.Password(f.Random.Int(3, 50)), nivelAcesso: f.Random.Int(1, 2), dataNasc: f.Date.Past(50, DateTime.Today.AddYears(-18)), dataCad: DateTime.Now.Date, true)
                )
                .RuleFor(fun => fun.Email, (f, fun) => f.Internet.Email(fun.Nome.ToLower(), fun.Sobrenome.ToLower()))
                .RuleFor(fun => fun.Usuario, (f, fun) => fun.Email);


            return faker.Generate(qtd);
        }

        public FuncionarioUsuario FuncionarioUsuarioNivelAcessoInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var faker = new Faker<FuncionarioUsuario>("pt_BR");

            faker.CustomInstantiator(f =>
                new FuncionarioUsuario(cod: Guid.NewGuid(), nome: f.Name.FirstName(genero), sobrenome: f.Person.LastName, cpf: f.Person.Cpf(), rg: "18.333.521-0", ctps: "036943.04562-SP", codEndereco: Guid.Empty, endereco: null, email: string.Empty, salario: (double)f.Finance.Amount(1, 10000, 2), cargo: f.Random.Word(), usuario: string.Empty, senha: f.Internet.Password(f.Random.Int(3, 50)), nivelAcesso: f.Random.Int(3, 5), dataNasc: f.Date.Past(50, DateTime.Today.AddYears(-18)), dataCad: DateTime.Now.Date, true)
                )
                .RuleFor(fun => fun.Email, (f, fun) => f.Internet.Email(fun.Nome.ToLower(), fun.Sobrenome.ToLower()))
                .RuleFor(fun => fun.Usuario, (f, fun) => fun.Email);


            return faker.Generate();
        }

        public Funcionario FuncionarioVazio()
        {
            return new Funcionario(cod: Guid.Empty, nome: string.Empty, sobrenome: string.Empty, cpf: string.Empty, rg: string.Empty, ctps: string.Empty, codEndereco: Guid.Empty, endereco: null, email: string.Empty, salario: 0, cargo: string.Empty, dataNasc: DateTime.Now.Date, dataCad: DateTime.Now.Date, true);
        }

        public Funcionario FuncionarioCargoMaxLengthExcedidoCtpsInvalido()
        {
            const int MAX_LENGTH_CARGO_EXCEDIDO = 151;

            var genero = new Faker().PickRandom<Name.Gender>();

            var faker = new Faker<Funcionario>("pt_BR");

            faker.CustomInstantiator(f =>
                new Funcionario(Guid.NewGuid(), f.Name.FirstName(genero), f.Person.LastName, f.Person.Cpf(), "18.333.521-0", "036943.0004562-SP", Guid.Empty, null, string.Empty, (double)f.Finance.Amount(1, 10000, 2), f.Random.String2(MAX_LENGTH_CARGO_EXCEDIDO), f.Date.Past(50, DateTime.Today.AddYears(-18)), DateTime.Now.Date, true)
                )
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));


            return faker.Generate();
        }
    }
}
