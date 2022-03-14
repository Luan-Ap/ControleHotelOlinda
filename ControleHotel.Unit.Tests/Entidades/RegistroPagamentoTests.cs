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
    [Collection(nameof(RegistroPagamentoFixtureCollection))]
    public class RegistroPagamentoTests : IClassFixture<RegistroPagamentoFixture>, IClassFixture<HospedagemFixture>, IClassFixture<ReservaFixture>, IClassFixture<ClienteFixture>, IClassFixture<QuartoFixture>, IClassFixture<EnderecoFixture>, IClassFixture<TipoQuartoFixture>
    {
        private readonly RegistroPagamentoFixture _registroPagamentoFixture;
        private readonly HospedagemFixture _hospedagemFixture;
        private readonly ReservaFixture _reservaFixture;
        private readonly ClienteFixture _clienteFixture;
        private readonly QuartoFixture _quartoFixture;
        private readonly EnderecoFixture _enderecoFixture;
        private readonly TipoQuartoFixture _tipoQuartoFixture;

        public RegistroPagamentoTests(RegistroPagamentoFixture registroPagamentoFixture, HospedagemFixture hospedagemFixture, ReservaFixture reservaFixture, ClienteFixture clienteFixture, QuartoFixture quartoFixture, EnderecoFixture enderecoFixture, TipoQuartoFixture tipoQuartoFixture)
        {
            _registroPagamentoFixture = registroPagamentoFixture;
            _hospedagemFixture = hospedagemFixture;
            _reservaFixture = reservaFixture;
            _clienteFixture = clienteFixture;
            _quartoFixture = quartoFixture;
            _enderecoFixture = enderecoFixture;
            _tipoQuartoFixture = tipoQuartoFixture;
        }

        [Fact]
        [Trait("RegistroPagamento", "RegistroPagamento_RegistroPagamentosHospedagensValido_RegistroValido")]
        public void RegistroPagamento_RegistroPagamentosHospedagensValido_RegistroValido()
        {
            //ARRANGE e ACT
            var registros = _registroPagamentoFixture.RegistroPagamentosHospedagensValido(5);
            bool valido;

            foreach (var reg in registros)
            {
                reg.AdicionarComplemento(_hospedagemFixture.HospedagemValida(1)[0]);
                reg.Hospedagem.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
                reg.Hospedagem.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                reg.Hospedagem.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
                reg.Hospedagem.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);
                valido = reg.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                reg.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
        }

        [Fact]
        [Trait("RegistroPagamento", "RegistroPagamento_RegistroPagamentosReservasValido_RegistroValido")]
        public void RegistroPagamento_RegistroPagamentosReservasValido_RegistroValido()
        {
            //ARRANGE e ACT
            var registros = _registroPagamentoFixture.RegistroPagamentosReservasValido(5);
            bool valido;

            foreach (var reg in registros)
            {
                reg.AdicionarComplemento(_reservaFixture.ReservaValida(1)[0]);
                reg.Reserva.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
                reg.Reserva.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                reg.Reserva.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
                reg.Reserva.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);
                valido = reg.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                reg.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
        }

        [Fact]
        [Trait("RegistroPagamento", "RegistroPagamento_RegistroPagamentoValorInvalido_RegistroInvalido")]
        public void RegistroPagamento_RegistroPagamentoValorInvalido_RegistroInvalido()
        {
            //ARRANGE
            var registro = _registroPagamentoFixture.RegistroPagamentoValorInvalido();
            registro.AdicionarComplemento(_reservaFixture.ReservaValida(1)[0]);
            registro.Reserva.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
            registro.Reserva.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
            registro.Reserva.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
            registro.Reserva.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);

            //ACT
            var valido = registro.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            registro.Validacao.Errors.Should().HaveCount(1, because: "apenas o campo Valor é inválido");

            registro.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Valo de pagamento deve ser maior que 0"), because: "o valor passado para o campo não era maior que 0");
        }

        [Fact]
        [Trait("RegistroPagamento", "RegistroPagamento_RegistroPagamentoReservaHospedagemNulos_RegistroInvalido")]
        public void RegistroPagamento_RegistroPagamentoReservaHospedagemNulos_RegistroInvalido()
        {
            //ARRANGE
            var registro = _registroPagamentoFixture.RegistroPagamentoReservaHospedagemNulos();

            //ACT
            var valido = registro.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            registro.Validacao.Errors.Should().HaveCount(1);

            registro.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("O Registro Pagemento precisa ser de uma Reserva ou de uma Hospedagem"), because: "não foi atribuído nem uma Reserva nem uma Hospedagem ao Registro");
        }

        [Fact]
        [Trait("RegistroPagamento", "RegistroPagamento_RegistroPagamentoReservaHospedagemNaoNulos_RegistroInvalido")]
        public void RegistroPagamento_RegistroPagamentoReservaHospedagemNaoNulos_RegistroInvalido()
        {
            //ARRANGE
            var registro = _registroPagamentoFixture.RegistroPagamentoReservaHospedagemNaoNulos();
            registro.AdicionarComplemento(_reservaFixture.ReservaValida(1)[0]);
            registro.Reserva.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
            registro.Reserva.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
            registro.Reserva.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
            registro.Reserva.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);
            
            registro.AdicionarComplemento(_hospedagemFixture.HospedagemValida(1)[0]);
            registro.Hospedagem.AdicionarComplemento(registro.Reserva.Cliente);
            registro.Hospedagem.Cliente.AdicionarComplemento(registro.Hospedagem.Cliente.Endereco);
            registro.Hospedagem.AdicionarComplemento(registro.Reserva.Quarto);
            registro.Hospedagem.Quarto.AdicionarComplemento(registro.Hospedagem.Quarto.TipoQuarto);

            //ACT
            var valido = registro.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            registro.Validacao.Errors.Should().HaveCount(1);

            registro.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("O Registro Pagemento precisa ser de uma Reserva ou de uma Hospedagem"), because: "foram atribuídos uma Reserva e uma Hospedagem ao mesmo Registro");
        }

        [Fact]
        [Trait("RegistroPagamento", "RegistroPagamento_RegistroPagamentoReservaInvalida_RegistroInvalido")]
        public void RegistroPagamento_RegistroPagamentoReservaInvalida_RegistroInvalido()
        {
            //ARRANGE
            var registro = _registroPagamentoFixture.RegistroPagamentoReservaInvalida();
            registro.AdicionarComplemento(_reservaFixture.ReservaCamposInvalidos());

            //ACT
            var valido = registro.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            registro.Validacao.Errors.Should().HaveCount(5, because: "os dados da Reserva atribuída ao registro são inválidos");
        }

        [Fact]
        [Trait("RegistroPagamento", "RegistroPagamento_RegistroPagamentoHospedagemInvalida_RegistroInvalido")]
        public void RegistroPagamento_RegistroPagamentoHospedagemInvalida_RegistroInvalido()
        {
            //ARRANGE
            var registro = _registroPagamentoFixture.RegistroPagamentoHospedagemInvalida();
            registro.AdicionarComplemento(_hospedagemFixture.HospedagemClienteQuartoInvalidos());

            //ACT
            var valido = registro.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            registro.Validacao.Errors.Should().HaveCount(2, because: "os dados da Hospedagem atribuída ao registro são inválidos");
        }
    }
}
