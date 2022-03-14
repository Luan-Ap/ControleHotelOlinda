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
    public partial class TelaConsultarOfertas : Form
    {
        private readonly ITipoQuartoService _tipoQuartoService;
        private readonly IQuartoService _quartoService;
        private readonly IServiceProvider _provider;

        private Guid cod;

        private TipoQuarto tipoQuarto;
        private Quarto quarto;
        private DataTable table;
        private DataColumn column;
        private DataRow row;

        public TelaConsultarOfertas(ITipoQuartoService tipoQuartoService, IQuartoService quartoService, IServiceProvider provider)
        {
            InitializeComponent();

            _tipoQuartoService = tipoQuartoService;
            _quartoService = quartoService;
            _provider = provider;
        }

        private void TelaConsultarOfertas_Load(object sender, EventArgs e)
        {
            ConfigurarDatas();
            ListarTiposQuarto();
        }

        private void ListarQuartos()
        {
            List<Quarto> quartos = _quartoService.GetQuartosParaReserva(dpEntrada.Value, dpSaida.Value, tipoQuarto.Codigo).ToList();

            if(quartos.Count > 0)
            {
                table = new DataTable("Quartos");

                IniciarColunas(quartos[0]);
                PreencherTabela(quartos);

                dgvQuartos.DataSource = table;
            }
            else
            {
                MessageBox.Show("Não há ofertas disponíveis! Defina outra Data ou selecione outro Tipo de Quarto!", "Consultar Ofertas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Não há ofertas disponíveis! Defina outra Data ou selecione outro tipo de quarto!";
                LimparCamposLinhas();
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

        private void ListarTiposQuarto()
        {
            List<TipoQuarto> tipoQuartos = _tipoQuartoService.GetTiposQuarto().ToList();

            cbxTipos.DataSource = tipoQuartos;

            cbxTipos.ValueMember = "Codigo";
            cbxTipos.DisplayMember = "Tipo";

            cbxTipos.SelectedItem = null;
        }

        private void ConfigurarDatas()
        {
            dpEntrada.MinDate = DateTime.Now.AddDays(1);
            dpSaida.MinDate = dpEntrada.MinDate.AddDays(1);

            dpEntrada.MaxDate = DateTime.Now.AddYears(1);
            dpSaida.MaxDate = dpEntrada.MaxDate.AddDays(1);

            dpEntrada.Value = dpEntrada.MinDate;
            dpSaida.Value = dpSaida.MinDate;
        }

        private void CbxTipos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tipoQuarto = (TipoQuarto)cbxTipos.SelectedItem;
            mtxtValor.Text = tipoQuarto.Valor.ToString("000.00");

            dgvQuartos.Enabled = true;
        }

        private void LimparCamposLinhas()
        {
            cod = Guid.Empty;

            mtxtTotal.Text = string.Empty;
            mtxtValor.Text = string.Empty;

            txtNum.Text = string.Empty;
            txtDescricao.Text = string.Empty;

            cbxTipos.SelectedItem = null;

            for (int i = dgvQuartos.Rows.Count; i > 0; i--)
            {
                dgvQuartos.Rows.RemoveAt(i - 1);
            }   

            dpEntrada.Focus();
        }

        private void PreencherCampos()
        {
            cod = Guid.Parse(dgvQuartos.CurrentRow.Cells["Codigo"].Value.ToString());

            txtNum.Text = dgvQuartos.CurrentRow.Cells["NumQuarto"].Value.ToString();
            txtDescricao.Text = dgvQuartos.CurrentRow.Cells["Descricao"].Value.ToString();

            mtxtTotal.Text = _quartoService.CalcularValorTotal(mtxtValor.Text, dpSaida.Value, dpEntrada.Value);

            btnFazerReserva.Focus();
        }

        private void DpEntrada_CloseUp(object sender, EventArgs e)
        {
            dpSaida.MinDate = dpEntrada.Value.AddDays(1);
        }

        private bool TipoQuartoNaoSelecionado()
        {
            if ((mtxtValor.Text.Replace(" ", "").Length < 5) || (cbxTipos.Text == ""))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (btnConsultar.Text.Equals("Consultar Novamente"))
            {
                AtivarCampos();
                btnConsultar.Text = "Consultar Ofertas";
                return;
            }

            if (TipoQuartoNaoSelecionado() == false)
            {
                ListarQuartos(); 
            }
            else
            {
                MessageBox.Show("Selecione um Tipo de Quarto para Consultar as Ofertas", "Consultar Ofertas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AtivarCampos()
        {
            dpEntrada.Enabled = true;
            dpSaida.Enabled = true;
            cbxTipos.Enabled = true;
            btnFazerReserva.Enabled = false;

            LimparCamposLinhas();
        }

        private void DesativarCampos()
        {
            dpEntrada.Enabled = false;
            dpSaida.Enabled = false;
            cbxTipos.Enabled = false;

            btnConsultar.Text = "Consultar Novamente";
        }

        private void dgvQuartos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuartos.CurrentRow.Index != -1)
            {
                btnFazerReserva.Enabled = true;
                PreencherCampos();
                DesativarCampos();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFazerReserva_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione um Quarto para Fazer a Reserva!", "Reservar Quarto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            tipoQuarto = (TipoQuarto)cbxTipos.SelectedItem;

            quarto = _quartoService.GetQuartoByCod(cod);

            TelaFazerReserva reserva = new TelaFazerReserva(_provider.GetRequiredService<IReservaService>(), _provider.GetRequiredService<IClienteService>(), _provider, quarto, dpEntrada.Value, dpSaida.Value, mtxtTotal.Text);
            reserva.ShowDialog();

            LimparCamposLinhas();

            btnFazerReserva.Enabled = false;
        }
    }
}
