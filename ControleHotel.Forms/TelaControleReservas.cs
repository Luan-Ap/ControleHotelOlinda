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
    public partial class TelaControleReservas : Form
    {
        private readonly IReservaService _reservaService;
        private readonly IServiceProvider _provider;

        private DataTable table;
        private DataColumn column;
        private DataRow row;
        
        private Guid cod;
        private Reserva reserva;

        public TelaControleReservas(IReservaService reservaService, IServiceProvider provider)
        {
            InitializeComponent();
            _reservaService = reservaService;
            _provider = provider;
        }

        private void TelaControleReservas_Load(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void TelaControleReservas_Enter(object sender, EventArgs e)
        {
            ListarReservas();
        }

        private void ListarReservas(int opc = 1)
        {
            List<Reserva> reservas = new();

            switch (opc)
            {
                case 1:
                    reservas = _reservaService.GetReservas().ToList();
                    break;

                case 2:
                    reservas = _reservaService.GetReservas("Ativa").ToList();
                    break;

                case 3:
                    reservas = _reservaService.GetReservas("Concluida").ToList();
                    break;

                case 4:
                    reservas = _reservaService.GetReservas("Cancelada").ToList();
                    break;
            }

            if (reservas.Count > 0)
            {
                table = new DataTable("Reservas");

                IniciarColunas(reservas[0]);
                PreencherTabela(reservas);

                dgvReservas.DataSource = table;
            }
            else
            {
                MessageBox.Show("Não há Reservas para a listagem selecionada", "Listar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void IniciarColunas(Reserva r)
        {
            column = new DataColumn();
            column.DataType = r.Codigo.GetType();
            column.ColumnName = nameof(r.Codigo);
            column.Unique = true;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.CodCliente.GetType();
            column.ColumnName = nameof(r.CodCliente);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.CodQuarto.GetType();
            column.ColumnName = nameof(r.CodQuarto);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.Quarto.TipoQuarto.Tipo.GetType();
            column.ColumnName = nameof(r.Quarto.TipoQuarto.Tipo);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.NumAcompanhantes.GetType();
            column.ColumnName = nameof(r.NumAcompanhantes);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.Cliente.Nome.GetType();
            column.ColumnName = nameof(r.Cliente.Nome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.Quarto.NumQuarto.GetType();
            column.ColumnName = nameof(r.Quarto.NumQuarto);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.TotalDiaria.GetType();
            column.ColumnName = nameof(r.TotalDiaria);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.DataEntrada.GetType();
            column.ColumnName = nameof(r.DataEntrada);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.DataSaida.GetType();
            column.ColumnName = nameof(r.DataSaida);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.Status.GetType();
            column.ColumnName = nameof(r.Status);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.Cliente.Sobrenome.GetType();
            column.ColumnName = nameof(r.Cliente.Sobrenome);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.Cliente.Cpf.GetType();
            column.ColumnName = nameof(r.Cliente.Cpf);

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = r.Cliente.Email.GetType();
            column.ColumnName = nameof(r.Cliente.Email);

            table.Columns.Add(column);
        }

        private void PreencherTabela(List<Reserva> reservas)
        {
            foreach (var r in reservas)
            {
                row = table.NewRow();
                row["Codigo"] = r.Codigo;
                row["CodCliente"] = r.CodCliente;
                row["CodQuarto"] = r.CodQuarto;
                row["Tipo"] = r.Quarto.TipoQuarto.Tipo;
                row["NumAcompanhantes"] = r.NumAcompanhantes;
                row["Nome"] = r.Cliente.Nome;
                row["NumQuarto"] = r.Quarto.NumQuarto;
                row["TotalDiaria"] = r.TotalDiaria;
                row["DataEntrada"] = r.DataEntrada;
                row["DataSaida"] = r.DataSaida;
                row["Status"] = r.Status;
                row["Sobrenome"] = r.Cliente.Sobrenome;
                row["Cpf"] = r.Cliente.Cpf;
                row["Email"] = r.Cliente.Email;

                table.Rows.Add(row);
            }
        }

        private void LimparCampos()
        {
            cod = Guid.Empty;

            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAcomp.Text = string.Empty;
            txtCheckIn.Text = string.Empty;
            txtCheckOut.Text = string.Empty;
            txtNum.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtStatus.Text = string.Empty;

            mtxtCpf.Text = string.Empty;
            mtxtTotal.Text = string.Empty;
        }

        private void PreencherCampos()
        {
            cod = Guid.Parse(dgvReservas.CurrentRow.Cells["Codigo"].Value.ToString());

            txtNome.Text = dgvReservas.CurrentRow.Cells["Nome"].Value.ToString();
            txtSobrenome.Text = dgvReservas.CurrentRow.Cells["Sobrenome"].Value.ToString();
            txtEmail.Text = dgvReservas.CurrentRow.Cells["Email"].Value.ToString();
            txtAcomp.Text = dgvReservas.CurrentRow.Cells["NumAcompanhantes"].Value.ToString();
            
            var checkIn = Convert.ToDateTime(dgvReservas.CurrentRow.Cells["DataEntrada"].Value);
            txtCheckIn.Text = checkIn.ToString("d");
            
            var checkOut = Convert.ToDateTime(dgvReservas.CurrentRow.Cells["DataSaida"].Value.ToString());
            txtCheckOut.Text = checkOut.ToString("d");
            txtNum.Text = dgvReservas.CurrentRow.Cells["NumQuarto"].Value.ToString();
            txtTipo.Text = dgvReservas.CurrentRow.Cells["Tipo"].Value.ToString();
            txtStatus.Text = dgvReservas.CurrentRow.Cells["Status"].Value.ToString();

            mtxtCpf.Text = dgvReservas.CurrentRow.Cells["Cpf"].Value.ToString();
            
            var total = Convert.ToDouble(dgvReservas.CurrentRow.Cells["TotalDiaria"].Value);
            mtxtTotal.Text = total.ToString("0,000.00");
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RbTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodas.Checked)
            {
                ListarReservas();
            }
        }

        private void RbAtivas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAtivas.Checked)
            {
                ListarReservas(2);
            }
        }

        private void RbConcluidas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConcluidas.Checked)
            {
                ListarReservas(3);
            }
        }

        private void RbCanceladas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCanceladas.Checked)
            {
                ListarReservas(4);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCpf.Text.Trim()))
            {
                MessageBox.Show("Informe um Cpf para realizar a Consulta", "Consultar Reserva",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                stLbAvisoTxt.Text = "Informe um Cpf para realizar a Consulta";

                LimparCampos();
                return;
            }

            int index = 0;
            foreach (DataGridViewRow linha in dgvReservas.Rows)
            {
                if (linha.Cells["Cpf"].Value.ToString().Equals(mtxtCpf.Text.Trim()))
                {
                    dgvReservas.CurrentCell = dgvReservas.Rows[index].Cells["Nome"];
                    PreencherCampos();
                    return;
                }
                index++;
            }
            MessageBox.Show("Reserva não encontrada!\nTente um Cpf diferente", "Consultar Reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            stLbAvisoTxt.Text = "Reserva não encontrada!";
            LimparCampos();
        }

        private void DgvReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReservas.CurrentRow.Index != -1)
            {
                PreencherCampos();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (cod.Equals(Guid.Empty))
            {
                MessageBox.Show("Selecione uma Reserva para ser Cancelada", "Cancelar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stLbAvisoTxt.Text = "Selecione uma Reserva para ser Cancelada";
                
                return;
            }

            if (txtStatus.Text.Equals("Cancelada"))
            {
                MessageBox.Show("Esta Reserva já foi Cancelada ou Concluída!\nSelecione ou Consulte uma Reserva ainda 'Ativa'", "Cancelar Reserva",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stLbAvisoTxt.Text = "Esta Reserva já foi Cancelada!";

                return;
            }

            string nome = txtNome.Text;
            string sobrenome = txtSobrenome.Text;

            if (MessageBox.Show($"Deseja Realmente Cancelar a Reserva do Cliente {nome} {sobrenome}", "Cancelar Reserva",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                reserva = _reservaService.GetReservaByCod(cod);
                double multa = _reservaService.VerificarMultaCancelamento(reserva);

                if (multa == 0)
                {
                    if (_reservaService.CancelarReserva(cod))
                    {
                        MessageBox.Show("Reserva Cancelada com Sucesso!", "Cancelar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stLbAvisoTxt.Text = "Reserva Cancelada com Sucesso!";

                        ListarReservas();
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao Cancelar Reserva!", "Cancelar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stLbAvisoTxt.Text = "Falha ao Cancelar Reserva!";
                    }
                }
                else
                {
                    MessageBox.Show($"Tempo limite para cancelamento da Reserva atingido!\nPara Cancelar a Reserva será necessário pagar uma taxa de R${multa:0,000.00}", "Cancelar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var telaPagto = new TelaRegistrarPagamento(_provider.GetRequiredService<IRegistroPagamentoService>(), _provider.GetRequiredService<IReservaService>(), _provider.GetRequiredService<ICheckOutService>(), r: reserva, multaCancelamento: multa);
                    telaPagto.ShowDialog();

                    ListarReservas();
                    LimparCampos();
                }
            }
        }
    }
}
