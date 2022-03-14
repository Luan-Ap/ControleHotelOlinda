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
    public partial class TelaCadastroCliente : Form
    {
        private readonly IClienteService _clienteService;
        private Cliente cliente;
        private Endereco endereco;

        public TelaCadastroCliente(IClienteService clienteService)
        {
            InitializeComponent();
            _clienteService = clienteService;
        }

        private void TelaCadastroCliente_Load(object sender, EventArgs e)
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
            mtxtCep.Text = string.Empty;
            mtxtTelefone.Text = string.Empty;

            numEndereco.Value = numEndereco.Minimum;

            txtNome.Focus();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            var codEnderecoCliente = Guid.NewGuid();
            var textoEnderecoCliente = txtRua.Text.Trim();
            var numeroCliente = numEndereco.Value.ToString();
            var cepCliente = mtxtCep.Text.Trim();
            var telefoneCliente = mtxtTelefone.Text.Trim();
            var estadoCliente = txtEstado.Text;

            var codCliente = Guid.NewGuid();
            var nomeCliente = txtNome.Text.Trim();
            var sobrenomeCliente = txtSobrenome.Text.Trim();
            var emailCliente = txtEmail.Text.Trim();
            var cpfCliente = mtxtCpf.Text.Trim().ToString();
            var rgCliente = mtxtRg.Text.Trim().ToString();
            var dataNascCliente = dpNasc.Value.Date;
            var dataCadCliente = DateTime.Now.Date;

            var ativo = true;

            endereco = new Endereco(cod: codEnderecoCliente, textEndereco: textoEnderecoCliente, num: numeroCliente, cep: cepCliente, telefone: telefoneCliente, estado: estadoCliente, ativo: ativo);

            cliente = new Cliente(cod: codCliente, nome: nomeCliente, sobrenome: sobrenomeCliente, cpf: cpfCliente, rg: rgCliente, email: emailCliente, codEndereco: codEnderecoCliente, endereco: endereco, dataNasc: dataNascCliente, dataCad: dataCadCliente, ativo: ativo);

            if (_clienteService.ValidarCliente(cliente))
            {
                if (_clienteService.SaveUpdateCliente(cliente))
                {
                    MessageBox.Show("Cliente Cadastrado com Sucesso", "Cadastrar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Cliente Cadastrado com Sucesso";

                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao Cadastrar Cliente", "Cadastrar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Falha ao Cadastrar Cliente";
                }
            }
            else
            {
                MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(cliente)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
