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
    [CollectionDefinition(nameof(ProdutoFixtureCollection))]
    public class ProdutoFixtureCollection : ICollectionFixture<ProdutoFixture>
    {

    }
    public class ProdutoFixture
    {
        public List<Produto> ProdutoValido(int qtd)
        {
            var faker = new Faker<Produto>("pt_BR");

            faker.CustomInstantiator(f =>
                new Produto(cod: Guid.NewGuid(), nome: f.Commerce.ProductName(), qtd: f.Random.Int(1, 100), valor: double.Parse(f.Commerce.Price(1, 100, 2)), tipo: f.PickRandom<TipoProduto>(), dataCadastro: DateTime.Now.Date, ativo: true)
            );

            return faker.Generate(qtd);
        }

        public Produto ProdutoQuantidadeValorNomeInvalidos()
        {
            var faker = new Faker<Produto>("pt_BR");

            faker.CustomInstantiator(f =>
                new Produto(cod: Guid.NewGuid(), string.Empty, qtd: f.Random.Int(-100, 0), valor: double.Parse(f.Commerce.Price(-100, 0, 2)), tipo: f.PickRandom<TipoProduto>(), dataCadastro: DateTime.Now.Date, ativo: true)
            );

            return faker.Generate();
        }

        public Produto ProdutoNomeMaxLengthExcedido()
        {
            const int MAX_LENGTH_NOME_EXCEDIDO = 151;
            var faker = new Faker<Produto>("pt_BR");

            faker.CustomInstantiator(f =>
                new Produto(cod: Guid.NewGuid(), nome: f.Random.String2(MAX_LENGTH_NOME_EXCEDIDO), qtd: f.Random.Int(1, 100), valor: double.Parse(f.Commerce.Price(1, 100, 2)), tipo: f.PickRandom<TipoProduto>(), dataCadastro: DateTime.Now.Date, ativo: true)
            );

            return faker.Generate();
        }
    }
}
