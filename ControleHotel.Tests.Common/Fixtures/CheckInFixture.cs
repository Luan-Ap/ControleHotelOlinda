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
    [CollectionDefinition(nameof(CheckInFixtureCollection))]
    public class CheckInFixtureCollection : ICollectionFixture<CheckInFixture>, ICollectionFixture<ReservaFixture>, ICollectionFixture<ClienteFixture>, ICollectionFixture<QuartoFixture>, ICollectionFixture<EnderecoFixture>, ICollectionFixture<TipoQuartoFixture>
    {

    }

    public class CheckInFixture
    {
        public List<CheckIn> CheckInValido(int qtd)
        {
            var faker = new Faker<CheckIn>("pt_BR");

            faker.CustomInstantiator(f =>
                new CheckIn(cod: Guid.NewGuid(), codReserva: Guid.Empty, reserva: null, ativo: true)
            );

            return faker.Generate(qtd);
        }

        public CheckIn CheckInReservaInvalida()
        {
            return new CheckIn(cod: Guid.Empty, codReserva: Guid.Empty, reserva: null, ativo: false);
        }
    }
}
