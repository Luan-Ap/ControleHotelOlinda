using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Repository
{
    public interface IQuartoRepository
    {
        bool SaveQuarto(Quarto quarto);
        bool UpdateQuarto(Quarto quarto);
        IEnumerable<Quarto> GetQuarto();
        IEnumerable<Quarto> GetQuartoByTipo(string tipo);
        IEnumerable<Quarto> GetQuartosDisponiveis(DateTime entrada, DateTime saida, Guid codTipo);
        Quarto GetQuartoByCod(Guid? cod);
        bool DesativarQuarto(Guid? cod);
    }
}
