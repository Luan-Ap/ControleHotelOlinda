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
    public partial class TelaControleProdutos : Form
    {
        private readonly IProdutoService _produtoService;
        private DataColumn column;
        private DataRow row;
        private DataTable table;
        private Guid cod = Guid.Empty;

        public TelaControleProdutos(IProdutoService produtoService)
        {
            InitializeComponent();
            _produtoService = produtoService;  
        }

        private void TelaControleProdutos_Enter(object sender, EventArgs e)
        {
            ListarProdutos();
        }

        private void ListarProdutos()
        {
            List<Produto> produtos = _produtoService.GetProdutos().ToList();

            if (produtos.Count > 0)
            {
                table = new DataTable("Produtos");

                IniciarColunas(produtos[0]);
                PreencherTabela(produtos);

                dgvProdutos.DataSource = table;

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Não há Produtos cadastrados", "Listar Produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void IniciarColunas(Produto p)
        {
            column = new DataColumn();
            column.DataType = p.Codigo.GetType();
            column.ColumnName = nameof(p.Codigo);
            column.Unique = true;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = p.Nome.GetType();
            column.ColumnName = nameof(p.Nome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = p.Quantidade.GetType();
            column.ColumnName = nameof(p.Quantidade);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = p.DataCadastro.GetType();
            column.ColumnName = nameof(p.DataCadastro);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = p.Ativo.GetType();
            column.ColumnName = nameof(p.Ativo);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = p.Valor.GetType();
            column.ColumnName = nameof(p.Valor);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = p.TipoProduto.GetType();
            column.ColumnName = nameof(p.TipoProduto);

            table.Columns.Add(column);
        }

        private void PreencherTabela(List<Produto> produtos)
        {
            foreach (var p in produtos)
            {
                row = table.NewRow();
                row["Codigo"] = p.Codigo;
                row["Nome"] = p.Nome;
                row["Quantidade"] = p.Quantidade;
                row["DataCadastro"] = p.DataCadastro;
                row["Valor"] = p.Valor;
                row["TipoProduto"] = p.TipoProduto;
                row["Ativo"] = p.Ativo;

                table.Rows.Add(row);
            }
        }

        private void MtxtValor_Click(object sender, EventArgs e)
        {
            if (mtxtValor.Text.Trim().Length == 1)
            {
                mtxtValor.SelectionStart = 0;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtCadastro.Text = string.Empty;
            mtxtValor.Text = string.Empty;
            numQtd.Value = numQtd.Minimum;

            cod = Guid.Empty;
        }

        private void PreencherCampos()
        {
            cod = Guid.Parse(dgvProdutos.CurrentRow.Cells["Codigo"].Value.ToString());

            txtNome.Text = dgvProdutos.CurrentRow.Cells["Nome"].Value.ToString();
            txtTipo.Text = dgvProdutos.CurrentRow.Cells["Tipo"].FormattedValue.ToString();
            var data = Convert.ToDateTime(dgvProdutos.CurrentRow.Cells["DataCadastro"].Value);
            txtCadastro.Text = data.Date.ToString("d");
            var valor = Convert.ToDouble(dgvProdutos.CurrentRow.Cells["Valor"].Value.ToString());
            mtxtValor.Text = valor.ToString("000.00");
            numQtd.Value = Convert.ToDecimal(dgvProdutos.CurrentRow.Cells["Quantidade"].Value);

            if (txtTipo.Text.Equals("Serviço"))
            {
                numQtd.Enabled = false;
            }
            else
            {
                numQtd.Enabled = true;
            }
        }

        private void DgvProdutos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.CurrentRow.Index != -1)
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
                MessageBox.Show("Selecione um Produto para Desativar!", "Desativar Produto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Produto para Desativar!";

                LimparCampos();
                return;
            }

            var nome = dgvProdutos.CurrentRow.Cells["Nome"].Value.ToString();

            if (MessageBox.Show($"Deseja realmente desativar o Produto {nome}?", "Desativar Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_produtoService.DesativarProduto(cod))
                {
                    MessageBox.Show($"Produto {nome} Desativado com Sucesso!", "Desativar Produto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = $"Produto {nome} Desativado com Sucesso!";

                    ListarProdutos();
                }
                else
                {
                    MessageBox.Show("Falha ao Desativar Produto!", "Desativar Produto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Falha ao Desativar Produto!";
                }
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Produto para Atualizar!", "Atualizar Produto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Produto para Atualizar!";

                LimparCampos();
                return;
            }

            var nome = txtNome.Text.Trim();
            var qtd = Convert.ToInt32(numQtd.Value);
            var valor = double.Parse(mtxtValor.Text.Replace(" ", "0"));
            var tipo = (TipoProduto)Enum.Parse(typeof(TipoProduto), txtTipo.Text);
            var dataCadastro = DateTime.Parse(txtCadastro.Text);
            var ativo = Convert.ToBoolean(dgvProdutos.CurrentRow.Cells["Ativo"].Value);

            var produto = new Produto(cod: cod, nome: nome, qtd: qtd, valor: valor, tipo: tipo, dataCadastro: dataCadastro, ativo: ativo);

            if(_produtoService.ValidarProduto(produto))
            {
                if(_produtoService.SaveUpadateProduto(produto, true))
                {
                    MessageBox.Show("Produto Atualizado com Sucesso", "Atualizar Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Produto Atualizado com Sucesso";

                    ListarProdutos();
                }
                else
                {
                    MessageBox.Show("Falha ao Atualizar Produto", "Atualizar Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Falha ao Atualizar Produto";
                }
            }
            else
            {
                MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(produto)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
