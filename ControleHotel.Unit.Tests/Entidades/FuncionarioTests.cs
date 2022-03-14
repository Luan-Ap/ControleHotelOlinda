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
    [Collection(nameof(FuncionarioFixtureColletion))]
    public class FuncionarioTests : IClassFixture<FuncionarioFixture>, IClassFixture<EnderecoFixture>
    {
        private readonly FuncionarioFixture _funcionarioFixture;
        private readonly EnderecoFixture _enderecoFixture;

        public FuncionarioTests(FuncionarioFixture funcionarioFixture, EnderecoFixture enderecoFixture)
        {
            _funcionarioFixture = funcionarioFixture;
            _enderecoFixture = enderecoFixture;
        }

        [Fact]
        [Trait("Funcionario", "Funcionario_CamposCorretamentePreenchidos_FuncionarioValido")]
        public void Funcionario_CamposCorretamentePreenchidos_FuncionarioValido()
        {
            //ARRANGE e ACT
            var funcionarios = _funcionarioFixture.FuncionarioValido(5);
            bool valido;
            foreach (var funcionario in funcionarios)
            {
                funcionario.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                valido = funcionario.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                funcionario.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
        }

        [Fact]
        [Trait("Funcionario", "Funcionario_CamposNaoPreenchidos_FuncionarioInvalido")]
        public void Funcionario_CamposNaoPreenchidos_FuncionarioInvalido()
        {
            //ARRANGE
            var funcionario = _funcionarioFixture.FuncionarioVazio();

            //ACT
            var valido = funcionario.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "os campos não foram preenchidos");
            funcionario.Validacao.Errors.Should().NotBeEmpty(because: "há erros no preenchimento");
            funcionario.Validacao.Errors.Should().HaveCount(16, because: "nenhum dos campos foi preenchido");

            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Nome é obrigatório"), because: "campo nome não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Nome presita ter, no mínimo, 3 caracteres"), because: "campo nome não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Sobrenome é obrigatório"), because: "campo sobrenome não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Sobrenome presita ter, no mínimo, 3 caracteres"), because: "campo sobrenome não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo CPF é obrigatório"), because: "campo cpf não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo CPF inválido"), because: "campo cpf não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo RG é obrigatório"), because: "campo rg não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo RG inválido"), because: "campo rg não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Email é obrigatório"), because: "campo e-mail não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Ctps é obrigatório"), because: "campo ctps não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Ctps inválido"), because: "campo ctps não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Cargo é obrigatório"), because: "campo cargo não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Salário é obrigatório"), because: "campo salário não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Salário precisa ser maior que 0"), because: "campo salário não foi preenchido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Dados de Endereço são obrigatórios"), because: "dados de endereço não foram preenchidos");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Idade precisa ser maior ou igual a 18 anos"), because: "campo data de nascimento foi preenchido com uma data inválida");

        }

        [Fact]
        [Trait("Funcionario", "Funcionario_MaxLengthCargoExecidoCtpsInvalido_FuncionarioInvalido")]
        public void Funcionario_MaxLengthCargoExecidoCtpsInvalido_FuncionarioInvalido()
        {
            //ARRANGE
            var funcionario = _funcionarioFixture.FuncionarioCargoMaxLengthExcedidoCtpsInvalido();
            funcionario.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);

            //ACT
            var valido = funcionario.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "os campos não foram preenchidos de forma correta");
            funcionario.Validacao.Errors.Should().NotBeEmpty(because: "há erros no preenchimento");
            funcionario.Validacao.Errors.Should().HaveCount(2, because: "há erros no preenchimento dos campos Ctps e Cargo");

            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Ctps inválido"), because: "formato do campo ctps inválido");
            funcionario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Campo Cargo pode ter, no mácimo, 150 caracteres"), because: "capacidade do campo cargo foi excedida");
        }

        [Fact]
        [Trait("FuncionarioUsuario", "FuncionarioUsuario_CamposCorretamentePreenchidos_FuncionarioUsuarioValido")]
        public void FuncionarioUsuario_CamposCorretamentePreenchidos_FuncionarioUsuarioValido()
        {
            //ARRANGE e ACT
            var funcionariosUsuarios = _funcionarioFixture.FuncionarioUsuarioValido(5);
            bool valido;
            foreach (var funcionario in funcionariosUsuarios)
            {
                funcionario.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);
                valido = funcionario.Validar();

                //ASSERT
                valido.Should().BeTrue(because: "todos os campos foram preenchidos corretamente");
                funcionario.Validacao.Errors.Should().BeEmpty(because: "não há erros no preenchimento");
            }
        }

        [Fact]
        [Trait("FuncionarioUsuario", "FuncionarioUsuario_CampoNivelAcessoInvalido_FuncionarioUsuarioInvalido")]
        public void FuncionarioUsuario_CampoNivelAcessoInvalido_FuncionarioUsuarioInvalido()
        {
            //ARRANGE
            var funcionariosUsuario = _funcionarioFixture.FuncionarioUsuarioNivelAcessoInvalido();
            funcionariosUsuario.AdicionarComplemento(_enderecoFixture.EndercoValido(1)[0]);

            //ACT
            var valido = funcionariosUsuario.Validar();

            //ASSERT
            valido.Should().BeFalse(because: "campo Nível de Acesso é inválido");
            funcionariosUsuario.Validacao.Errors.Should().HaveCount(1, because: "há erro no preenchimento do campo Nível de Acesso");

            funcionariosUsuario.Validacao.Errors.Should().Contain(e => e.ErrorMessage.Equals("Nível de acesso precisa ser 1 ou 2"), because: "o campo nível de acesso é inválido");
        }
    }
}
