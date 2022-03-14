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
    [Collection(nameof(ProdutoFixtureCollection))]
    public class ProdutoTests : IClassFixture<ProdutoFixture>
    {
        private readonly ProdutoFixture _produtoFixture;

        public ProdutoTests(ProdutoFixture produtoFixture)
        {
            _produtoFixture = produtoFixture;
        }

        [Fact]
        [Trait("Produto", "Produto_CamposCorretamentePreenchidos_ProdutoValido")]
        public void Produto_CamposCorretamentePreenchidos_ProdutoValido()
        {
            //ARRANGE
            var produtos = _produtoFixture.ProdutoValido(5);
            bool valido;
            //ACT
            foreach (var produto in produtos)
            {
                valido = produto.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                produto.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
        }

        [Fact]
        [Trait("Produto", "Produto_CamposQuantidadeValorNomeInvalidos_ProdutoInvalido")]
        public void Produto_CamposQuantidadeValorNomeInvalidos_ProdutoInvalido()
        {
            //ARRANGE
            var produto = _produtoFixture.ProdutoQuantidadeValorNomeInvalidos();

            //ACT
            var valido = produto.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "os campos Quantidade, Valor e Nome do Produto são inválidos");
            produto.Validacao.Errors.Should().HaveCount(3, because: "apenas os campos Quantidade, Valor e Nome do Produto são inválidos");

            produto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Nome do Produto é obrigatório"));
            produto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Quantidade precisa ser maior que 0"));
            produto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Valor do Produto precisa ser maior que 0"));
        }

        [Fact]
        [Trait("Produto", "Produto_CamposQuantidadeValorInvalidos_ProdutoInvalido")]
        public void Produto_CamposQuantidadeValorInvalidos_ProdutoInvalido()
        {
            //ARRANGE
            var produto = _produtoFixture.ProdutoNomeMaxLengthExcedido();

            //ACT
            var valido = produto.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "a capacidade máxima do campo Nome do Produto foi excedida");
            produto.Validacao.Errors.Should().HaveCount(1, because: "apenas o campo Nome do Produto é inválidos");

            produto.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Nome do Produto pode ter, no máximo, 150 caracteres"));
        }

    }
}
