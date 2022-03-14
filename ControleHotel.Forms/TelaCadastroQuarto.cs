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
    public partial class TelaCadastroQuarto : Form
    {
        private readonly ITipoQuartoService _tipoQuartoService;
        private readonly IQuartoService _quartoService;
        private TipoQuarto tipoQuarto;
        private Quarto quarto;

        public TelaCadastroQuarto(ITipoQuartoService tipoQuartoService, IQuartoService quartoService)
        {
            InitializeComponent();

            _tipoQuartoService = tipoQuartoService;
            _quartoService = quartoService;
        }

        private void TelaCadastroQuarto_Load(object sender, EventArgs e)
        {
            ListarTiposQuarto();
        }

        private void ListarTiposQuarto()
        {
            List<TipoQuarto> tipoQuartos = _tipoQuartoService.GetTiposQuarto().ToList();

            cbxTipos.DataSource = tipoQuartos;

            cbxTipos.ValueMember = "Codigo";
            cbxTipos.DisplayMember = "Tipo";

            cbxTipos.SelectedItem = null;
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            mtxtNum.Text = "";
            mtxtValor.Text = "";
            cbxTipos.SelectedItem = null;

            mtxtNum.Focus();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CbxTipos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tipoQuarto = (TipoQuarto)cbxTipos.SelectedItem;
            mtxtValor.Text = tipoQuarto.Valor.ToString("000.00");
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mtxtNum.Text.Trim()))
            {
                tipoQuarto = (TipoQuarto)cbxTipos.SelectedItem;

                quarto = new Quarto(cod: Guid.NewGuid(), num: Convert.ToInt32(mtxtNum.Text.Trim()), descricao: txtDescricao.Text.Trim(), tipoId: tipoQuarto == null ? null : tipoQuarto.Codigo, tipo: tipoQuarto, dataCadastro: DateTime.Now.Date, ativo: true);

                if (_quartoService.ValidarQuarto(quarto))
                {


                    if (_quartoService.SaveUpdateQuarto(quarto))
                    {
                        MessageBox.Show("Quarto Cadastrado com Sucesso!", "Cadastrar Quarto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        stLbAvisoTxt.Text = "Quarto Cadastrado com Sucesso!";

                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao Cadastrar!\n Quarto com este número já existente.", "Cadastrar Quarto",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        stLbAvisoTxt.Text = "Falha no Cadastro!";

                        txtDescricao.Focus();
                    }
                }
                else
                {
                    MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(quarto)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo Número", "Preenchimento dos Campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
