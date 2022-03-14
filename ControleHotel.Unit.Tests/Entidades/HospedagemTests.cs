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
    [Collection(nameof(HospedagemFixtureCollection))]
    public class HospedagemTests : IClassFixture<HospedagemFixture>, IClassFixture<ClienteFixture>, IClassFixture<QuartoFixture>, IClassFixture<EnderecoFixture>, IClassFixture<TipoQuartoFixture>
    {
        private readonly HospedagemFixture _hospedagemFixture;
        private readonly ClienteFixture _clienteFixture;
        private readonly QuartoFixture _quartoFixture;
        private readonly EnderecoFixture _enderecoFixture;
        private readonly TipoQuartoFixture _tipoQuartoFixture;

        public HospedagemTests(HospedagemFixture hospedagemFixture, ClienteFixture clienteFixture, QuartoFixture quartoFixture, EnderecoFixture enderecoFixture, TipoQuartoFixture tipoQuartoFixture)
        {
            _hospedagemFixture = hospedagemFixture;
            _clienteFixture = clienteFixture;
            _quartoFixture = quartoFixture;
            _enderecoFixture = enderecoFixture;
            _tipoQuartoFixture = tipoQuartoFixture;
        }

        [Fact]
        [Trait("Hospedagem", "Hospedagem_CamposCorretamentePreenchidos_HospedagemValida")]
        public void Hospedagem_CamposCorretamentePreenchidos_HospedagemValida()
        {
            //ARRANGE e ACT
            var hospedagens = _hospedagemFixture.HospedagemValida(5);
            bool valido;

            foreach (var hospedagem in hospedagens)
            {
                hospedagem.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
                hospedagem.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                hospedagem.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
                hospedagem.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);

                valido = hospedagem.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                hospedagem.Validacao.Errors.Should().BeEmpty(because: "não erros no preenchimento");
            }
        }

        [Fact]
        [Trait("Hospedagem", "Hospedagem_ClienteQuartoInvalidos_HospedagemInvalida")]
        public void Hospedagem_ClienteQuartoInvalidos_HospedagemInvalida()
        {
            //ARRANGE
            var hospedagem = _hospedagemFixture.HospedagemClienteQuartoInvalidos();

            //ACT
            var valido = hospedagem.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            hospedagem.Validacao.Errors.Should().HaveCount(2, because: "há apenas erros no preenchimento dos dados do Cliente e Quarto");

            hospedagem.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados do Cliente são obrigatórios"), because: "os dados do cliente não foram corretamente informados");
            hospedagem.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados do Quarto são obrigatórios"), because: "os dados do quarto não foram corretamente informados");
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(100.50, true)]
        [InlineData(200.50, true)]
        [Trait("Hospedagem", "Hospedagem_VerificarHaConsumos_ResultadoEsperado")]
        public void Hospedagem_VerificarHaConsumos_ResultadoEsperado(double valor, bool resultado)
        {
            //ARRANGE ACT
            var valido = Hospedagem.VerificarHaConsumos(valor);

            //ASSERT
            valido.Should().Be(resultado);

            
        }
    }
}
