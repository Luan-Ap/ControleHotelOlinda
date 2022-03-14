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
    [CollectionDefinition(nameof(HospedagemFixtureCollection))]
    public class HospedagemFixtureCollection : ICollectionFixture<HospedagemFixture>, ICollectionFixture<ClienteFixture>, ICollectionFixture<QuartoFixture>, ICollectionFixture<EnderecoFixture>, ICollectionFixture<TipoQuartoFixture>
    {

    }

    public class HospedagemFixture
    {
        public List<Hospedagem> HospedagemValida(int qtd)
        {
            var faker = new Faker<Hospedagem>("pt_BR");

            faker.CustomInstantiator(f => 
                new Hospedagem(cod: Guid.NewGuid(), codCliente: Guid.Empty, cliente: null, entrada: DateTime.Now, saida: DateTime.Now.AddDays(5), codQuarto: Guid.Empty, quarto: null, consumo: (double)f.Finance.Amount(0, 1000, 2), ativo: true)
            );

            return faker.Generate(qtd);
        }

        public Hospedagem HospedagemClienteQuartoInvalidos()
        {
            return new Hospedagem(cod: Guid.NewGuid(), codCliente: Guid.Empty, cliente: null, entrada: DateTime.Now, saida: DateTime.Now.AddDays(5), codQuarto: Guid.Empty, quarto: null, consumo: 0, ativo: true);
        }
    }
}
