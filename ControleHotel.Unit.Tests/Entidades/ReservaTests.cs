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
    [Collection(nameof(ReservaFixtureCollection))]
    public class ReservaTests : IClassFixture<ReservaFixture>, IClassFixture<ClienteFixture>, IClassFixture<QuartoFixture>, IClassFixture<EnderecoFixture>, IClassFixture<TipoQuartoFixture>
    {
        private readonly ReservaFixture _reservaFixture;
        private readonly ClienteFixture _clienteFixture;
        private readonly QuartoFixture _quartoFixture;
        private readonly EnderecoFixture _enderecoFixture;
        private readonly TipoQuartoFixture _tipoQuartoFixture;

        public ReservaTests(ReservaFixture reservaFixture, ClienteFixture clienteFixture, QuartoFixture quartoFixture, EnderecoFixture enderecoFixture, TipoQuartoFixture tipoQuartoFixture)
        {
            _reservaFixture = reservaFixture;
            _clienteFixture = clienteFixture;
            _quartoFixture = quartoFixture;
            _enderecoFixture = enderecoFixture;
            _tipoQuartoFixture = tipoQuartoFixture;
        }

        [Fact]
        [Trait("Reserva", "Reserva_CamposCorretamentePreenchidos_ReservaValida")]
        public void Reserva_CamposCorretamentePreenchidos_ReservaValida()
        {
            //ARRANGE e ACT
            var reservas = _reservaFixture.ReservaValida(5);
            bool valido;

            foreach(var reserva in reservas)
            {
                reserva.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
                reserva.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                reserva.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
                reserva.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);

                valido = reserva.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                reserva.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
        }

        [Fact]
        [Trait("Reserva", "Reserva_CamposInvalidos_ReservaInvalida")]
        public void Reserva_CamposInvalidos_ReservaInvalida()
        {
            //ARRANGE
            var reserva = _reservaFixture.ReservaCamposInvalidos();

            //ACT
            var valido = reserva.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            reserva.Validacao.Errors.Should().HaveCount(5, because: "há erros no preenchimento dos campos");

            reserva.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados do Cliente são obrigatórios"), because: "os dados do cliente não foram corretamente informados");
            reserva.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados do Quarto são obrigatórios"), because: "os dados do quarto não foram corretamente informados");
            reserva.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("A quantidade máxima de acompanhantes é 3"), because: "o valor passado para o campo excedeu o limite");
            reserva.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("A Data de Entrada precisa ser a data de hoje ou uma futura"), because: "a data escolhida é uma data passada");
            reserva.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("A Data de Saída precisa ser, ao menos, um dia após a Data de Entrada"), because: "a data escolhida é uma data anterior à data de entrada");
        }

        [Theory]
        [MemberData(nameof(ReservaCancelamento))]
        [Trait("Reserva", "Reserva_VerificarHaMultaParaCancelamento_ResultadoEsperado")]
        public void Reserva_VerificarHaMultaParaCancelamento_ResultadoEsperado(ReservaCancelamento reservaCancelamento)
        {
            //ARRANGE ACT
            var valido = Reserva.VerificarHaMultaParaCancelamento(reservaCancelamento.DataEntrada);

            //ASSERT
            valido.Should().Be(reservaCancelamento.Multada);
        }

        public static IEnumerable<object[]> ReservaCancelamento()
        {
            yield return new object[]
            {
                new ReservaCancelamento
                {
                    DataEntrada = DateTime.Now,
                    Multada = true
                }
            };

            yield return new object[]
            {
                new ReservaCancelamento
                {
                    DataEntrada = DateTime.Now.AddDays(2),
                    Multada = false
                }
            };
        }

        
    }
    public class ReservaCancelamento
    {
        public DateTime DataEntrada { get; set; }
        public bool Multada { get; set; }
    }

}
