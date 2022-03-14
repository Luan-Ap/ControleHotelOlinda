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
    public partial class TelaFazerCheckIn : Form
    {
        private readonly IReservaService _reservaService;
        private readonly ICheckInService _checkInService;
        private readonly IHospedagemService _hospedagemService;

        private Reserva reserva;
        private CheckIn checkIn;
        private Hospedagem hospedagem;

        public TelaFazerCheckIn(IReservaService reservaService, ICheckInService checkInService, IHospedagemService hospedagemService)
        {
            InitializeComponent();

            _reservaService = reservaService;
            _checkInService = checkInService;
            _hospedagemService = hospedagemService;
        }

        private void PreencherCampos()
        {
            txtNome.Text = reserva.Cliente.Nome;
            txtSobrenome.Text = reserva.Cliente.Sobrenome;
            txtNum.Text = reserva.Quarto.NumQuarto.ToString();
            txtTipo.Text = reserva.Quarto.TipoQuarto.Tipo;
            txtAcomp.Text = reserva.NumAcompanhantes.ToString();

            dpEntrada.Value = reserva.DataEntrada;
            dpSaida.Value = reserva.DataSaida;

            mtxtTotal.Text = reserva.TotalDiaria.ToString("0,000.00");

            btnFazerCheckIn.Enabled = true;
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtNum.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtAcomp.Text = string.Empty;

            dpEntrada.Value = dpEntrada.MinDate;
            dpSaida.Value = dpSaida.MinDate;

            mtxtCpf.Text = string.Empty;
            mtxtTotal.Text = string.Empty;

            btnFazerCheckIn.Enabled = false;
        }

        private void TelaFazerCheckIn_Load(object sender, EventArgs e)
        {
            btnFazerCheckIn.Enabled = false;

            dpEntrada.MinDate = DateTime.Today.Date;
            dpSaida.MinDate = dpEntrada.MinDate.AddDays(1);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCpf.Text.Trim()))
            {
                MessageBox.Show("Digite um Cpf do Titular para realizar a Consulta", "Consultar Reserva",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stLbAvisoTxt.Text = "Preencha o campo Cpf";
            }
            else
            {
                List<Reserva> reservas = _reservaService.GetReservasForCheckIn(mtxtCpf.Text).ToList();

                if (reservas.Count > 0)
                {
                    reserva = _checkInService.VerificarDataReservaCheckIn(reservas);

                    if(reserva != null)
                    {
                        PreencherCampos();
                        return;
                    }
                    
                    MessageBox.Show("O Cliente em questão não possui uma Reserva com Check-In para hoje", "Consultar Reserva",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stLbAvisoTxt.Text = "Reserva não encontrada!";

                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Reserva não encontrada!\nTente um outro Cpf", "Consultar Reserva",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stLbAvisoTxt.Text = "Reserva não encontrada!";

                    LimparCampos();
                }
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnFazerCheckIn_Click(object sender, EventArgs e)
        {
            checkIn = new CheckIn(cod: Guid.NewGuid(), codReserva: reserva.Codigo, reserva: reserva, ativo: true);

            hospedagem = new Hospedagem(cod: Guid.NewGuid(), codCliente: reserva.CodCliente, cliente: reserva.Cliente, entrada: reserva.DataEntrada, saida: reserva.DataSaida, codQuarto: reserva.CodQuarto, quarto: reserva.Quarto, consumo: 0, ativo: true);

            if (_checkInService.ValidarCheckIn(checkIn))
            {
                if (_checkInService.RealizarCheckIn(checkIn) && _hospedagemService.SavaHospedagem(hospedagem))
                {
                    MessageBox.Show("Check-In Realizado com Sucesso! Sua Hospedagem foi Iniciada.", "Fazer Check-In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Check-In Realizado com Sucesso!";
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao Realizar Check-In!", "Fazer Check-In",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stLbAvisoTxt.Text = "Falha ao Fazer Check-In!";
                }
            }
            else
            {
                MessageBox.Show(AuxilioForms.ListarErrosPreenchimento(checkIn), "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
