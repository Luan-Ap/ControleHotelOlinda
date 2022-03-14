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
    public partial class TelaControleFuncionario : Form
    {
        private readonly IFuncionarioService _funcionarioService;
        private Funcionario funcionario;
        private Endereco endereco;
        private DataTable table;
        private DataColumn column;
        private DataRow row;
        private Guid cod;

        public TelaControleFuncionario(IFuncionarioService funcionarioService)
        {
            InitializeComponent();
            _funcionarioService = funcionarioService;
        }

        private void TelaControleFuncionario_Enter(object sender, EventArgs e)
        {
            ListarFuncionarios();
        }

        private void ListarFuncionarios()
        {
            List<Funcionario> funcionarios = _funcionarioService.GetFuncionarios().ToList();

            if (funcionarios.Count > 0)
            {
                table = new DataTable("Funcionarios");

                IniciarColunas(funcionarios[0]);
                PreencherTabela(funcionarios);

                dgvFunc.DataSource = table;

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Não há Funcionários cadastrados", "Listar Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void IniciarColunas(Funcionario f)
        {
            column = new DataColumn();
            column.DataType = f.Codigo.GetType();
            column.ColumnName = nameof(f.Codigo);
            column.Unique = true;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Nome.GetType();
            column.ColumnName = nameof(f.Nome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Sobrenome.GetType();
            column.ColumnName = nameof(f.Sobrenome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Cpf.GetType();
            column.ColumnName = nameof(f.Cpf);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Rg.GetType();
            column.ColumnName = nameof(f.Rg);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Ctps.GetType();
            column.ColumnName = nameof(f.Ctps);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Email.GetType();
            column.ColumnName = nameof(f.Email);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.CodEndereco.GetType();
            column.ColumnName = nameof(f.CodEndereco);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.DataNascimento.GetType();
            column.ColumnName = nameof(f.DataNascimento);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.DataCadastro.GetType();
            column.ColumnName = nameof(f.DataCadastro);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Cargo.GetType();
            column.ColumnName = nameof(f.Cargo);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Salario.GetType();
            column.ColumnName = nameof(f.Salario);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Ativo.GetType();
            column.ColumnName = nameof(f.Ativo);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Endereco.TextoEndereco.GetType();
            column.ColumnName = nameof(f.Endereco.TextoEndereco);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Endereco.Numero.GetType();
            column.ColumnName = nameof(f.Endereco.Numero);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Endereco.Cep.GetType();
            column.ColumnName = nameof(f.Endereco.Cep);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Endereco.Telefone.GetType();
            column.ColumnName = nameof(f.Endereco.Telefone);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Endereco.Estado.GetType();
            column.ColumnName = nameof(f.Endereco.Estado);

            table.Columns.Add(column);
        }

        private void PreencherTabela(List<Funcionario> funcionarios)
        {
            foreach (var f in funcionarios)
            {
                row = table.NewRow();
                row["Codigo"] = f.Codigo;
                row["Nome"] = f.Nome;
                row["Sobrenome"] = f.Sobrenome;
                row["Cpf"] = f.Cpf;
                row["Rg"] = f.Rg;
                row["Ctps"] = f.Ctps;
                row["Email"] = f.Email;
                row["CodEndereco"] = f.CodEndereco;
                row["DataNascimento"] = f.DataNascimento;
                row["DataCadastro"] = f.DataCadastro;
                row["Cargo"] = f.Cargo;
                row["Salario"] = f.Salario;
                row["Ativo"] = f.Ativo;
                row["TextoEndereco"] = f.Endereco.TextoEndereco;
                row["Numero"] = f.Endereco.Numero;
                row["Cep"] = f.Endereco.Cep;
                row["Telefone"] = f.Endereco.Telefone;
                row["Estado"] = f.Endereco.Estado;


                table.Rows.Add(row);
            }
        }

        private void LimparCampos()
        {
            cod = Guid.Empty;

            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCargo.Text = string.Empty;
            txtNascimento.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtEstado.Text = string.Empty;

            mtxtCpf.Text = string.Empty;
            mtxtRg.Text = string.Empty;
            mtxtCtps.Text = string.Empty;
            mtxtSalario.Text = string.Empty;
            mtxtCep.Text = string.Empty;
            mtxtTelefone.Text = string.Empty;

            numEndereco.Value = numEndereco.Minimum;

            txtNome.Focus();
        }

        private void PreencherCampos()
        {
            cod = Guid.Parse(dgvFunc.CurrentRow.Cells["Codigo"].Value.ToString());

            txtNome.Text = dgvFunc.CurrentRow.Cells["Nome"].Value.ToString();
            txtSobrenome.Text = dgvFunc.CurrentRow.Cells["Sobrenome"].Value.ToString();
            txtEmail.Text = dgvFunc.CurrentRow.Cells["Email"].Value.ToString();
            txtCargo.Text = dgvFunc.CurrentRow.Cells["Cargo"].Value.ToString();
            var nasc = Convert.ToDateTime(dgvFunc.CurrentRow.Cells["DataNascimento"].Value);
            txtNascimento.Text = nasc.ToString("d");
            txtRua.Text = dgvFunc.CurrentRow.Cells["TextoEndereco"].Value.ToString();
            txtEstado.Text = dgvFunc.CurrentRow.Cells["Estado"].Value.ToString();

            mtxtCpf.Text = dgvFunc.CurrentRow.Cells["Cpf"].Value.ToString();
            mtxtRg.Text = dgvFunc.CurrentRow.Cells["Rg"].Value.ToString();
            mtxtCtps.Text = dgvFunc.CurrentRow.Cells["Ctps"].Value.ToString();
            var salario = Convert.ToDouble(dgvFunc.CurrentRow.Cells["Salario"].Value);
            mtxtSalario.Text = salario.ToString("00,000.00");
            mtxtCep.Text = dgvFunc.CurrentRow.Cells["Cep"].Value.ToString();
            mtxtTelefone.Text = dgvFunc.CurrentRow.Cells["Telefone"].Value.ToString();

            numEndereco.Value = Convert.ToDecimal(dgvFunc.CurrentRow.Cells["Numero"].Value);
        }

        private void DgvFunc_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFunc.CurrentRow.Index != -1)
            {
                PreencherCampos();
            }
        }

        private void BtnDesativar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Funcionário para Desativar!", "Desativar Funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Funcionário para Desativar!";

                LimparCampos();
                return;
            }

            var nome = dgvFunc.CurrentRow.Cells["Nome"].Value.ToString();
            var sobrenome = dgvFunc.CurrentRow.Cells["Sobrenome"].Value.ToString();

            if (MessageBox.Show($"Deseja realmente desativar o Funcionário {nome} {sobrenome}?", "Desativar Funcionário", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_funcionarioService.DesativarFuncionario(cod))
                {
                    MessageBox.Show($"Funcionário {nome} {sobrenome} Desativado com Sucesso!", "Desativar Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarFuncionarios();

                    stLbAvisoTxt.Text = $"Funcionário {nome} {sobrenome} Desativado com Sucesso!";
                }
                else
                {
                    MessageBox.Show("Falha ao Desativar Funcionário!", "Desativar Funcionário",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Falha ao Desativar Funcionário!";
                }
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCpf.Text.Trim()))
            {
                MessageBox.Show("Informe um Cpf para realizar a Consulta", "Consultar Funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Informe um Cpf para realizar a Consulta";

                LimparCampos();
                return;
            }

            int index = 0;
            foreach (DataGridViewRow linha in dgvFunc.Rows)
            {
                if (linha.Cells["Cpf"].Value.ToString().Equals(mtxtCpf.Text.Trim()))
                {
                    dgvFunc.CurrentCell = dgvFunc.Rows[index].Cells["Nome"];
                    PreencherCampos();
                    return;
                }
                index++;
            }
            MessageBox.Show("Funcionário não encontrado!\nTente um Cpf diferente", "Consultar Funcionário",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            stLbAvisoTxt.Text = "Funcionário não encontrado!";
            LimparCampos();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Funcionário para Atualizar!", "Atualizar Funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Funcionário para Atualizar!";

                LimparCampos();
                return;
            }

            var codEnderecoFunc = Guid.Parse(dgvFunc.CurrentRow.Cells["CodEndereco"].Value.ToString());
            var textoEnderecoFunc = txtRua.Text.Trim();
            var numeroFunc = numEndereco.Value.ToString();
            var cepFunc = mtxtCep.Text.Trim();
            var telefoneFunc = mtxtTelefone.Text.Trim();
            var estadoFunc = txtEstado.Text;

            var nomeFunc = txtNome.Text.Trim();
            var sobrenomeFunc = txtSobrenome.Text.Trim();
            var emailFunc = txtEmail.Text.Trim();
            var cpfFunc = dgvFunc.CurrentRow.Cells["Cpf"].Value.ToString();
            var rgFunc = dgvFunc.CurrentRow.Cells["Rg"].Value.ToString();
            var ctpsFunc = dgvFunc.CurrentRow.Cells["Ctps"].Value.ToString();
            var cargoFunc = txtCargo.Text.Trim();
            var salarioFunc = double.Parse(mtxtSalario.Text.Replace(" ", "0"));
            var dataNascFunc = DateTime.Parse(txtNascimento.Text);
            var dataCadFunc = Convert.ToDateTime(dgvFunc.CurrentRow.Cells["DataCadastro"].Value);

            var ativo = Convert.ToBoolean(dgvFunc.CurrentRow.Cells["Ativo"].Value);

            endereco = new Endereco(cod: codEnderecoFunc, textEndereco: textoEnderecoFunc, num: numeroFunc, cep: cepFunc, telefone: telefoneFunc, estado: estadoFunc, ativo: ativo);

            funcionario = new Funcionario(cod: cod, nome: nomeFunc, sobrenome: sobrenomeFunc, cpf: cpfFunc, rg: rgFunc, ctps: ctpsFunc, codEndereco: codEnderecoFunc, endereco: endereco, email: emailFunc, salario: salarioFunc, cargo: cargoFunc, dataNasc: dataNascFunc, dataCad: dataCadFunc, ativo: ativo);

            if (_funcionarioService.ValidarFuncionario(funcionario))
            {
                if (_funcionarioService.SaveUpdateFuncionario(funcionario, true))
                {
                    MessageBox.Show("Funcionário Atualizado com Sucesso", "Atualizar Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Funcionário Atualizado com Sucesso";

                    ListarFuncionarios();
                }
                else
                {
                    MessageBox.Show("Falha ao Atualizar Funcionário", "Atualizar Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Falha ao Atualizar Funcionário";
                }
            }
            else
            {
                MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(funcionario)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
