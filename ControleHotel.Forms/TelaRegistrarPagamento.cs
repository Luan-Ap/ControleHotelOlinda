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
    public partial class TelaRegistrarPagamento : Form
    {
        private readonly IRegistroPagamentoService _registroPagamentoService;
        private readonly IReservaService _reservaService;
        private readonly ICheckOutService _checkOutService;

        private RegistroPagamento registro;
        private readonly Reserva reserva;
        private readonly CheckOut checkOut;
        private readonly double multa;

        public TelaRegistrarPagamento(IRegistroPagamentoService registroPagamentoService, IReservaService reservaService, ICheckOutService checkOutService, Reserva r = null, CheckOut c = null, double multaCancelamento = 0)
        {
            InitializeComponent();

            _registroPagamentoService = registroPagamentoService;
            _reservaService = reservaService;
            _checkOutService = checkOutService;

            reserva = r;
            checkOut = c;
            multa = multaCancelamento;
        }

        private void TelaRegistrarPagamento_Load(object sender, EventArgs e)
        {
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            if (reserva != null)
            {
                txtNome.Text = reserva.Cliente.Nome;
                txtSobrenome.Text = reserva.Cliente.Sobrenome;
                mtxtCpf.Text = reserva.Cliente.Cpf;

                if(multa > 0)
                {
                    mtxtTotal.Text = multa.ToString("0,000.00");
                }
                else
                {
                    mtxtTotal.Text = reserva.TotalDiaria.ToString("0,000.00");
                }

            }
            else
            {
                txtNome.Text = checkOut.Hospedagem.Cliente.Nome;
                txtSobrenome.Text = checkOut.Hospedagem.Cliente.Sobrenome;
                mtxtCpf.Text = checkOut.Hospedagem.Cliente.Cpf;
                mtxtTotal.Text = checkOut.Hospedagem.ConsumoTotal.ToString("0,000.00");
            }
            
            cbxFormas.DataSource = Enum.GetValues(typeof(FormaPagto));
        }

        private void BtnFazerReserva_Click(object sender, EventArgs e)
        {
            FormaPagto pagto = (FormaPagto)cbxFormas.SelectedItem;

            if(reserva != null && multa == 0)
            {
                registro = new RegistroPagamento(cod: Guid.NewGuid(), codReserva: reserva.Codigo, reserva: reserva, codHosp: null, hosp: null, pagto: pagto, valor: reserva.TotalDiaria, dataPagto: reserva.DataReserva, ativo: true);

                if (_registroPagamentoService.ValidarRegistro(registro))
                {
                    if (_reservaService.SaveReserva(registro))
                    {
                        MessageBox.Show("Registro de Pagamento Concluído!", "Registrar Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBox.Show("Reserva Realizada com Sucesso!", "Realizar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao Registrar Pagamento!", "Registrar Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        stLbAvisoTxt.Text = "Falha ao Registrar Pagamento!";
                    }
                }
                else
                {
                    MessageBox.Show(AuxilioForms.ListarErrosPreenchimento(registro), "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (reserva != null && multa > 0)
            {
                registro = new RegistroPagamento(cod: Guid.NewGuid(), codReserva: reserva.Codigo, reserva: reserva, codHosp: null, hosp: null, pagto: pagto, valor: multa, dataPagto: DateTime.Now.Date, ativo: true);

                if (_registroPagamentoService.ValidarRegistro(registro))
                {
                    if (_reservaService.CancelarReserva(reserva.Codigo, registro))
                    {
                        MessageBox.Show("Registro de Pagamento Concluído!", "Registrar Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBox.Show("Reserva Cancelada com Sucesso!", "Cancelar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao Registrar Pagamento!", "Registrar Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        stLbAvisoTxt.Text = "Falha ao Registrar Pagamento!";
                    }
                }
                else
                {
                    MessageBox.Show(AuxilioForms.ListarErrosPreenchimento(registro), "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                registro = new RegistroPagamento(cod: Guid.NewGuid(), codReserva: null, reserva: null, codHosp: checkOut.Hospedagem.Codigo, hosp: checkOut.Hospedagem, pagto: pagto, valor: checkOut.Hospedagem.ConsumoTotal, dataPagto: DateTime.Now.Date, ativo: true);

                if (_registroPagamentoService.ValidarRegistro(registro))
                {
                    if (_checkOutService.RealizarCheckOut(checkOut, registro))
                    {
                        MessageBox.Show("Registro de Pagamento Concluído!", "Registrar Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBox.Show("Check-Out Feito com Sucesso!", "Fazer Check-Out", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao Registrar Pagamento!", "Registrar Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        stLbAvisoTxt.Text = "Falha ao Registrar Pagamento!";
                    }
                }
                else
                {
                    MessageBox.Show(AuxilioForms.ListarErrosPreenchimento(registro), "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
