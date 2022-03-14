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
    public partial class TelaControleClientes : Form
    {
        private readonly IClienteService _clienteService;
        private Cliente cliente;
        private Endereco endereco;
        private DataTable table;
        private DataColumn column;
        private DataRow row;
        private Guid cod = Guid.Empty;

        public TelaControleClientes(IClienteService clienteService)
        {
            InitializeComponent();
            _clienteService = clienteService;
        }

        private void TelaControleClientes_Enter(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            List<Cliente> clientes = _clienteService.GetClientes().ToList();

            if (clientes.Count > 0)
            {
                table = new DataTable("Clientes");

                IniciarColunas(clientes[0]);
                PreencherTabela(clientes);

                dgvClientes.DataSource = table;

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Não há Clientes cadastrados", "Listar Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void IniciarColunas(Cliente c)
        {
            column = new DataColumn();
            column.DataType = c.Codigo.GetType();
            column.ColumnName = nameof(c.Codigo);
            column.Unique = true;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Nome.GetType();
            column.ColumnName = nameof(c.Nome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Sobrenome.GetType();
            column.ColumnName = nameof(c.Sobrenome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Cpf.GetType();
            column.ColumnName = nameof(c.Cpf);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Rg.GetType();
            column.ColumnName = nameof(c.Rg);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Email.GetType();
            column.ColumnName = nameof(c.Email);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.CodEndereco.GetType();
            column.ColumnName = nameof(c.CodEndereco);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.DataNascimento.GetType();
            column.ColumnName = nameof(c.DataNascimento);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.DataCadastro.GetType();
            column.ColumnName = nameof(c.DataCadastro);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Ativo.GetType();
            column.ColumnName = nameof(c.Ativo);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Endereco.TextoEndereco.GetType();
            column.ColumnName = nameof(c.Endereco.TextoEndereco);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Endereco.Numero.GetType();
            column.ColumnName = nameof(c.Endereco.Numero);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Endereco.Cep.GetType();
            column.ColumnName = nameof(c.Endereco.Cep);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Endereco.Telefone.GetType();
            column.ColumnName = nameof(c.Endereco.Telefone);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = c.Endereco.Estado.GetType();
            column.ColumnName = nameof(c.Endereco.Estado);

            table.Columns.Add(column);
        }

        private void PreencherTabela(List<Cliente> clientes)
        {
            foreach (var c in clientes)
            {
                row = table.NewRow();
                row["Codigo"] = c.Codigo;
                row["Nome"] = c.Nome;
                row["Sobrenome"] = c.Sobrenome;
                row["Cpf"] = c.Cpf;
                row["Rg"] = c.Rg;
                row["Email"] = c.Email;
                row["CodEndereco"] = c.CodEndereco;
                row["DataNascimento"] = c.DataNascimento;
                row["DataCadastro"] = c.DataCadastro;
                row["Ativo"] = c.Ativo;
                row["TextoEndereco"] = c.Endereco.TextoEndereco;
                row["Numero"] = c.Endereco.Numero;
                row["Cep"] = c.Endereco.Cep;
                row["Telefone"] = c.Endereco.Telefone;
                row["Estado"] = c.Endereco.Estado;
                

                table.Rows.Add(row);
            }
        }

        private void LimparCampos()
        {
            cod = Guid.Empty;

            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCadastro.Text = string.Empty;
            txtNascimento.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtEstado.Text = string.Empty;

            mtxtCpf.Text = string.Empty;
            mtxtRg.Text = string.Empty;
            mtxtCep.Text = string.Empty;
            mtxtTelefone.Text = string.Empty;

            numEndereco.Value = numEndereco.Minimum;

            txtNome.Focus();
        }

        private void PreencherCampos()
        {
            cod = Guid.Parse(dgvClientes.CurrentRow.Cells["Codigo"].Value.ToString());

            txtNome.Text = dgvClientes.CurrentRow.Cells["Nome"].Value.ToString();
            txtSobrenome.Text = dgvClientes.CurrentRow.Cells["Sobrenome"].Value.ToString();
            txtEmail.Text = dgvClientes.CurrentRow.Cells["Email"].Value.ToString();
            var cad = Convert.ToDateTime(dgvClientes.CurrentRow.Cells["DataCadastro"].Value);
            txtCadastro.Text = cad.ToString("d");
            var nasc = Convert.ToDateTime(dgvClientes.CurrentRow.Cells["DataNascimento"].Value);
            txtNascimento.Text = nasc.ToString("d");
            txtRua.Text = dgvClientes.CurrentRow.Cells["TextoEndereco"].Value.ToString();
            txtEstado.Text = dgvClientes.CurrentRow.Cells["Estado"].Value.ToString();

            mtxtCpf.Text = dgvClientes.CurrentRow.Cells["Cpf"].Value.ToString();
            mtxtRg.Text = dgvClientes.CurrentRow.Cells["Rg"].Value.ToString();
            mtxtCep.Text = dgvClientes.CurrentRow.Cells["Cep"].Value.ToString();
            mtxtTelefone.Text = dgvClientes.CurrentRow.Cells["Telefone"].Value.ToString();

            numEndereco.Value = Convert.ToDecimal(dgvClientes.CurrentRow.Cells["Numero"].Value);
        }

        private void DgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow.Index != -1)
            {
                PreencherCampos();
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDesativar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Cliente para Desativar!", "Desativar Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Cliente para Desativar!";

                LimparCampos();
                return;
            }

            var nome = dgvClientes.CurrentRow.Cells["Nome"].Value.ToString();
            var sobrenome = dgvClientes.CurrentRow.Cells["Sobrenome"].Value.ToString();

            if (MessageBox.Show($"Deseja realmente desativar o Cliente {nome} {sobrenome}?", "Desativar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_clienteService.DesativarCliente(cod))
                {
                    MessageBox.Show($"Cliente {nome} {sobrenome} Desativado com Sucesso!", "Desativar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();

                    stLbAvisoTxt.Text = $"Cliente {nome} {sobrenome} Desativado com Sucesso!";
                }
                else
                {
                    MessageBox.Show("Falha ao Desativar Cliente!", "Desativar Cliente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Falha ao Desativar Cliente!";
                }
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCpf.Text.Trim()))
            {
                MessageBox.Show("Informe um Cpf para realizar a Consulta", "Consultar Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Informe um Cpf para realizar a Consulta";

                LimparCampos();
                return;
            }

            int index = 0;
            foreach (DataGridViewRow linha in dgvClientes.Rows)
            {
                if (linha.Cells["Cpf"].Value.ToString().Equals(mtxtCpf.Text.Trim()))
                {
                    dgvClientes.CurrentCell = dgvClientes.Rows[index].Cells["Nome"];
                    PreencherCampos();
                    return;
                }
                index++;
            }
            MessageBox.Show("Cliente não encontrado!\nTente um Cpf diferente", "Consultar Cliente",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            stLbAvisoTxt.Text = "Cliente não encontrado!";
            LimparCampos();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Cliente para Atualizar!", "Atualizar Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Cliente para Atualizar!";

                LimparCampos();
                return;
            }

            var codEnderecoCliente = Guid.Parse(dgvClientes.CurrentRow.Cells["CodEndereco"].Value.ToString());
            var textoEnderecoCliente = txtRua.Text.Trim();
            var numeroCliente = numEndereco.Value.ToString();
            var cepCliente = mtxtCep.Text.Trim();
            var telefoneCliente = mtxtTelefone.Text.Trim();
            var estadoCliente = txtEstado.Text;

            var nomeCliente = txtNome.Text.Trim();
            var sobrenomeCliente = txtSobrenome.Text.Trim();
            var emailCliente = txtEmail.Text.Trim();
            var cpfCliente = dgvClientes.CurrentRow.Cells["Cpf"].Value.ToString();
            var rgCliente = dgvClientes.CurrentRow.Cells["Rg"].Value.ToString();
            var dataNascCliente = DateTime.Parse(txtNascimento.Text);
            var dataCadCliente = DateTime.Parse(txtCadastro.Text);

            var ativo = Convert.ToBoolean(dgvClientes.CurrentRow.Cells["Ativo"].Value);

            endereco = new Endereco(cod: codEnderecoCliente, textEndereco: textoEnderecoCliente, num: numeroCliente, cep: cepCliente, telefone: telefoneCliente, estado: estadoCliente, ativo: ativo);

            cliente = new Cliente(cod: cod, nome: nomeCliente, sobrenome: sobrenomeCliente, cpf: cpfCliente, rg: rgCliente, email: emailCliente, codEndereco: codEnderecoCliente, endereco: endereco, dataNasc: dataNascCliente, dataCad: dataCadCliente, ativo: ativo);

            if (_clienteService.ValidarCliente(cliente))
            {
                if (_clienteService.SaveUpdateCliente(cliente, true))
                {
                    MessageBox.Show("Cliente Atualizado com Sucesso", "Atualizar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Cliente Atualizado com Sucesso";

                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Falha ao Atualizar Cliente", "Atualizar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Falha ao Atualizar Cliente";
                }
            }
            else
            {
                MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(cliente)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
