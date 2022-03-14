using ControleHotel.Dominio.Entidades;
using ControleHotel.Tests.Common.Fixtures;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControleHotel.Unit.Tests.Entidades
{
    [Collection(nameof(CheckOutFixtureCollection))]
    public class CheckOutTests : IClassFixture<CheckOutFixture>, IClassFixture<HospedagemFixture>, IClassFixture<ClienteFixture>, IClassFixture<QuartoFixture>, IClassFixture<EnderecoFixture>, IClassFixture<TipoQuartoFixture>
    {
        private readonly CheckOutFixture _checkOutFixture;
        private readonly HospedagemFixture _hospedagemFixture;
        private readonly ClienteFixture _clienteFixture;
        private readonly QuartoFixture _quartoFixture;
        private readonly EnderecoFixture _enderecoFixture;
        private readonly TipoQuartoFixture _tipoQuartoFixture;

        public CheckOutTests(CheckOutFixture checkOutFixture, HospedagemFixture hospedagemFixture, ClienteFixture clienteFixture, QuartoFixture quartoFixture, EnderecoFixture enderecoFixture, TipoQuartoFixture tipoQuartoFixture)
        {
            _checkOutFixture = checkOutFixture;
            _hospedagemFixture = hospedagemFixture;
            _clienteFixture = clienteFixture;
            _quartoFixture = quartoFixture;
            _enderecoFixture = enderecoFixture;
            _tipoQuartoFixture = tipoQuartoFixture;
        }

        [Fact]
        [Trait("CheckOut", "CheckOut_CheckOutHospedagemValida_CheckOutValido")]
        public void CheckOut_CheckOutHospedagemValida_CheckOutValido()
        {
            //ARRANGE e ACT
            var checkOuts = _checkOutFixture.CheckOutHospedagemValida(5);
            bool valido;

            foreach (var checkOut in checkOuts)
            {
                checkOut.AdicionarComplemento(_hospedagemFixture.HospedagemValida(1)[0]);
                checkOut.Hospedagem.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
                checkOut.Hospedagem.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                checkOut.Hospedagem.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
                checkOut.Hospedagem.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);

                valido = checkOut.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                checkOut.Validacao.Errors.Should().BeEmpty(because: "os dados da reserva são válidos");

            }
        }

        [Fact]
        [Trait("CheckOut", "CheckOut_CheckOutHospedagemInvalido_CheckOutInvalido")]
        public void CheckOut_CheckOutHospedagemInvalido_CheckOutInvalido()
        {
            //ARRANGE
            var checkOut = _checkOutFixture.CheckOutHospedagemInvalida();

            //ACT
            var valido = checkOut.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            checkOut.Validacao.Errors.Should().HaveCount(1);

            checkOut.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados da Hospedagem são obrigatórios"), because: "os dados da hospedagem não foram fornecidos");
        }

        [Theory]
        [MemberData(nameof(GerarDataSaida))]
        [Trait("CheckIn", "CheckIn_VerificarDataEntradaReservaValida_ResultadoEsperado")]
        public void CheckIn_VerificarDataEntradaReservaValida_ResultadoEsperado(DataSaidaValidacao dataSaida)
        {
            //ARRANGE e ACT
            var valido = CheckOut.VerificarDataSaidaHospedagemValida(dataSaida.DataSaida);

            //ASSERT
            valido.Should().Be(dataSaida.Resultado);
        }

        public static IEnumerable<object[]> GerarDataSaida()
        {
            yield return new object[]
            {
                new DataSaidaValidacao
                {
                    DataSaida = DateTime.Now,
                    Resultado = true
                }
            };

            yield return new object[]
            {
                new DataSaidaValidacao
                {
                    DataSaida = DateTime.Now.AddDays(5),
                    Resultado = false
                }
            };

            yield return new object[]
            {
                new DataSaidaValidacao
                {
                    DataSaida = DateTime.Now.AddDays(-1),
                    Resultado = false
                }
            };
        }
    }

    public class DataSaidaValidacao
    {
        public DateTime DataSaida { get; set; }
        public bool Resultado { get; set; }
    }
}
