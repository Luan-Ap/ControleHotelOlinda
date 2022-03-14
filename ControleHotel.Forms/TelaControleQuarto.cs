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
    public partial class TelaControleQuarto : Form
    {
        private readonly IQuartoService _quartoService;
        private readonly ITipoQuartoService _tipoQuartoService;
        private DataColumn column;
        private DataRow row;
        private DataTable table;
        private Guid cod;

        public TelaControleQuarto(IQuartoService quartoService, ITipoQuartoService tipoQuartoService)
        {
            InitializeComponent();
            _quartoService = quartoService;
            _tipoQuartoService = tipoQuartoService; 
        }

        private void TelaControleQuarto_Enter(object sender, EventArgs e)
        {
            ListarQuartos();
        }

        private void ListarQuartos()
        {
            List<Quarto> quartos = _quartoService.GetQuarto().ToList();
            
            if(quartos.Count > 0)
            {
                table = new DataTable("Quartos");

                IniciarColunas(quartos[0]);
                PreencherTabela(quartos);

                dgvQuartos.DataSource = table;

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Não há Quartos cadastrados", "Listar Quartos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void IniciarColunas(Quarto q)
        {
            column = new DataColumn();
            column.DataType = q.Codigo.GetType();
            column.ColumnName = nameof(q.Codigo);
            column.Unique = true;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = q.NumQuarto.GetType();
            column.ColumnName = nameof(q.NumQuarto);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = q.CodTipoQuarto.GetType();
            column.ColumnName = nameof(q.CodTipoQuarto);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = q.DataCadastro.GetType();
            column.ColumnName = nameof(q.DataCadastro);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = q.TipoQuarto.Valor.GetType();
            column.ColumnName = nameof(q.TipoQuarto.Valor);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = q.TipoQuarto.Tipo.GetType();
            column.ColumnName = nameof(q.TipoQuarto.Tipo);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = q.TipoQuarto.MaxAcompanhantes.GetType();
            column.ColumnName = nameof(q.TipoQuarto.MaxAcompanhantes);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = q.Ativo.GetType();
            column.ColumnName = nameof(q.Ativo);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = q.Descricao.GetType();
            column.ColumnName = nameof(q.Descricao);

            table.Columns.Add(column);
        }

        private void PreencherTabela(List<Quarto> quartos)
        {
            foreach (var q in quartos)
            {
                row = table.NewRow();
                row["Codigo"] = q.Codigo;
                row["NumQuarto"] = q.NumQuarto;
                row["CodTipoQuarto"] = q.CodTipoQuarto;
                row["DataCadastro"] = q.DataCadastro;
                row["Valor"] = q.TipoQuarto.Valor;
                row["Tipo"] = q.TipoQuarto.Tipo;
                row["MaxAcompanhantes"] = q.TipoQuarto.MaxAcompanhantes;
                row["Ativo"] = q.Ativo;
                row["Descricao"] = q.Descricao;

                table.Rows.Add(row);
            }
        }

        private void DgvQuartos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuartos.CurrentRow.Index != -1)
            {
                PreencherCampos();
            }
        }

        private void PreencherCampos()
        {
            cod = Guid.Parse(dgvQuartos.CurrentRow.Cells["Codigo"].Value.ToString());

            mtxtNum.Text = dgvQuartos.CurrentRow.Cells["NumQuarto"].Value.ToString();
            txtDescricao.Text = dgvQuartos.CurrentRow.Cells["Descricao"].Value.ToString();
            txtTipo.Text = dgvQuartos.CurrentRow.Cells["Tipo"].Value.ToString();
            float valor = float.Parse(dgvQuartos.CurrentRow.Cells["Valor"].Value.ToString());
            mtxtValor.Text = valor.ToString("000.00");
            var data = Convert.ToDateTime(dgvQuartos.CurrentRow.Cells["DataCadastro"].Value);
            txtCadastro.Text = data.Date.ToString("d");

            mtxtNum.Focus();

            stLbAvisoTxt.Text = "Quarto Selecionado com Sucesso!";
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewRow linha in dgvQuartos.Rows)
            {
                if (linha.Cells["NumQuarto"].Value.ToString().Equals(mtxtNum.Text.Trim()))
                {
                    dgvQuartos.CurrentCell = dgvQuartos.Rows[index].Cells["NumQuarto"];
                    PreencherCampos();
                    return;
                }
                index++;
            }
            MessageBox.Show("Quarto não encontrado!\nTente um número diferente", "Consultar Quarto",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            stLbAvisoTxt.Text = "Quarto não encontrado!";
            LimparCampos();
        }

        private void LimparCampos()
        {
            cod = Guid.Empty;

            mtxtNum.Text = "";
            txtDescricao.Text = "";
            txtTipo.Text = "";
            txtCadastro.Text = "";
            mtxtValor.Text = "";

            mtxtNum.Focus();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDesativar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Quarto para Desativar!", "Desativar Quarto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Quarto para Desativar!";

                LimparCampos();
                return;
            }

            
            int num = Convert.ToInt32(dgvQuartos.CurrentRow.Cells["NumQuarto"].Value);
            string tipo = dgvQuartos.CurrentRow.Cells["Tipo"].Value.ToString();

            if (MessageBox.Show($"Deseja realmente desativar o Quarto Nº{num} e Tipo {tipo}?", "Desativar Quarto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_quartoService.DesativarQuarto(cod) == true)
                {
                    MessageBox.Show($"Quarto Nº{num} Desativado com Sucesso!", "Desativar Quarto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarQuartos();

                    stLbAvisoTxt.Text = $"Quarto Nº{num} Desativado com Sucesso!";
                }
                else
                {
                    MessageBox.Show("Falha ao Desativar Quarto!", "Desativar Quarto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Falha ao Desativar Quarto!";
                }
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Quarto para Atualizar!", "Atualizar Quarto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Selecione um Quarto para Atualizar!";

                LimparCampos();
                return;
            }

            var codTipoQuarto = Guid.Parse(dgvQuartos.CurrentRow.Cells["CodTipoQuarto"].Value.ToString());
            var tipoQuarto = _tipoQuartoService.GetTipoQuartoByCod(codTipoQuarto);

            var num = int.Parse(mtxtNum.Text.Trim());
            var desc = txtDescricao.Text.Trim();
            var dataCad = Convert.ToDateTime(dgvQuartos.CurrentRow.Cells["DataCadastro"].Value);
            var ativo = Convert.ToBoolean(dgvQuartos.CurrentRow.Cells["Ativo"].Value);

            var quarto = new Quarto(cod: cod, num: num, descricao: desc, tipoId: tipoQuarto.Codigo, tipo: tipoQuarto, dataCadastro: dataCad, ativo: ativo);

            if (_quartoService.ValidarQuarto(quarto))
            {
                if(_quartoService.SaveUpdateQuarto(quarto, true))
                {
                    MessageBox.Show("Quarto Atualizado com Sucesso!", "Atualizar Quarto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Quarto Atualizado com Sucesso!";

                    LimparCampos();
                    ListarQuartos();
                }
                else
                {
                    MessageBox.Show("Falha ao Atualizar Quarto! Num. Quarto já existente!", "Atualizar Quarto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Falha ao Atualizar Quarto!";
                }
            }
            else
            {
                MessageBox.Show(AuxilioForms.ListarErrosPreenchimento(quarto), "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
