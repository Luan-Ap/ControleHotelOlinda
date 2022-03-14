using ControleHotel.Dominio.Entidades;
using ControleHotel.Dominio.Interfaces.Services;
using ControleHotel.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleHotel.Forms
{
    public partial class TelaCadastroUsuario : Form
    {
        private readonly IFuncionarioUsuarioService _funcionarioUsuarioService;
        private FuncionarioUsuario usuario;
        private Funcionario _funcionario;
        public TelaCadastroUsuario(IFuncionarioUsuarioService funcionarioUsuarioService, Funcionario funcionario)
        {
            InitializeComponent();
            _funcionarioUsuarioService = funcionarioUsuarioService;
            _funcionario = funcionario;
        }

        private void TelaCadastroUsuario_Load(object sender, EventArgs e)
        {
            txtNome.Text = $"{_funcionario.Nome} {_funcionario.Sobrenome}";
            txtCargo.Text = _funcionario.Cargo;
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            var senhaUsuario = txtSenha.Text.Trim();
            var nivelUsuario = Convert.ToInt32(numAcesso.Value);

            usuario = new FuncionarioUsuario(cod: _funcionario.Codigo, nome: _funcionario.Nome, sobrenome: _funcionario.Sobrenome, cpf: _funcionario.Cpf, rg: _funcionario.Rg, ctps: _funcionario.Ctps, codEndereco: _funcionario.Endereco.Codigo, endereco: _funcionario.Endereco, email: _funcionario.Email, salario: _funcionario.Salario, cargo: _funcionario.Cargo, usuario: _funcionario.Email, senha: senhaUsuario, nivelAcesso: nivelUsuario, dataNasc: _funcionario.DataNascimento, dataCad: _funcionario.DataCadastro, ativo: _funcionario.Ativo);

            if (_funcionarioUsuarioService.ValidarUsuario(usuario))
            {
                if (_funcionarioUsuarioService.SaveUpdateFuncionarioUsuario(usuario))
                {
                    MessageBox.Show("Funcionário-Usuário Cadastrado com Sucesso", "Cadastrar Funcionário-Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
                else
                {
                    MessageBox.Show("Falha ao Cadastrar Funcionário-Usuário", "Cadastrar Funcionário-Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Falha ao Cadastrar Funcionário-Usuário";
                }
            }
            else
            {
                MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(usuario)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
