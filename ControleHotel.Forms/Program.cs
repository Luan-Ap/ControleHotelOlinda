using ControleHotel.Dominio.Interfaces.Repository;
using ControleHotel.Dominio.Interfaces.Services;
using ControleHotel.Infra.Repository;
using ControleHotel.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ControleHotel.Forms
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = GetServices();

            var provider = services.BuildServiceProvider();

            Application.Run(new TelaPrincipal(provider));
        }

        private static ServiceCollection GetServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<ICheckInRepository, CheckInRepository>();
            services.AddTransient<ICheckOutRepository, CheckOutRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IFuncionarioUsuarioRepository, FuncionarioUsuarioRepository>();
            services.AddTransient<IHospedagemRepository, HospedagemRepository>();
            services.AddTransient<IProduto_Hospedagem_Repository, Produto_Hospedagem_Repository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IQuartoRepository, QuartoRepository>();
            services.AddTransient<IRegistroPagamentoRepository, RegistroPagamentoRepository>();
            services.AddTransient<IReservaRepository, ReservaRepository>();
            services.AddTransient<ITipoQuartoRepository, TipoQuartoRepository>();

            services.AddTransient<ICheckInService, CheckInService>();
            services.AddTransient<ICheckOutService, CheckOutService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<IFuncionarioUsuarioService, FuncionarioUsuarioService>();
            services.AddTransient<IHospedagemService, HospedagemService>();
            services.AddTransient<IProduto_Hospedagem_Service, Produto_Hospedagem_Service>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IQuartoService, QuartoService>();
            services.AddTransient<IRegistroPagamentoService, RegistroPagamentoService>();
            services.AddTransient<IReservaService, ReservaService>();
            services.AddTransient<ITipoQuartoService, TipoQuartoService>();

            return services;
        }
    }
}
