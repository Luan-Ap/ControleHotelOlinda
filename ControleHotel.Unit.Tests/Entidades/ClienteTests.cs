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
    [Collection(nameof(ClienteFixtureCollection))]
    public class ClienteTests : IClassFixture<ClienteFixture>, IClassFixture<EnderecoFixture>
    {
        private readonly ClienteFixture _clienteFixture;
        private readonly EnderecoFixture _enderecoFixture;

        public ClienteTests(ClienteFixture clienteFixture, EnderecoFixture enderecoFixture)
        {
            _clienteFixture = clienteFixture;
            _enderecoFixture = enderecoFixture;
        }

        [Fact]
        [Trait("Cliente", "Cliente_CamposCorretamentePreenchidos_ClienteValido")]
        public void Cliente_CamposCorretamentePreenchidos_ClienteValido()
        {
            //ARRANGE e ACT
            var clientes = _clienteFixture.ClienteValido(5);
            bool valido;
            foreach (var cliente in clientes)
            {
                cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                valido = cliente.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                cliente.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
        }

        [Fact]
        [Trait("Cliente", "Cliente_CamposNaoPreenchidos_ClienteInvalido")]
        public void Cliente_CamposNaoPreenchidos_ClienteInvalido()
        {
            //ARRANGE
            var cliente = _clienteFixture.ClienteVazio();
            //ACT
            var valido = cliente.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "os campos não foram preenchidos");
            cliente.Validacao.Errors.Should().NotBeEmpty(because: "há erros no preenchimento");
            cliente.Validacao.Errors.Should().HaveCount(11, because: "nenhum dos campos foi preenchido");

            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Nome é obrigatório"), because: "campo nome não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Nome presita ter, no mínimo, 3 caracteres"), because: "campo nome não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Sobrenome é obrigatório"), because: "campo sobrenome não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Sobrenome presita ter, no mínimo, 3 caracteres"), because: "campo sobrenome não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo CPF é obrigatório"), because: "campo cpf não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo CPF inválido"), because: "campo cpf não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo RG é obrigatório"), because: "campo rg não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo RG inválido"), because: "campo rg não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Email é obrigatório"), because: "campo e-mail não foi preenchido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados de Endereço são obrigatórios"), because: "dados de endereço não foram preenchidos");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Idade precisa ser maior ou igual a 18 anos"), because: "campo data de nascimento foi preenchido com uma data inválida");
        }

        [Fact]
        [Trait("Cliente", "Cliente_MaxLengthExcedido_ClienteInvalido")]
        public void Cliente_MaxLengthExcedido_ClienteInvalido()
        {
            //ARRANGE
            var cliente = _clienteFixture.ClienteMaxLengthExcedido();
            cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);

            //ACT
            var valido = cliente.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "a capacidade máxima dos campos foi excedida");
            cliente.Validacao.Errors.Should().NotBeEmpty(because: "há erros no preenchimento");
            cliente.Validacao.Errors.Should().HaveCount(3, because: "a capacidade máxima dos campos Nome, Sobrenome, E-mail e Senha foi excedida");

            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Nome pode ter, no máximo, 150 caracteres"), because: "capacidade máxima do campo nome foi excedida");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Sobrenome pode ter, no máximo, 150 caracteres"), because: "capacidade máxima do campo sobrenome foi excedida");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo E-mail pode ter, no máximo, 150 caracteres"), because: "capacidade máxima do campo e-mail foi excedida");
        }

        [Fact]
        [Trait("Cliente", "Cliente_RgCpfEmailInvalidos_ClienteInvalido")]
        public void Cliente_RgCpfEmailInvalidos_ClienteInvalido()
        {
            //ARRANGE
            var cliente = _clienteFixture.ClienteRgCpfEmailInvalidos();
            cliente.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);

            //ACT
            var valido = cliente.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "os campos RG, CPF e E-mail são inválidos");
            cliente.Validacao.Errors.Should().NotBeEmpty(because: "há erros no preenchimento");
            cliente.Validacao.Errors.Should().HaveCount(3, because: "os campos RG, CPF e E-mail foram preenchidos de forma inválida");

            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Email é inválido"), because: "formato do e-mail é inválido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo CPF inválido"), because: "formato do CPF é inválido");
            cliente.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo RG inválido"), because: "formato do RG é inválido");
        }
    }
}
