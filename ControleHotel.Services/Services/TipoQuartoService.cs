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
    public class TipoQuartoService : ITipoQuartoService
    {
        private readonly ITipoQuartoRepository _tipoQuartoRepository;

        public TipoQuartoService(ITipoQuartoRepository tipoQuartoRepository)
        {
            _tipoQuartoRepository = tipoQuartoRepository;
        }

        public TipoQuarto GetTipoQuartoByCod(Guid? cod)
        {
            return _tipoQuartoRepository.GetTipoQuartoByCod(cod);
        }

        public IEnumerable<TipoQuarto> GetTiposQuarto()
        {
            return _tipoQuartoRepository.GetTiposQuarto();
        }
    }
}
