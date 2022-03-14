using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using ControleHotel.Dominio.Entidades;

namespace ControleHotel.Tests.Common.Fixtures
{
    [CollectionDefinition(nameof(EnderecoFixtureCollection))]
    public class EnderecoFixtureCollection : ICollectionFixture<EnderecoFixture>
    {

    }
    public class EnderecoFixture
    {
        public List<Endereco> EndercoValido(int qtd)
        {
            var faker = new Faker<Endereco>("pt_BR");

            faker.CustomInstantiator(f =>
                new Endereco(Guid.NewGuid(), f.Address.StreetName(), f.Random.Int(1, 999).ToString(), f.Address.ZipCode("#####-###"), f.Phone.PhoneNumber("(##) ####-####"), f.Address.StateAbbr(), true)
            );


            return faker.Generate(qtd);
        }

        public Endereco EndercoVazio()
        {
            return new Endereco(Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
        }

        public Endereco EnderecoMaxLengthExcedido()
        {
            var faker = new Faker<Endereco>("pt_BR");
            const int MAX_LENGTH_RUA_EXCEDIDO = 151;
            const int MAX_LENGTH_ESTADO_EXCEDIDO = 3;

            faker.CustomInstantiator(f =>
                new Endereco(Guid.NewGuid(), f.Random.String(MAX_LENGTH_RUA_EXCEDIDO), f.Random.Int(1000000, 9999999).ToString(), f.Address.ZipCode("#####-###"), f.Phone.PhoneNumber("(##) ####-####"), f.Random.String(MAX_LENGTH_ESTADO_EXCEDIDO), true)
            );


            return faker.Generate();
        }

        public Endereco EnderecoCepTelefoneInvalidos()
        {
            var faker = new Faker<Endereco>("pt_BR");

            faker.CustomInstantiator(f =>
                new Endereco(Guid.NewGuid(), f.Address.StreetName(), f.Random.Int(1, 999).ToString(), f.Address.ZipCode("########-###"), f.Phone.PhoneNumber("(##) #######-####"), f.Address.StateAbbr(), true)
            );


            return faker.Generate();
        }
    }
}
