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
    public partial class TelaControleUsuario : Form
    {
        private readonly IFuncionarioUsuarioService _funcionarioUsuarioService;
        private FuncionarioUsuario usuario;
        private Endereco endereco;
        private DataTable table;
        private DataColumn column;
        private DataRow row;
        private Guid cod;

        public TelaControleUsuario(IFuncionarioUsuarioService funcionarioUsuarioService)
        {
            InitializeComponent();
            _funcionarioUsuarioService = funcionarioUsuarioService;
        }

        private void TelaControleUsuario_Enter(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            List<FuncionarioUsuario> usuarios = _funcionarioUsuarioService.GetFuncionarioUsuario().ToList();
            
            if(usuarios.Count > 0)
            {
                table = new DataTable("Usuários");

                IniciarColunas(usuarios[0]);
                PreencherTabela(usuarios);

                dgvUsuarios.DataSource = table;

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Não há Usuários cadastrados", "Listar Usuários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void IniciarColunas(FuncionarioUsuario f)
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
            column.DataType = f.Usuario.GetType();
            column.ColumnName = nameof(f.Usuario);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.Senha.GetType();
            column.ColumnName = nameof(f.Senha);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = f.NivelAcesso.GetType();
            column.ColumnName = nameof(f.NivelAcesso);

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

        private void PreencherTabela(List<FuncionarioUsuario> usuarios)
        {
            foreach (var f in usuarios)
            {
                row = table.NewRow();
                row["Codigo"] = f.Codigo;
                row["Nome"] = f.Nome;
                row["Sobrenome"] = f.Sobrenome;
                row["Cpf"] = f.Cpf;
                row["Rg"] = f.Rg;
                row["Ctps"] = f.Ctps;
                row["Email"] = f.Email;
                row["Usuario"] = f.Usuario;
                row["Senha"] = f.Senha;
                row["NivelAcesso"] = f.NivelAcesso;
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
            txtCargo.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;

            numAcesso.Value = numAcesso.Minimum;

            txtNome.Focus();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Usuário para Atualizar!", "Atualizar Usuário",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Usuário para Atualizar!";

                LimparCampos();
                return;
            }

            var codEnderecoFunc = Guid.Parse(dgvUsuarios.CurrentRow.Cells["CodEndereco"].Value.ToString());
            var textoEnderecoFunc = dgvUsuarios.CurrentRow.Cells["TextoEndereco"].Value.ToString();
            var numeroFunc = dgvUsuarios.CurrentRow.Cells["Numero"].Value.ToString();
            var cepFunc = dgvUsuarios.CurrentRow.Cells["Cep"].Value.ToString();
            var telefoneFunc = dgvUsuarios.CurrentRow.Cells["Telefone"].Value.ToString();
            var estadoFunc = dgvUsuarios.CurrentRow.Cells["Estado"].Value.ToString();

            var nomeFunc = txtNome.Text.Trim();
            var sobrenomeFunc = txtSobrenome.Text.Trim();
            var emailFunc = dgvUsuarios.CurrentRow.Cells["Email"].Value.ToString();
            var cpfFunc = dgvUsuarios.CurrentRow.Cells["Cpf"].Value.ToString();
            var rgFunc = dgvUsuarios.CurrentRow.Cells["Rg"].Value.ToString();
            var ctpsFunc = dgvUsuarios.CurrentRow.Cells["Ctps"].Value.ToString();
            var cargoFunc = txtCargo.Text.Trim();
            var usuarioFunc = txtUsuario.Text.Trim();
            var senhaFunc = txtSenha.Text.Trim();
            var acessoFunc = Convert.ToInt32(numAcesso.Value);
            var salarioFunc = Convert.ToDouble(dgvUsuarios.CurrentRow.Cells["Salario"].Value);
            var dataNascFunc = Convert.ToDateTime(dgvUsuarios.CurrentRow.Cells["DataNascimento"].Value);
            var dataCadFunc = Convert.ToDateTime(dgvUsuarios.CurrentRow.Cells["DataCadastro"].Value);

            var ativo = Convert.ToBoolean(dgvUsuarios.CurrentRow.Cells["Ativo"].Value);

            endereco = new Endereco(cod: codEnderecoFunc, textEndereco: textoEnderecoFunc, num: numeroFunc, cep: cepFunc, telefone: telefoneFunc, estado: estadoFunc, ativo: ativo);

            usuario = new FuncionarioUsuario(cod: cod, nome: nomeFunc, sobrenome: sobrenomeFunc, cpf: cpfFunc, rg: rgFunc, ctps: ctpsFunc, codEndereco: codEnderecoFunc, endereco: endereco, email: emailFunc, salario: salarioFunc, cargo: cargoFunc, usuario: usuarioFunc, senha: senhaFunc, nivelAcesso: acessoFunc, dataNasc: dataNascFunc, dataCad: dataCadFunc, ativo: ativo);

            if (_funcionarioUsuarioService.ValidarUsuario(usuario))
            {
                if (_funcionarioUsuarioService.SaveUpdateFuncionarioUsuario(usuario, true))
                {
                    MessageBox.Show("Usuário Atualizado com Sucesso", "Atualizar Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Usuário Atualizado com Sucesso";

                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Falha ao Atualizar Usuário", "Atualizar Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Falha ao Atualizar Usuário";
                }
            }
            else
            {
                MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(usuario)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherCampos()
        {
            cod = Guid.Parse(dgvUsuarios.CurrentRow.Cells["Codigo"].Value.ToString());

            txtNome.Text = dgvUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
            txtSobrenome.Text = dgvUsuarios.CurrentRow.Cells["Sobrenome"].Value.ToString();
            txtCargo.Text = dgvUsuarios.CurrentRow.Cells["Cargo"].Value.ToString();
            txtUsuario.Text = dgvUsuarios.CurrentRow.Cells["Usuario"].Value.ToString();
            txtSenha.Text = dgvUsuarios.CurrentRow.Cells["Senha"].Value.ToString();

            numAcesso.Value = Convert.ToDecimal(dgvUsuarios.CurrentRow.Cells["NivelAcesso"].Value);
        }

        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.CurrentRow.Index != -1)
            {
                PreencherCampos();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
