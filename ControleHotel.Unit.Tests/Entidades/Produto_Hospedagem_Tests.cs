using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ControleHotel.Tests.Common.Fixtures;

namespace ControleHotel.Unit.Tests.Entidades
{
    [Collection(nameof(Produto_Hospedagem_FixtureCollection))]
    public class Produto_Hospedagem_Tests : IClassFixture<Produto_Hospedagem_Fixture>, IClassFixture<HospedagemFixture>, IClassFixture<ClienteFixture>, IClassFixture<QuartoFixture>, IClassFixture<ProdutoFixture>, IClassFixture<EnderecoFixture>, IClassFixture<TipoQuartoFixture>
    {
        private readonly Produto_Hospedagem_Fixture _produto_Hospedagem_Fixture;
        private readonly HospedagemFixture _hospedagemFixture;
        private readonly ClienteFixture _clienteFixture;
        private readonly QuartoFixture _quartoFixture;
        private readonly ProdutoFixture _produtoFixture;
        private readonly EnderecoFixture _enderecoFixture;
        private readonly TipoQuartoFixture _tipoQuartoFixture;

        public Produto_Hospedagem_Tests(Produto_Hospedagem_Fixture produto_Hospedagem_Fixture, HospedagemFixture hospedagemFixture, ClienteFixture clienteFixture, QuartoFixture quartoFixture, ProdutoFixture produtoFixture, EnderecoFixture enderecoFixture, TipoQuartoFixture tipoQuartoFixture)
        {
            _produto_Hospedagem_Fixture = produto_Hospedagem_Fixture;
            _hospedagemFixture = hospedagemFixture;
            _clienteFixture = clienteFixture;
            _quartoFixture = quartoFixture;
            _produtoFixture = produtoFixture;
            _enderecoFixture = enderecoFixture;
            _tipoQuartoFixture = tipoQuartoFixture;
        }

        [Fact]
        [Trait("ProdutoHospedagem", "ProdutoHospedagem_ProdutoHospedagemValido_ProdutoHospedagemValido")]
        public void ProdutoHospedagem_ProdutoHospedagemValido_ProdutoHospedagemValido()
        {
            //ARRANGE e ACT
            var produtosHospedagem = _produto_Hospedagem_Fixture.ProdutoHospedagemValido(5);
            bool valido;

            foreach(var prodHosp in produtosHospedagem)
            {
                prodHosp.AdicionarComplemento(_hospedagemFixture.HospedagemValida(1)[0]);
                prodHosp.Hospedagem.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
                prodHosp.Hospedagem.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                prodHosp.Hospedagem.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
                prodHosp.Hospedagem.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);
                prodHosp.AdicionarComplemento(_produtoFixture.ProdutoValido(1)[0]);

                valido = prodHosp.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram corretamente preenchidos");
                prodHosp.Validacao.Errors.Should().BeEmpty(because: "todos os dados são válidos");
            }
        }

        [Fact]
        [Trait("ProdutoHospedagem", "ProdutoHospedagem_ProdutoHospedagemQtdValorInvalidos_ProdutoHospedagemInvalido")]
        public void ProdutoHospedagem_ProdutoHospedagemQtdValorInvalidos_ProdutoHospedagemInvalido()
        {
            //ARRANGE
            var prodHosp = _produto_Hospedagem_Fixture.ProdutoHospedagemQtdValorInvalidos();
            prodHosp.AdicionarComplemento(_hospedagemFixture.HospedagemValida(1)[0]);
            prodHosp.Hospedagem.AdicionarComplemento(_clienteFixture.ClienteValido(1)[0]);
            prodHosp.Hospedagem.Cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
            prodHosp.Hospedagem.AdicionarComplemento(_quartoFixture.QuartoValidoOuMaxLengthExcedido(1)[0]);
            prodHosp.Hospedagem.Quarto.AdicionarComplemento(_tipoQuartoFixture.TipoQuartoValido(1)[0]);
            prodHosp.AdicionarComplemento(_produtoFixture.ProdutoValido(1)[0]);

            //ACT
            var valido = prodHosp.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            prodHosp.Validacao.Errors.Should().HaveCount(2);

            prodHosp.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Valor Total deve ser maior que 0"), because: "o valor passado não era maior que 0");
            prodHosp.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Quantidade Consumida deve ser maior que 0"), because: "a quantidade passada não era maior que 0");
        }

        [Fact]
        [Trait("ProdutoHospedagem", "ProdutoHospedagem_ProdutoHospedagemNulos_ProdutoHospedagemInvalido")]
        public void ProdutoHospedagem_ProdutoHospedagemNulos_ProdutoHospedagemInvalido()
        {
            //ARRANGE
            var prodHosp = _produto_Hospedagem_Fixture.ProdutoHospedagemNulos();

            //ACT
            var valido = prodHosp.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "há erros no preenchimento dos campos");
            prodHosp.Validacao.Errors.Should().HaveCount(2);

            prodHosp.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados da Hospedagem são obrigatórios"), because: "uma Hospedagem não foi atribuída");
            prodHosp.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados do Produto são obrigatórios"), because: "um Produto não foi atribuído");
        }
    }
}
