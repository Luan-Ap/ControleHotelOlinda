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
    public partial class TelaControleConsumos : Form
    {
        private readonly IProduto_Hospedagem_Service _prodHospedagem;
        private readonly IHospedagemService _hospedagemService;
        private readonly IProdutoService _produtoService;

        private Guid codHospedagem;
        private Hospedagem hospedagem;
        private Produto produto;

        private double totalAtual = 0;
        private decimal qtd = 0;

        private DataTable table;
        private DataColumn column;
        private DataRow row;

        public TelaControleConsumos(IProduto_Hospedagem_Service prodHospedagem, IHospedagemService hospedagemService, IProdutoService produtoService, Guid cod)
        {
            InitializeComponent();

            _prodHospedagem = prodHospedagem;
            _hospedagemService = hospedagemService;
            _produtoService = produtoService;
            codHospedagem = cod;
        }

        private void TelaControleConsumos_Load(object sender, EventArgs e)
        {
            ListarConsumos();
            hospedagem = _hospedagemService.GetHospedagemByCod(codHospedagem);
            btnAdicionar.Enabled = false;

            if (!hospedagem.Ativo)
            {
                gboxAdicionar.Enabled = false;
                stLbAvisoTxt.Text = "Hospedagem já Concluída! Não é possível Adicionar Consumos!";
            }
            else
            {
                ListarProdutos();
                
            }
        }

        private void ListarProdutos(int opc = 1)
        {
            LimparAdicaoConsumo();

            List<Produto> produtos = new();

            switch (opc)
            {
                case 1:
                    produtos = _produtoService.GetProdutos("Serviço").ToList();
                    break;

                case 2:
                    produtos = _produtoService.GetProdutos("Mercadoria").ToList();
                    break;
            }

            cbProdutos.DataSource = produtos;

            cbProdutos.DisplayMember = "Nome";
            cbProdutos.ValueMember = "Codigo";

            cbProdutos.SelectedIndex = -1;
        }

        private void ListarConsumos()
        {
            List<Produto_Hospedagem> consumos = _prodHospedagem.GetConsumosByHospedagem(codHospedagem).ToList();

            if (consumos.Count > 0)
            {
                table = new DataTable("Consumos");

                IniciarColunas(consumos[0]);
                PreencherTabela(consumos);

                dgvConsumos.DataSource = table;
            }
            
        }

        private void IniciarColunas(Produto_Hospedagem pH)
        {
            column = new DataColumn();
            column.DataType = pH.Codigo.GetType();
            column.ColumnName = nameof(pH.Codigo);
            column.Unique = true;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = pH.CodHospedagem.GetType();
            column.ColumnName = nameof(pH.CodHospedagem);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = pH.CodProduto.GetType();
            column.ColumnName = nameof(pH.CodProduto);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = pH.Produto.Nome.GetType();
            column.ColumnName = nameof(pH.Produto.Nome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = pH.Produto.TipoProduto.GetType();
            column.ColumnName = nameof(pH.Produto.TipoProduto);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = pH.Produto.Valor.GetType();
            column.ColumnName = nameof(pH.Produto.Valor);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = pH.QuantidadeConsumida.GetType();
            column.ColumnName = nameof(pH.QuantidadeConsumida);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = pH.ValorTotal.GetType();
            column.ColumnName = nameof(pH.ValorTotal);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = pH.DataConsumo.GetType();
            column.ColumnName = nameof(pH.DataConsumo);

            table.Columns.Add(column);
        }

        private void PreencherTabela(List<Produto_Hospedagem> consumos)
        {
            foreach (var pH in consumos)
            {
                row = table.NewRow();
                row["Codigo"] = pH.Codigo;
                row["CodHospedagem"] = pH.CodHospedagem;
                row["CodProduto"] = pH.CodProduto;
                row["Nome"] = pH.Produto.Nome;
                row["TipoProduto"] = pH.Produto.TipoProduto;
                row["Valor"] = pH.Produto.Valor;
                row["QuantidadeConsumida"] = pH.QuantidadeConsumida;
                row["ValorTotal"] = pH.ValorTotal;
                row["DataConsumo"] = pH.DataConsumo;

                table.Rows.Add(row);
            }
        }

        private void PreencherCampos()
        {
            txtProduto.Text = dgvConsumos.CurrentRow.Cells["Produto"].Value.ToString();
            txtQtd.Text = dgvConsumos.CurrentRow.Cells["QuantidadeConsumida"].Value.ToString();
            txtTipo.Text = dgvConsumos.CurrentRow.Cells["TipoProduto"].Value.ToString();

            double valorUni = double.Parse(dgvConsumos.CurrentRow.Cells["Valor"].Value.ToString());
            mtxtValUnit.Text = valorUni.ToString("000.00");

            double valorTotal = double.Parse(dgvConsumos.CurrentRow.Cells["ValorTotal"].Value.ToString());
            mtxtTotConsumo.Text = valorTotal.ToString("000.00");

            DateTime dataConsumo = Convert.ToDateTime(dgvConsumos.CurrentRow.Cells["DataConsumo"].Value);
            txtDataConsumo.Text = dataConsumo.ToString("d");

        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RbServico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbServico.Checked)
            {
                ListarProdutos();
            }
            
        }

        private void RbMercadoria_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMercadoria.Checked)
            {
                ListarProdutos(2);
            }
        }

        private void CbProdutos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LimparAdicaoConsumo();
            produto = (Produto)cbProdutos.SelectedItem;
            numQtd.Enabled = true;
            numQtd.Minimum = 0;
            numQtd.Maximum = produto.Quantidade;
            mtxtUnitario.Text = produto.Valor.ToString("000.00");
            mtxtValTot.Text = "000.00";

            btnAdicionar.Enabled = true;
        }

        private void LimparAdicaoConsumo()
        {
            cbProdutos.Text = "";
            mtxtUnitario.Text = "";
            numQtd.Value = numQtd.Minimum;
            mtxtValTot.Text = "";
            numQtd.Enabled = false;
            totalAtual = 0;
            qtd = 0;

            btnAdicionar.Enabled = false;
        }

        private void NumQtd_ValueChanged(object sender, EventArgs e)
        {
            if (numQtd.Value > qtd)
            {
                totalAtual += produto.Valor;
            }
            else
            {
                totalAtual -= produto.Valor;
            }
            qtd = numQtd.Value;
            mtxtValTot.Text = totalAtual.ToString("000.00");
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (qtd > 0 || totalAtual > 0)
            {
                var cod = Guid.NewGuid();
                var data = DateTime.Now.Date;

                Produto_Hospedagem consumo = new Produto_Hospedagem(cod: cod, codHosp: codHospedagem, hosp: hospedagem, codProd: produto.Codigo, produto: produto, qtd: Convert.ToInt32(qtd), total: totalAtual, dataConsumo: data, ativo: true);

                if (_prodHospedagem.ValidarProdutoHospedagem(consumo))
                {
                    if (_prodHospedagem.SaveConsumos(consumo))
                    {
                        MessageBox.Show("Consumo Adicionado à Hospedagem com Sucesso!", "Adicionar Consumo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        stLbAvisoTxt.Text = "Consumo adicionado com Sucesso!";

                        LimparAdicaoConsumo();
                        ListarConsumos();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao Adicionar Consumo à Hospedagem!", "Adicionar Consumo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        stLbAvisoTxt.Text = "Falha ao Adicionar Consumo!";

                        LimparAdicaoConsumo();
                    }
                }
                else
                {
                    MessageBox.Show(AuxilioForms.ListarErrosPreenchimento(consumo), "Erros no preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Escolha um Produto e defina a Quantidade para Adicionar ao Consumo!", "Adicionar Consumo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Escolha um Produto e defina a Quantidade!";
            }
        }

        private void dgvConsumos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConsumos.CurrentRow.Index != -1)
            {
                PreencherCampos();
            }
        }
    }
}
