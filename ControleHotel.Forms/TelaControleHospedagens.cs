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
    public partial class TelaControleHospedagens : Form
    {
        private readonly IHospedagemService _hospedagemService;
        private readonly IServiceProvider _provider;

        private DataTable table;
        private DataColumn column;
        private DataRow row;
        private Guid cod;

        public TelaControleHospedagens(IHospedagemService hospedagemService, IServiceProvider provider)
        {
            InitializeComponent();
            _hospedagemService = hospedagemService;
            _provider = provider;
        }

        private void TelaControleHospedagens_Enter(object sender, EventArgs e)
        {
            ListarHospedagens();
        }

        private void ListarHospedagens(int opc = 1)
        {
            List<Hospedagem> hospedagens = new();

            switch (opc)
            {
                case 1:
                    hospedagens = _hospedagemService.GetHospedagens().ToList();
                    break;

                case 2:
                    hospedagens = _hospedagemService.GetHospedagensByStatus(true).ToList();
                    break;

                case 3:
                    hospedagens = _hospedagemService.GetHospedagensByStatus(false).ToList();
                    break;
            }

            if (hospedagens.Count > 0)
            {
                table = new DataTable("Hospedagens");

                IniciarColunas(hospedagens[0]);
                PreencherTabela(hospedagens);

                dgvHospedagens.DataSource = table;
            }
            else
            {
                MessageBox.Show("Não há Hospedagens para a listagem selecionada", "Listar Hospedagens", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void IniciarColunas(Hospedagem h)
        {
            column = new DataColumn();
            column.DataType = h.Codigo.GetType();
            column.ColumnName = nameof(h.Codigo);
            column.Unique = true;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.CodCliente.GetType();
            column.ColumnName = nameof(h.CodCliente);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.CodQuarto.GetType();
            column.ColumnName = nameof(h.CodQuarto);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.Quarto.TipoQuarto.Tipo.GetType();
            column.ColumnName = nameof(h.Quarto.TipoQuarto.Tipo);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.Cliente.Nome.GetType();
            column.ColumnName = nameof(h.Cliente.Nome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.Quarto.NumQuarto.GetType();
            column.ColumnName = nameof(h.Quarto.NumQuarto);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.ConsumoTotal.GetType();
            column.ColumnName = nameof(h.ConsumoTotal);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.DataEntrada.GetType();
            column.ColumnName = nameof(h.DataEntrada);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.DataSaida.GetType();
            column.ColumnName = nameof(h.DataSaida);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.Cliente.Sobrenome.GetType();
            column.ColumnName = nameof(h.Cliente.Sobrenome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.Cliente.Cpf.GetType();
            column.ColumnName = nameof(h.Cliente.Cpf);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.Cliente.Email.GetType();
            column.ColumnName = nameof(h.Cliente.Email);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = h.Ativo.GetType();
            column.ColumnName = nameof(h.Ativo);

            table.Columns.Add(column);
        }

        private void PreencherTabela(List<Hospedagem> hospedagens)
        {
            foreach (var h in hospedagens)
            {
                row = table.NewRow();
                row["Codigo"] = h.Codigo;
                row["CodCliente"] = h.CodCliente;
                row["CodQuarto"] = h.CodQuarto;
                row["Tipo"] = h.Quarto.TipoQuarto.Tipo;
                row["Nome"] = h.Cliente.Nome;
                row["NumQuarto"] = h.Quarto.NumQuarto;
                row["ConsumoTotal"] = h.ConsumoTotal;
                row["DataEntrada"] = h.DataEntrada;
                row["DataSaida"] = h.DataSaida;
                row["Sobrenome"] = h.Cliente.Sobrenome;
                row["Cpf"] = h.Cliente.Cpf;
                row["Email"] = h.Cliente.Email;
                row["Ativo"] = h.Ativo;

                table.Rows.Add(row);
            }
        }

        private void PreencherCampos()
        {
            cod = Guid.Parse(dgvHospedagens.CurrentRow.Cells["Codigo"].Value.ToString());

            txtNome.Text = dgvHospedagens.CurrentRow.Cells["Nome"].Value.ToString();
            txtSobrenome.Text = dgvHospedagens.CurrentRow.Cells["Sobrenome"].Value.ToString();
            txtEmail.Text = dgvHospedagens.CurrentRow.Cells["Email"].Value.ToString();

            var checkIn = Convert.ToDateTime(dgvHospedagens.CurrentRow.Cells["DataEntrada"].Value);
            txtCheckIn.Text = checkIn.ToString("d");

            var checkOut = Convert.ToDateTime(dgvHospedagens.CurrentRow.Cells["DataSaida"].Value.ToString());
            txtCheckOut.Text = checkOut.ToString("d");

            txtNum.Text = dgvHospedagens.CurrentRow.Cells["NumQuarto"].Value.ToString();
            txtTipo.Text = dgvHospedagens.CurrentRow.Cells["Tipo"].Value.ToString();

            var ativa = Convert.ToBoolean(dgvHospedagens.CurrentRow.Cells["Ativo"].Value.ToString());
            txtStatus.Text = ativa ? "Ativa" : "Concluída";

            mtxtCpf.Text = dgvHospedagens.CurrentRow.Cells["Cpf"].Value.ToString();

            var total = Convert.ToDouble(dgvHospedagens.CurrentRow.Cells["ConsumoTotal"].Value);
            mtxtTotal.Text = total.ToString("0,000.00");
        }

        private void LimparCampos()
        {
            cod = Guid.Empty;

            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCheckIn.Text = string.Empty;
            txtCheckOut.Text = string.Empty;
            txtNum.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtStatus.Text = string.Empty;

            mtxtCpf.Text = string.Empty;
            mtxtTotal.Text = string.Empty;
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RbTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodas.Checked)
            {
                ListarHospedagens();
            }
        }

        private void RbAtivas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAtivas.Checked)
            {
                ListarHospedagens(2);
            }
        }

        private void RbConcluidas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConcluidas.Checked)
            {
                ListarHospedagens(3);
            }
        }

        private void DgvReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvHospedagens.CurrentRow.Index != -1)
            {
                PreencherCampos();
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCpf.Text.Trim()))
            {
                MessageBox.Show("Informe um Cpf para realizar a Consulta", "Consultar Hospedagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Informe um Cpf para realizar a Consulta";

                LimparCampos();
                return;
            }

            int index = 0;
            foreach (DataGridViewRow linha in dgvHospedagens.Rows)
            {
                if (linha.Cells["Cpf"].Value.ToString().Equals(mtxtCpf.Text.Trim()))
                {
                    dgvHospedagens.CurrentCell = dgvHospedagens.Rows[index].Cells["Nome"];
                    PreencherCampos();
                    return;
                }
                index++;
            }
            MessageBox.Show("Hospedagem não encontrada!\nTente um Cpf diferente", "Consultar Hospedagem",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            stLbAvisoTxt.Text = "Hospedagem não encontrada!";
            LimparCampos();
        }

        private void BtnConsumos_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione uma Hospedagem para consultar seus Consumos", "Consultar Consumos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            TelaControleConsumos telaConsumos = new TelaControleConsumos(_provider.GetRequiredService<IProduto_Hospedagem_Service>(), _hospedagemService, _provider.GetRequiredService<IProdutoService>(), cod);
            telaConsumos.ShowDialog();

            ListarHospedagens();
            LimparCampos();
        }
    }
}
