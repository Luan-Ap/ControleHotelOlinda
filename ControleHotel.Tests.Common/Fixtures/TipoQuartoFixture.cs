using Bogus;
using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControleHotel.Tests.Common.Fixtures
{
    [CollectionDefinition(nameof(TipoQuartoFixtureCollection))]
    public class TipoQuartoFixtureCollection : ICollectionFixture<TipoQuartoFixture>
    {

    }

    public class TipoQuartoFixture
    {
        public List<TipoQuarto> TipoQuartoValido(int qtd)
        {
            var faker = new Faker<TipoQuarto>("pt_BR");

            faker.CustomInstantiator(f =>
                new TipoQuarto(cod: Guid.NewGuid(), valor: (double)f.Finance.Amount(100, 400, 2), tipo: f.Random.String2(1, 20), f.Random.Int(0, 3), ativo: true)
                );

            return faker.Generate(qtd);
        }

        public TipoQuarto TipoQuartoValorTipoInvalidos()
        {
            var faker = new Faker<TipoQuarto>("pt_BR");

            faker.CustomInstantiator(f => 
                new TipoQuarto(cod: Guid.Empty, valor: 0, tipo: string.Empty, f.Random.Int(4, 20), ativo: true)
                );

            return faker.Generate();
        }

        public TipoQuarto TipoQuartoMaxLengthExcedido()
        {
            const int MAX_LENGTH_EXCEDIDO = 21;
            var faker = new Faker<TipoQuarto>("pt_BR");

            faker.CustomInstantiator(f =>
                new TipoQuarto(cod: Guid.NewGuid(), valor: (double)f.Finance.Amount(100, 400, 2), tipo: f.Random.String2(MAX_LENGTH_EXCEDIDO), f.Random.Int(0, 3), ativo: true)
                );

            return faker.Generate();
        }
    }
}
