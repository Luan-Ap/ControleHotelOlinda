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
    [CollectionDefinition(nameof(RegistroPagamentoFixtureCollection))]
    public class RegistroPagamentoFixtureCollection : ICollectionFixture<RegistroPagamentoFixture>, ICollectionFixture<HospedagemFixture>, ICollectionFixture<ReservaFixture>, ICollectionFixture<ClienteFixture>, ICollectionFixture<QuartoFixture>, ICollectionFixture<EnderecoFixture>, ICollectionFixture<TipoQuartoFixture>
    {

    }

    public class RegistroPagamentoFixture
    {
        public List<RegistroPagamento> RegistroPagamentosHospedagensValido(int qtd)
        {
            var faker = new Faker<RegistroPagamento>("pt_BR");

            faker.CustomInstantiator(f =>
                new RegistroPagamento(cod: Guid.NewGuid(), codReserva: null, reserva: null, codHosp: Guid.Empty, hosp: null, pagto: f.PickRandom<FormaPagto>(), valor: (double)f.Finance.Amount(1, 5000, 2), dataPagto: DateTime.Now, ativo: true)
            );

            return faker.Generate(qtd);
        }

        public List<RegistroPagamento> RegistroPagamentosReservasValido(int qtd)
        {
            var faker = new Faker<RegistroPagamento>("pt_BR");

            faker.CustomInstantiator(f =>
                new RegistroPagamento(cod: Guid.NewGuid(), codReserva: Guid.Empty, reserva: null, codHosp: null, hosp: null, pagto: f.PickRandom<FormaPagto>(), valor: (double)f.Finance.Amount(1, 5000, 2), dataPagto: DateTime.Now, ativo: true)
            );

            return faker.Generate(qtd);
        }

        public RegistroPagamento RegistroPagamentoValorInvalido()
        {
            var faker = new Faker<RegistroPagamento>("pt_BR");

            faker.CustomInstantiator(f =>
                new RegistroPagamento(cod: Guid.NewGuid(), codReserva: Guid.Empty, reserva: null, codHosp: null, hosp: null, pagto: f.PickRandom<FormaPagto>(), valor: 0, dataPagto: DateTime.Now, ativo: true)
            );

            return faker.Generate();
        }

        public RegistroPagamento RegistroPagamentoReservaHospedagemNulos()
        {
            var faker = new Faker<RegistroPagamento>("pt_BR");

            faker.CustomInstantiator(f =>
                new RegistroPagamento(cod: Guid.NewGuid(), codReserva: null, reserva: null, codHosp: null, hosp: null, pagto: f.PickRandom<FormaPagto>(), valor: (double)f.Finance.Amount(1, 5000, 2), dataPagto: DateTime.Now, ativo: true)
            );

            return faker.Generate();
        }

        public RegistroPagamento RegistroPagamentoReservaHospedagemNaoNulos()
        {
            var faker = new Faker<RegistroPagamento>("pt_BR");

            faker.CustomInstantiator(f =>
                new RegistroPagamento(cod: Guid.NewGuid(), codReserva: Guid.Empty, reserva: null, codHosp: Guid.Empty, hosp: null, pagto: f.PickRandom<FormaPagto>(), valor: (double)f.Finance.Amount(1, 5000, 2), dataPagto: DateTime.Now, ativo: true)
            );

            return faker.Generate();
        }

        public RegistroPagamento RegistroPagamentoReservaInvalida()
        {
            var faker = new Faker<RegistroPagamento>("pt_BR");

            faker.CustomInstantiator(f =>
                new RegistroPagamento(cod: Guid.NewGuid(), codReserva: Guid.Empty, reserva: null, codHosp: null, hosp: null, pagto: f.PickRandom<FormaPagto>(), valor: (double)f.Finance.Amount(1, 5000, 2), dataPagto: DateTime.Now, ativo: true)
            );

            return faker.Generate();
        }

        public RegistroPagamento RegistroPagamentoHospedagemInvalida()
        {
            var faker = new Faker<RegistroPagamento>("pt_BR");

            faker.CustomInstantiator(f =>
                new RegistroPagamento(cod: Guid.NewGuid(), codReserva: null, reserva: null, codHosp: Guid.Empty, hosp: null, pagto: f.PickRandom<FormaPagto>(), valor: (double)f.Finance.Amount(1, 5000, 2), dataPagto: DateTime.Now, ativo: true)
            );

            return faker.Generate();
        }
    }
}
