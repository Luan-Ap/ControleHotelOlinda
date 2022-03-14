using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;

namespace ControleHotel.Tests.Common.Fixtures
{
    [CollectionDefinition(nameof(ClienteFixtureCollection))]
    public class ClienteFixtureCollection : ICollectionFixture<ClienteFixture>, ICollectionFixture<EnderecoFixture>
    {

    }

    public class ClienteFixture
    {
        public List<Cliente> ClienteValido(int qtd)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var faker = new Faker<Cliente>("pt_BR");

            faker.CustomInstantiator(f =>
                new Cliente(Guid.NewGuid(), f.Name.FirstName(genero), f.Person.LastName, f.Person.Cpf(), "28.222.345-0", string.Empty, Guid.Empty, null, f.Date.Past(50, DateTime.Today.AddYears(-18)), DateTime.Now.Date, true)
                )
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));


            return faker.Generate(qtd);
        }

        public Cliente ClienteVazio()
        {
            return new Cliente(Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Guid.Empty, null, DateTime.UtcNow, DateTime.Now, false);
        }

        public Cliente ClienteMaxLengthExcedido()
        {
            const int MAXLENGTHEXCEDIDO = 151;

            var genero = new Faker().PickRandom<Name.Gender>();

            var faker = new Faker<Cliente>("pt_BR");

            faker.CustomInstantiator(f =>
                new Cliente(Guid.NewGuid(), f.Random.String2(MAXLENGTHEXCEDIDO), f.Random.String2(MAXLENGTHEXCEDIDO), f.Person.Cpf(), "28.222.345-0", string.Empty, Guid.Empty, null, f.Date.Past(50, DateTime.Today.AddYears(-18)), DateTime.Now.Date, true)
                )
                .RuleFor(c => c.Email, f => f.Random.String2(MAXLENGTHEXCEDIDO));

            return faker.Generate();
        }

        public Cliente ClienteRgCpfEmailInvalidos()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var faker = new Faker<Cliente>("pt_BR");

            faker.CustomInstantiator(f =>
                new Cliente(Guid.NewGuid(), f.Name.FirstName(genero), f.Person.LastName, "222.455.33", "28.222-0", "dssdfdfdsfsdsdf", Guid.Empty, null, f.Date.Past(50, DateTime.Today.AddYears(-18)), DateTime.Now.Date, true)
                );

            return faker.Generate();
        }
    }
}
