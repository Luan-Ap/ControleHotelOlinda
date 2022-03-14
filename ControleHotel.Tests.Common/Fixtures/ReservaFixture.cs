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
    [CollectionDefinition(nameof(ReservaFixtureCollection))]
    public class ReservaFixtureCollection : ICollectionFixture<ReservaFixture>, ICollectionFixture<ClienteFixture>, ICollectionFixture<QuartoFixture>, ICollectionFixture<EnderecoFixture>, ICollectionFixture<TipoQuartoFixture>
    {

    }

    public class ReservaFixture
    {
        public List<Reserva> ReservaValida(int qtd)
        {
            var faker = new Faker<Reserva>("pt_BR");

            faker.CustomInstantiator(f =>
                new Reserva(cod: Guid.NewGuid(), codCliente: Guid.Empty, cliente: null, codQuarto: Guid.Empty, quarto: null, acomp: f.Random.Int(0, 3), total: (double)f.Finance.Amount(100, 5000, 2), entrada: DateTime.Now.AddDays(1), saida: DateTime.Now.AddDays(5), reserva: DateTime.Today.Date, f.PickRandom<StatusReserva>(), ativo: true)
            );

            return faker.Generate(qtd);
        }

        public Reserva ReservaCamposInvalidos()
        {
            var faker = new Faker<Reserva>("pt_BR");

            faker.CustomInstantiator(f =>
                new Reserva(cod: Guid.Empty, codCliente: Guid.Empty, cliente: null, codQuarto: Guid.Empty, quarto: null, acomp: f.Random.Int(4, 10), total: 0, entrada: DateTime.Now.AddDays(-1), saida: DateTime.Now.AddDays(-3), reserva: DateTime.Today.Date, f.PickRandom<StatusReserva>(), ativo: true)
            );

            return faker.Generate();
        }
    }
}
