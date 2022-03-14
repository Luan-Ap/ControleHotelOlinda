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
    [Collection(nameof(QuartoFixtureCollection))]
    public class QuartoTests : IClassFixture<QuartoFixture>, IClassFixture<TipoQuartoFixture>
    {
        private readonly QuartoFixture _quartoFixture;
        private readonly TipoQuartoFixture _tipoQuartoFixture;

        public QuartoTests(QuartoFixture quartoFixture, TipoQuartoFixture tipoQuartoFixture)
        {
            _quartoFixture = quartoFixture;
            _tipoQuartoFixture = tipoQuartoFixture;
        }

        [Fact]
        [Trait("Quarto", "Quarto_CamposCorretamentePreenchidos_QuartoValido")]
        public void Quarto_CamposCorretamentePreenchidos_QuartoValido()
        {
            //ARRANGE e ACT
            var quartos = _quartoFixture.QuartoValidoOuMaxLengthExcedido(5);
            bool valido;

            foreach (var quarto in quartos)
            {
                quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);
                valido = quarto.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                quarto.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
        }

        [Fact]
        [Trait("Quarto", "Quarto_CamposInvalidos_QuartoInvalido")]
        public void Quarto_CamposInvalidos_QuartoInvalido()
        {
            //ARRANGE
            var quarto = _quartoFixture.QuartoCamposInvalidos();

            //ACT
            var valido = quarto.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "os campos são inválidos");
            quarto.Validacao.Errors.Should().HaveCount(4, because: "os campos Núm. do Quarto, Descrição e Tipo Quarto não foram preenchidos");

            quarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Núm. do Quarto precisa ser maior que 0"), because: "não foi passado um número maior que 0 para o campo");
            quarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Descrição é obrigatório"), because: "campo não foi preenchido");
            quarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Descrição precisa ter, no mínimo, 10 caracteres"), because: "campo não foi preenchido com a quantidade mínima de caracteres");
            quarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Selecione um Tipo Quarto"), because: "um Tipo Quarto não foi escolhido");
        }

        [Fact]
        [Trait("Quarto", "Quarto_CampoDescricaoExcesido_QuartoInvalido")]
        public void Quarto_CampoDescricaoExcesido_QuartoInvalido()
        {
            //ARRANGE
            var quarto = _quartoFixture.QuartoValidoOuMaxLengthExcedido(1, true)[0];
            quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);

            //ACT
            var valido = quarto.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "o campo Descrição é inválido");
            quarto.Validacao.Errors.Should().HaveCount(1, because: "apenas o campo Descrição foi preenchido de forma incorreta");

            quarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Descrição pode ter, no máximo, 250 caracteres"), because: "o campo foi preenchido com uma quantidade de caracteres maior que 250");
        }
    }
}
