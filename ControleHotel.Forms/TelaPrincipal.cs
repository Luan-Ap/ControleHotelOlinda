using ControleHotel.Dominio.Interfaces.Services;
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
    public partial class TelaPrincipal : Form
    {
        public IServiceProvider _provider;
        public TelaPrincipal(IServiceProvider provider)
        {
            InitializeComponent();

            _provider = provider;
            var telaLogin = new TelaFazerLogin(_provider.GetRequiredService<IFuncionarioUsuarioService>(), this);
            telaLogin.ShowDialog();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            IniciarMenus();
            DefinarData();
        }

        private void DefinarData()
        {
            string data = DateTime.Now.ToLongDateString();
            data = data.Substring(0, 1).ToUpper() + data.Substring(1, data.Length - 1);
            stLbData.Text = data;
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            stLbHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void IniciarMenus()
        {
            panelMenuClientes.Visible = false;
            panelMenuFunc.Visible = false;
            panelMenuProd.Visible = false;
            panelMenuQuartos.Visible = false;
            panelMenuReservas.Visible = false;
            panelMenuCheckInOut.Visible = false;
            panelMenuHospedagens.Visible = false;
        }

        //private void AbrirFormFilho<MeuForm>() where MeuForm : Form, new()
        //{
        //    Form formFilho;
        //    formFilho = panelFormsFilhos.Controls.OfType<MeuForm>().FirstOrDefault();
        //    if (formFilho == null)
        //    {
        //        formFilho = new MeuForm
        //        {
        //            TopLevel = false,
        //            FormBorderStyle = FormBorderStyle.None,
        //            Dock = DockStyle.Fill
        //        };
        //        panelFormsFilhos.Controls.Add(formFilho);
        //        panelFormsFilhos.Tag = formFilho;
        //        formFilho.Show();
        //        formFilho.BringToFront();
        //        formFilho.Focus();
        //    }
        //    else
        //    {
        //        formFilho.BringToFront();
        //        formFilho.Focus();
        //    }
        //}

        private T VerificarFormFilho<T>() where T : Form
        {
            Form formFilho;
            
            formFilho = panelFormsFilhos.Controls.OfType<T>().FirstOrDefault();

            return (T)formFilho;
        }

        private void ConfigurarFormFilho<T>(T form) where T : Form
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelFormsFilhos.Controls.Add(form);
            panelFormsFilhos.Tag = form;

            form.Show();
            form.BringToFront();
            form.Focus();
        }

        private static void ExibirFormFilho<T>(T form) where T : Form
        {
            form.BringToFront();
            form.Focus();
        }

        private void MostrarMenu(Panel menu)
        {
            if (menu.Visible == false)
            {
                IniciarMenus();
                menu.Visible = true;
            }
            else
            {
                menu.Visible = false;
                
            }
        }

        private void BtnCadastroCliente_Click(object sender, EventArgs e)
        {
            var cadastroCliente = new TelaCadastroCliente(_provider.GetRequiredService<IClienteService>());
            cadastroCliente.ShowDialog();
        }

        private void BtnMenuClientes_Click(object sender, EventArgs e)
        {
            MostrarMenu(panelMenuClientes);
        }

        private void BtnMenuCheckInOut_Click(object sender, EventArgs e)
        {
            MostrarMenu(panelMenuCheckInOut);
        }

        private void BtnMenuReservas_Click(object sender, EventArgs e)
        {
            MostrarMenu(panelMenuReservas);
        }

        private void BtnMenuHospedagens_Click(object sender, EventArgs e)
        {
            MostrarMenu(panelMenuHospedagens);
        }

        private void BtnMenuQuartos_Click(object sender, EventArgs e)
        {
            MostrarMenu(panelMenuQuartos);
        }

        private void BtnMenuFunc_Click(object sender, EventArgs e)
        {
            MostrarMenu(panelMenuFunc);
        }

        private void BtnMenuProd_Click(object sender, EventArgs e)
        {
            MostrarMenu(panelMenuProd);
        }

        private void BtnControleQuarto_Click(object sender, EventArgs e)
        {
            var form = VerificarFormFilho<TelaControleQuarto>();

            if(form == null)
            {   
                form = new TelaControleQuarto(_provider.GetRequiredService<IQuartoService>(), _provider.GetRequiredService<ITipoQuartoService>());
                
                ConfigurarFormFilho(form);
            }
            else
            {
                ExibirFormFilho(form);
            }
        }

        private void BtnCadastrarQuarto_Click(object sender, EventArgs e)
        {
            var cadastroQuarto = new TelaCadastroQuarto(_provider.GetRequiredService<ITipoQuartoService>(), _provider.GetRequiredService<IQuartoService>());
            cadastroQuarto.ShowDialog();
        }

        private void BtnControleProd_Click(object sender, EventArgs e)
        {
            var form = VerificarFormFilho<TelaControleProdutos>();

            if (form == null)
            {
                form = new TelaControleProdutos(_provider.GetRequiredService<IProdutoService>());

                ConfigurarFormFilho(form);
            }
            else
            {
                ExibirFormFilho(form);
            }
        }

        private void BtnCadastrarProd_Click(object sender, EventArgs e)
        {
            var cadastroProduto = new TelaCadastroProduto(_provider.GetRequiredService<IProdutoService>());
            cadastroProduto.ShowDialog();
        }

        private void BtnControleCliente_Click(object sender, EventArgs e)
        {
            var form = VerificarFormFilho<TelaControleClientes>();

            if (form == null)
            {
                form = new TelaControleClientes(_provider.GetRequiredService<IClienteService>());

                ConfigurarFormFilho(form);
            }
            else
            {
                ExibirFormFilho(form);
            }
        }

        private void BtnControleFunc_Click(object sender, EventArgs e)
        {
            var form = VerificarFormFilho<TelaControleFuncionario>();

            if (form == null)
            {
                form = new TelaControleFuncionario(_provider.GetRequiredService<IFuncionarioService>());

                ConfigurarFormFilho(form);
            }
            else
            {
                ExibirFormFilho(form);
            }
        }

        private void BtnCadastrarFunc_Click(object sender, EventArgs e)
        {
            var cadastroFunc = new TelaCadastroFuncionario(_provider.GetRequiredService<IFuncionarioService>(), _provider);
            cadastroFunc.ShowDialog();
        }

        private void BtnControleUsuario_Click(object sender, EventArgs e)
        {
            var form = VerificarFormFilho<TelaControleUsuario>();

            if (form == null)
            {
                form = new TelaControleUsuario(_provider.GetRequiredService<IFuncionarioUsuarioService>());

                ConfigurarFormFilho(form);
            }
            else
            {
                ExibirFormFilho(form);
            }
        }

        private void btnConsultarOfertas_Click(object sender, EventArgs e)
        {
            var form = VerificarFormFilho<TelaConsultarOfertas>();

            if (form == null)
            {
                form = new TelaConsultarOfertas(_provider.GetRequiredService<ITipoQuartoService>(), _provider.GetRequiredService<IQuartoService>(), _provider);

                ConfigurarFormFilho(form);
            }
            else
            {
                ExibirFormFilho(form);
            }
        }

        private void btnControleReservas_Click(object sender, EventArgs e)
        {
            var form = VerificarFormFilho<TelaControleReservas>();

            if (form == null)
            {
                form = new TelaControleReservas(_provider.GetRequiredService<IReservaService>(), _provider);

                ConfigurarFormFilho(form);
            }
            else
            {
                ExibirFormFilho(form);
            }
        }

        private void btnControleHospedagem_Click(object sender, EventArgs e)
        {
            var form = VerificarFormFilho<TelaControleHospedagens>();

            if (form == null)
            {
                form = new TelaControleHospedagens(_provider.GetRequiredService<IHospedagemService>(), _provider);

                ConfigurarFormFilho(form);
            }
            else
            {
                ExibirFormFilho(form);
            }
        }

        private void btnFazerCheckIn_Click(object sender, EventArgs e)
        {
            var fazerCheckIn = new TelaFazerCheckIn(_provider.GetRequiredService<IReservaService>(), _provider.GetRequiredService<ICheckInService>(), _provider.GetRequiredService<IHospedagemService>());
            fazerCheckIn.ShowDialog();
        }

        private void btnFazerCheckOut_Click(object sender, EventArgs e)
        {
            var fazerCheckOut = new TelaFazerCheckOut(_provider.GetRequiredService<ICheckOutService>(), _provider.GetRequiredService<IHospedagemService>(), _provider);
            fazerCheckOut.ShowDialog();
        }
    }
}
