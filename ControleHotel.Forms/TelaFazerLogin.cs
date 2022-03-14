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
    public partial class TelaFazerLogin : Form
    {
        private readonly IFuncionarioUsuarioService _usuarioService;
        private TelaPrincipal telaPrincipal;
        private int numTentativas = 3;

        public TelaFazerLogin(IFuncionarioUsuarioService usuarioService, TelaPrincipal tela)
        {
            InitializeComponent();

            _usuarioService = usuarioService;
            telaPrincipal = tela;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text.Trim()) || string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                MessageBox.Show("Preencha os campos Usuário e Senha!", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Preencha os campos Usuário e Senha!";

                return;
            }

            var user = txtUser.Text.Trim();
            var senha = txtSenha.Text.Trim();

            var usuario = _usuarioService.GetFuncionarioUsuarioByLogin(user, senha);

            if(usuario != null)
            {
                DefinirAcesso(usuario);

                MessageBox.Show($"Login Efetuado com Sucesso!\nSeja Bem-Vindo(a) {usuario.Nome} {usuario.Sobrenome}", "Fazer Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            else
            {
                numTentativas--;

                if (numTentativas > 0)
                {
                    MessageBox.Show($"Usuário não encontrado! Verifique os campos e tente novamente.\nVocê tem mais {numTentativas} chance(s)!",
                    "Login Funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Usuário não encontrado!";

                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Você não possui mais tentativas para acessar o sistema!\nO programa será encerrado", "Encerramento do Programa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
        }

        private void DefinirAcesso(FuncionarioUsuario usuario)
        {
            telaPrincipal.lbNome.Text = usuario.Nome;
            telaPrincipal.lbCargo.Text = usuario.Cargo;
            telaPrincipal.lbUsuario.Text = usuario.Usuario;
            telaPrincipal.lbNivAcesso.Text = usuario.NivelAcesso.ToString();

            if(usuario.NivelAcesso == 1)
            {
                telaPrincipal.btnCadastrarFunc.Enabled = false;
                telaPrincipal.btnCadastrarProd.Enabled = false;
                telaPrincipal.btnCadastrarQuarto.Enabled = false;
                
                telaPrincipal.btnControleFunc.Enabled = false;
                telaPrincipal.btnControleQuarto.Enabled = false;
                telaPrincipal.btnControleUsuario.Enabled = false;
                telaPrincipal.btnControleProd.Enabled = false;
            }
        }

        private void LimparCampos()
        {
            txtUser.Text = string.Empty;
            txtSenha.Text = string.Empty;

            txtUser.Focus();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
