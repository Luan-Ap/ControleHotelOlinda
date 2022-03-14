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
    [Collection(nameof(EnderecoFixtureCollection))]
    public class EnderecoTests : IClassFixture<EnderecoFixture>
    {
        private readonly EnderecoFixture _enderecoFixture;

        public EnderecoTests(EnderecoFixture enderecoFixture)
        {
            _enderecoFixture = enderecoFixture;
        }

        [Fact]
        [Trait("Endereco", "Endereco_CamposCorretamentePreenchidos_EnderecoValido")]
        public void Endereco_CamposCorretamentePreenchidos_EnderecoValido()
        {
            //ARRANGE e ACT
            var enderecos = _enderecoFixture.EndercoValido(5);
            bool valido;
            foreach(var endereco in enderecos)
            {
                valido = endereco.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                endereco.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
            
        }

        [Fact]
        [Trait("Endereco", "Endereco_CamposNaoPreenchidos_EnderecoInvalido")]
        public void Endereco_CamposNaoPreenchidos_EnderecoInvalido()
        {
            //ARRANGE
            var endereco = _enderecoFixture.EndercoVazio();

            //ACT
            var valido = endereco.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "os campos não foram preenchidos");
            endereco.Validacao.Errors.Should().NotBeEmpty(because: "há erros no preenchimento");
            endereco.Validacao.Errors.Should().HaveCount(7, because: "nenhum dos campos foi preenchido");

            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Rua é obrigatório"), because: "campo rua não foi preenchido");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Rua presita ter, no mínimo, 5 caracteres"), because: "campo rua não foi preenchido");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Número é obrigatório"), because: "campo número não foi preenchido");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Cep é obrigatório"), because: "campo cep não foi preenchido");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Telefone é obrigatório"), because: "campo telefone não foi preenchido");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Estado é obrigatório"), because: "campo estado não foi preenchido");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Estado pode ter apenas 2 caractres"), because: "campo estado não foi preenchido");
        }

        [Fact]
        [Trait("Endereco", "Endereco_MaxLengthExcedido_EnderecoInvalido")]
        public void Endereco_MaxLengthExcedido_EnderecoInvalido()
        {
            //ARRANGE
            var endereco = _enderecoFixture.EnderecoMaxLengthExcedido();

            //ACT
            var valido = endereco.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "a capacidade máxima dos campos foi excedida");
            endereco.Validacao.Errors.Should().NotBeEmpty(because: "há erros no preenchimento");
            endereco.Validacao.Errors.Should().HaveCount(3, because: "a capacidade máxima dos campos Rua, Número e Estado foi excedida");

            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Rua pode ter, no máximo, 150 caracteres"), because: "capacidade máxima do campo rua foi excedida");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Número pode ter, no máximo, 6 números"), because: "capacidade máxima do campo número foi excedida");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Estado pode ter apenas 2 caractres"), because: "capacidade máxima do estado nome foi excedida");
        }

        [Fact]
        [Trait("Endereco", "Endereco_CepTelefoneInvalidos_EnderecoInvalido")]
        public void Endereco_CepTelefoneInvalidos_EnderecoInvalido()
        {
            //ARRANGE
            var endereco = _enderecoFixture.EnderecoCepTelefoneInvalidos();

            //ACT
            var valido = endereco.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "os campos Cep e Telefone são inválidos");
            endereco.Validacao.Errors.Should().HaveCount(2, because: "os campos Cep e Telefone foram preenchidos de forma inválida");

            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Cep inválido"), because: "formato do cep é inválido");
            endereco.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Telefone inválido"), because: "formato do telefone é inválido");
        }
    }
}
