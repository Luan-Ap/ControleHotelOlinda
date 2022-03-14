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
    [CollectionDefinition(nameof(Produto_Hospedagem_FixtureCollection))]
    public class Produto_Hospedagem_FixtureCollection : ICollectionFixture<Produto_Hospedagem_Fixture>, ICollectionFixture<HospedagemFixture>, ICollectionFixture<ClienteFixture>, ICollectionFixture<QuartoFixture>, ICollectionFixture<ProdutoFixture>, ICollectionFixture<EnderecoFixture>, ICollectionFixture<TipoQuartoFixture>
    {

    }

    public class Produto_Hospedagem_Fixture
    {
        public List<Produto_Hospedagem> ProdutoHospedagemValido(int qtd)
        {
            var faker = new Faker<Produto_Hospedagem>("pt_BR");

            faker.CustomInstantiator(f =>
                new Produto_Hospedagem(cod: Guid.NewGuid(), codHosp: Guid.Empty, hosp: null, codProd: Guid.Empty, produto: null, qtd: f.Random.Int(1, 10), total: (double)f.Finance.Amount(1, 500, 2), dataConsumo: DateTime.Now, ativo: true)
            );

            return faker.Generate(qtd);
        }

        public Produto_Hospedagem ProdutoHospedagemQtdValorInvalidos()
        {
            var faker = new Faker<Produto_Hospedagem>("pt_BR");

            faker.CustomInstantiator(f =>
                new Produto_Hospedagem(cod: Guid.NewGuid(), codHosp: Guid.Empty, hosp: null, codProd: Guid.Empty, produto: null, qtd: f.Random.Int(-100, 0), total: (double)f.Finance.Amount(-500, 0, 2), dataConsumo: DateTime.Now, ativo: true)
            );

            return faker.Generate();
        }

        public Produto_Hospedagem ProdutoHospedagemNulos()
        {
            var faker = new Faker<Produto_Hospedagem>("pt_BR");

            faker.CustomInstantiator(f =>
                new Produto_Hospedagem(cod: Guid.NewGuid(), codHosp: Guid.Empty, hosp: null, codProd: Guid.Empty, produto: null, qtd: f.Random.Int(1, 10), total: (double)f.Finance.Amount(1, 500, 2), dataConsumo: DateTime.Now, ativo: true)
            );

            return faker.Generate();
        }
    }
}
