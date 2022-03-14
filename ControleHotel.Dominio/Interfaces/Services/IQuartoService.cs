using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IQuartoService
    {
        bool ValidarQuarto(Quarto quarto);
        bool SaveUpdateQuarto(Quarto quarto, bool alterarQuarto = false);
        IEnumerable<Quarto> GetQuarto(string tipo = "");
        Quarto GetQuartoByCod(Guid? cod);
        IEnumerable<Quarto> GetQuartosParaReserva(DateTime entrada, DateTime saida, Guid codTipo);
        bool DesativarQuarto(Guid? cod);
        string CalcularValorTotal(string diaria, DateTime saida, DateTime entrada);
    }
}
