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
    [Collection(nameof(CheckInFixtureCollection))]
    public class CheckInTests : IClassFixture<CheckInFixture>, IClassFixture<ReservaFixture>, IClassFixture<ClienteFixture>, IClassFixture<QuartoFixture>, IClassFixture<EnderecoFixture>, IClassFixture<TipoQuartoFixture>
    {
        private readonly CheckInFixture _checkInFixture;
        private readonly ReservaFixture _reservaFixture;
        private readonly ClienteFixture _clienteFixture;
        private readonly QuartoFixture _quartoFixture;
        private readonly EnderecoFixture _enderecoFixture;
        private readonly TipoQuartoFixture _tipoQuartoFixture;

        public CheckInTests(CheckInFixture checkInFixture, ReservaFixture reservaFixture, QuartoFixture quartoFixture, EnderecoFixture enderecoFixture, TipoQuartoFixture tipoQuartoFixture, ClienteFixture clienteFixture)
        {
            _checkInFixture = checkInFixture;
            _reservaFixture = reservaFixture;
            _quartoFixture = quartoFixture;
            _enderecoFixture = enderecoFixture;
            _tipoQuartoFixture = tipoQuartoFixture;
            _clienteFixture = clienteFixture;
        }

        [Fact]
        [Trait("CheckIn", "CheckIn_CheckInReservaValida_CheckInValido")]
        public void CheckIn_CheckInReservaValida_CheckInValido()
        {
            //ARRANGE e ACT
            var checkIns = _checkInFixture.CheckInValido(5);
            bool valido;

            foreach(var checkIn in checkIns)
            {
                checkIn.AdicionarComplemento(_reservaFixture.ReservaValida(1)[0]);
                checkIn.Reserva.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
                checkIn.Reserva.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                checkIn.Reserva.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
                checkIn.Reserva.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);

                valido = checkIn.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                checkIn.Validacao.Errors.Should().BeEmpty(because: "os dados da reserva são válidos");
                
            }
        }

        [Fact]
        [Trait("CheckIn", "CheckIn_CheckInReservaInvalida_CheckInInvalido")]
        public void CheckIn_CheckInReservaInvalida_CheckInInvalido()
        {
            //ARRANGE
            var checkIn = _checkInFixture.CheckInReservaInvalida();

            //ACT
            var valido = checkIn.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            checkIn.Validacao.Errors.Should().HaveCount(1);

            checkIn.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados da Reserva são obrigatórios"), because: "os dados da reserva não foram fornecidos");
        }

        [Theory]
        [MemberData(nameof(GerarDataEntrada))]
        [Trait("CheckIn", "CheckIn_VerificarDataEntradaReservaValida_ResultadoEsperado")]
        public void CheckIn_VerificarDataEntradaReservaValida_ResultadoEsperado(DataEntradaValidacao dataEntrada)
        {
            //ARRANGE e ACT
            var valido = CheckIn.VerificarDataEntradaReservaValida(dataEntrada.DataEntrada);

            //ASSERT
            valido.Should().Be(dataEntrada.Resultado);
        }

        public static IEnumerable<object[]> GerarDataEntrada()
        {
            yield return new object[]
            {
                new DataEntradaValidacao
                {
                    DataEntrada = DateTime.Now.Date,
                    Resultado = true
                }
            };

            yield return new object[]
            {
                new DataEntradaValidacao
                {
                    DataEntrada = DateTime.Now.Date.AddDays(-5),
                    Resultado = false
                }
            };

            yield return new object[]
            {
                new DataEntradaValidacao
                {
                    DataEntrada = DateTime.Now.Date.AddDays(-1),
                    Resultado = false
                }
            };
        }
    }

    public class DataEntradaValidacao
    {
        public DateTime DataEntrada { get; set; }
        public bool Resultado { get; set; }
    }
}
