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
    [CollectionDefinition(nameof(QuartoFixtureCollection))]
    public class QuartoFixtureCollection : ICollectionFixture<QuartoFixture>, ICollectionFixture<TipoQuartoFixture>
    {

    }

    public class QuartoFixture
    {
        public List<Quarto> QuartoValidoOuMaxLengthExcedido(int qtd, bool descricaoExcedido = false)
        {
            const int MAX_LENGTH_EXCEDIDO = 251;
            var faker = new Faker<Quarto>("pt_BR");

            faker.CustomInstantiator(f =>
                new Quarto(cod: Guid.NewGuid(), num: f.Random.Int(1, 30), descricao: descricaoExcedido ? f.Random.String2(MAX_LENGTH_EXCEDIDO) : f.Lorem.Sentence(5), tipoId: Guid.Empty, tipo: null, dataCadastro: DateTime.Now.Date, ativo: true)
                );

            return faker.Generate(qtd);
        }

        public Quarto QuartoCamposInvalidos()
        {
            return new Quarto(cod: Guid.Empty, num: 0, descricao: string.Empty, tipoId: Guid.Empty, null, dataCadastro: DateTime.Now.Date, ativo: true);
        }
    }
}
