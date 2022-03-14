using ControleHotel.Dominio.Entidades;
using ControleHotel.Dominio.Interfaces.Services;
using ControleHotel.Services.Services;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class TelaCadastroFuncionario : Form
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IServiceProvider _provider;
        private Funcionario funcionario;
        private Endereco endereco;

        public TelaCadastroFuncionario(IFuncionarioService funcionarioService, IServiceProvider provider)
        {
            InitializeComponent();
            _funcionarioService = funcionarioService;
            _provider = provider;
        }

        private void TelaCadastroFuncionario_Load(object sender, EventArgs e)
        {
            dpNasc.MaxDate = DateTime.Now.AddYears(-18);
            dpNasc.MinDate = dpNasc.MaxDate.AddYears(-80);
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dpNasc.Value = dpNasc.MaxDate;
            txtRua.Text = string.Empty;
            txtEstado.Text = string.Empty;

            mtxtCpf.Text = string.Empty;
            mtxtRg.Text = string.Empty;
            mtxtCtps.Text = string.Empty;
            mtxtSalario.Text = string.Empty;
            mtxtCep.Text = string.Empty;
            mtxtTelefone.Text = string.Empty;

            numEndereco.Value = numEndereco.Minimum;
            rbOutro.Checked = true;

            txtNome.Focus();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RbOutro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOutro.Checked)
            {
                txtCargo.Text = string.Empty;
                txtCargo.ReadOnly = false;
            }
        }

        private void RbRecepcionista_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRecepcionista.Checked)
            {
                txtCargo.Text = "Recepcionista";
                txtCargo.ReadOnly = true;
            }
        }

        private void RbGerente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGerente.Checked)
            {
                txtCargo.Text = "Gerente";
                txtCargo.ReadOnly = true;
            }
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            var codEnderecoFunc = Guid.NewGuid();
            var textoEnderecoFunc = txtRua.Text.Trim();
            var numeroFunc = numEndereco.Value.ToString();
            var cepFunc = mtxtCep.Text.Trim();
            var telefoneFunc = mtxtTelefone.Text.Trim();
            var estadoFunc = txtEstado.Text;

            var codFunc = Guid.NewGuid();
            var nomeFunc = txtNome.Text.Trim();
            var sobrenomeFunc = txtSobrenome.Text.Trim();
            var emailFunc = txtEmail.Text.Trim();
            var cpfFunc = mtxtCpf.Text.Trim();
            var rgFunc = mtxtRg.Text.Trim();
            var ctpsFunc = mtxtCtps.Text.Trim();
            var cargoFunc = txtCargo.Text.Trim();
            var salarioFunc = double.Parse(mtxtSalario.Text.Replace(" ", "0"));
            var dataNascFunc = dpNasc.Value;
            var dataCadFunc = DateTime.Now.Date;

            var ativo = true;

            endereco = new Endereco(cod: codEnderecoFunc, textEndereco: textoEnderecoFunc, num: numeroFunc, cep: cepFunc, telefone: telefoneFunc, estado: estadoFunc, ativo: ativo);

            funcionario = new Funcionario(cod: codFunc, nome: nomeFunc, sobrenome: sobrenomeFunc, cpf: cpfFunc, rg: rgFunc, ctps: ctpsFunc, codEndereco: codEnderecoFunc, endereco: endereco, email: emailFunc, salario: salarioFunc, cargo: cargoFunc, dataNasc: dataNascFunc, dataCad: dataCadFunc, ativo: ativo);

            if (_funcionarioService.ValidarFuncionario(funcionario))
            {
                if (rbOutro.Checked)
                {
                    if (_funcionarioService.SaveUpdateFuncionario(funcionario))
                    {
                        MessageBox.Show("Funcionário Cadastrado com Sucesso", "Cadastrar Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stLbAvisoTxt.Text = "Funcionário Cadastrado com Sucesso";

                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao Cadastrar Funcionário", "Cadastrar Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stLbAvisoTxt.Text = "Falha ao Cadastrar Funcionário";
                    }
                }
                else
                {
                    var cadastroUsuario = new TelaCadastroUsuario(_provider.GetRequiredService<IFuncionarioUsuarioService>(), funcionario);
                    cadastroUsuario.ShowDialog();

                    LimparCampos();
                }
                
            }
            else
            {
                MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(funcionario)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
