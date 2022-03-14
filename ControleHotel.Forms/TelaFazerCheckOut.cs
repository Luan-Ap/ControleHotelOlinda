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
    public partial class TelaFazerCheckOut : Form
    {
        private readonly ICheckOutService _checkOutService;
        private readonly IHospedagemService _hospedagemService;
        private readonly IServiceProvider _provider;

        private CheckOut checkOut;
        private Hospedagem hospedagem;

        public TelaFazerCheckOut(ICheckOutService checkOutService, IHospedagemService hospedagemService, IServiceProvider provider)
        {
            InitializeComponent();

            _checkOutService = checkOutService;
            _hospedagemService = hospedagemService;
            _provider = provider;
        }

        private void PreencherCampos()
        {
            txtNome.Text = hospedagem.Cliente.Nome;
            txtSobrenome.Text = hospedagem.Cliente.Sobrenome;
            txtNum.Text = hospedagem.Quarto.NumQuarto.ToString();
            txtTipo.Text = hospedagem.Quarto.TipoQuarto.Tipo;

            dpEntrada.Value = hospedagem.DataEntrada;
            dpSaida.Value = hospedagem.DataSaida;

            mtxtTotal.Text = hospedagem.ConsumoTotal.ToString("0,000.00");

            btnFazerCheckOut.Enabled = true;

            stLbAvisoTxt.Text = "Hospedagem encontrada com Sucesso!";
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtNum.Text = string.Empty;
            txtTipo.Text = string.Empty;

            dpEntrada.Value = dpEntrada.MinDate;
            dpSaida.Value = dpSaida.MinDate;

            mtxtCpf.Text = string.Empty;
            mtxtTotal.Text = string.Empty;

            btnFazerCheckOut.Enabled = false;
            mtxtCpf.Focus();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCpf.Text.Trim()))
            {
                MessageBox.Show("Digite um Cpf do Titular para realizar a Consulta", "Consultar Hospedagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stLbAvisoTxt.Text = "Preencha o campo Cpf";
            }
            else
            {
                hospedagem = _hospedagemService.GetHospedagemForCheckOut(mtxtCpf.Text);

                if (hospedagem != null)
                {
                    if(_checkOutService.VerificarDataHospedagemCheckOut(hospedagem) != null)
                    {
                        PreencherCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Hospedagem não encontrada! Tente um outro Cpf", "Consultar Hospedagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stLbAvisoTxt.Text = "Hospedagem não encontrada!";

                    LimparCampos();
                }
            }
        }

        private void BtnFazerCheckOut_Click(object sender, EventArgs e)
        {
            checkOut = new CheckOut(cod: Guid.NewGuid(), codHosp: hospedagem.Codigo, hosp: hospedagem, ativo: true);

            if (_checkOutService.ValidarCheckOut(checkOut))
            {
                if (!_hospedagemService.VerificarConsumos(hospedagem.ConsumoTotal))
                {
                    if (_checkOutService.RealizarCheckOut(checkOut))
                    {
                        MessageBox.Show("Check-Out realizado com Sucesso!", "Fazer Check-Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stLbAvisoTxt.Text = "Check-Out realizado com Sucesso!";
                    }
                    else
                    {
                        MessageBox.Show("Falha ao realizar Check-Out!", "Fazer Check-Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stLbAvisoTxt.Text = "Falha ao realizar Check-Out!";                        
                    }
                    LimparCampos();
                }
                else
                {
                    var telaPagamento = new TelaRegistrarPagamento(_provider.GetRequiredService<IRegistroPagamentoService>(), _provider.GetRequiredService<IReservaService>(), _provider.GetRequiredService<ICheckOutService>(), c: checkOut);
                    telaPagamento.ShowDialog();

                    LimparCampos();
                }
            }
            else
            {
                MessageBox.Show(AuxilioForms.ListarErrosPreenchimento(checkOut), "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
