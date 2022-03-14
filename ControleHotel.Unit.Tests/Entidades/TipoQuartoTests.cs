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
    [Collection(nameof(TipoQuartoFixtureCollection))]
    public class TipoQuartoTests : IClassFixture<TipoQuartoFixture>
    {
        private readonly TipoQuartoFixture _tipoQuartoFixture;
        
        public TipoQuartoTests(TipoQuartoFixture tipoQuartoFixture)
        {
            _tipoQuartoFixture = tipoQuartoFixture;
        }

        [Fact]
        [Trait("TipoQuarto", "TipoQuarto_CamposCorretamentePreenchidos_TipoQuartoValido")]
        public void TipoQuarto_CamposCorretamentePreenchidos_TipoQuartoValido()
        {
            //ARRANGE e ACT
            var tiposQaurto = _tipoQuartoFixture.TipoQuartoValido(5);
            bool valido;

            foreach(var tipo in tiposQaurto)
            {
                valido = tipo.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                tipo.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimentos");
            }
        }

        [Fact]
        [Trait("TipoQuart", "TipoQuarto_CamposInvalidos_TipoQuartoInvalido")]
        public void TipoQuarto_CamposInvalidos_TipoQuartoInvalido()
        {
            //ARRANGE
            var tipoQuarto = _tipoQuartoFixture.TipoQuartoValorTipoInvalidos();

            //ACT
            var valido = tipoQuarto.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            tipoQuarto.Validacao.Errors.Should().HaveCount(3, because: "os campos Valor, Tipo e Max. Acompanhantes são inválidos");

            tipoQuarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Tipo Quarto é obrigatório"), because: "o campo não foi preenchido");
            tipoQuarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Valor precisa ser maior que 0"), because: "o valor passado para o campo não era maior que 0");
            tipoQuarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Max. Acompanhantes precisa estar entre 0 e 3"), because: "o valor passado para o campo não estava entre o limite estabelecido");
        }

        [Fact]
        [Trait("TipoQuart", "TipoQuarto_CamposTipoExcedido_TipoQuartoInvalido")]
        public void TipoQuarto_CamposTipoExcedido_TipoQuartoInvalido()
        {
            //ARRANGE
            var tipoQuarto = _tipoQuartoFixture.TipoQuartoMaxLengthExcedido();

            //ACT
            var valido = tipoQuarto.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            tipoQuarto.Validacao.Errors.Should().HaveCount(1, because: "apenas o campo TIpo Quarto é inválido");

            tipoQuarto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Tipo Quarto pode ter, no máximo, 20 caracteres"), because: "o campo foi preenchido com uma quantidade de caracteres maior que 20");
        }

    }
}
