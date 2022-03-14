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
    public class RegistroPagamentoService : IRegistroPagamentoService
    {
        private readonly IRegistroPagamentoRepository _registroPagamentoRepository;

        public RegistroPagamentoService(IRegistroPagamentoRepository registroPagamentoRepository)
        {
            _registroPagamentoRepository = registroPagamentoRepository;
        }

        public bool ValidarRegistro(RegistroPagamento registro)
        {
            return registro.Validar();
        }

        public IEnumerable<RegistroPagamento> GetRegistrosPagamentos()
        {
            return _registroPagamentoRepository.GetRegistrosPagamentos();
        }
    }
}
