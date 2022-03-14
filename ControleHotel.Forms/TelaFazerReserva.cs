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
    public partial class TelaFazerReserva : Form
    {
        private readonly IReservaService _reservaService;
        private readonly IClienteService _clienteService;
        private readonly IServiceProvider _provider;

        private Reserva reserva;
        private readonly Quarto quarto;
        private Cliente cliente;
        
        private readonly DateTime entrada;
        private readonly DateTime saida;
        private readonly double valorTotal;

        public TelaFazerReserva(IReservaService reservaService, IClienteService clienteService, IServiceProvider provider, Quarto q, DateTime en, DateTime s, string valor)
        {
            InitializeComponent();

            _reservaService = reservaService;
            _clienteService = clienteService;
            _provider = provider;

            quarto = q;
            entrada = en;
            saida = s;
            valorTotal = double.Parse(valor);
        }

        private void TelaFazerReserva_Load(object sender, EventArgs e)
        {
            PreencherDadosReserva();
            btnFazerReserva.Enabled = false;
        }

        private void PreencherDadosReserva()
        {
            txtNum.Text = quarto.NumQuarto.ToString();
            txtDescricao.Text = quarto.Descricao;
            txtTipo.Text = quarto.TipoQuarto.Tipo;

            numAcomp.Maximum = quarto.TipoQuarto.MaxAcompanhantes;

            dpEntrada.Value = entrada;
            dpSaida.Value = saida;
            mtxtTotal.Text = valorTotal.ToString("0,000.00");
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCpf.Text.Trim()))
            {
                MessageBox.Show("Digite um Cpf para realizar a Consulta", "Consultar Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stLbAvisoTxt.Text = "Preencha o campo Cpf";
            }
            else
            {
                cliente = _clienteService.GetClienteByCpf(mtxtCpf.Text.Trim());
                if (cliente != null)
                {
                    txtNome.Text = cliente.Nome;
                    txtSobrenome.Text = cliente.Sobrenome;
                    txtEmail.Text = cliente.Email;
                    mtxtCpf.Text = cliente.Cpf;

                    btnFazerReserva.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado!\nTente um outro Cpf", "Consultar Cliente",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stLbAvisoTxt.Text = "Cliente não encontrado!";

                    LimparDadosClientes();
                }
            }
        }

        private void LimparDadosClientes()
        {
            mtxtCpf.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            mtxtCpf.Text = string.Empty;

            mtxtCpf.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFazerReserva_Click(object sender, EventArgs e)
        {
            reserva = new Reserva(cod: Guid.NewGuid(), codCliente: cliente.Codigo, cliente: cliente, codQuarto: quarto.Codigo, quarto: quarto, acomp: Convert.ToInt32(numAcomp.Value), total: valorTotal, entrada: entrada, saida: saida, reserva: DateTime.Now.Date, status: StatusReserva.Ativa, ativo: true);

            if (_reservaService.ValidarReserva(reserva))
            {
                TelaRegistrarPagamento telaPagamento = new TelaRegistrarPagamento(_provider.GetRequiredService<IRegistroPagamentoService>(), _provider.GetRequiredService<IReservaService>(), _provider.GetRequiredService<ICheckOutService>(), r: reserva);
                telaPagamento.ShowDialog();

                Close();
            }
            else
            {
                MessageBox.Show(AuxilioForms.ListarErrosPreenchimento(reserva), "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
