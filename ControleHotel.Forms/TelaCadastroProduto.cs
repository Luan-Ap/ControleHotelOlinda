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
    public partial class TelaCadastroProduto : Form
    {
        private readonly IProdutoService _produtoService;
        private Produto produto;

        public TelaCadastroProduto(IProdutoService produtoService)
        {
            InitializeComponent();
            _produtoService = produtoService;
        }

        private void TelaCadastroProduto_Load(object sender, EventArgs e)
        {
            PreencherTipos();
        }

        private void PreencherTipos()
        {
            cbxTipos.DataSource = Enum.GetValues(typeof(TipoProduto));
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            mtxtValor.Text = string.Empty;
            numQtd.Value = numQtd.Minimum;

            txtNome.Focus();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            var cod = Guid.NewGuid();
            var nome = txtNome.Text.Trim();
            var qtd = Convert.ToInt32(numQtd.Value);
            var valor = double.Parse(mtxtValor.Text.Replace(" ", "0"));
            var tipo = (TipoProduto)cbxTipos.SelectedItem;
            var dataCadastro = DateTime.Now.Date;
            var ativo = true;

            produto = new Produto(cod: cod, nome: nome, qtd: qtd, valor: valor, tipo: tipo, dataCadastro: dataCadastro, ativo: ativo);

            if (_produtoService.ValidarProduto(produto))
            {
                if (_produtoService.SaveUpadateProduto(produto))
                {
                    MessageBox.Show("Produto Cadastrado com Sucesso", "Cadastrar Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Produto Cadastrado com Sucesso";

                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao Cadastrar Produto", "Cadastrar Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stLbAvisoTxt.Text = "Falha ao Cadastrar Produto";
                }
            }
            else
            {
                MessageBox.Show($"{AuxilioForms.ListarErrosPreenchimento(produto)}", "Erros no Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CbxTipos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxTipos.Text.Equals("Serviço"))
            {
                numQtd.Maximum = 1;
                numQtd.Value = numQtd.Minimum;
            }
            else
            {
                numQtd.Maximum = 100;
                numQtd.Value = numQtd.Minimum;
            }
        }
    }
}
