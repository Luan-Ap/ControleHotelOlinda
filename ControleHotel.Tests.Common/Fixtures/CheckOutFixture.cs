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
    [CollectionDefinition(nameof(CheckOutFixtureCollection))]
    public class CheckOutFixtureCollection : ICollectionFixture<CheckOutFixture>, ICollectionFixture<HospedagemFixture>,
        ICollectionFixture<ClienteFixture>, ICollectionFixture<QuartoFixture>, ICollectionFixture<EnderecoFixture>, ICollectionFixture<TipoQuartoFixture>
    {

    }

    public class CheckOutFixture
    {
        public List<CheckOut> CheckOutHospedagemValida(int qtd)
        {
            var faker = new Faker<CheckOut>("pt_BR");

            faker.CustomInstantiator(f =>
                new CheckOut(cod: Guid.NewGuid(), codHosp: Guid.Empty, hosp: null, ativo: true)
            );

            return faker.Generate(qtd);
        }

        public CheckOut CheckOutHospedagemInvalida()
        {
            return new CheckOut(cod: Guid.Empty, codHosp: Guid.Empty, hosp: null, ativo: false);
        }
    }
}
