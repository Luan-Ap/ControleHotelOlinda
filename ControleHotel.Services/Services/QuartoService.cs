using ControleHotel.Dominio.Entidades;
using ControleHotel.Dominio.Interfaces.Repository;
using ControleHotel.Dominio.Interfaces.Services;
using ControleHotel.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Services.Services
{
    public class QuartoService : IQuartoService
    {
        private readonly IQuartoRepository _quartoRepository;

        public QuartoService(IQuartoRepository quartoRepository)
        {
            _quartoRepository = quartoRepository;
        }

        public string CalcularValorTotal(string diaria, DateTime saida, DateTime entrada)
        {
            var valor = double.Parse(diaria);
            var dias = saida.Date.Subtract(entrada.Date).Days;
            return (dias * valor).ToString("0,000.00");
        }

        public bool DesativarQuarto(Guid? cod)
        {
            var quartoDesativar = _quartoRepository.DesativarQuarto(cod);

            return quartoDesativar;
        }

        public IEnumerable<Quarto> GetQuarto(string tipo = "")
        {
            if (string.IsNullOrEmpty(tipo))
            {
                return _quartoRepository.GetQuarto();
            }
            else
            {
                return _quartoRepository.GetQuartoByTipo(tipo);
            }
        }

        public Quarto GetQuartoByCod(Guid? cod)
        {
            return _quartoRepository.GetQuartoByCod(cod);
        }

        public IEnumerable<Quarto> GetQuartosParaReserva(DateTime entrada, DateTime saida, Guid codTipo)
        {
            return _quartoRepository.GetQuartosDisponiveis(entrada, saida, codTipo);
        }

        public bool SaveUpdateQuarto(Quarto quarto, bool alterarQuarto = false)
        {
            if (alterarQuarto == false)
            {
                return _quartoRepository.SaveQuarto(quarto);
            }
            else
            {
                return _quartoRepository.UpdateQuarto(quarto);
            }
        }

        public bool ValidarQuarto(Quarto quarto)
        {
            var valido = quarto.Validar();

            return valido;
        }
    }
}
